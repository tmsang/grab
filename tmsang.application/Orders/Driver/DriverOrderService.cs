using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Collections.Generic;
using tmsang.domain;
using System.Threading.Tasks;

namespace tmsang.application
{
    public class DriverOrderService : IDriverOrderService
    {
        readonly IRepository<R_Order> orderRepository;
        readonly IRepository<R_Request> requestRepository;
        readonly IRepository<R_Response> responseRepository;
        readonly IRepository<R_Evaluation> evaluationRepository;

        readonly IRepository<R_Driver> driverRepository;
        readonly IRepository<R_Guest> guestRepository;
        readonly IRepository<R_Location> locationRepository;
        readonly IRepositoryNonRoot<M_RoutineCost> routineCostRepository;

        readonly R_LocationDomainService locationDomainService;
        readonly R_FeePolicyDomainService feePolicyDomainService;
        readonly R_GuestDomainService accountDomainService;

        readonly IHubContext<SignalrHub, IHubClient> signalrHub;

        readonly IStorage storage;
        readonly IAuth auth;
        readonly IBingMap util;
        readonly IHttpContextAccessor http;
        readonly IUnitOfWork unitOfWork;

        public DriverOrderService(
            IRepository<R_Order> orderRepository,
            IRepository<R_Request> requestRepository,
            IRepository<R_Response> responseRepository,
            IRepository<R_Evaluation> evaluationRepository,

            IRepository<R_Driver> driverRepository,
            IRepository<R_Guest> guestRepository,
            IRepository<R_Location> locationRepository,
            IRepositoryNonRoot<M_RoutineCost> routineCostRepository,
            R_FeePolicyDomainService feePolicyDomainService,
            R_LocationDomainService locationDomainService,
            R_GuestDomainService accountDomainService,

            IHubContext<SignalrHub, IHubClient> signalrHub,

            IStorage storage,
            IAuth auth,
            IBingMap util,
            IHttpContextAccessor http,
            IUnitOfWork unitOfWork
        )
        {
            this.orderRepository = orderRepository;
            this.requestRepository = requestRepository;
            this.responseRepository = responseRepository;
            this.evaluationRepository = evaluationRepository;

            this.driverRepository = driverRepository;
            this.guestRepository = guestRepository;
            this.locationRepository = locationRepository;
            this.routineCostRepository = routineCostRepository;
            this.feePolicyDomainService = feePolicyDomainService;
            this.locationDomainService = locationDomainService;
            this.accountDomainService = accountDomainService;

            this.signalrHub = signalrHub;

            this.storage = storage;
            this.auth = auth;
            this.util = util;
            this.http = http;
            this.unitOfWork = unitOfWork;
        }


        public IEnumerable<GuestRequestDto> Requests()
        {
            // get user (driver + current position)
            var driver = (R_Driver)http.HttpContext.Items["User"];
            var driverLocation = this.driverRepository.FindById(driver.Id, "Locations").Locations.LastOrDefault();

            var R = 6371;
            var lat1 = driverLocation.Lat;
            var lng1 = driverLocation.Lng;

            // get requests (compare distance to "current position")
            var orders = this.orderRepository.Find(new R_OrderGetByStatusSpec(E_OrderStatus.Pending)).AsQueryable();            
            var requests = this.requestRepository.Find(new R_RequestGetByOrdersSpec(orders)).AsQueryable();
            var locations = this.locationRepository.Find(new R_LocationGetByRequestsSpec(requests)).AsQueryable();
            var guests = this.guestRepository.Find(new R_GuestGetByAccountIdsSpec(orders.Select(p => p.GuestId).ToList()), "Locations").AsQueryable();
            
            var result = (from order in orders
                          join request in requests on order.Id equals request.Id
                          join guest in guests on order.GuestId equals guest.Id

                          // ===============================================
                          // Tinh khoang cach [lat1, lng1, lat2, lng2]
                          // ===============================================
                          let lat2 = guest.Locations.OrderByDescending(p => p.Date).FirstOrDefault().Lat
                          let lng2 = guest.Locations.OrderByDescending(p => p.Date).FirstOrDefault().Lng

                          let dLat = (lat2 - lat1) * (Math.PI / 180)
                          let dLng = (lng2 - lng1) * (Math.PI / 180)

                          let a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) 
                                    + Math.Cos(lat1 * (Math.PI / 180)) * Math.Cos(lat2 * (Math.PI / 180)) 
                                    * Math.Sin(dLng / 2) * Math.Sin(dLng / 2)

                          let c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))
                          let d = R * c
                          
                          let distance = d * 1000
                          // ===============================================

                          where distance <= 5000

                          orderby request.RequestDateTime descending

                          select new GuestRequestDto
                          {
                              OrderId = order.Id,
                              Status = order.Status,

                              FromAddress = locations.FirstOrDefault(p => p.Id == request.FromLocationId).Address,

                              ToLat = locations.FirstOrDefault(p => p.Id == request.ToLocationId).Latitude,
                              ToLng = locations.FirstOrDefault(p => p.Id == request.ToLocationId).Longtitude,
                              ToAddress = locations.FirstOrDefault(p => p.Id == request.ToLocationId).Address,

                              RequestDateTime = request.RequestDateTime,
                              Distance = request.Distance,
                              Cost = request.Cost,

                              GuestName = guest.FullName,
                              GuestPhone = guest.Phone,
                              GuestLat = lat2,
                              GuestLng = lng2
                          });
            
            return result;
        }

        public async Task AcceptAsync(Guid orderId)
        {
            // Change status - Order: Accepted
            var order = this.orderRepository.FindOne(new R_OrderGetSpec(orderId));
            if (order.Status != E_OrderStatus.Pending)
            {
                throw new Exception("Your Booking is not PENDING yet, so cannot Accept");
            }
            order.UpdateStatus(E_OrderStatus.Accepted);

            // Add record R_Response: [start(null), end(null), fee, tax]
            var user = (R_Driver)http.HttpContext.Items["User"];
            var location = this.locationDomainService.AddIfNotExists(user.Address);
            if (location == null)
            {
                throw new Exception("There are error with google map - or driver location can not analyze...");
            }

            var fee = this.feePolicyDomainService.GetFee(user.Id, location.ProvinceOrCity);
            var tax = this.feePolicyDomainService.GetTax();
            var response = R_Response.Create(orderId, user.Id, fee, tax);

            // Add record ResponseHistory
            response.AddHistories(E_OrderStatus.Accepted, "Driver accept this booking");

            this.unitOfWork.ForceBeginTransaction();
            this.responseRepository.Add(response);

            // SignalR to Client (should use: Socket IO) change status button (at client side)
            var msg = new MessageInstance
            {
                From = "sangthach",
                Message = "abc.....",
                Timestamp = DateTime.Now.ToString()
            };
            await signalrHub.Clients.All.BroadcastMessage(msg);
        }

        public async Task Start(Guid orderId)
        {
            // Change status - Order: Started
            var order = this.orderRepository.FindOne(new R_OrderGetSpec(orderId));
            if (order.Status != E_OrderStatus.Accepted)
            {
                throw new Exception("Your Booking is not ACCEPTED yet, so cannot STARTED");
            }
            order.UpdateStatus(E_OrderStatus.Started);

            // Update record R_Response: [start]
            var response = this.responseRepository.FindOne(new R_ResponseGetByIdSpec(orderId));
            response.UpdateTimeStart(DateTime.Now);

            // Add record ResponseHistory
            response.AddHistories(E_OrderStatus.Started, "Driver started");

            // Clean unused data [DriverLocations...]


            // SignalR to Client (should use: Socket IO) change status button (at client side)
            var msg = new MessageInstance
            {
                From = "sangthach",
                Message = "abc.....",
                Timestamp = DateTime.Now.ToString()
            };
            await signalrHub.Clients.All.BroadcastMessage(msg);
        }

        public async Task End(Guid orderId)
        {
            // Change status - Order: Ended
            var order = this.orderRepository.FindOne(new R_OrderGetSpec(orderId));
            if (order.Status != E_OrderStatus.Started)
            {
                throw new Exception("Your Booking is not STARTED yet, so cannot ENDED");
            }
            order.UpdateStatus(E_OrderStatus.Ended);

            // Update record R_Response: [end]
            var response = this.responseRepository.FindOne(new R_ResponseGetByIdSpec(orderId));
            response.UpdateTimeEnd(DateTime.Now);

            // Add record ResponseHistory
            response.AddHistories(E_OrderStatus.Ended, "Driver ended");

            // Create location data [DriverLocations...] -> for user able to see Driver


            // SignalR to Client (should use: Socket IO) change status button (at client side)
            var msg = new MessageInstance
            {
                From = "sangthach",
                Message = "abc.....",
                Timestamp = DateTime.Now.ToString()
            };
            await signalrHub.Clients.All.BroadcastMessage(msg);
        }


        public async Task<StatisticDto> Statistic()
        {

            var driver = (R_Driver)http.HttpContext.Items["User"];

            var routineCost = this.routineCostRepository.FindOne(new M_RoutineCostGetCostSpec());

            var orders = this.orderRepository.All();

            var cancelOrders = this.responseRepository.Find(
                                    new R_OrderGetCancelStatusByDriverIdSpec(orders, driver.Id)
                                );

            var doneOrders = this.responseRepository.Find(
                                    new R_OrderGetDoneStatusByDriverIdSpec(orders, driver.Id)
                                );

            var requests = this.requestRepository.Find(new R_RequestGetByResponsesSpec(doneOrders));

            var result = new StatisticDto
            {
                Price = routineCost.Cost,
                CancelCounter = cancelOrders.Count(),
                DoneCounter = doneOrders.Count(),
                TotalAmount = requests.Sum(p => p.Cost)
            };

            return result;
        }

        public async Task<IEnumerable<DriverRequestHistoryDto>> RequestHistories()
        {
            var emptyList = new List<DriverRequestHistoryDto>();

            // get user (driver + current position)
            var driver = (R_Driver)http.HttpContext.Items["User"];

            var responses = this.responseRepository.Find(new R_ResponseGetByDriverIdSpec(driver.Id)).AsQueryable();
            
            var orders = this.orderRepository.Find(new R_OrderGetByResponsesSpec(responses)).AsQueryable();
            var requests = this.requestRepository.Find(new R_RequestGetByOrdersSpec(orders)).AsQueryable();
            var locations = this.locationRepository.Find(new R_LocationGetByRequestsSpec(requests)).AsQueryable();

            var guests = this.guestRepository.Find(new R_GuestGetByOrdersSpec(orders)).AsQueryable();
            var evalations = this.evaluationRepository.Find(new R_EvaluationGetByOrderIdSpec(orders)).AsQueryable();

            var items = (from order in orders
                         join request in requests on order.Id equals request.Id

                         orderby request.RequestDateTime descending

                         select new 
                         {
                             OrderId = order.Id,
                             Status = order.Status,

                             FromAddress = locations.FirstOrDefault(p => p.Id == request.FromLocationId).Address,
                             ToAddress = locations.FirstOrDefault(p => p.Id == request.ToLocationId).Address,
                             RequestDateTime = request.RequestDateTime,
                             Distance = request.Distance,
                             Cost = request.Cost,
                             GuestId = order.GuestId
                         }
                       ).ToList();
                                                
            foreach (var item in items)
            {
                var itm = new DriverRequestHistoryDto { 
                    OrderId = item.OrderId,
                    Status = item.Status,
                    FromAddress = item.FromAddress,
                    ToAddress = item.ToAddress,
                    RequestDateTime = item.RequestDateTime,
                    Distance = item.Distance,
                    Cost = item.Cost                    
                };

                var response = responses.Where(p => p.Id == item.OrderId).FirstOrDefault();
                if (response == null) {
                    emptyList.Add(itm); continue;
                }

                itm.Start = response.Start;
                itm.End = response.End;

                var guest = guests.Where(p => p.Id == item.GuestId).FirstOrDefault();
                if (guest == null) {
                    emptyList.Add(itm); continue;
                }

                itm.GuestName = guest.FullName;
                itm.GuestPhone = guest.Phone;

                var evalation = evalations.Where(p => p.Id == item.OrderId).FirstOrDefault();
                if (evalation == null) {
                    emptyList.Add(itm); continue;
                }

                itm.Rating = evalation.Rating;
                itm.Note = evalation.Note;

                emptyList.Add(itm);
            }

            return emptyList;
        }


        // Interval get data
        // khong can include "Locations" de add - no tu add vao
        // truong hop clear thi phai include vao moi clear hay remove duoc nhe
        public IntervalDriverResultDto IntervalGets(string lat, string lng)
        {
            // a. update driver position 
            var driver = (R_Driver)http.HttpContext.Items["User"];
            var locations = this.driverRepository.FindById(driver.Id, "Locations").Locations;
            locations.Clear();
            locations.Add(B_DriverLocation.Create(double.Parse(lat), double.Parse(lng), DateTime.Now.Ticks));

            // b. return list of requests
            return new IntervalDriverResultDto
            {
                Requests = Requests()
            };
        }
    }
}
