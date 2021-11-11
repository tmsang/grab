using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using tmsang.domain;

namespace tmsang.application
{
    public class GuestOrderService : IGuestOrderService
    {
        readonly IRepository<R_Request> requestRepository;
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
            IRepository<R_Request> requestRepository,
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
            this.requestRepository = requestRepository;
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

            // create request -> requestId            
            var user = (R_Guest)http.HttpContext.Items["User"];
            var routineCost = this.routineCostRepository.FindOne(new M_RoutineCostGetCostSpec());
            if (routineCost == null) 
            {
                throw new Exception("Routine Cost has not set on valid date");
            }
            var request = R_Request.Create(user.Id, fromLocation, toLocation, routineCost.Cost);

            // save status in histories (latest)
            request.AddHistories();

            this.unitOfWork.ForceBeginTransaction();
            this.requestRepository.Add(request);

            // signal-R to Driver
            var msg = new MessageInstance {
                From = "sangthach",
                Message = "abc.....",
                Timestamp = DateTime.Now.ToString()
            };
            signalrHub.Clients.All.BroadcastMessage(msg);
        }        

        public void Cancel(string requestId)
        {
            throw new NotImplementedException();
        }

        public void Evaluable(EvaluableDto evaluableDto)
        {
            throw new NotImplementedException();
        }

        public IList<TransactionHistoriesDto> TransactionHistories(string accountId)
        {
            throw new NotImplementedException();
        }
    }    
}
