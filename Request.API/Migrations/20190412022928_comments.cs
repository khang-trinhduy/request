using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Request.API.Migrations
{
    public partial class comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Data",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Emoji",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email_Contents",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email_Subject",
                table: "Data",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "Emoji",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "Email_Contents",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "Email_Subject",
                table: "Data");
        }
    }
}
