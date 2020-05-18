using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperHero.Data.Migrations
{
    public partial class SuperHeroInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    SuperHeroName = table.Column<string>(nullable: false),
                    AliasFirstName = table.Column<string>(nullable: true),
                    AliasLastName = table.Column<string>(nullable: true),
                    HomePlanet = table.Column<string>(nullable: true),
                    SuperPower = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.SuperHeroName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
