using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Request.API.Migrations
{
    public partial class addtrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TriggerId",
                table: "Rules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CampaignName",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRunning",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CampaignActivityOperatorId",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Data",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CampaignName",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRunning",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmailActivityOperator_AdapterId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Consequence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Method = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consequence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trigger",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataId = table.Column<int>(nullable: true),
                    ConsequenceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trigger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trigger_Consequence_ConsequenceId",
                        column: x => x.ConsequenceId,
                        principalTable: "Consequence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trigger_Data_DataId",
                        column: x => x.DataId,
                        principalTable: "Data",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TriggerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Trigger_TriggerId",
                        column: x => x.TriggerId,
                        principalTable: "Trigger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Param = table.Column<string>(nullable: true),
                    Operator = table.Column<string>(nullable: true),
                    Threshold = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condition_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rules_TriggerId",
                table: "Rules",
                column: "TriggerId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_CampaignActivityOperatorId",
                table: "Data",
                column: "CampaignActivityOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_CampaignId",
                table: "Data",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_EmailActivityOperator_AdapterId",
                table: "Activities",
                column: "EmailActivityOperator_AdapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Condition_EventId",
                table: "Condition",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_TriggerId",
                table: "Event",
                column: "TriggerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trigger_ConsequenceId",
                table: "Trigger",
                column: "ConsequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Trigger_DataId",
                table: "Trigger",
                column: "DataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Activities_EmailActivityOperator_AdapterId",
                table: "Activities",
                column: "EmailActivityOperator_AdapterId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Data_Activities_CampaignActivityOperatorId",
                table: "Data",
                column: "CampaignActivityOperatorId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Data_Data_CampaignId",
                table: "Data",
                column: "CampaignId",
                principalTable: "Data",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rules_Trigger_TriggerId",
                table: "Rules",
                column: "TriggerId",
                principalTable: "Trigger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Activities_EmailActivityOperator_AdapterId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Data_Activities_CampaignActivityOperatorId",
                table: "Data");

            migrationBuilder.DropForeignKey(
                name: "FK_Data_Data_CampaignId",
                table: "Data");

            migrationBuilder.DropForeignKey(
                name: "FK_Rules_Trigger_TriggerId",
                table: "Rules");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Trigger");

            migrationBuilder.DropTable(
                name: "Consequence");

            migrationBuilder.DropIndex(
                name: "IX_Rules_TriggerId",
                table: "Rules");

            migrationBuilder.DropIndex(
                name: "IX_Data_CampaignActivityOperatorId",
                table: "Data");

            migrationBuilder.DropIndex(
                name: "IX_Data_CampaignId",
                table: "Data");

            migrationBuilder.DropIndex(
                name: "IX_Activities_EmailActivityOperator_AdapterId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TriggerId",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "CampaignName",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "IsRunning",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "CampaignActivityOperatorId",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "CampaignName",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "IsRunning",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "EmailActivityOperator_AdapterId",
                table: "Activities");
        }
    }
}
