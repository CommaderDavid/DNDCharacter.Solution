using Microsoft.EntityFrameworkCore.Migrations;

namespace DNDCharacter.Migrations
{
    public partial class CharacterDeath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CharacterDeath",
                table: "CampaignCharacter",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterDeath",
                table: "CampaignCharacter");
        }
    }
}
