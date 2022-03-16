using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using tmsang.application;
using tmsang.domain;
using tmsang.infra;

namespace tmsang.api
{
    public static class CustomServicesExtension
    {
        /*
         * Note:
         * 1. Uu tien thu tu cac service
         * 
         * **/
        public static IServiceCollection AddGrabCustomServices(
             this IServiceCollection services, 
             IConfiguration config)
        {
            // ----------------------------------------------
            // DI: Infra Layer (infra truoc nhe!!!)
            // ----------------------------------------------
            services.AddScoped<IEmailDispatcher, SmtpEmailDispatcher>();
            services.AddScoped<IEmailGenerator, EmailGenerator>();
            services.AddScoped<IRequestCorrelationIdentifier, W3CWebRequestCorrelationIdentifier>();
            services.AddScoped<IDomainEventRepository, MemoryDomainEventRepository>();
            services.AddScoped<ISmsProvider, SmsProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IStorage, Storage>();
            services.AddScoped<IAuth, Auth>();
            services.AddScoped<IBingMap, BingMap>();
            services.AddScoped<IFirebaseAdminSDK, FirebaseAdminSDK>();

            services.AddScoped<IRepository<R_Admin>, MyRepository<R_Admin>>();
            services.AddScoped<IRepository<R_Driver>, MyRepository<R_Driver>>();
            services.AddScoped<IRepository<R_Guest>, MyRepository<R_Guest>>();            
                        
            // ----------------------------------------------
            // DI: Application
            // ----------------------------------------------
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IGuestService, GuestService>();

            // ----------------------------------------------
            // DI: Domain
            // ----------------------------------------------
            // A. ACCOUNT
            services.AddScoped<R_AdminDomainService>();
            services.AddScoped<R_DriverDomainService>();
            services.AddScoped<R_GuestDomainService>();

            services.AddScoped<Handles<R_AdminCreatedEvent>, DomainEventHandle<R_AdminCreatedEvent>>();         // event
            services.AddScoped<Handles<R_AdminCreatedEvent>, R_AdminCreatedEmailHandle>();                      // handle
            services.AddScoped<Handles<R_AdminChangePasswordEvent>, DomainEventHandle<R_AdminChangePasswordEvent>>();   // event
            services.AddScoped<Handles<R_AdminChangePasswordEvent>, R_AdminChangePasswordEmailHandle>();                // handle

            services.AddScoped<Handles<R_DriverCreatedEvent>, DomainEventHandle<R_DriverCreatedEvent>>();
            services.AddScoped<Handles<R_DriverCreatedEvent>, R_DriverCreatedEmailHandle>();
            services.AddScoped<Handles<R_DriverChangePasswordEvent>, DomainEventHandle<R_DriverChangePasswordEvent>>();   // event
            services.AddScoped<Handles<R_DriverChangePasswordEvent>, R_DriverChangePasswordEmailHandle>();                // handle

            services.AddScoped<Handles<R_GuestCreatedEvent>, DomainEventHandle<R_GuestCreatedEvent>>();                        
            services.AddScoped<Handles<R_GuestCreatedEvent>, R_GuestCreatedEmailHandle>();
            services.AddScoped<Handles<R_GuestChangePasswordEvent>, DomainEventHandle<R_GuestChangePasswordEvent>>();   // event
            services.AddScoped<Handles<R_GuestChangePasswordEvent>, R_GuestChangePasswordEmailHandle>();                // handle

            services.AddScoped<Handles<R_AccountSmsVerificationEvent>, DomainEventHandle<R_AccountSmsVerificationEvent>>();
            services.AddScoped<Handles<R_AccountSmsVerificationEvent>, R_AccountSmsVerificationHandle>();

            // B. ORDER            
            services.AddScoped<IRepository<R_Order>, MyRepository<R_Order>>();
            services.AddScoped<IRepository<R_Request>, MyRepository<R_Request>>();
            services.AddScoped<IRepository<R_Response>, MyRepository<R_Response>>();
            services.AddScoped<IRepository<R_Evaluation>, MyRepository<R_Evaluation>>();

            services.AddScoped<IRepository<R_FeePolicy>, MyRepository<R_FeePolicy>>();
            services.AddScoped<IRepository<R_FeePolicyGroup>, MyRepository<R_FeePolicyGroup>>();

            services.AddScoped<IGuestOrderService, GuestOrderService>();
            services.AddScoped<IDriverOrderService, DriverOrderService>();
            services.AddScoped<IAdminOrderService, AdminOrderService>();

            services.AddScoped<IRepository<R_Location>, MyRepository<R_Location>>();
            services.AddScoped<IRepositoryNonRoot<M_RoutineCost>, MyRepositoryNonRoot<M_RoutineCost>>();
            services.AddScoped<IRepositoryNonRoot<M_TaxVAT>, MyRepositoryNonRoot<M_TaxVAT>>();

            services.AddScoped<R_LocationDomainService>();
            services.AddScoped<R_GuestDomainService>();
            services.AddScoped<R_FeePolicyDomainService>();

            services.AddScoped<Handles<R_RequestsOfGuestEvent>, DomainEventHandle<R_RequestsOfGuestEvent>>();

            // C. Common
            

            // D. Resolve cac service manual
            var serviceProvider = services.BuildServiceProvider();
            DomainEvents.Init(serviceProvider);

            return services;
        }

        public static void AddUnitOfWork<T>(this IServiceCollection services) where T : DbContext
        {
            services.AddScoped<IUnitOfWork<T>, DbUnitOfWork<T>>();           // do xai memory, nen rem dong nay
            services.AddScoped<IUnitOfWork>(provider => provider.GetService<IUnitOfWork<T>>());
            // services.AddScoped<IUnitOfWork, MemoryUnitOfWork>();
        }

        public static void AddUnitOfWorkPool(this IServiceCollection services, Action<UnitOfWorkPoolOptionsBuilder> optionsAction)
        {
            var optionsBuilder = new UnitOfWorkPoolOptionsBuilder();
            optionsAction.Invoke(optionsBuilder);

            services.AddScoped(typeof(IUnitOfWork<>), typeof(DbUnitOfWork<>));
            services.AddSingleton(typeof(UnitOfWorkPoolOptions), optionsBuilder.Options);
            services.AddScoped<IUnitOfWorkPool, DbUnitOfWorkPool>();
        }
    }
}
