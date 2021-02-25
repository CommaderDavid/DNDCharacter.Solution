using Microsoft.EntityFrameworkCore.Migrations;

namespace DNDCharacter.Migrations
{
    public partial class Stats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatId",
                table: "CampaignCharacter",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatId",
                table: "CampaignCharacter");
        }
    }
}
