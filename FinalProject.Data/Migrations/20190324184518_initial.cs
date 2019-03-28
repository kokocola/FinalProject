using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "movie");

            migrationBuilder.CreateTable(
                name: "titles",
                schema: "movie",
                columns: table => new
                {
                    titleId = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    titleType = table.Column<string>(maxLength: 20, nullable: true),
                    primaryTitle = table.Column<string>(maxLength: 1000, nullable: true),
                    originalTitle = table.Column<string>(maxLength: 1000, nullable: true),
                    isAdult = table.Column<bool>(nullable: true),
                    startYear = table.Column<short>(nullable: true),
                    endYear = table.Column<short>(nullable: true),
                    runtimeMinutes = table.Column<int>(nullable: true),
                    genres = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titles", x => x.titleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "titles",
                schema: "movie");
        }
    }
}
