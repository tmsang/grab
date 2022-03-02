using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            // Admin
            modelBuilder.Entity<R_Admin>().ToTable("R_Admins");

            modelBuilder.Entity<B_AdminHistory>()
                .ToTable("B_AdminHistories")
                .HasOne<R_Admin>(p => p.Admin)
                .WithMany(p => p.Histories)
                .HasForeignKey(p => p.AccountId);

            modelBuilder.Entity<B_AdminPolicy>()
                .ToTable("B_AdminPolicies")
                .HasOne<R_Admin>(p => p.Admin)
                .WithMany(p => p.Policies)
                .HasForeignKey(p => p.AccountId);

            // Driver
            modelBuilder.Entity<R_Driver>().ToTable("R_Drivers");

            modelBuilder.Entity<B_DriverHistory>()
                .ToTable("B_DriverHistories")
                .HasOne(p => p.Driver)
                .WithMany(p => p.Histories)
                .HasForeignKey(p => p.AccountId);

            modelBuilder.Entity<B_DriverPolicy>()
                .ToTable("B_DriverPolicies")
                .HasOne(p => p.Driver)
                .WithMany(p => p.Policies)
                .HasForeignKey(p => p.AccountId);

            modelBuilder.Entity<B_DriverFeePolicy>()
                .ToTable("B_DriverFeePolicies")
                .HasOne(p => p.Driver)
                .WithMany(p => p.FeePolicies)
                .HasForeignKey(p => p.AccountId);

            modelBuilder.Entity<B_DriverTrustLevel>()
                .ToTable("B_DriverTrustLevels")
                .HasOne(p => p.Driver)
                .WithMany(p => p.TrustLevels)
                .HasForeignKey(p => p.AccountId);

            modelBuilder.Entity<B_DriverBike>()
                .ToTable("B_DriverBikes")
                .HasOne<R_Driver>(p => p.Driver)
                .WithMany(p => p.Bikes)
                .HasForeignKey(p => p.AccountId);

            modelBuilder.Entity<B_DriverLocation>()
                .ToTable("B_DriverLocations")
                .HasOne<R_Driver>(p => p.Driver)
                .WithMany(p => p.Locations)
                .HasForeignKey(p => p.AccountId);

            // Guest
            modelBuilder.Entity<R_Guest>().ToTable("R_Guests");

            modelBuilder.Entity<B_GuestHistory>()
                .ToTable("B_GuestHistories")
                .HasOne(p => p.Guest)
                .WithMany(p => p.Histories)
                .HasForeignKey(p => p.AccountId);

            modelBuilder.Entity<B_GuestPolicy>()
                .ToTable("B_GuestPolicies")
                .HasOne(p => p.Guest)
                .WithMany(p => p.Policies)
                .HasForeignKey(p => p.AccountId);

            modelBuilder.Entity<B_GuestLocation>()
               .ToTable("B_GuestLocations")
               .HasOne(p => p.Guest)
               .WithMany(p => p.Locations)
               .HasForeignKey(p => p.AccountId);

            // Order
            modelBuilder.Entity<R_Order>().ToTable("R_Orders");

            // request (1-n guest-request)          ban than no la ROOT, nhung cung lai la Child
            modelBuilder.Entity<R_Request>()
                .ToTable("R_Requests")
                .HasOne(p => p.Guest)
                .WithMany(p => p.Requests)
                .HasForeignKey(p => p.GuestId);

            modelBuilder.Entity<B_RequestHistory>()
                .ToTable("B_RequestHistories")
                .HasOne(p => p.Request)
                .WithMany(p => p.Histories)
                .HasForeignKey(p => p.RequestId);

            // response (1-n driver-response)       ban than no la ROOT, nhung cung lai la Child
            modelBuilder.Entity<R_Response>()
                .ToTable("R_Responses")
                .HasOne(p => p.Driver)
                .WithMany(p => p.Responses)
                .HasForeignKey(p => p.DriverId);

            modelBuilder.Entity<B_ResponseHistory>()
                .ToTable("B_ResponseHistories")
                .HasOne(p => p.Response)
                .WithMany(p => p.Histories)
                .HasForeignKey(p => p.ResponseId);

            
            modelBuilder.Entity<R_Payment>()        
                .ToTable("R_Payments")
                .HasOne(p => p.Guest)
                .WithMany(p => p.Payments)
                .HasForeignKey(p => p.GuestId);

            modelBuilder.Entity<B_PaymentHistory>()
                .ToTable("B_PaymentHistories")
                .HasOne(p => p.Payment)
                .WithMany(p => p.Histories)
                .HasForeignKey(p => p.PaymentId);
            
            modelBuilder.Entity<R_Evaluation>()
                .ToTable("R_Evaluations")
                .HasOne(p => p.Guest)
                .WithMany(p => p.Evaluations)
                .HasForeignKey(p => p.GuestId);

            modelBuilder.Entity<B_EvaluationHistory>()
                .ToTable("B_EvaluationHistories")
                .HasOne(p => p.Evaluation)
                .WithMany(p => p.Histories)
                .HasForeignKey(p => p.EvaluationId);

            // fee policy (use convention)
            modelBuilder.Entity<R_FeePolicy>().ToTable("R_FeePolicies");

            modelBuilder.Entity<R_FeePolicyGroup>().ToTable("R_FeePolicyGroups");

            modelBuilder.Entity<B_FeePolicyAccountInGroup>()
                .ToTable("B_FeePolicyAccountInGroups")
                .HasOne(p => p.Group)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.GroupId);                        
            
            // master
            modelBuilder.Entity<M_AccountStatus>().ToTable("M_AccountStatus");
            modelBuilder.Entity<M_OrderStatus>().ToTable("M_OrderStatus");
            modelBuilder.Entity<M_PersonalPolicyType>().ToTable("M_PersonalPolicyTypes");
            modelBuilder.Entity<M_RoutineCost>().ToTable("M_RoutineCosts");
            modelBuilder.Entity<M_TaxVAT>().ToTable("M_TaxVAT");

            // common
            modelBuilder.Entity<R_Location>().ToTable("R_Locations");



            // ==========================================
            // SEED DATA
            // ==========================================
            var year = DateTime.Now.Year;

            modelBuilder.Entity<M_RoutineCost>().HasData(
                M_RoutineCost.Create(
                    1, $"RoutineCost - 01/{year}",
                    new DateTime(year, 1, 1),
                    new DateTime(year, 1, DateTime.DaysInMonth(year, 1)),
                    E_Status.Active,
                    8000),
                M_RoutineCost.Create(
                    2, $"RoutineCost - 02/{year}",
                    new DateTime(year, 2, 1),
                    new DateTime(year, 2, DateTime.DaysInMonth(year, 2)),
                    E_Status.Active,
                    5000),
                M_RoutineCost.Create(
                    3, $"RoutineCost - 03/{year}",
                    new DateTime(year, 3, 1),
                    new DateTime(year, 3, DateTime.DaysInMonth(year, 3)),
                    E_Status.Active,
                    7000),
                M_RoutineCost.Create(
                    4, $"RoutineCost - 04/{year}",
                    new DateTime(year, 4, 1),
                    new DateTime(year, 4, DateTime.DaysInMonth(year, 4)),
                    E_Status.Active,
                    8000),
                M_RoutineCost.Create(
                    5, $"RoutineCost - 05/{year}",
                    new DateTime(year, 5, 1),
                    new DateTime(year, 5, DateTime.DaysInMonth(year, 5)),
                    E_Status.Active,
                    5000),
                M_RoutineCost.Create(
                    6, $"RoutineCost - 06/{year}",
                    new DateTime(year, 6, 1),
                    new DateTime(year, 6, DateTime.DaysInMonth(year, 6)),
                    E_Status.Active,
                    7000),
                M_RoutineCost.Create(
                    7, $"RoutineCost - 07/{year}",
                    new DateTime(year, 7, 1),
                    new DateTime(year, 7, DateTime.DaysInMonth(year, 7)),
                    E_Status.Active,
                    8000),
                M_RoutineCost.Create(
                    8, $"RoutineCost - 08/{year}",
                    new DateTime(year, 8, 1),
                    new DateTime(year, 8, DateTime.DaysInMonth(year, 8)),
                    E_Status.Active,
                    5000),
                M_RoutineCost.Create(
                    9, $"RoutineCost - 09/{year}",
                    new DateTime(year, 9, 1),
                    new DateTime(year, 9, DateTime.DaysInMonth(year, 9)),
                    E_Status.Active,
                    7000),
                M_RoutineCost.Create(
                    10, $"RoutineCost - 10/{year}", 
                    new DateTime(year, 10, 1), 
                    new DateTime(year, 10, DateTime.DaysInMonth(year, 10)), 
                    E_Status.Active, 
                    8000),
                M_RoutineCost.Create(
                    11, $"RoutineCost - 11/{year}",
                    new DateTime(year, 11, 1),
                    new DateTime(year, 11, DateTime.DaysInMonth(year, 11)),
                    E_Status.Active,
                    5000),
                M_RoutineCost.Create(
                    12, $"RoutineCost - 12/{year}",
                    new DateTime(year, 12, 1),
                    new DateTime(year, 12, DateTime.DaysInMonth(year, 12)),
                    E_Status.Active,
                    7000)
            );

            modelBuilder.Entity<M_TaxVAT>().HasData(
                M_TaxVAT.Create(
                    1, $"Tax - 01/{year}",
                    new DateTime(year, 1, 1),
                    new DateTime(year, 1, DateTime.DaysInMonth(year, 1)),
                    E_Status.Active,
                    0.02),
                M_TaxVAT.Create(
                    2, $"Tax - 02/{year}",
                    new DateTime(year, 2, 1),
                    new DateTime(year, 2, DateTime.DaysInMonth(year, 2)),
                    E_Status.Active,
                    0.05),
                M_TaxVAT.Create(
                    3, $"Tax - 03/{year}",
                    new DateTime(year, 3, 1),
                    new DateTime(year, 3, DateTime.DaysInMonth(year, 3)),
                    E_Status.Active,
                    0.1),
                M_TaxVAT.Create(
                    4, $"Tax - 04/{year}",
                    new DateTime(year, 4, 1),
                    new DateTime(year, 4, DateTime.DaysInMonth(year, 4)),
                    E_Status.Active,
                    0.02),
                M_TaxVAT.Create(
                    5, $"Tax - 05/{year}",
                    new DateTime(year, 5, 1),
                    new DateTime(year, 5, DateTime.DaysInMonth(year, 5)),
                    E_Status.Active,
                    0.05),
                M_TaxVAT.Create(
                    6, $"Tax - 06/{year}",
                    new DateTime(year, 6, 1),
                    new DateTime(year, 6, DateTime.DaysInMonth(year, 6)),
                    E_Status.Active,
                    0.1),
                M_TaxVAT.Create(
                    7, $"Tax - 07/{year}",
                    new DateTime(year, 7, 1),
                    new DateTime(year, 7, DateTime.DaysInMonth(year, 7)),
                    E_Status.Active,
                    0.02),
                M_TaxVAT.Create(
                    8, $"Tax - 08/{year}",
                    new DateTime(year, 8, 1),
                    new DateTime(year, 8, DateTime.DaysInMonth(year, 8)),
                    E_Status.Active,
                    0.05),
                M_TaxVAT.Create(
                    9, $"Tax - 09/{year}",
                    new DateTime(year, 9, 1),
                    new DateTime(year, 9, DateTime.DaysInMonth(year, 9)),
                    E_Status.Active,
                    0.1),
                M_TaxVAT.Create(
                    10, $"Tax - 10/{year}",
                    new DateTime(year, 10, 1),
                    new DateTime(year, 10, DateTime.DaysInMonth(year, 10)),
                    E_Status.Active,
                    0.02),
                M_TaxVAT.Create(
                    11, $"Tax - 11/{year}",
                    new DateTime(year, 11, 1),
                    new DateTime(year, 11, DateTime.DaysInMonth(year, 11)),
                    E_Status.Active,
                    0.05),
                M_TaxVAT.Create(
                    12, $"Tax - 12/{year}",
                    new DateTime(year, 12, 1),
                    new DateTime(year, 12, DateTime.DaysInMonth(year, 12)),
                    E_Status.Active,
                    0.1)
            );            

            // With data have relationship (cannot use IList.Add -> should use HasData for Parent and Child)
            // https://stackoverflow.com/questions/56609546/how-to-fix-the-seed-entity-for-entity-type-x-cannot-be-added-because-there-was
            // account
            var auth = new Auth();
            var password = "1234567";
            var hash = auth.EncryptPassword(password);

            var guestId1 = Guid.NewGuid();
            var guestId2 = Guid.NewGuid();            
            modelBuilder.Entity<R_Guest>().HasData(
                R_Guest.CreateForSeed(guestId1, "Guest 1", "0919239081", "sangnew2016@gmail.com", hash.Hash, hash.Salt),
                R_Guest.CreateForSeed(guestId2, "Guest 2", "0708825109", "sangnews2014@gmail.com", hash.Hash, hash.Salt)
            );
            modelBuilder.Entity<B_GuestLocation>().HasData(
                B_GuestLocation.CreateForSeed(10.74783, 106.68921166666667, DateTime.Now.Ticks, guestId1, 1),
                B_GuestLocation.CreateForSeed(10.74593, 106.68101166666667, DateTime.Now.Ticks, guestId2, 2)
            );
                        
            var driverId1 = Guid.NewGuid();
            var driverId2 = Guid.NewGuid();                                    
            modelBuilder.Entity<R_Driver>().HasData(
                R_Driver.CreateForSeed(driverId1, "Driver 1", "023363000", "", "123 ton dan p7 q4", "0919239081", "sangnew2015@gmail.com", hash.Hash, hash.Salt),
                R_Driver.CreateForSeed(driverId2, "Driver 2", "023363001", "", "32/1 hoang dieu p10 q4", "0708825109", "sangnew2013@gmail.com", hash.Hash, hash.Salt)
            );
            modelBuilder.Entity<B_DriverLocation>().HasData(
                B_DriverLocation.CreateForSeed(10.74583, 106.68721166666667, DateTime.Now.Ticks, driverId1, 1),
                B_DriverLocation.CreateForSeed(10.74683, 106.68821166666667, DateTime.Now.Ticks, driverId2, 2)
            );            
            
            modelBuilder.Entity<R_Admin>().HasData(
                R_Admin.CreateForSeed("Admin 1", "sangnew2015@gmail.com", "0919239081", "123 hoang dieu p10q4", hash.Hash, hash.Salt)
            );

            // create group
            var normalGroupPolicy = R_FeePolicyGroup.Create("Normal");
            var woundedGroupPolicy = R_FeePolicyGroup.Create("Wounded");
            var poorGroupPolicy = R_FeePolicyGroup.Create("Poor");
            modelBuilder.Entity<R_FeePolicyGroup>().HasData(
                normalGroupPolicy, woundedGroupPolicy, poorGroupPolicy
            );

            // add user into group            
            modelBuilder.Entity<B_FeePolicyAccountInGroup>().HasData(
                B_FeePolicyAccountInGroup.Create(1, normalGroupPolicy.Id, driverId1),
                B_FeePolicyAccountInGroup.Create(2, normalGroupPolicy.Id, driverId2)
            );

            // fee - cost
            modelBuilder.Entity<R_FeePolicy>().HasData(
                R_FeePolicy.Create("Ho Chi Minh", normalGroupPolicy.Id, 0.1),
                R_FeePolicy.Create("Tay Nguyen", normalGroupPolicy.Id, 0.25),
                R_FeePolicy.Create("Binh Duong", normalGroupPolicy.Id, 0.1),
                R_FeePolicy.Create("Ca Mau", normalGroupPolicy.Id, 0.05)
            );
        }


    }
}
