using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Request.API.Migrations
{
    public partial class denneb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "States",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Roles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Nodes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Nodes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Nodes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Nodes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "Nodes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Activities",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Actions",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "Nodes");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "States",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Roles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Nodes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Activities",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Actions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
