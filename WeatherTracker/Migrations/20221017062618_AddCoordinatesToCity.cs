using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherTracker.Migrations
{
    public partial class AddCoordinatesToCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "UserCities",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "UserCities",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "UserCities");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "UserCities");
        }
    }
}
