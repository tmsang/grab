using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Collections.Generic;
using tmsang.domain;

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
        readonly IZalo zalo;
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
            IZalo zalo,
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
            this.zalo = zalo;
            this.http = http;
            this.unitOfWork = unitOfWork;
        }

        public void ZaloCall(string zaloUserId) {
            this.zalo.CallPhone(23232323);
        }

        public IEnumerable<AdminRequestDto> RequestsByDate(DateTime dateTime) {
            // get user (driver + current position)
            var admin = (R_Admin)http.HttpContext.Items["User"];            
            
            var requests = this.requestRepository.Find(new R_RequestGetByDateSpec(dateTime)).AsQueryable();
            var locations = this.locationRepository.Find(new R_LocationGetByRequestsSpec(requests)).AsQueryable();
            var orders = this.orderRepository.Find(new R_OrderGetByRequestsSpec(requests)).AsQueryable();
            var guests = this.guestRepository.Find(new R_GuestGetByAccountIdsSpec(orders.Select(p => p.GuestId).ToList()), "Locations").AsQueryable();

            var date = dateTime.Date;
            var result = (from order in orders
                          join request in requests on order.Id equals request.Id
                          join guest in guests on order.GuestId equals guest.Id

                          let lat2 = guest.Locations.OrderByDescending(p => p.Date).FirstOrDefault().Lat
                          let lng2 = guest.Locations.OrderByDescending(p => p.Date).FirstOrDefault().Lng

                          where request.RequestDateTime.Date == date

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

        public IEnumerable<NearestDriverDto> NearestDrivers(DateTime dateTime)
        {
            // get user (admin)
            var admin = (R_Admin)http.HttpContext.Items["User"];

            // ============================================================================
            // a. lay danh sach toa do Guest
            // b. lay danh sach toa do Driver
            // c. so sanh toa do Driver & toa do Guest => D1(1 km), D2(3 km), D3(5 km)
            // Luu y: bo qua trang thai PROCESSING, DONE, CANCEL (D1, D2, D3 == 0)
            //      GuestLocation, DriverLocation: la toa do dang dung
            //      Location: la toa do request
            // ============================================================================       


            // a. lay toa do khach (theo status = pending + date = hom nay)
            var orders = this.orderRepository.Find(new R_OrderGetByStatusSpec(E_OrderStatus.Pending)).AsQueryable();
            var requests = this.requestRepository.Find(new R_RequestGetByOrdersSpec(orders)).AsQueryable();            
            var guests = this.guestRepository.Find(new R_GuestGetByAccountIdsSpec(orders.Select(p => p.GuestId).ToList()), "Locations").AsQueryable();

            var ticks = dateTime.Date.Ticks;

            var guestLocations = (from order in orders
                          join request in requests on order.Id equals request.Id
                          join guest in guests on order.GuestId equals guest.Id

                          let loc = guest.Locations.Where(p => p.Date >= ticks).OrderByDescending(p => p.Date).FirstOrDefault()
                          let lat = loc.Lat
                          let lng = loc.Lng

                          where request.RequestDateTime.Date == dateTime.Date

                          select new 
                          {
                              OrderId = order.Id,                                                            
                              Lat = lat,
                              Lng = lng
                          }).ToList();
            if (guestLocations == null || guestLocations.Count <= 0) return null;

            // b. lay toa do driver (driver co update location theo ngay + driver khong o trong chuyen)                        
            var responses = this.responseRepository.Find(new R_ResponseGetAllSpec()).AsQueryable();

            // get driver trong chuyen (theo ngay)            
            var driversInTrip = (from order in orders
                            join request in requests on order.Id equals request.Id
                            join response in responses on order.Id equals response.Id
                            
                            where request.RequestDateTime.Date == dateTime.Date && 
                                (order.Status == E_OrderStatus.Accepted || order.Status == E_OrderStatus.Started)

                            select new 
                            {
                                response.DriverId                                
                            });

            // get driver khong o trong chuyen
            var drivers = this.driverRepository.Find(new R_DriverGetByNotInIdsSpec(driversInTrip.Select(p => p.DriverId).ToList()), "Locations").ToList();
            if (drivers == null || drivers.Count <= 0) return null;

            // c. so sanh toa do                        
            var driversNotInTrip = new List<NearestDriverDto>();            

            foreach (var guestLocation in guestLocations)
            {
                var lat2 = guestLocation.Lat;
                var lng2 = guestLocation.Lng;

                foreach (var driver in drivers)
                {
                    var loc = driver.Locations.Where(p => p.Date >= ticks).OrderByDescending(p => p.Date).FirstOrDefault();
                    if (loc == null) continue;

                    var lat1 = loc.Lat;
                    var lng1 = loc.Lng;
                    var distance = this.util.GetDistanceByCoordinate(lat1, lng1, lat2, lng2);       // km

                    driversNotInTrip.Add(new NearestDriverDto
                    {
                        OrderId = guestLocation.OrderId,
                        DriverId = driver.Id,
                        Distance = Math.Round(distance, 2)
                    });
                }                
            }
            driversNotInTrip = driversNotInTrip.OrderBy(p => p.OrderId).ThenBy(p => p.Distance).ToList();
            
            return driversNotInTrip;
        }

        public IntervalAdminResultDto IntervalGets(DateTime date)
        {            
            var result = new IntervalAdminResultDto { 
                Requests = RequestsByDate(date).ToList(),
                NearestDrivers = NearestDrivers(date)
            };

            return result;
        }

        public IntervalAdminResultMapDto IntervalGetsMap(DateTime dateTime)
        {
            // get requests
            var requestsByDate = RequestsByDate(dateTime).ToList();

            // get positions [guest dang book + driver dang free de accept]
            var guests = this.guestRepository.Find(new R_GuestGetSpec(), "Locations").AsQueryable();
            var drivers = this.driverRepository.Find(new R_DriverGetSpec(), "Locations").AsQueryable();

            var orders = this.orderRepository.Find(new R_OrderGetByStatusSpec(E_OrderStatus.Pending)).AsQueryable();
            var requests = this.requestRepository.Find(new R_RequestGetByOrdersSpec(orders)).AsQueryable();
            var responses = this.responseRepository.Find(new R_ResponseGetAllSpec()).AsQueryable();

            var ticks = dateTime.Date.Ticks;

            var positions = (
                from order in orders
                join request in requests on order.Id equals request.Id
                join guest in guests on order.GuestId equals guest.Id

                let location = guest.Locations.Where(p => p.Date >= ticks).OrderByDescending(p => p.Date).FirstOrDefault()                
                where request.RequestDateTime.Date == dateTime.Date && location.Date >= ticks 

                select new AdminPositionDto {
                    Id = guest.Id,
                    Type = 1,
                    FullName = guest.FullName,
                    Phone = guest.Phone,
                    Lat = location.Lat,
                    Lng = location.Lng
                }
            ).Concat(
                // lay danh dach driver co position (hom nay) - danh dach drive dang start trip!
                from driver in drivers
                let location = driver.Locations.Where(p => p.Date >= ticks).OrderByDescending(p => p.Date).FirstOrDefault()
                where location.Date >= ticks && !(
                    from order in orders
                    join request in requests on order.Id equals request.Id
                    join response in responses on order.Id equals response.Id
                    where request.RequestDateTime.Date == dateTime.Date &&
                        (order.Status == E_OrderStatus.Accepted || order.Status == E_OrderStatus.Started)
                    select response.DriverId).Contains(driver.Id)

                select new AdminPositionDto
                {
                    Id = driver.Id,
                    Type = 2,
                    FullName = driver.FullName,
                    Phone = driver.Phone,
                    Lat = location.Lat,
                    Lng = location.Lng
                }
            ).Distinct();

            return new IntervalAdminResultMapDto { 
                TotalRequests = requestsByDate.Count,
                TotalNew = requestsByDate.Where(p => p.Status == E_OrderStatus.Pending).Count(),
                TotalProcessing = requestsByDate.Where(p => p.Status == E_OrderStatus.Accepted || p.Status == E_OrderStatus.Started).Count(),
                TotalDone = requestsByDate.Where(p => p.Status == E_OrderStatus.Ended || p.Status == E_OrderStatus.Evaluation).Count(),
                TotalCancel = requestsByDate.Where(p => p.Status == E_OrderStatus.CancelByUser || p.Status == E_OrderStatus.CancelByDriver || p.Status == E_OrderStatus.CancelByAdmin || p.Status == E_OrderStatus.CancelBySystem).Count(),

                Positions = positions
            };
        }
    }
}
