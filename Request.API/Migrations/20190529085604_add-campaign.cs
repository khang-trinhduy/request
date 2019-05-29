using Microsoft.EntityFrameworkCore.Migrations;

namespace Request.API.Migrations
{
    public partial class addcampaign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
