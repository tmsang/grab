using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmsang.infra.Migrations
{
    public partial class Seed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2022, 2, 22, 8, 23, 5, 169, DateTimeKind.Local).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 169, DateTimeKind.Local).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 169, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 169, DateTimeKind.Local).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 169, DateTimeKind.Local).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 6,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 169, DateTimeKind.Local).AddTicks(5128));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 7,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 169, DateTimeKind.Local).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 8,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 169, DateTimeKind.Local).AddTicks(5139));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 9,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 169, DateTimeKind.Local).AddTicks(5144));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 10,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 169, DateTimeKind.Local).AddTicks(5149));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 11,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 169, DateTimeKind.Local).AddTicks(5254));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 12,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 169, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 170, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 171, DateTimeKind.Local).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 171, DateTimeKind.Local).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 4,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 171, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 5,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 171, DateTimeKind.Local).AddTicks(135));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 6,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 171, DateTimeKind.Local).AddTicks(140));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 7,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 171, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 8,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 171, DateTimeKind.Local).AddTicks(150));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 9,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 171, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 10,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 171, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 11,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 171, DateTimeKind.Local).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 12,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 23, 5, 171, DateTimeKind.Local).AddTicks(169));

            migrationBuilder.InsertData(
                table: "R_Admins",
                columns: new[] { "Id", "AccountStatus", "Address", "Email", "FullName", "Password", "Phone", "Salt" },
                values: new object[] { new Guid("4717de26-5f60-4a20-9a3d-1c82552b4705"), 1, "123 hoang dieu p10q4", "sangnew2015@gmail.com", "Admin 1", "1234567", "0919239081", new byte[] { 7, 41, 156, 177, 113, 114, 163, 132, 10, 5, 66, 180, 165, 129, 2, 209 } });

            migrationBuilder.InsertData(
                table: "R_Drivers",
                columns: new[] { "Id", "AccountStatus", "Address", "Email", "FullName", "Password", "PersonalId", "PersonalImage", "Phone", "Salt" },
                values: new object[] { new Guid("007d3bfb-8e69-47cf-9a0b-ba4d67cb0ba4"), 1, "123 ton dan p7 q4", "sangnew2015@gmail.com", "Driver 1", "1234567", "023363000", "", "0919239081", new byte[] { 7, 41, 156, 177, 113, 114, 163, 132, 10, 5, 66, 180, 165, 129, 2, 209 } });

            migrationBuilder.InsertData(
                table: "R_FeePolicies",
                columns: new[] { "Id", "Cost", "GroupId", "ProvinceOrCity" },
                values: new object[,]
                {
                    { new Guid("c37770b7-d214-4a2c-897f-87b740ad8e7f"), 0.050000000000000003, new Guid("acedb852-f4fd-4808-930b-a190139b0881"), "Ca Mau" },
                    { new Guid("de71c6cf-747f-4cf0-88dc-e035ef4f1043"), 0.10000000000000001, new Guid("acedb852-f4fd-4808-930b-a190139b0881"), "Binh Duong" },
                    { new Guid("f7d0a263-2c2e-442d-9555-ebc1d6b798f3"), 0.25, new Guid("acedb852-f4fd-4808-930b-a190139b0881"), "Tay Nguyen" },
                    { new Guid("a365ccdf-793c-4f4b-9e64-313557d2a388"), 0.10000000000000001, new Guid("acedb852-f4fd-4808-930b-a190139b0881"), "Ho Chi Minh" }
                });

            migrationBuilder.InsertData(
                table: "R_FeePolicyGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5b1b8e3e-daf9-420f-807f-cd7c2f27682c"), "Poor" },
                    { new Guid("f45fa678-b181-492c-9cfd-4a0c83c5a5fd"), "Wounded" },
                    { new Guid("acedb852-f4fd-4808-930b-a190139b0881"), "Normal" }
                });

            migrationBuilder.InsertData(
                table: "R_Guests",
                columns: new[] { "Id", "AccountStatus", "Email", "FullName", "Password", "Phone", "Salt" },
                values: new object[] { new Guid("7ea8ef63-74d6-4834-a4ed-97b1431ae95c"), 1, "sangnew2016@gmail.com", "Guest 1", "1234567", "0919239081", new byte[] { 7, 41, 156, 177, 113, 114, 163, 132, 10, 5, 66, 180, 165, 129, 2, 209 } });

            migrationBuilder.UpdateData(
                table: "B_FeePolicyAccountInGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "GroupId",
                value: new Guid("acedb852-f4fd-4808-930b-a190139b0881"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "R_Admins",
                keyColumn: "Id",
                keyValue: new Guid("4717de26-5f60-4a20-9a3d-1c82552b4705"));

            migrationBuilder.DeleteData(
                table: "R_Drivers",
                keyColumn: "Id",
                keyValue: new Guid("007d3bfb-8e69-47cf-9a0b-ba4d67cb0ba4"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("a365ccdf-793c-4f4b-9e64-313557d2a388"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("c37770b7-d214-4a2c-897f-87b740ad8e7f"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("de71c6cf-747f-4cf0-88dc-e035ef4f1043"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("f7d0a263-2c2e-442d-9555-ebc1d6b798f3"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("5b1b8e3e-daf9-420f-807f-cd7c2f27682c"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("acedb852-f4fd-4808-930b-a190139b0881"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("f45fa678-b181-492c-9cfd-4a0c83c5a5fd"));

            migrationBuilder.DeleteData(
                table: "R_Guests",
                keyColumn: "Id",
                keyValue: new Guid("7ea8ef63-74d6-4834-a4ed-97b1431ae95c"));

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
    }
}
