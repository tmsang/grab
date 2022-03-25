using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmsang.infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "M_AccountStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    To = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ChangedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_AccountStatus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "M_OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    To = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ChangedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_OrderStatus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "M_PersonalPolicyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    To = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ChangedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_PersonalPolicyTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "M_RoutineCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cost = table.Column<double>(type: "double", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    To = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ChangedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_RoutineCosts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "M_TaxVAT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cost = table.Column<double>(type: "double", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    To = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ChangedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_TaxVAT", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "R_Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Salt = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_Admins", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "R_Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonalImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Salt = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_Drivers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "R_Evaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Rating = table.Column<float>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_Evaluations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "R_FeePolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GroupId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProvinceOrCity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cost = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_FeePolicies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "R_FeePolicyGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_FeePolicyGroups", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "R_Guests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Salt = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_Guests", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "R_Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Latitude = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Longtitude = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProvinceOrCity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_Locations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "R_Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_Orders", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "R_Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Paid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GuestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_Payments", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "R_Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FromLocationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ToLocationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Distance = table.Column<double>(type: "double", nullable: false),
                    Cost = table.Column<double>(type: "double", nullable: false),
                    RequestDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Reason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_Requests", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "R_Responses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    End = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Fee = table.Column<double>(type: "double", nullable: false),
                    Tax = table.Column<double>(type: "double", nullable: false),
                    DriverId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_Responses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_AdminHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountStatusId = table.Column<int>(type: "int", nullable: false),
                    HappenDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_AdminHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_AdminHistories_R_Admins_AccountId",
                        column: x => x.AccountId,
                        principalTable: "R_Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_AdminPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    To = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_AdminPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_AdminPolicies_R_Admins_AccountId",
                        column: x => x.AccountId,
                        principalTable: "R_Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_DriverBikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlateNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BikeOwner = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EngineNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChassisNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BikeType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Brand = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistrationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_DriverBikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_DriverBikes_R_Drivers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "R_Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_DriverFeePolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FeePolicyId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    To = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_DriverFeePolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_DriverFeePolicies_R_Drivers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "R_Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_DriverHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountStatusId = table.Column<int>(type: "int", nullable: false),
                    HappenDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_DriverHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_DriverHistories_R_Drivers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "R_Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_DriverLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Lat = table.Column<double>(type: "double", nullable: false),
                    Lng = table.Column<double>(type: "double", nullable: false),
                    Date = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_DriverLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_DriverLocations_R_Drivers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "R_Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_DriverPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    To = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_DriverPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_DriverPolicies_R_Drivers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "R_Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_DriverTrustLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CancelRequestCounter = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_DriverTrustLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_DriverTrustLevels_R_Drivers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "R_Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_EvaluationHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    HappenDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EvaluationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_EvaluationHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_EvaluationHistories_R_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "R_Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_FeePolicyAccountInGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DriverId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_FeePolicyAccountInGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_FeePolicyAccountInGroups_R_FeePolicyGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "R_FeePolicyGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_GuestHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountStatusId = table.Column<int>(type: "int", nullable: false),
                    HappenDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_GuestHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_GuestHistories_R_Guests_AccountId",
                        column: x => x.AccountId,
                        principalTable: "R_Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_GuestLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Lat = table.Column<double>(type: "double", nullable: false),
                    Lng = table.Column<double>(type: "double", nullable: false),
                    Date = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_GuestLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_GuestLocations_R_Guests_AccountId",
                        column: x => x.AccountId,
                        principalTable: "R_Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_GuestPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    To = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_GuestPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_GuestPolicies_R_Guests_AccountId",
                        column: x => x.AccountId,
                        principalTable: "R_Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_PaymentHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    HappenDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_PaymentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_PaymentHistories_R_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "R_Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_RequestHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    HappenDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_RequestHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_RequestHistories_R_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "R_Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "B_ResponseHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    HappenDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResponseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_ResponseHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_B_ResponseHistories_R_Responses_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "R_Responses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "M_RoutineCosts",
                columns: new[] { "Id", "ChangedDate", "Cost", "From", "Name", "Status", "To" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 25, 10, 48, 28, 680, DateTimeKind.Local).AddTicks(2716), 8000.0, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 01/2022", 1, new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2022, 3, 25, 10, 48, 28, 680, DateTimeKind.Local).AddTicks(3416), 7000.0, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 12/2022", 1, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2022, 3, 25, 10, 48, 28, 680, DateTimeKind.Local).AddTicks(3411), 5000.0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 11/2022", 1, new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2022, 3, 25, 10, 48, 28, 680, DateTimeKind.Local).AddTicks(3406), 8000.0, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 10/2022", 1, new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 3, 25, 10, 48, 28, 680, DateTimeKind.Local).AddTicks(3393), 5000.0, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 08/2022", 1, new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 3, 25, 10, 48, 28, 680, DateTimeKind.Local).AddTicks(3388), 8000.0, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 07/2022", 1, new DateTime(2022, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2022, 3, 25, 10, 48, 28, 680, DateTimeKind.Local).AddTicks(3400), 7000.0, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 09/2022", 1, new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 3, 25, 10, 48, 28, 680, DateTimeKind.Local).AddTicks(3378), 5000.0, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 05/2022", 1, new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 3, 25, 10, 48, 28, 680, DateTimeKind.Local).AddTicks(3373), 8000.0, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 04/2022", 1, new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 3, 25, 10, 48, 28, 680, DateTimeKind.Local).AddTicks(3367), 7000.0, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 03/2022", 1, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 3, 25, 10, 48, 28, 680, DateTimeKind.Local).AddTicks(3359), 5000.0, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 02/2022", 1, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 3, 25, 10, 48, 28, 680, DateTimeKind.Local).AddTicks(3383), 7000.0, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 06/2022", 1, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "M_TaxVAT",
                columns: new[] { "Id", "ChangedDate", "Cost", "From", "Name", "Status", "To" },
                values: new object[,]
                {
                    { 9, new DateTime(2022, 3, 25, 10, 48, 28, 681, DateTimeKind.Local).AddTicks(7808), 0.10000000000000001, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 09/2022", 1, new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2022, 3, 25, 10, 48, 28, 681, DateTimeKind.Local).AddTicks(7824), 0.10000000000000001, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 12/2022", 1, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2022, 3, 25, 10, 48, 28, 681, DateTimeKind.Local).AddTicks(7818), 0.050000000000000003, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 11/2022", 1, new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2022, 3, 25, 10, 48, 28, 681, DateTimeKind.Local).AddTicks(7813), 0.02, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 10/2022", 1, new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 3, 25, 10, 48, 28, 681, DateTimeKind.Local).AddTicks(7803), 0.050000000000000003, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 08/2022", 1, new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 3, 25, 10, 48, 28, 681, DateTimeKind.Local).AddTicks(7799), 0.02, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 07/2022", 1, new DateTime(2022, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 3, 25, 10, 48, 28, 681, DateTimeKind.Local).AddTicks(7789), 0.050000000000000003, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 05/2022", 1, new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 3, 25, 10, 48, 28, 681, DateTimeKind.Local).AddTicks(7724), 0.02, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 04/2022", 1, new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 3, 25, 10, 48, 28, 681, DateTimeKind.Local).AddTicks(7719), 0.10000000000000001, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 03/2022", 1, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 3, 25, 10, 48, 28, 681, DateTimeKind.Local).AddTicks(7713), 0.050000000000000003, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 02/2022", 1, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2022, 3, 25, 10, 48, 28, 681, DateTimeKind.Local).AddTicks(7316), 0.02, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 01/2022", 1, new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 3, 25, 10, 48, 28, 681, DateTimeKind.Local).AddTicks(7794), 0.10000000000000001, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 06/2022", 1, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "R_Admins",
                columns: new[] { "Id", "AccountStatus", "Address", "Email", "FullName", "Password", "Phone", "Salt" },
                values: new object[,]
                {
                    { new Guid("f7b6fb14-0b1c-4805-b1f2-ce6a9bb61bf4"), 1, "123 hoang dieu p10q4", "sangnew2020@gmail.com", "Admin 1", "EBWbmOigtUUSMmeTRwSpwVd2ft+svPYs0BBtB6jdm1M=", "0919239081", new byte[] { 194, 114, 250, 149, 234, 175, 65, 44, 25, 84, 22, 15, 36, 121, 76, 58 } },
                    { new Guid("18cb4527-34a1-4b91-aa11-7f162c2da86e"), 1, "456 hoang dieu p10q4", "sangnew2021@gmail.com", "Admin 2", "EBWbmOigtUUSMmeTRwSpwVd2ft+svPYs0BBtB6jdm1M=", "0708825109", new byte[] { 194, 114, 250, 149, 234, 175, 65, 44, 25, 84, 22, 15, 36, 121, 76, 58 } }
                });

            migrationBuilder.InsertData(
                table: "R_Drivers",
                columns: new[] { "Id", "AccountStatus", "Address", "Email", "FullName", "Password", "PersonalId", "PersonalImage", "Phone", "Salt" },
                values: new object[,]
                {
                    { new Guid("bd066d70-66a0-4db3-b20b-11d8dd499217"), 1, "32/1 hoang dieu p10 q4", "sangnew2013@gmail.com", "Driver 2", "EBWbmOigtUUSMmeTRwSpwVd2ft+svPYs0BBtB6jdm1M=", "023363001", "", "0708825109", new byte[] { 194, 114, 250, 149, 234, 175, 65, 44, 25, 84, 22, 15, 36, 121, 76, 58 } },
                    { new Guid("bfc7a2ce-4cad-41e3-a822-9459109908fd"), 1, "123 ton dan p7 q4", "sangnew2015@gmail.com", "Driver 1", "EBWbmOigtUUSMmeTRwSpwVd2ft+svPYs0BBtB6jdm1M=", "023363000", "", "0919239081", new byte[] { 194, 114, 250, 149, 234, 175, 65, 44, 25, 84, 22, 15, 36, 121, 76, 58 } }
                });

            migrationBuilder.InsertData(
                table: "R_FeePolicies",
                columns: new[] { "Id", "Cost", "GroupId", "ProvinceOrCity" },
                values: new object[,]
                {
                    { new Guid("dffccae3-c313-4763-a2ec-53c7ab4bd2f5"), 0.10000000000000001, new Guid("b0f96fba-8302-467b-a985-70f3307d3ae7"), "Ho Chi Minh" },
                    { new Guid("1457c289-85ed-45d2-8a4e-8b4577986e41"), 0.25, new Guid("b0f96fba-8302-467b-a985-70f3307d3ae7"), "Tay Nguyen" },
                    { new Guid("cdd08ea9-8d8d-45d3-a868-2a462033ccb8"), 0.10000000000000001, new Guid("b0f96fba-8302-467b-a985-70f3307d3ae7"), "Binh Duong" },
                    { new Guid("3fc3bfc1-9f58-460b-8f81-1558759a5833"), 0.050000000000000003, new Guid("b0f96fba-8302-467b-a985-70f3307d3ae7"), "Ca Mau" }
                });

            migrationBuilder.InsertData(
                table: "R_FeePolicyGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b0f96fba-8302-467b-a985-70f3307d3ae7"), "Normal" },
                    { new Guid("c143b41e-b01d-45a0-89f9-7d2476234eb0"), "Wounded" },
                    { new Guid("3ca8550d-7e9a-4963-8578-a90cc6e0e1ea"), "Poor" }
                });

            migrationBuilder.InsertData(
                table: "R_Guests",
                columns: new[] { "Id", "AccountStatus", "Email", "FullName", "Password", "Phone", "Salt" },
                values: new object[,]
                {
                    { new Guid("75647c3e-9277-4320-ab9e-858cdf3a9b88"), 1, "sangnew2016@gmail.com", "Guest 1", "EBWbmOigtUUSMmeTRwSpwVd2ft+svPYs0BBtB6jdm1M=", "0919239081", new byte[] { 194, 114, 250, 149, 234, 175, 65, 44, 25, 84, 22, 15, 36, 121, 76, 58 } },
                    { new Guid("942b8df7-9f14-4a6a-a909-ec054ec7483d"), 1, "sangnews2014@gmail.com", "Guest 2", "EBWbmOigtUUSMmeTRwSpwVd2ft+svPYs0BBtB6jdm1M=", "0708825109", new byte[] { 194, 114, 250, 149, 234, 175, 65, 44, 25, 84, 22, 15, 36, 121, 76, 58 } }
                });

            migrationBuilder.InsertData(
                table: "B_AdminHistories",
                columns: new[] { "Id", "AccountId", "AccountStatusId", "Description", "HappenDate" },
                values: new object[,]
                {
                    { 1, new Guid("f7b6fb14-0b1c-4805-b1f2-ce6a9bb61bf4"), 1, "Seed account", new DateTime(2022, 3, 25, 10, 48, 28, 757, DateTimeKind.Local).AddTicks(5820) },
                    { 2, new Guid("18cb4527-34a1-4b91-aa11-7f162c2da86e"), 1, "Seed account", new DateTime(2022, 3, 25, 10, 48, 28, 757, DateTimeKind.Local).AddTicks(6698) }
                });

            migrationBuilder.InsertData(
                table: "B_DriverHistories",
                columns: new[] { "Id", "AccountId", "AccountStatusId", "Description", "HappenDate" },
                values: new object[,]
                {
                    { 1, new Guid("bfc7a2ce-4cad-41e3-a822-9459109908fd"), 1, "Seed account", new DateTime(2022, 3, 25, 10, 48, 28, 756, DateTimeKind.Local).AddTicks(8563) },
                    { 2, new Guid("bd066d70-66a0-4db3-b20b-11d8dd499217"), 1, "Seed account", new DateTime(2022, 3, 25, 10, 48, 28, 756, DateTimeKind.Local).AddTicks(9458) }
                });

            migrationBuilder.InsertData(
                table: "B_DriverLocations",
                columns: new[] { "Id", "AccountId", "Date", "Lat", "Lng" },
                values: new object[,]
                {
                    { 1, new Guid("bfc7a2ce-4cad-41e3-a822-9459109908fd"), 637838021087562635L, 10.74583, 106.68721166666667 },
                    { 2, new Guid("bd066d70-66a0-4db3-b20b-11d8dd499217"), 637838021087565918L, 10.746829999999999, 106.68821166666667 }
                });

            migrationBuilder.InsertData(
                table: "B_FeePolicyAccountInGroups",
                columns: new[] { "Id", "DriverId", "GroupId" },
                values: new object[,]
                {
                    { 1, new Guid("bfc7a2ce-4cad-41e3-a822-9459109908fd"), new Guid("b0f96fba-8302-467b-a985-70f3307d3ae7") },
                    { 2, new Guid("bd066d70-66a0-4db3-b20b-11d8dd499217"), new Guid("b0f96fba-8302-467b-a985-70f3307d3ae7") }
                });

            migrationBuilder.InsertData(
                table: "B_GuestHistories",
                columns: new[] { "Id", "AccountId", "AccountStatusId", "Description", "HappenDate" },
                values: new object[,]
                {
                    { 1, new Guid("75647c3e-9277-4320-ab9e-858cdf3a9b88"), 1, "Seed account", new DateTime(2022, 3, 25, 10, 48, 28, 755, DateTimeKind.Local).AddTicks(4306) },
                    { 2, new Guid("942b8df7-9f14-4a6a-a909-ec054ec7483d"), 1, "Seed account", new DateTime(2022, 3, 25, 10, 48, 28, 755, DateTimeKind.Local).AddTicks(5204) }
                });

            migrationBuilder.InsertData(
                table: "B_GuestLocations",
                columns: new[] { "Id", "AccountId", "Date", "Lat", "Lng" },
                values: new object[,]
                {
                    { 1, new Guid("75647c3e-9277-4320-ab9e-858cdf3a9b88"), 637838021087548083L, 10.74783, 106.68921166666667 },
                    { 2, new Guid("942b8df7-9f14-4a6a-a909-ec054ec7483d"), 637838021087551708L, 10.74593, 106.68101166666666 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_B_AdminHistories_AccountId",
                table: "B_AdminHistories",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_B_AdminPolicies_AccountId",
                table: "B_AdminPolicies",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_B_DriverBikes_AccountId",
                table: "B_DriverBikes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_B_DriverFeePolicies_AccountId",
                table: "B_DriverFeePolicies",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_B_DriverHistories_AccountId",
                table: "B_DriverHistories",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_B_DriverLocations_AccountId",
                table: "B_DriverLocations",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_B_DriverPolicies_AccountId",
                table: "B_DriverPolicies",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_B_DriverTrustLevels_AccountId",
                table: "B_DriverTrustLevels",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_B_EvaluationHistories_EvaluationId",
                table: "B_EvaluationHistories",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_B_FeePolicyAccountInGroups_GroupId",
                table: "B_FeePolicyAccountInGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_B_GuestHistories_AccountId",
                table: "B_GuestHistories",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_B_GuestLocations_AccountId",
                table: "B_GuestLocations",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_B_GuestPolicies_AccountId",
                table: "B_GuestPolicies",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_B_PaymentHistories_PaymentId",
                table: "B_PaymentHistories",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_B_RequestHistories_RequestId",
                table: "B_RequestHistories",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_B_ResponseHistories_ResponseId",
                table: "B_ResponseHistories",
                column: "ResponseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "B_AdminHistories");

            migrationBuilder.DropTable(
                name: "B_AdminPolicies");

            migrationBuilder.DropTable(
                name: "B_DriverBikes");

            migrationBuilder.DropTable(
                name: "B_DriverFeePolicies");

            migrationBuilder.DropTable(
                name: "B_DriverHistories");

            migrationBuilder.DropTable(
                name: "B_DriverLocations");

            migrationBuilder.DropTable(
                name: "B_DriverPolicies");

            migrationBuilder.DropTable(
                name: "B_DriverTrustLevels");

            migrationBuilder.DropTable(
                name: "B_EvaluationHistories");

            migrationBuilder.DropTable(
                name: "B_FeePolicyAccountInGroups");

            migrationBuilder.DropTable(
                name: "B_GuestHistories");

            migrationBuilder.DropTable(
                name: "B_GuestLocations");

            migrationBuilder.DropTable(
                name: "B_GuestPolicies");

            migrationBuilder.DropTable(
                name: "B_PaymentHistories");

            migrationBuilder.DropTable(
                name: "B_RequestHistories");

            migrationBuilder.DropTable(
                name: "B_ResponseHistories");

            migrationBuilder.DropTable(
                name: "M_AccountStatus");

            migrationBuilder.DropTable(
                name: "M_OrderStatus");

            migrationBuilder.DropTable(
                name: "M_PersonalPolicyTypes");

            migrationBuilder.DropTable(
                name: "M_RoutineCosts");

            migrationBuilder.DropTable(
                name: "M_TaxVAT");

            migrationBuilder.DropTable(
                name: "R_FeePolicies");

            migrationBuilder.DropTable(
                name: "R_Locations");

            migrationBuilder.DropTable(
                name: "R_Orders");

            migrationBuilder.DropTable(
                name: "R_Admins");

            migrationBuilder.DropTable(
                name: "R_Drivers");

            migrationBuilder.DropTable(
                name: "R_Evaluations");

            migrationBuilder.DropTable(
                name: "R_FeePolicyGroups");

            migrationBuilder.DropTable(
                name: "R_Guests");

            migrationBuilder.DropTable(
                name: "R_Payments");

            migrationBuilder.DropTable(
                name: "R_Requests");

            migrationBuilder.DropTable(
                name: "R_Responses");
        }
    }
}
