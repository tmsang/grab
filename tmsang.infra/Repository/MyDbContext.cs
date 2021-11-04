using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using tmsang.domain;

namespace tmsang.infra
{
    public class MyDbContext: DbContext
    {
        
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        
        // Account
        public DbSet<R_Admin> Admins { get; set; }
        public DbSet<B_AdminHistory> AdminHistories { get; set; }
        public DbSet<B_AdminPolicy> AdminPolicies { get; set; }

        public DbSet<R_Driver> Drivers { get; set; }
        public DbSet<B_DriverHistory> DriverHistories { get; set; }
        public DbSet<B_DriverPolicy> DriverPolicies { get; set; }
        public DbSet<B_DriverFeePolicy> DriverFeePolicies { get; set; }
        public DbSet<B_DriverTrustLevel> DriverTrustLevels { get; set; }
        public DbSet<B_DriverBike> DriverBikes { get; set; }

        public DbSet<R_Guest> Guests { get; set; }
        public DbSet<B_GuestHistory> GuestHistories { get; set; }
        public DbSet<B_GuestPolicy> GuestPolicies { get; set; }

        // Order
        public DbSet<R_Order> Orders { get; set; }
        
        public DbSet<R_Request> Requests { get; set; }
        public DbSet<B_RequestHistory> RequestHistories { get; set; }
        public DbSet<R_Response> Responses { get; set; }
        public DbSet<B_ResponseHistory> ResponseHistories { get; set; }
        public DbSet<R_Payment> Payments { get; set; }
        public DbSet<B_PaymentHistory> PaymentHistories { get; set; }
        public DbSet<R_Evaluation> Evaluations { get; set; }
        public DbSet<B_EvaluationHistory> EvaluationHistories { get; set; }

        // FeePolicy
        public DbSet<R_FeePolicy> FeePolicies { get; set; }
        public DbSet<R_FeePolicyGroup> FeePolicyGroups { get; set; }
        public DbSet<B_FeePolicyAccountInGroup> FeePolicyAccountInGroups { get; set; }

        // Common
        public DbSet<R_Location> Locations { get; set; }

        // Master Data
        public DbSet<M_AccountStatus> AccountStatus { get; set; }        
        public DbSet<M_OrderStatus> OrderStatus { get; set; }
        public DbSet<M_PersonalPolicyType> PersonalPolicyTypes { get; set; }
        public DbSet<M_RoutineCost> RoutineCosts { get; set; }
        public DbSet<M_TaxVAT> TaxVATs { get; set; }        


        public override int SaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<R_Admin>().ToTable("R_Admins");
            modelBuilder.Entity<B_AdminHistory>().ToTable("B_AdminHistories");
            modelBuilder.Entity<B_AdminPolicy>().ToTable("B_AdminPolicies");

            modelBuilder.Entity<R_Driver>().ToTable("R_Drivers");
            modelBuilder.Entity<B_DriverHistory>().ToTable("B_DriverHistories");
            modelBuilder.Entity<B_DriverPolicy>().ToTable("B_DriverPolicies");
            modelBuilder.Entity<B_DriverFeePolicy>().ToTable("B_DriverFeePolicies");
            modelBuilder.Entity<B_DriverTrustLevel>().ToTable("B_DriverTrustLevels");
            modelBuilder.Entity<B_DriverBike>().ToTable("B_DriverBikes");

            modelBuilder.Entity<R_Guest>().ToTable("R_Guests");
            modelBuilder.Entity<B_GuestHistory>().ToTable("B_GuestHistories");
            modelBuilder.Entity<B_GuestPolicy>().ToTable("B_GuestPolicies");

            modelBuilder.Entity<R_Order>().ToTable("R_Orders");
            modelBuilder.Entity<R_Request>().ToTable("R_Requests");
            modelBuilder.Entity<B_RequestHistory>().ToTable("B_RequestHistories");
            modelBuilder.Entity<R_Response>().ToTable("R_Responses");
            modelBuilder.Entity<B_ResponseHistory>().ToTable("B_ResponseHistories");
            modelBuilder.Entity<R_Payment>().ToTable("R_Payments");
            modelBuilder.Entity<B_PaymentHistory>().ToTable("B_PaymentHistories");
            modelBuilder.Entity<R_Evaluation>().ToTable("R_Evaluations");
            modelBuilder.Entity<B_EvaluationHistory>().ToTable("B_EvaluationHistories");

            modelBuilder.Entity<R_FeePolicy>().ToTable("R_FeePolicies");
            modelBuilder.Entity<R_FeePolicyGroup>().ToTable("R_FeePolicyGroups");
            modelBuilder.Entity<B_FeePolicyAccountInGroup>().ToTable("B_FeePolicyAccountInGroups");                        
            
            modelBuilder.Entity<M_AccountStatus>().ToTable("M_AccountStatus");
            modelBuilder.Entity<M_OrderStatus>().ToTable("M_OrderStatus");
            modelBuilder.Entity<M_PersonalPolicyType>().ToTable("M_PersonalPolicyTypes");
            modelBuilder.Entity<M_RoutineCost>().ToTable("M_RoutineCosts");
            modelBuilder.Entity<M_TaxVAT>().ToTable("M_TaxVAT");

            modelBuilder.Entity<R_Location>().ToTable("R_Locations");
        }

    }
}
