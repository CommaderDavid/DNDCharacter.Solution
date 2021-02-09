using Microsoft.EntityFrameworkCore.Migrations;

namespace DNDCharacter.Migrations
{
    public partial class RuleDeath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CharacterDeath",
                table: "Campaigns",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Rulebook",
                table: "Campaigns",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterDeath",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Rulebook",
                table: "Campaigns");
        }
    }
}
