using Microsoft.EntityFrameworkCore.Migrations;

namespace Request.API.Migrations
{
    public partial class addnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NodeId",
                table: "Actions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actions_NodeId",
                table: "Actions",
                column: "NodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Nodes_NodeId",
                table: "Actions",
                column: "NodeId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Nodes_NodeId",
                table: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Actions_NodeId",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "NodeId",
                table: "Actions");
        }
    }
}
