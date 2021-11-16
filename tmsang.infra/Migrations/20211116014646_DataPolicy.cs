using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmsang.infra.Migrations
{
    public partial class DataPolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_R_Drivers_B_FeePolicyAccountInGroups_B_FeePolicyAccountInGro~",
                table: "R_Drivers");

            migrationBuilder.DropIndex(
                name: "IX_R_Drivers_B_FeePolicyAccountInGroupId",
                table: "R_Drivers");

            migrationBuilder.DropColumn(
                name: "B_FeePolicyAccountInGroupId",
                table: "R_Drivers");

            migrationBuilder.AddColumn<Guid>(
                name: "DriverId",
                table: "B_FeePolicyAccountInGroups",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChangedDate",
                value: new DateTime(2021, 11, 16, 8, 46, 46, 185, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChangedDate",
                value: new DateTime(2021, 11, 16, 8, 46, 46, 185, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChangedDate",
                value: new DateTime(2021, 11, 16, 8, 46, 46, 185, DateTimeKind.Local).AddTicks(6632));

            migrationBuilder.InsertData(
                table: "M_TaxVAT",
                columns: new[] { "Id", "ChangedDate", "Cost", "From", "Name", "Status", "To" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 16, 8, 46, 46, 187, DateTimeKind.Local).AddTicks(426), 0.02, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 10/2021", 1, new DateTime(2021, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 11, 16, 8, 46, 46, 187, DateTimeKind.Local).AddTicks(1015), 0.050000000000000003, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 11/2021", 1, new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 11, 16, 8, 46, 46, 187, DateTimeKind.Local).AddTicks(1022), 0.10000000000000001, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tax - 12/2021", 1, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "R_FeePolicies",
                columns: new[] { "Id", "Cost", "GroupId", "ProvinceOrCity" },
                values: new object[,]
                {
                    { new Guid("b154ed11-db90-4f38-aad1-1873a77807dd"), 0.10000000000000001, new Guid("e8b73f2b-e37a-4b06-92ca-7729849a1431"), "Ho Chi Minh" },
                    { new Guid("963052af-e5a2-43fc-87b1-bb4561872920"), 0.25, new Guid("e8b73f2b-e37a-4b06-92ca-7729849a1431"), "Tay Nguyen" },
                    { new Guid("522d9619-567d-4242-a8b2-46fe37cf993b"), 0.10000000000000001, new Guid("e8b73f2b-e37a-4b06-92ca-7729849a1431"), "Binh Duong" },
                    { new Guid("f508176b-7884-490b-8c2e-bf9f11322f9d"), 0.050000000000000003, new Guid("e8b73f2b-e37a-4b06-92ca-7729849a1431"), "Ca Mau" }
                });

            migrationBuilder.InsertData(
                table: "R_FeePolicyGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("e8b73f2b-e37a-4b06-92ca-7729849a1431"), "Normal" },
                    { new Guid("a1d84449-8e29-4e53-86b4-9cee49f0c604"), "Wounded" },
                    { new Guid("7ce984a8-a557-473c-b617-2d08ce3ce278"), "Poor" }
                });

            migrationBuilder.InsertData(
                table: "B_FeePolicyAccountInGroups",
                columns: new[] { "Id", "DriverId", "GroupId" },
                values: new object[] { 1, new Guid("9ad9d9f3-a26f-4454-944f-ef0369243b1c"), new Guid("e8b73f2b-e37a-4b06-92ca-7729849a1431") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "B_FeePolicyAccountInGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("522d9619-567d-4242-a8b2-46fe37cf993b"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("963052af-e5a2-43fc-87b1-bb4561872920"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("b154ed11-db90-4f38-aad1-1873a77807dd"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("f508176b-7884-490b-8c2e-bf9f11322f9d"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("7ce984a8-a557-473c-b617-2d08ce3ce278"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("a1d84449-8e29-4e53-86b4-9cee49f0c604"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("e8b73f2b-e37a-4b06-92ca-7729849a1431"));

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "B_FeePolicyAccountInGroups");

            migrationBuilder.AddColumn<int>(
                name: "B_FeePolicyAccountInGroupId",
                table: "R_Drivers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChangedDate",
                value: new DateTime(2021, 11, 15, 16, 29, 1, 27, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChangedDate",
                value: new DateTime(2021, 11, 15, 16, 29, 1, 27, DateTimeKind.Local).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChangedDate",
                value: new DateTime(2021, 11, 15, 16, 29, 1, 27, DateTimeKind.Local).AddTicks(4940));

            migrationBuilder.CreateIndex(
                name: "IX_R_Drivers_B_FeePolicyAccountInGroupId",
                table: "R_Drivers",
                column: "B_FeePolicyAccountInGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_R_Drivers_B_FeePolicyAccountInGroups_B_FeePolicyAccountInGro~",
                table: "R_Drivers",
                column: "B_FeePolicyAccountInGroupId",
                principalTable: "B_FeePolicyAccountInGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
