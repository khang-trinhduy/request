using Microsoft.EntityFrameworkCore.Migrations;

namespace Request.API.Migrations
{
    public partial class removeactivityondata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Data_Activities_ActivityId",
                table: "Data");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "Data",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Data_Activities_ActivityId",
                table: "Data",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Data_Activities_ActivityId",
                table: "Data");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "Data",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Data_Activities_ActivityId",
                table: "Data",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
