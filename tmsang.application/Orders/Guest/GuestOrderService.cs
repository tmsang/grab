using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Collections.Generic;
using tmsang.domain;
using System.Threading.Tasks;

namespace tmsang.application
{
    public class GuestOrderService : IGuestOrderService
    {
        readonly IRepository<R_Order> orderRepository;
        readonly IRepository<R_Request> requestRepository;
        readonly IRepository<R_Response> responseRepository;
        readonly IRepository<R_Evaluation> evaluationRepository;

        readonly IRepository<R_Driver> driverRepository;
        readonly IRepository<R_Location> locationRepository;
        readonly IRepositoryNonRoot<M_RoutineCost> routineCostRepository;        

        readonly R_LocationDomainService locationDomainService;
        readonly R_GuestDomainService accountDomainService;

        readonly IHubContext<SignalrHub, IHubClient> signalrHub;

        readonly IStorage storage;
        readonly IAuth auth;
        readonly IBingMap util;
        readonly IHttpContextAccessor http;
        readonly IUnitOfWork unitOfWork;

        public GuestOrderService(
            IRepository<R_Order> orderRepository,
            IRepository<R_Request> requestRepository,
            IRepository<R_Response> responseRepository,
            IRepository<R_Evaluation> evaluationRepository,

            IRepository<R_Driver> driverRepository,
            IRepository<R_Location> locationRepository,
            IRepositoryNonRoot<M_RoutineCost> routineCostRepository,
            R_LocationDomainService locationDomainService,
            R_GuestDomainService accountDomainService,

            IHubContext<SignalrHub, IHubClient> signalrHub,

            IStorage storage,
            IAuth auth,
            IBingMap util,
            IHttpContextAccessor http,
            IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.requestRepository = requestRepository;
            this.responseRepository = responseRepository;
            this.evaluationRepository = evaluationRepository;

            this.driverRepository = driverRepository;
            this.locationRepository = locationRepository;
            this.routineCostRepository = routineCostRepository;
            this.locationDomainService = locationDomainService;
            this.accountDomainService = accountDomainService;

            this.signalrHub = signalrHub;

            this.storage = storage;
            this.auth = auth;
            this.util = util;
            this.http = http;
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> GetPrice() 
        {            
            var routineCost = this.routineCostRepository.FindOne(new M_RoutineCostGetCostSpec());
            if (routineCost == null)
            {
                throw new Exception("Routine Cost has not set on valid date");
            }

            return routineCost.Cost + "";
        }

        public async Task<BookResultDto> Book(BookDto bookDto)
        {
            // validate input
            bookDto.EmptyValidation();

            // check location -> add or get Id location
            R_Location fromLocation = this.locationDomainService.AddIfNotExists(bookDto.FromAddress, bookDto.FromLatitude, bookDto.FromLongtitude);
            R_Location toLocation = this.locationDomainService.AddIfNotExists(bookDto.ToAddress, bookDto.ToLatitude, bookDto.ToLongtitude);
            
            // get accountId + routineCost
            var guest = (R_Guest)http.HttpContext.Items["User"];
            //var routineCost = this.routineCostRepository.FindOne(new M_RoutineCostGetCostSpec());
            //if (routineCost == null) 
            //{
            //    throw new Exception("Routine Cost has not set on valid date");
            //}

            // create request -> requestId  
            var order = R_Order.Create(guest.Id, E_OrderStatus.Pending);

            var request = await R_Request.CreateAsync(order.Id, guest.Id, fromLocation, toLocation, bookDto.Distance, bookDto.Amount, util);
            
            request.AddHistories(E_OrderStatus.Pending, "Create Request");

            this.unitOfWork.ForceBeginTransaction();
            this.orderRepository.Add(order);
            this.requestRepository.Add(request);

            // TODO: signal-R to Driver + Admin
            var msg = new MessageInstance {
                From = "sangthach",
                Message = "abc.....",
                Timestamp = DateTime.Now.ToString()
            };
            await signalrHub.Clients.All.BroadcastMessage(msg);

            return new BookResultDto { 
                OrderId = order.Id
            };
        }             

        public async Task Cancel(string requestId, string reason)
        {
            // validate input & validate status Request before Driver accept the request
            if (string.IsNullOrEmpty(requestId)) 
            {
                throw new Exception("RequestId is null or empty, not GUID");
            }

            var orderId = Guid.Parse(requestId);
            R_Order order = this.orderRepository.FindOne(new R_OrderGetSpec(orderId));
            if (order.Status != E_OrderStatus.Pending && order.Status != E_OrderStatus.Accepted) 
            {
                throw new Exception("Your request is processing - cannot cancel");
            }

            // update status request [Reason(R_Request) + Status(R_Order) + Status(B_RequestHistory)]
            var request = this.requestRepository.FindOne(new R_RequestGetSpec(orderId));
            order.UpdateStatus(E_OrderStatus.CancelByUser);
            request.UpdateReason(reason);
            request.AddHistories(E_OrderStatus.CancelByUser, "User cancelled this request");

            this.unitOfWork.ForceBeginTransaction();            

            // TODO: signal-R to Driver + Admin
            var msg = new MessageInstance
            {
                From = "sangthach",
                Message = "abc.....",
                Timestamp = DateTime.Now.ToString()
            };
            await signalrHub.Clients.All.BroadcastMessage(msg);
        }

        public async Task Evaluable(EvaluableDto evaluableDto)
        {
            // validate input
            evaluableDto.EmptyValidation();

            // check valid status
            var orderId = Guid.Parse(evaluableDto.OrderId);
            R_Order order = this.orderRepository.FindOne(new R_OrderGetSpec(orderId));
            if (order.Status != E_OrderStatus.Ended) 
            {
                throw new Exception("Your Booking has not finished yet, so cannot evaluate");
            }

            // update info [Rating, Note(R_Evaluation) + Status(B_EvaluationHistory)]
            R_Evaluation evaluation = R_Evaluation.Create(orderId, evaluableDto.Rating, evaluableDto.Remark);
            order.UpdateStatus(E_OrderStatus.Evaluation);
            evaluation.AddHistories(E_OrderStatus.Evaluation, "Client evaluate grab service");

            this.unitOfWork.ForceBeginTransaction();
            this.evaluationRepository.Add(evaluation);

            // signal-R to Admin
            var msg = new MessageInstance
            {
                From = "sangthach",
                Message = "abc.....",
                Timestamp = DateTime.Now.ToString()
            };
            await signalrHub.Clients.All.BroadcastMessage(msg);
        }


        public async Task<StatisticDto> Statistic() {
           
            var guest = (R_Guest)http.HttpContext.Items["User"];

            var routineCost = this.routineCostRepository.FindOne(new M_RoutineCostGetCostSpec());

            var cancelOrders = this.orderRepository.Find(new R_OrderGetCancelStatusByGuestIdSpec(guest.Id));
                            
            var doneOrders = this.orderRepository.Find(new R_OrderGetDoneStatusByGuestIdSpec(guest.Id));

            var requests = this.requestRepository.Find(new R_RequestGetByOrdersSpec(doneOrders));                            

            var result = new StatisticDto 
            { 
                Price = routineCost.Cost,
                CancelCounter = cancelOrders.Count(),
                DoneCounter = doneOrders.Count(),
                TotalAmount = requests.Sum(p => p.Cost * p.Distance)
            };

            return result;
        }

        public async Task<IEnumerable<GuestRequestHistoryDto>> RequestHistories()
        {
            // query list transactions by accountId: 
            // [R_Order, R_Request, R_Response, R_Evaluation] - Root: R_Request

            var user = (R_Guest)http.HttpContext.Items["User"];

            var orders = this.orderRepository.Find(new R_OrderGetByGuestIdSpec(user.Id)).AsQueryable();

            var requests = this.requestRepository.Find(new R_RequestGetByOrdersSpec(orders)).AsQueryable();

            var locations = this.locationRepository.Find(new R_LocationGetByRequestsSpec(requests)).AsQueryable();

            var responses = this.responseRepository.Find(new R_ResponseGetByOrderIdSpec(orders)).AsQueryable();

            var evalations = this.evaluationRepository.Find(new R_EvaluationGetByOrderIdSpec(orders)).AsQueryable();
            
            var drivers = this.driverRepository.Find(new R_DriverGetByResponsesSpec(responses)).AsQueryable();
                                    
            var items = (from order in orders
                          join request in requests on order.Id equals request.Id                          
                          
                          orderby request.RequestDateTime descending

                          select new GuestRequestHistoryDto
                          { 
                             OrderId = order.Id,
                             Status = order.Status,

                             FromAddress = locations.FirstOrDefault(p => p.Id == request.FromLocationId).Address,
                             ToAddress = locations.FirstOrDefault(p => p.Id == request.ToLocationId).Address,
                             RequestDateTime = request.RequestDateTime,                             
                             Distance = request.Distance,
                             Cost = request.Cost                                                                                     
                          }
                       ).ToList();

            foreach (var item in items)
            {
                var response = responses.Where(p => p.Id == item.OrderId).FirstOrDefault();
                if (response == null) continue;

                item.Start = response.Start;
                item.End = response.End;

                var driver = drivers.Where(p => p.Id == response.DriverId).FirstOrDefault();
                if (driver == null) continue;

                item.DriverName = driver.FullName;
                item.DriverPhone = driver.Phone;

                var evalation = evalations.Where(p => p.Id == item.OrderId).FirstOrDefault();
                if (evalation == null) continue;

                item.Rating = evalation.Rating;
                item.Note = evalation.Note;
            }

            return items;
        }

        // Interval get data: [driver positions, order Status]
        public async Task<IntervalGuestResultDto> IntervalGets(string lat, string lng, Guid orderId)
        {
            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lng))
            {
                throw new Exception("Latitude or Longitude is null or empty");
            }
            double _lat = 0.0, _lng = 0.0;
            if (!double.TryParse(lat, out _lat) || !double.TryParse(lng, out _lng))
            {
                throw new Exception("Latitude or Longitude is invalid number (double)");
            }

            // get list driver positions            
            var positions = new List<DriverPositionDto>();
            var drivers = this.driverRepository.Find(new R_DriverGetSpec(), "Locations");
            if (drivers != null)
            {
                foreach (var driver in drivers)
                {
                    if (driver.Locations != null && driver.Locations.Count > 0)
                    {
                        var coordinate = driver.Locations.LastOrDefault();
                        var distance = util.GetDistanceByCoordinate(_lat, _lng, coordinate.Lat, coordinate.Lng);
                        if (distance < Constants.DISTANCE_DEFAULT)
                        {
                            positions.Add(new DriverPositionDto
                            {
                                Phone = driver.Phone,
                                Lat = coordinate.Lat,
                                Lng = coordinate.Lng,
                                Distance = distance
                            });
                        }
                    }
                }
            }

            R_Order order = this.orderRepository.FindOne(new R_OrderGetSpec(orderId));
            if (order == null)
            {
                throw new Exception("OrderId does not exists, please check it");
            }

            return new IntervalGuestResultDto
            {
                OrderId = order.Id,
                Status = order.Status,
                Positions = positions           // driver positions (not relate orderId)
            };
        }
    }    
}
