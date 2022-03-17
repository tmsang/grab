using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Collections.Generic;
using tmsang.domain;
using System.Threading.Tasks;

namespace tmsang.application
{
    public class AdminOrderService : IAdminOrderService
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

        public AdminOrderService(
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
            IUnitOfWork unitOfWork)
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

        public IEnumerable<AdminRequestDto> RequestsByDate(DateTime from, DateTime to) {
            // get user (driver + current position)
            var admin = (R_Admin)http.HttpContext.Items["User"];            
            
            var requests = this.requestRepository.Find(new R_RequestGetByDateSpec(date)).AsQueryable();
            var locations = this.locationRepository.Find(new R_LocationGetByRequestsSpec(requests)).AsQueryable();
            var orders = this.orderRepository.Find(new R_OrderGetByRequestsSpec(requests)).AsQueryable();
            var guests = this.guestRepository.Find(new R_GuestGetByAccountIdsSpec(orders.Select(p => p.GuestId).ToList()), "Locations").AsQueryable();

            var fromDate = from.Date;
            var toDate = to.Date;
            var result = (from order in orders
                          join request in requests on order.Id equals request.Id
                          join guest in guests on order.GuestId equals guest.Id

                          let lat2 = guest.Locations.OrderByDescending(p => p.Date).FirstOrDefault().Lat
                          let lng2 = guest.Locations.OrderByDescending(p => p.Date).FirstOrDefault().Lng

                          where request.RequestDateTime.Date >= fromDate && request.RequestDateTime.Date <= toDate

                          orderby request.RequestDateTime descending

                          select new AdminRequestDto
                          {
                              OrderId = order.Id,
                              Status = order.Status,

                              FromLat = locations.FirstOrDefault(p => p.Id == request.FromLocationId).Latitude,
                              FromLng = locations.FirstOrDefault(p => p.Id == request.FromLocationId).Longtitude,
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

        public IntervalAdminResultDto IntervalGets(DateTime from, DateTime to)
        {            
            var result = new IntervalAdminResultDto { 
                Requests = RequestsByDate(from, to)
            };

            return result;
        }
    }
}
