using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Request.API.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email_Subject",
                table: "Data",
                newName: "Reason");

            migrationBuilder.RenameColumn(
                name: "Email_Contents",
                table: "Data",
                newName: "ApproverName");

            migrationBuilder.AddColumn<string>(
                name: "Messages",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AbsentName",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DayOff",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReallyNotApproved",
                table: "Data",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Messages",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "AbsentName",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "DayOff",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "IsReallyNotApproved",
                table: "Data");

            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "Data",
                newName: "Email_Subject");

            migrationBuilder.RenameColumn(
                name: "ApproverName",
                table: "Data",
                newName: "Email_Contents");
        }
    }
}
