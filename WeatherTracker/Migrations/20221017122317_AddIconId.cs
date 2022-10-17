using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherTracker.Migrations
{
    public partial class AddIconId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconId",
                table: "WeatherDataSets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconId",
                table: "WeatherDataSets");
        }
    }
}
