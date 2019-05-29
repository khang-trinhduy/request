using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Request.API.Migrations
{
    public partial class addnode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentNodeId",
                table: "Rules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextNodeId",
                table: "Rules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NodeId",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentNodeId",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NodeId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<int>(nullable: true),
                    Iscompleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProcessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nodes_Nodes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nodes_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rules_CurrentNodeId",
                table: "Rules",
                column: "CurrentNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_NextNodeId",
                table: "Rules",
                column: "NextNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_NodeId",
                table: "Roles",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CurrentNodeId",
                table: "Requests",
                column: "CurrentNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_NodeId",
                table: "Activities",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_ProcessId",
                table: "Nodes",
                column: "ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Nodes_NodeId",
                table: "Activities",
                column: "NodeId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Nodes_CurrentNodeId",
                table: "Requests",
                column: "CurrentNodeId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Nodes_NodeId",
                table: "Roles",
                column: "NodeId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rules_Nodes_CurrentNodeId",
                table: "Rules",
                column: "CurrentNodeId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rules_Nodes_NextNodeId",
                table: "Rules",
                column: "NextNodeId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Nodes_NodeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Nodes_CurrentNodeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Nodes_NodeId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Rules_Nodes_CurrentNodeId",
                table: "Rules");

            migrationBuilder.DropForeignKey(
                name: "FK_Rules_Nodes_NextNodeId",
                table: "Rules");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropIndex(
                name: "IX_Rules_CurrentNodeId",
                table: "Rules");

            migrationBuilder.DropIndex(
                name: "IX_Rules_NextNodeId",
                table: "Rules");

            migrationBuilder.DropIndex(
                name: "IX_Roles_NodeId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Requests_CurrentNodeId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Activities_NodeId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CurrentNodeId",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "NextNodeId",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "NodeId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CurrentNodeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "NodeId",
                table: "Activities");
        }
    }
}
