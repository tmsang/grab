using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmsang.infra.Migrations
{
    public partial class Seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2022, 2, 22, 8, 42, 26, 916, DateTimeKind.Local).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 916, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 916, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 916, DateTimeKind.Local).AddTicks(7870));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 916, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 6,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 916, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 7,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 916, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 8,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 916, DateTimeKind.Local).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 9,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 916, DateTimeKind.Local).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 10,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 916, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 11,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 916, DateTimeKind.Local).AddTicks(7911));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 12,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 916, DateTimeKind.Local).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 918, DateTimeKind.Local).AddTicks(4057));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 918, DateTimeKind.Local).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 918, DateTimeKind.Local).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 4,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 918, DateTimeKind.Local).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 5,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 918, DateTimeKind.Local).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 6,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 918, DateTimeKind.Local).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 7,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 918, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 8,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 918, DateTimeKind.Local).AddTicks(4730));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 9,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 918, DateTimeKind.Local).AddTicks(4737));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 10,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 918, DateTimeKind.Local).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 11,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 918, DateTimeKind.Local).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "M_TaxVAT",
                keyColumn: "Id",
                keyValue: 12,
                column: "ChangedDate",
                value: new DateTime(2022, 2, 22, 8, 42, 26, 918, DateTimeKind.Local).AddTicks(4753));

            migrationBuilder.InsertData(
                table: "R_Admins",
                columns: new[] { "Id", "AccountStatus", "Address", "Email", "FullName", "Password", "Phone", "Salt" },
                values: new object[] { new Guid("5cdd78c2-927e-451c-a061-61973a42afc4"), 1, "123 hoang dieu p10q4", "sangnew2015@gmail.com", "Admin 1", "NI6OnARi1R83Y6kKkKwq/GgtwWRQDDUpESW8gQDxxXU=", "0919239081", new byte[] { 199, 96, 71, 205, 34, 46, 169, 145, 4, 164, 201, 243, 39, 183, 46, 111 } });

            migrationBuilder.InsertData(
                table: "R_Drivers",
                columns: new[] { "Id", "AccountStatus", "Address", "Email", "FullName", "Password", "PersonalId", "PersonalImage", "Phone", "Salt" },
                values: new object[] { new Guid("19550a31-fc22-4d2c-9351-c77fb0ce356c"), 1, "123 ton dan p7 q4", "sangnew2015@gmail.com", "Driver 1", "NI6OnARi1R83Y6kKkKwq/GgtwWRQDDUpESW8gQDxxXU=", "023363000", "", "0919239081", new byte[] { 199, 96, 71, 205, 34, 46, 169, 145, 4, 164, 201, 243, 39, 183, 46, 111 } });

            migrationBuilder.InsertData(
                table: "R_FeePolicies",
                columns: new[] { "Id", "Cost", "GroupId", "ProvinceOrCity" },
                values: new object[,]
                {
                    { new Guid("670e390e-88a6-46bf-bb26-bb9306f6c2df"), 0.050000000000000003, new Guid("d35f2936-264c-4696-b14f-5def80a885f4"), "Ca Mau" },
                    { new Guid("66b35b2b-3039-453c-8233-9506405b873e"), 0.10000000000000001, new Guid("d35f2936-264c-4696-b14f-5def80a885f4"), "Binh Duong" },
                    { new Guid("8f9baad2-d9e8-4d86-a7af-2b3f2811d7a2"), 0.25, new Guid("d35f2936-264c-4696-b14f-5def80a885f4"), "Tay Nguyen" },
                    { new Guid("a097719c-d582-420c-bec9-394879bbdfdc"), 0.10000000000000001, new Guid("d35f2936-264c-4696-b14f-5def80a885f4"), "Ho Chi Minh" }
                });

            migrationBuilder.InsertData(
                table: "R_FeePolicyGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8aa184ca-d386-4979-8d63-1bc87d6d88a9"), "Poor" },
                    { new Guid("624fb462-f666-4c4e-a987-73b6ae9076b3"), "Wounded" },
                    { new Guid("d35f2936-264c-4696-b14f-5def80a885f4"), "Normal" }
                });

            migrationBuilder.InsertData(
                table: "R_Guests",
                columns: new[] { "Id", "AccountStatus", "Email", "FullName", "Password", "Phone", "Salt" },
                values: new object[] { new Guid("aa7f012c-0bc0-40ec-a531-59a42255e684"), 1, "sangnew2016@gmail.com", "Guest 1", "NI6OnARi1R83Y6kKkKwq/GgtwWRQDDUpESW8gQDxxXU=", "0919239081", new byte[] { 199, 96, 71, 205, 34, 46, 169, 145, 4, 164, 201, 243, 39, 183, 46, 111 } });

            migrationBuilder.UpdateData(
                table: "B_FeePolicyAccountInGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "GroupId",
                value: new Guid("d35f2936-264c-4696-b14f-5def80a885f4"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "R_Admins",
                keyColumn: "Id",
                keyValue: new Guid("5cdd78c2-927e-451c-a061-61973a42afc4"));

            migrationBuilder.DeleteData(
                table: "R_Drivers",
                keyColumn: "Id",
                keyValue: new Guid("19550a31-fc22-4d2c-9351-c77fb0ce356c"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("66b35b2b-3039-453c-8233-9506405b873e"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("670e390e-88a6-46bf-bb26-bb9306f6c2df"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("8f9baad2-d9e8-4d86-a7af-2b3f2811d7a2"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicies",
                keyColumn: "Id",
                keyValue: new Guid("a097719c-d582-420c-bec9-394879bbdfdc"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("624fb462-f666-4c4e-a987-73b6ae9076b3"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("8aa184ca-d386-4979-8d63-1bc87d6d88a9"));

            migrationBuilder.DeleteData(
                table: "R_FeePolicyGroups",
                keyColumn: "Id",
                keyValue: new Guid("d35f2936-264c-4696-b14f-5def80a885f4"));

            migrationBuilder.DeleteData(
                table: "R_Guests",
                keyColumn: "Id",
                keyValue: new Guid("aa7f012c-0bc0-40ec-a531-59a42255e684"));

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
    }
}
