using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmsang.infra.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("2b1610fc-30fa-4664-aa8e-a251baad1c43"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("6f90b7a9-bb83-4240-9ba9-21a4acccd053"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("9ef8909a-f862-40ff-9e08-f76f7b3f8f81"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("ecaeff73-2603-4f03-99c6-2ea30989c530"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("1156d402-59d7-401d-a756-1f3409ab5ccc"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("8e81fdb7-1450-4f04-9dc4-a24860fa8f2e"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("be11e902-4002-48cf-a4f2-c158b50948ea"));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 693, DateTimeKind.Local).AddTicks(525));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 693, DateTimeKind.Local).AddTicks(1837));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 693, DateTimeKind.Local).AddTicks(1846));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 693, DateTimeKind.Local).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 693, DateTimeKind.Local).AddTicks(1859));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 6,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 693, DateTimeKind.Local).AddTicks(1865));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 7,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 693, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 8,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 693, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 9,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 693, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 10,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 693, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 11,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 693, DateTimeKind.Local).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 12,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 693, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 694, DateTimeKind.Local).AddTicks(6833));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 694, DateTimeKind.Local).AddTicks(7456));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 694, DateTimeKind.Local).AddTicks(7464));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 4,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 694, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 5,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 694, DateTimeKind.Local).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 6,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 694, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 7,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 694, DateTimeKind.Local).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 8,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 694, DateTimeKind.Local).AddTicks(7495));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 9,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 694, DateTimeKind.Local).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 10,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 694, DateTimeKind.Local).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 11,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 694, DateTimeKind.Local).AddTicks(7510));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 12,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 15, 30, 694, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.InsertData(
                table: "R_FeePolicies",
                columns: new[] { "Id", "Cost", "GroupId", "ProvinceOrCity" },
                values: new object[,]
                {
                    { new Guid("92eec0bd-0b33-4268-9151-f8f2669f7788"), 0.050000000000000003, new Guid("61764659-f772-41d5-bf29-50276291a565"), "Ca Mau" },
                    { new Guid("53dc95bf-4e10-4d37-bca6-eb0d284b0247"), 0.10000000000000001, new Guid("61764659-f772-41d5-bf29-50276291a565"), "Binh Duong" },
                    { new Guid("8aa90251-2f03-46e2-b1bf-43410d43b543"), 0.25, new Guid("61764659-f772-41d5-bf29-50276291a565"), "Tay Nguyen" },
                    { new Guid("771046fd-51dd-4dd3-856f-08e214ae0af9"), 0.10000000000000001, new Guid("61764659-f772-41d5-bf29-50276291a565"), "Ho Chi Minh" }
                });

            migrationBuilder.InsertData(
                table: "R_FeePolicyGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2c9d830d-e906-48a3-89d0-0816d391eed5"), "Poor" },
                    { new Guid("7d338776-58f2-4c1c-904d-88ff85569e0f"), "Wounded" },
                    { new Guid("61764659-f772-41d5-bf29-50276291a565"), "Normal" }
                });

            migrationBuilder.InsertData(
                table: "R_Guests",
                columns: new[] { "Id", "AccountStatus", "Email", "FullName", "Password", "Phone", "Salt" },
                values: new object[] { new Guid("97f6c942-e828-41db-9967-807c6122c969"), 1, "sangnew2016@gmail.com", "Sang Thach 1", "1234567", "0919239081", new byte[] { 231, 40, 94, 174, 154, 169, 69, 24, 175, 234, 156, 36, 233, 41, 81, 54 } });

            migrationBuilder.UpdateData(
                table: "B_FeePolicyAccountInGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "GroupId",
                value: new Guid("61764659-f772-41d5-bf29-50276291a565"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("53dc95bf-4e10-4d37-bca6-eb0d284b0247"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("771046fd-51dd-4dd3-856f-08e214ae0af9"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("8aa90251-2f03-46e2-b1bf-43410d43b543"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("92eec0bd-0b33-4268-9151-f8f2669f7788"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("2c9d830d-e906-48a3-89d0-0816d391eed5"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("61764659-f772-41d5-bf29-50276291a565"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("7d338776-58f2-4c1c-904d-88ff85569e0f"));

            migrationBuilder.DeleteData(
                table: "R_Guests",
                keyColumn: "Id",
                keyValue: new Guid("97f6c942-e828-41db-9967-807c6122c969"));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 665, DateTimeKind.Local).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 666, DateTimeKind.Local).AddTicks(641));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 666, DateTimeKind.Local).AddTicks(648));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 666, DateTimeKind.Local).AddTicks(654));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 666, DateTimeKind.Local).AddTicks(660));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 6,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 666, DateTimeKind.Local).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 7,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 666, DateTimeKind.Local).AddTicks(676));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 8,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 666, DateTimeKind.Local).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 9,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 666, DateTimeKind.Local).AddTicks(688));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 10,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 666, DateTimeKind.Local).AddTicks(694));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 11,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 666, DateTimeKind.Local).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 12,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 666, DateTimeKind.Local).AddTicks(706));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 667, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 667, DateTimeKind.Local).AddTicks(8989));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 667, DateTimeKind.Local).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 4,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 667, DateTimeKind.Local).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 5,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 667, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 6,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 667, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 7,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 667, DateTimeKind.Local).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 8,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 667, DateTimeKind.Local).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 9,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 667, DateTimeKind.Local).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 10,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 667, DateTimeKind.Local).AddTicks(9036));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 11,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 667, DateTimeKind.Local).AddTicks(9041));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 12,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 21, 17, 12, 49, 667, DateTimeKind.Local).AddTicks(9047));

            migrationBuilder.InsertData(
                table: "R_FeePolicies",
                columns: new[] { "Id", "Cost", "GroupId", "ProvinceOrCity" },
                values: new object[,]
                {
                    { new Guid("6f90b7a9-bb83-4240-9ba9-21a4acccd053"), 0.050000000000000003, new Guid("1156d402-59d7-401d-a756-1f3409ab5ccc"), "Ca Mau" },
                    { new Guid("ecaeff73-2603-4f03-99c6-2ea30989c530"), 0.10000000000000001, new Guid("1156d402-59d7-401d-a756-1f3409ab5ccc"), "Binh Duong" },
                    { new Guid("9ef8909a-f862-40ff-9e08-f76f7b3f8f81"), 0.25, new Guid("1156d402-59d7-401d-a756-1f3409ab5ccc"), "Tay Nguyen" },
                    { new Guid("2b1610fc-30fa-4664-aa8e-a251baad1c43"), 0.10000000000000001, new Guid("1156d402-59d7-401d-a756-1f3409ab5ccc"), "Ho Chi Minh" }
                });

            migrationBuilder.InsertData(
                table: "R_FeePolicyGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8e81fdb7-1450-4f04-9dc4-a24860fa8f2e"), "Wounded" },
                    { new Guid("1156d402-59d7-401d-a756-1f3409ab5ccc"), "Normal" },
                    { new Guid("be11e902-4002-48cf-a4f2-c158b50948ea"), "Poor" }
                });

            migrationBuilder.UpdateData(
                table: "B_FeePolicyAccountInGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "GroupId",
                value: new Guid("1156d402-59d7-401d-a756-1f3409ab5ccc"));
        }
    }
}
