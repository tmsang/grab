using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmsang.infra.Migrations
{
    public partial class ChangeFeePolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_R_FeePolicies_M_PersonalPolicyTypes_PersonalPolicyTypeId",
                table: "R_FeePolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_R_FeePolicies_R_FeePolicyGroups_GroupId",
                table: "R_FeePolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_R_FeePolicies_R_Locations_LocationId",
                table: "R_FeePolicies");

            migrationBuilder.DropIndex(
                name: "IX_R_FeePolicies_GroupId",
                table: "R_FeePolicies");

            migrationBuilder.DropIndex(
                name: "IX_R_FeePolicies_LocationId",
                table: "R_FeePolicies");

            migrationBuilder.DropIndex(
                name: "IX_R_FeePolicies_PersonalPolicyTypeId",
                table: "R_FeePolicies");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "R_FeePolicies");

            migrationBuilder.DropColumn(
                name: "PersonalPolicyTypeId",
                table: "R_FeePolicies");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "R_Responses",
                newName: "OrderId");

            migrationBuilder.AddColumn<string>(
                name: "ProvinceOrCity",
                table: "R_Locations",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupId",
                table: "R_FeePolicies",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "R_FeePolicies",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ProvinceOrCity",
                table: "R_FeePolicies",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProvinceOrCity",
                table: "R_Locations");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "R_FeePolicies");

            migrationBuilder.DropColumn(
                name: "ProvinceOrCity",
                table: "R_FeePolicies");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "R_Responses",
                newName: "RequestId");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupId",
                table: "R_FeePolicies",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "R_FeePolicies",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "PersonalPolicyTypeId",
                table: "R_FeePolicies",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChangedDate",
                value: new DateTime(2021, 11, 12, 14, 43, 12, 430, DateTimeKind.Local).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChangedDate",
                value: new DateTime(2021, 11, 12, 14, 43, 12, 430, DateTimeKind.Local).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "M_RoutineCosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChangedDate",
                value: new DateTime(2021, 11, 12, 14, 43, 12, 430, DateTimeKind.Local).AddTicks(4480));

            migrationBuilder.CreateIndex(
                name: "IX_R_FeePolicies_GroupId",
                table: "R_FeePolicies",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_R_FeePolicies_LocationId",
                table: "R_FeePolicies",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_R_FeePolicies_PersonalPolicyTypeId",
                table: "R_FeePolicies",
                column: "PersonalPolicyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_R_FeePolicies_M_PersonalPolicyTypes_PersonalPolicyTypeId",
                table: "R_FeePolicies",
                column: "PersonalPolicyTypeId",
                principalTable: "M_PersonalPolicyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_R_FeePolicies_R_FeePolicyGroups_GroupId",
                table: "R_FeePolicies",
                column: "GroupId",
                principalTable: "R_FeePolicyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_R_FeePolicies_R_Locations_LocationId",
                table: "R_FeePolicies",
                column: "LocationId",
                principalTable: "R_Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
