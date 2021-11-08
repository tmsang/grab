using Microsoft.EntityFrameworkCore.Migrations;

namespace tmsang.infra.Migrations
{
    public partial class NamingMode_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mode",
                table: "R_Guests",
                newName: "AccountStatus");

            migrationBuilder.RenameColumn(
                name: "Mode",
                table: "R_Drivers",
                newName: "AccountStatus");

            migrationBuilder.RenameColumn(
                name: "Mode",
                table: "R_Admins",
                newName: "AccountStatus");

            migrationBuilder.RenameColumn(
                name: "Mode",
                table: "M_TaxVAT",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Mode",
                table: "M_RoutineCosts",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Mode",
                table: "M_PersonalPolicyTypes",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Mode",
                table: "M_OrderStatus",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Mode",
                table: "M_AccountStatus",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Mode",
                table: "B_GuestPolicies",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Mode",
                table: "B_DriverPolicies",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Mode",
                table: "B_DriverFeePolicies",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Mode",
                table: "B_AdminPolicies",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountStatus",
                table: "R_Guests",
                newName: "Mode");

            migrationBuilder.RenameColumn(
                name: "AccountStatus",
                table: "R_Drivers",
                newName: "Mode");

            migrationBuilder.RenameColumn(
                name: "AccountStatus",
                table: "R_Admins",
                newName: "Mode");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "M_TaxVAT",
                newName: "Mode");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "M_RoutineCosts",
                newName: "Mode");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "M_PersonalPolicyTypes",
                newName: "Mode");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "M_OrderStatus",
                newName: "Mode");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "M_AccountStatus",
                newName: "Mode");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "B_GuestPolicies",
                newName: "Mode");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "B_DriverPolicies",
                newName: "Mode");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "B_DriverFeePolicies",
                newName: "Mode");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "B_AdminPolicies",
                newName: "Mode");
        }
    }
}
