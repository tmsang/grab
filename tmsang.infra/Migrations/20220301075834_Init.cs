using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmsang.infra.Migrations
{
    public partial class Init : Migration
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
                    table.ForeignKey(
                        name: "FK_R_Responses_R_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "R_Drivers",
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
                name: "R_Evaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_R_Evaluations_R_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "R_Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_R_Payments_R_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "R_Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_R_Requests_R_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "R_Guests",
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

            migrationBuilder.InsertData(
                table: "M_RoutineCosts",
                columns: new[] { "Id", "ChangedDate", "Cost", "From", "Name", "Status", "To" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 1, 14, 58, 33, 487, DateTimeKind.Local).AddTicks(4842), 8000.0, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 01/2022", 1, new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2022, 3, 1, 14, 58, 33, 487, DateTimeKind.Local).AddTicks(6365), 7000.0, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 12/2022", 1, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2022, 3, 1, 14, 58, 33, 487, DateTimeKind.Local).AddTicks(6360), 5000.0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 11/2022", 1, new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2022, 3, 1, 14, 58, 33, 487, DateTimeKind.Local).AddTicks(6354), 8000.0, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 10/2022", 1, new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 3, 1, 14, 58, 33, 487, DateTimeKind.Local).AddTicks(6342), 5000.0, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 08/2022", 1, new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 3, 1, 14, 58, 33, 487, DateTimeKind.Local).AddTicks(6335), 8000.0, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 07/2022", 1, new DateTime(2022, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2022, 3, 1, 14, 58, 33, 487, DateTimeKind.Local).AddTicks(6348), 7000.0, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 09/2022", 1, new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 3, 1, 14, 58, 33, 487, DateTimeKind.Local).AddTicks(6320), 5000.0, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 05/2022", 1, new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 3, 1, 14, 58, 33, 487, DateTimeKind.Local).AddTicks(6312), 8000.0, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 04/2022", 1, new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 3, 1, 14, 58, 33, 487, DateTimeKind.Local).AddTicks(6299), 7000.0, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 03/2022", 1, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 3, 1, 14, 58, 33, 487, DateTimeKind.Local).AddTicks(6289), 5000.0, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 02/2022", 1, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 3, 1, 14, 58, 33, 487, DateTimeKind.Local).AddTicks(6328), 7000.0, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 06/2022", 1, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "M_TaxVAT",
                columns: new[] { "Id", "ChangedDate", "Cost", "From", "Name", "Status", "To" },
                values: new object[,]
                {
                    { 8, new DateTime(2022, 3, 1, 14, 58, 33, 489, DateTimeKind.Local).AddTicks(8887), 0.050000000000000003, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 08/2022", 1, new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2022, 3, 1, 14, 58, 33, 489, DateTimeKind.Local).AddTicks(8912), 0.10000000000000001, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 12/2022", 1, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2022, 3, 1, 14, 58, 33, 489, DateTimeKind.Local).AddTicks(8907), 0.050000000000000003, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 11/2022", 1, new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2022, 3, 1, 14, 58, 33, 489, DateTimeKind.Local).AddTicks(8902), 0.02, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 10/2022", 1, new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2022, 3, 1, 14, 58, 33, 489, DateTimeKind.Local).AddTicks(8897), 0.10000000000000001, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 09/2022", 1, new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 3, 1, 14, 58, 33, 489, DateTimeKind.Local).AddTicks(8727), 0.02, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 07/2022", 1, new DateTime(2022, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 3, 1, 14, 58, 33, 489, DateTimeKind.Local).AddTicks(8722), 0.10000000000000001, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 06/2022", 1, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 3, 1, 14, 58, 33, 489, DateTimeKind.Local).AddTicks(8712), 0.050000000000000003, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 05/2022", 1, new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 3, 1, 14, 58, 33, 489, DateTimeKind.Local).AddTicks(8704), 0.02, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 04/2022", 1, new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 3, 1, 14, 58, 33, 489, DateTimeKind.Local).AddTicks(8698), 0.10000000000000001, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 03/2022", 1, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 3, 1, 14, 58, 33, 489, DateTimeKind.Local).AddTicks(8690), 0.050000000000000003, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 02/2022", 1, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2022, 3, 1, 14, 58, 33, 489, DateTimeKind.Local).AddTicks(8027), 0.02, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 01/2022", 1, new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "R_Admins",
                columns: new[] { "Id", "AccountStatus", "Address", "Email", "FullName", "Password", "Phone", "Salt" },
                values: new object[] { new Guid("a299daba-f48c-4d60-9e99-c5af2d975f14"), 1, "123 hoang dieu p10q4", "sangnew2015@gmail.com", "Admin 1", "W9T5QQza+idm6ZoqjrQ2QhV0uHAknfrjNKOoX54jX5w=", "0919239081", new byte[] { 128, 141, 199, 101, 55, 159, 41, 116, 94, 233, 93, 238, 13, 93, 31, 142 } });

            migrationBuilder.InsertData(
                table: "R_Drivers",
                columns: new[] { "Id", "AccountStatus", "Address", "Email", "FullName", "Password", "PersonalId", "PersonalImage", "Phone", "Salt" },
                values: new object[,]
                {
                    { new Guid("c4388621-fb2a-4637-98d4-7316ee7a1f7a"), 1, "123 ton dan p7 q4", "sangnew2015@gmail.com", "Driver 1", "W9T5QQza+idm6ZoqjrQ2QhV0uHAknfrjNKOoX54jX5w=", "023363000", "", "0919239081", new byte[] { 128, 141, 199, 101, 55, 159, 41, 116, 94, 233, 93, 238, 13, 93, 31, 142 } },
                    { new Guid("31181c09-b22f-449a-a940-9c1af9e600db"), 1, "32/1 hoang dieu p10 q4", "sangnew2013@gmail.com", "Driver 2", "W9T5QQza+idm6ZoqjrQ2QhV0uHAknfrjNKOoX54jX5w=", "023363001", "", "0708825109", new byte[] { 128, 141, 199, 101, 55, 159, 41, 116, 94, 233, 93, 238, 13, 93, 31, 142 } }
                });

            migrationBuilder.InsertData(
                table: "R_FeePolicies",
                columns: new[] { "Id", "Cost", "GroupId", "ProvinceOrCity" },
                values: new object[,]
                {
                    { new Guid("fdf8b454-c695-4681-8154-b9d305d9cd66"), 0.050000000000000003, new Guid("7cb7ae48-0a09-47da-b3ce-1f03ce96c9cc"), "Ca Mau" },
                    { new Guid("b3df074a-6198-44cc-80fb-9af1fdbead99"), 0.10000000000000001, new Guid("7cb7ae48-0a09-47da-b3ce-1f03ce96c9cc"), "Binh Duong" },
                    { new Guid("7f975bf5-fbb1-4a4e-abd7-30ec2620b990"), 0.10000000000000001, new Guid("7cb7ae48-0a09-47da-b3ce-1f03ce96c9cc"), "Ho Chi Minh" },
                    { new Guid("5c5201ee-0ebb-4fd8-a8b6-cf4592317bee"), 0.25, new Guid("7cb7ae48-0a09-47da-b3ce-1f03ce96c9cc"), "Tay Nguyen" }
                });

            migrationBuilder.InsertData(
                table: "R_FeePolicyGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7cb7ae48-0a09-47da-b3ce-1f03ce96c9cc"), "Normal" },
                    { new Guid("e2d5d855-ed98-4753-a6a3-1cfdcc1d87c8"), "Wounded" },
                    { new Guid("3533cb23-e359-4a14-bdec-5f8858fe60b7"), "Poor" }
                });

            migrationBuilder.InsertData(
                table: "R_Guests",
                columns: new[] { "Id", "AccountStatus", "Email", "FullName", "Password", "Phone", "Salt" },
                values: new object[,]
                {
                    { new Guid("45e4760e-5733-4666-97d7-f7613f9561eb"), 1, "sangnew2016@gmail.com", "Guest 1", "W9T5QQza+idm6ZoqjrQ2QhV0uHAknfrjNKOoX54jX5w=", "0919239081", new byte[] { 128, 141, 199, 101, 55, 159, 41, 116, 94, 233, 93, 238, 13, 93, 31, 142 } },
                    { new Guid("328ddfca-f8ff-4a02-851b-ab98d6d86b54"), 1, "sangnews2014@gmail.com", "Guest 2", "W9T5QQza+idm6ZoqjrQ2QhV0uHAknfrjNKOoX54jX5w=", "0708825109", new byte[] { 128, 141, 199, 101, 55, 159, 41, 116, 94, 233, 93, 238, 13, 93, 31, 142 } }
                });

            migrationBuilder.InsertData(
                table: "B_DriverLocations",
                columns: new[] { "Id", "AccountId", "Date", "Lat", "Lng" },
                values: new object[,]
                {
                    { 1, new Guid("c4388621-fb2a-4637-98d4-7316ee7a1f7a"), 637817435135115460L, 10.74583, 106.68721166666667 },
                    { 2, new Guid("31181c09-b22f-449a-a940-9c1af9e600db"), 637817435135120714L, 10.746829999999999, 106.68821166666667 }
                });

            migrationBuilder.InsertData(
                table: "B_FeePolicyAccountInGroups",
                columns: new[] { "Id", "DriverId", "GroupId" },
                values: new object[,]
                {
                    { 1, new Guid("c4388621-fb2a-4637-98d4-7316ee7a1f7a"), new Guid("7cb7ae48-0a09-47da-b3ce-1f03ce96c9cc") },
                    { 2, new Guid("31181c09-b22f-449a-a940-9c1af9e600db"), new Guid("7cb7ae48-0a09-47da-b3ce-1f03ce96c9cc") }
                });

            migrationBuilder.InsertData(
                table: "B_GuestLocations",
                columns: new[] { "Id", "AccountId", "Date", "Lat", "Lng" },
                values: new object[,]
                {
                    { 1, new Guid("45e4760e-5733-4666-97d7-f7613f9561eb"), 637817435135098118L, 10.74783, 106.68921166666667 },
                    { 2, new Guid("328ddfca-f8ff-4a02-851b-ab98d6d86b54"), 637817435135103989L, 10.74593, 106.68101166666666 }
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

            migrationBuilder.CreateIndex(
                name: "IX_R_Evaluations_GuestId",
                table: "R_Evaluations",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_R_Payments_GuestId",
                table: "R_Payments",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_R_Requests_GuestId",
                table: "R_Requests",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_R_Responses_DriverId",
                table: "R_Responses",
                column: "DriverId");
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
                name: "R_Evaluations");

            migrationBuilder.DropTable(
                name: "R_FeePolicyGroups");

            migrationBuilder.DropTable(
                name: "R_Payments");

            migrationBuilder.DropTable(
                name: "R_Requests");

            migrationBuilder.DropTable(
                name: "R_Responses");

            migrationBuilder.DropTable(
                name: "R_Guests");

            migrationBuilder.DropTable(
                name: "R_Drivers");
        }
    }
}
