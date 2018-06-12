using Microsoft.EntityFrameworkCore.Migrations;

namespace dataseed.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "ThemeId", "Name", "TitleColor" },
                values: new object[] { 1, "MSDN", "Red" });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "ThemeId", "Name", "TitleColor" },
                values: new object[] { 2, "TechNet", "DarkCyan" });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "ThemeId", "Name", "TitleColor" },
                values: new object[] { 3, "Personal", "LightBlue" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "ThemeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "ThemeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "ThemeId",
                keyValue: 3);
        }
    }
}
