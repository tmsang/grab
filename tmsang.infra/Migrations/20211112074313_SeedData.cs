using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmsang.infra.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "M_RoutineCosts",
                columns: new[] { "Id", "ChangedDate", "Cost", "From", "Name", "Status", "To" },
                values: new object[] { 1, new DateTime(2021, 11, 12, 14, 43, 12, 430, DateTimeKind.Local).AddTicks(3262), 8000.0, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 10/2021", 1, new DateTime(2021, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "M_RoutineCosts",
                columns: new[] { "Id", "ChangedDate", "Cost", "From", "Name", "Status", "To" },
                values: new object[] { 2, new DateTime(2021, 11, 12, 14, 43, 12, 430, DateTimeKind.Local).AddTicks(4473), 5000.0, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 11/2021", 1, new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "M_RoutineCosts",
                columns: new[] { "Id", "ChangedDate", "Cost", "From", "Name", "Status", "To" },
                values: new object[] { 3, new DateTime(2021, 11, 12, 14, 43, 12, 430, DateTimeKind.Local).AddTicks(4480), 7000.0, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RoutineCost - 12/2021", 1, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
