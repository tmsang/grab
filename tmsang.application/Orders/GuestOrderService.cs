using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Collections.Generic;
using tmsang.domain;

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
            this.http = http;
            this.unitOfWork = unitOfWork;
        }

        public void Book(BookDto bookDto)
        {
            // validate input
            bookDto.EmptyValidation();

            // check location -> add or get Id location
            R_Location fromLocation = this.locationDomainService.AddIfNotExists(bookDto.FromAddress, bookDto.FromLatitude, bookDto.FromLongtitude);
            R_Location toLocation = this.locationDomainService.AddIfNotExists(bookDto.ToAddress, bookDto.ToLatitude, bookDto.ToLongtitude);
            
            // get accountId + routineCost
            var user = (R_Guest)http.HttpContext.Items["User"];
            var routineCost = this.routineCostRepository.FindOne(new M_RoutineCostGetCostSpec());
            if (routineCost == null) 
            {
                throw new Exception("Routine Cost has not set on valid date");
            }

            // create request -> requestId  
            var order = R_Order.Create(user.Id, E_OrderStatus.Pending);

            var request = R_Request.Create(order.Id, fromLocation, toLocation, routineCost.Cost);
            
            request.AddHistories(E_OrderStatus.Pending, "Create Request");

            this.unitOfWork.ForceBeginTransaction();
            this.requestRepository.Add(request);

            // TODO: signal-R to Driver + Admin
            var msg = new MessageInstance {
                From = "sangthach",
                Message = "abc.....",
                Timestamp = DateTime.Now.ToString()
            };
            signalrHub.Clients.All.BroadcastMessage(msg);
        }        

        public void Cancel(string requestId, string reason)
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
            this.requestRepository.Update(request);

            // TODO: signal-R to Driver + Admin
            var msg = new MessageInstance
            {
                From = "sangthach",
                Message = "abc.....",
                Timestamp = DateTime.Now.ToString()
            };
            signalrHub.Clients.All.BroadcastMessage(msg);
        }

        public void Evaluable(EvaluableDto evaluableDto)
        {
            // validate input
            evaluableDto.EmptyValidation();

            // check valid status
            var orderId = Guid.Parse(evaluableDto.RequestId);
            R_Order order = this.orderRepository.FindOne(new R_OrderGetSpec(orderId));
            if (order.Status != E_OrderStatus.Pending) 
            {
                throw new Exception("Your Booking has not finished yet, so cannot evaluate");
            }

            // update info [Rating, Note(R_Evaluation) + Status(B_EvaluationHistory)]
            R_Evaluation evaluation = R_Evaluation.Create(orderId, evaluableDto.Rating, evaluableDto.Note);
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
            signalrHub.Clients.All.BroadcastMessage(msg);
        }

        public IEnumerable<TransactionHistoriesDto> TransactionHistories()
        {
            // query list transactions by accountId: 
            // [R_Order, R_Request, R_Response, R_Evaluation] - Root: R_Request

            var user = (R_Guest)http.HttpContext.Items["User"];
            
            var orders = this.orderRepository.Find(new R_OrderGetByAccountIdSpec(user.Id));

            var requests = this.requestRepository.Find(new R_RequestGetByOrderIdSpec(orders));

            var responses = this.responseRepository.Find(new R_ResponseGetByOrderIdSpec(orders));

            var evalations = this.evaluationRepository.Find(new R_EvaluationGetByOrderIdSpec(orders));

            var locations = this.locationRepository.Find(new R_LocationGetByRequestsSpec(requests));

            var drivers = this.driverRepository.Find(new R_DriverGetByResponsesSpec(responses));

            var result = from order in orders
                         join request in requests on order.Id equals request.Id
                         join response in responses on order.Id equals response.Id
                         join evaluation in evalations on order.Id equals evaluation.Id
                         
                         select new TransactionHistoriesDto
                         { 
                             OrderId = order.Id,
                             Status = order.Status,

                             FromAddress = locations.FirstOrDefault(p => p.Id == request.FromLocationId).Address,
                             ToAddress = locations.FirstOrDefault(p => p.Id == request.ToLocationId).Address,
                             RequestDateTime = request.RequestDateTime,
                             Reason = request.Reason,
                             Distance = request.Distance,
                             Cost = request.Cost,

                             Start = response.Start,
                             End = response.End,
                             DriverName = drivers.FirstOrDefault(p => p.Id == response.DriverId).FullName,
                             DriverPhone = drivers.FirstOrDefault(p => p.Id == response.DriverId).Phone,

                             Rating = evaluation.Rating,
                             Note = evaluation.Note
                         };

            return result;
        }
    }    
}
