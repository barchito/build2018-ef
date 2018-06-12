using Microsoft.EntityFrameworkCore.Migrations;

namespace valueconversion.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    ThemeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TitleColor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.ThemeId);
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "ThemeId", "Name", "TitleColor" },
                values: new object[,]
                {
                    { 1, "MSDN", "AliceBlue" },
                    { 2, "TechNet", "DarkCyan" },
                    { 3, "EF", "Purple" },
                    { 4, "Personal", "LightBlue" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Themes");
        }
    }
}
