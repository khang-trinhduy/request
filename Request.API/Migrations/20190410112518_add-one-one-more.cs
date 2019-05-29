using Microsoft.EntityFrameworkCore.Migrations;

namespace Request.API.Migrations
{
    public partial class addoneonemore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractType",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "GenericActivityOperator_AdapterId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_GenericActivityOperator_AdapterId",
                table: "Activities",
                column: "GenericActivityOperator_AdapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Activities_GenericActivityOperator_AdapterId",
                table: "Activities",
                column: "GenericActivityOperator_AdapterId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Activities_GenericActivityOperator_AdapterId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_GenericActivityOperator_AdapterId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "GenericActivityOperator_AdapterId",
                table: "Activities");

            migrationBuilder.AddColumn<string>(
                name: "ContractType",
                table: "Activities",
                nullable: false,
                defaultValue: "");
        }
    }
}
