using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Request.API.Migrations
{
    public partial class addoneormorethings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContractType",
                table: "Activities",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AbsentName",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TLActivityOperator_AdapterId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApproverName",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DayOff",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReallyNotApproved",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TLActivityOperator_AdapterId",
                table: "Activities",
                column: "TLActivityOperator_AdapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Activities_TLActivityOperator_AdapterId",
                table: "Activities",
                column: "TLActivityOperator_AdapterId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Activities_TLActivityOperator_AdapterId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_TLActivityOperator_AdapterId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ContractType",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AbsentName",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TLActivityOperator_AdapterId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ApproverName",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DayOff",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "IsReallyNotApproved",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Activities");
        }
    }
}
