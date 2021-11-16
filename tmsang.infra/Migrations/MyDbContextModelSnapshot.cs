﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tmsang.infra;

namespace tmsang.infra.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("tmsang.domain.B_AdminHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<int>("AccountStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("HappenDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("B_AdminHistories");
                });

            modelBuilder.Entity("tmsang.domain.B_AdminPolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("B_AdminPolicies");
                });

            modelBuilder.Entity("tmsang.domain.B_DriverBike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<string>("BikeOwner")
                        .HasColumnType("longtext");

                    b.Property<string>("BikeType")
                        .HasColumnType("longtext");

                    b.Property<string>("Brand")
                        .HasColumnType("longtext");

                    b.Property<string>("ChassisNo")
                        .HasColumnType("longtext");

                    b.Property<string>("EngineNo")
                        .HasColumnType("longtext");

                    b.Property<string>("PlateNo")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("B_DriverBikes");
                });

            modelBuilder.Entity("tmsang.domain.B_DriverFeePolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<int>("FeePolicyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("B_DriverFeePolicies");
                });

            modelBuilder.Entity("tmsang.domain.B_DriverHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<int>("AccountStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("HappenDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("B_DriverHistories");
                });

            modelBuilder.Entity("tmsang.domain.B_DriverPolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("B_DriverPolicies");
                });

            modelBuilder.Entity("tmsang.domain.B_DriverTrustLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<int>("CancelRequestCounter")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("B_DriverTrustLevels");
                });

            modelBuilder.Entity("tmsang.domain.B_EvaluationHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<Guid>("EvaluationId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("HappenDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EvaluationId");

                    b.ToTable("B_EvaluationHistories");
                });

            modelBuilder.Entity("tmsang.domain.B_FeePolicyAccountInGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("B_FeePolicyAccountInGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DriverId = new Guid("9ad9d9f3-a26f-4454-944f-ef0369243b1c"),
                            GroupId = new Guid("e8b73f2b-e37a-4b06-92ca-7729849a1431")
                        });
                });

            modelBuilder.Entity("tmsang.domain.B_GuestHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<int>("AccountStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("HappenDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("B_GuestHistories");
                });

            modelBuilder.Entity("tmsang.domain.B_GuestPolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("B_GuestPolicies");
                });

            modelBuilder.Entity("tmsang.domain.B_PaymentHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("HappenDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.ToTable("B_PaymentHistories");
                });

            modelBuilder.Entity("tmsang.domain.B_RequestHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("HappenDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("B_RequestHistories");
                });

            modelBuilder.Entity("tmsang.domain.B_ResponseHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("HappenDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("ResponseId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ResponseId");

                    b.ToTable("B_ResponseHistories");
                });

            modelBuilder.Entity("tmsang.domain.M_AccountStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ChangedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("From")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("To")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("M_AccountStatus");
                });

            modelBuilder.Entity("tmsang.domain.M_OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ChangedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("From")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("To")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("M_OrderStatus");
                });

            modelBuilder.Entity("tmsang.domain.M_PersonalPolicyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ChangedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("From")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("To")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("M_PersonalPolicyTypes");
                });

            modelBuilder.Entity("tmsang.domain.M_RoutineCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ChangedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<DateTime?>("From")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("To")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("M_RoutineCosts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChangedDate = new DateTime(2021, 11, 16, 8, 46, 46, 185, DateTimeKind.Local).AddTicks(5556),
                            Cost = 8000.0,
                            From = new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "RoutineCost - 10/2021",
                            Status = 1,
                            To = new DateTime(2021, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            ChangedDate = new DateTime(2021, 11, 16, 8, 46, 46, 185, DateTimeKind.Local).AddTicks(6624),
                            Cost = 5000.0,
                            From = new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "RoutineCost - 11/2021",
                            Status = 1,
                            To = new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            ChangedDate = new DateTime(2021, 11, 16, 8, 46, 46, 185, DateTimeKind.Local).AddTicks(6632),
                            Cost = 7000.0,
                            From = new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "RoutineCost - 12/2021",
                            Status = 1,
                            To = new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("tmsang.domain.M_TaxVAT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ChangedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<DateTime?>("From")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("To")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("M_TaxVAT");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChangedDate = new DateTime(2021, 11, 16, 8, 46, 46, 187, DateTimeKind.Local).AddTicks(426),
                            Cost = 0.02,
                            From = new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tax - 10/2021",
                            Status = 1,
                            To = new DateTime(2021, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            ChangedDate = new DateTime(2021, 11, 16, 8, 46, 46, 187, DateTimeKind.Local).AddTicks(1015),
                            Cost = 0.050000000000000003,
                            From = new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tax - 11/2021",
                            Status = 1,
                            To = new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            ChangedDate = new DateTime(2021, 11, 16, 8, 46, 46, 187, DateTimeKind.Local).AddTicks(1022),
                            Cost = 0.10000000000000001,
                            From = new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tax - 12/2021",
                            Status = 1,
                            To = new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("tmsang.domain.R_Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("R_Admins");
                });

            modelBuilder.Entity("tmsang.domain.R_Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("PersonalId")
                        .HasColumnType("longtext");

                    b.Property<string>("PersonalImage")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("R_Drivers");
                });

            modelBuilder.Entity("tmsang.domain.R_Evaluation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("R_Evaluations");
                });

            modelBuilder.Entity("tmsang.domain.R_FeePolicy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ProvinceOrCity")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("R_FeePolicies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b154ed11-db90-4f38-aad1-1873a77807dd"),
                            Cost = 0.10000000000000001,
                            GroupId = new Guid("e8b73f2b-e37a-4b06-92ca-7729849a1431"),
                            ProvinceOrCity = "Ho Chi Minh"
                        },
                        new
                        {
                            Id = new Guid("963052af-e5a2-43fc-87b1-bb4561872920"),
                            Cost = 0.25,
                            GroupId = new Guid("e8b73f2b-e37a-4b06-92ca-7729849a1431"),
                            ProvinceOrCity = "Tay Nguyen"
                        },
                        new
                        {
                            Id = new Guid("522d9619-567d-4242-a8b2-46fe37cf993b"),
                            Cost = 0.10000000000000001,
                            GroupId = new Guid("e8b73f2b-e37a-4b06-92ca-7729849a1431"),
                            ProvinceOrCity = "Binh Duong"
                        },
                        new
                        {
                            Id = new Guid("f508176b-7884-490b-8c2e-bf9f11322f9d"),
                            Cost = 0.050000000000000003,
                            GroupId = new Guid("e8b73f2b-e37a-4b06-92ca-7729849a1431"),
                            ProvinceOrCity = "Ca Mau"
                        });
                });

            modelBuilder.Entity("tmsang.domain.R_FeePolicyGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("R_FeePolicyGroups");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e8b73f2b-e37a-4b06-92ca-7729849a1431"),
                            Name = "Normal"
                        },
                        new
                        {
                            Id = new Guid("a1d84449-8e29-4e53-86b4-9cee49f0c604"),
                            Name = "Wounded"
                        },
                        new
                        {
                            Id = new Guid("7ce984a8-a557-473c-b617-2d08ce3ce278"),
                            Name = "Poor"
                        });
                });

            modelBuilder.Entity("tmsang.domain.R_Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("R_Guests");
                });

            modelBuilder.Entity("tmsang.domain.R_Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Latitude")
                        .HasColumnType("longtext");

                    b.Property<string>("Longtitude")
                        .HasColumnType("longtext");

                    b.Property<string>("ProvinceOrCity")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("R_Locations");
                });

            modelBuilder.Entity("tmsang.domain.R_Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("R_Orders");
                });

            modelBuilder.Entity("tmsang.domain.R_Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("Paid")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("R_Payments");
                });

            modelBuilder.Entity("tmsang.domain.R_Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<double>("Cost")
                        .HasColumnType("double");

                    b.Property<double>("Distance")
                        .HasColumnType("double");

                    b.Property<Guid>("FromLocationId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("R_GuestId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Reason")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RequestDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ToLocationId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("R_GuestId");

                    b.ToTable("R_Requests");
                });

            modelBuilder.Entity("tmsang.domain.R_Response", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Fee")
                        .HasColumnType("double");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Tax")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("R_Responses");
                });

            modelBuilder.Entity("tmsang.domain.B_AdminHistory", b =>
                {
                    b.HasOne("tmsang.domain.R_Admin", "Admin")
                        .WithMany("Histories")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("tmsang.domain.B_AdminPolicy", b =>
                {
                    b.HasOne("tmsang.domain.R_Admin", "Admin")
                        .WithMany("Policies")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("tmsang.domain.B_DriverBike", b =>
                {
                    b.HasOne("tmsang.domain.R_Driver", "Driver")
                        .WithMany("Bikes")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("tmsang.domain.B_DriverFeePolicy", b =>
                {
                    b.HasOne("tmsang.domain.R_Driver", "Driver")
                        .WithMany("FeePolicies")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("tmsang.domain.B_DriverHistory", b =>
                {
                    b.HasOne("tmsang.domain.R_Driver", "Driver")
                        .WithMany("Histories")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("tmsang.domain.B_DriverPolicy", b =>
                {
                    b.HasOne("tmsang.domain.R_Driver", "Driver")
                        .WithMany("Policies")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("tmsang.domain.B_DriverTrustLevel", b =>
                {
                    b.HasOne("tmsang.domain.R_Driver", "Driver")
                        .WithMany("TrustLevels")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("tmsang.domain.B_EvaluationHistory", b =>
                {
                    b.HasOne("tmsang.domain.R_Evaluation", "Evaluation")
                        .WithMany("Histories")
                        .HasForeignKey("EvaluationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evaluation");
                });

            modelBuilder.Entity("tmsang.domain.B_FeePolicyAccountInGroup", b =>
                {
                    b.HasOne("tmsang.domain.R_FeePolicyGroup", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("tmsang.domain.B_GuestHistory", b =>
                {
                    b.HasOne("tmsang.domain.R_Guest", "Guest")
                        .WithMany("Histories")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("tmsang.domain.B_GuestPolicy", b =>
                {
                    b.HasOne("tmsang.domain.R_Guest", "Guest")
                        .WithMany("Policies")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("tmsang.domain.B_PaymentHistory", b =>
                {
                    b.HasOne("tmsang.domain.R_Payment", "Payment")
                        .WithMany("Histories")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("tmsang.domain.B_RequestHistory", b =>
                {
                    b.HasOne("tmsang.domain.R_Request", "Request")
                        .WithMany("Histories")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("tmsang.domain.B_ResponseHistory", b =>
                {
                    b.HasOne("tmsang.domain.R_Response", "Response")
                        .WithMany("Histories")
                        .HasForeignKey("ResponseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Response");
                });

            modelBuilder.Entity("tmsang.domain.R_Request", b =>
                {
                    b.HasOne("tmsang.domain.R_Guest", null)
                        .WithMany("Requests")
                        .HasForeignKey("R_GuestId");
                });

            modelBuilder.Entity("tmsang.domain.R_Response", b =>
                {
                    b.HasOne("tmsang.domain.R_Driver", "Driver")
                        .WithMany("Responses")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("tmsang.domain.R_Admin", b =>
                {
                    b.Navigation("Histories");

                    b.Navigation("Policies");
                });

            modelBuilder.Entity("tmsang.domain.R_Driver", b =>
                {
                    b.Navigation("Bikes");

                    b.Navigation("FeePolicies");

                    b.Navigation("Histories");

                    b.Navigation("Policies");

                    b.Navigation("Responses");

                    b.Navigation("TrustLevels");
                });

            modelBuilder.Entity("tmsang.domain.R_Evaluation", b =>
                {
                    b.Navigation("Histories");
                });

            modelBuilder.Entity("tmsang.domain.R_FeePolicyGroup", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("tmsang.domain.R_Guest", b =>
                {
                    b.Navigation("Histories");

                    b.Navigation("Policies");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("tmsang.domain.R_Payment", b =>
                {
                    b.Navigation("Histories");
                });

            modelBuilder.Entity("tmsang.domain.R_Request", b =>
                {
                    b.Navigation("Histories");
                });

            modelBuilder.Entity("tmsang.domain.R_Response", b =>
                {
                    b.Navigation("Histories");
                });
#pragma warning restore 612, 618
        }
    }
}
