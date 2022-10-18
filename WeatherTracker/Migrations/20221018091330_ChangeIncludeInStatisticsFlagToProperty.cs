using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherTracker.Migrations
{
    public partial class ChangeIncludeInStatisticsFlagToProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IncludeInStatistics",
                table: "WeatherDataSets",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncludeInStatistics",
                table: "WeatherDataSets");
        }
    }
}
