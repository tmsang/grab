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

        readonly IRepository<R_Guest> guestRepository;
        readonly IRepository<R_Location> locationRepository;
        readonly IRepositoryNonRoot<M_RoutineCost> routineCostRepository;

        readonly R_LocationDomainService locationDomainService;
        readonly R_FeePolicyDomainService feePolicyDomainService;
        readonly R_GuestDomainService accountDomainService;

        readonly IHubContext<SignalrHub, IHubClient> signalrHub;

        readonly IStorage storage;
        readonly IAuth auth;
        readonly IHttpContextAccessor http;
        readonly IUnitOfWork unitOfWork;

        public DriverOrderService(
            IRepository<R_Order> orderRepository,
            IRepository<R_Request> requestRepository,
            IRepository<R_Response> responseRepository,
            IRepository<R_Evaluation> evaluationRepository,

            IRepository<R_Guest> guestRepository,
            IRepository<R_Location> locationRepository,
            IRepositoryNonRoot<M_RoutineCost> routineCostRepository,
            R_FeePolicyDomainService feePolicyDomainService,
            R_LocationDomainService locationDomainService,
            R_GuestDomainService accountDomainService,

            IHubContext<SignalrHub, IHubClient> signalrHub,

            IStorage storage,
            IAuth auth,
            IHttpContextAccessor http,
            IUnitOfWork unitOfWork
        )
        {
            this.orderRepository = orderRepository;
            this.requestRepository = requestRepository;
            this.responseRepository = responseRepository;
            this.evaluationRepository = evaluationRepository;

            this.guestRepository = guestRepository;
            this.locationRepository = locationRepository;
            this.routineCostRepository = routineCostRepository;
            this.feePolicyDomainService = feePolicyDomainService;
            this.locationDomainService = locationDomainService;
            this.accountDomainService = accountDomainService;

            this.signalrHub = signalrHub;

            this.storage = storage;
            this.auth = auth;
            this.http = http;
            this.unitOfWork = unitOfWork;
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
            var response = this.responseRepository.FindOne(new R_ResponseGetSpec(orderId));
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
            var response = this.responseRepository.FindOne(new R_ResponseGetSpec(orderId));
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


        public async Task<IEnumerable<DriverTransactionHistoriesDto>> TransactionHistories()
        {
            // list Client
            var user = (R_Driver)http.HttpContext.Items["User"];

            var responses = this.responseRepository.Find(new R_ResponseGetByDriverIdSpec(user.Id));

            var orders = this.orderRepository.Find(new R_OrderGetByOrderIdsSpec(responses.Select(p => p.OrderId).ToList()));

            var requests = this.requestRepository.Find(new R_RequestGetByOrderIdSpec(orders));                        

            var locations = this.locationRepository.Find(new R_LocationGetByRequestsSpec(requests));

            var guests = this.guestRepository.Find(new R_GuestGetByAccountIdsSpec(orders.Select(p => p.GuestId).ToList()));


            var result = (from order in orders
                          join request in requests on order.Id equals request.Id
                          join response in responses on order.Id equals response.Id                          

                          select new DriverTransactionHistoriesDto
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
                              GuestName = guests.FirstOrDefault(p => p.Id == response.DriverId).FullName,
                              GuestPhone = guests.FirstOrDefault(p => p.Id == response.DriverId).Phone,                              
                          });

            return result;
        }
    }
}
