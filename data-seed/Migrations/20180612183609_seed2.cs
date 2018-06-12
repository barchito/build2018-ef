using Microsoft.EntityFrameworkCore.Migrations;

namespace dataseed.Migrations
{
    public partial class seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "ThemeId", "Name", "TitleColor" },
                values: new object[] { 5, "Argentina", "LightBlue" });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "ThemeId", "Name", "TitleColor" },
                values: new object[] { 6, "River Plate", "Red" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "ThemeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "ThemeId",
                keyValue: 6);
        }
    }
}
