using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherTracker.Migrations
{
    public partial class AddCityIdToWeatherData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherDataSets_UserCities_CityId",
                table: "WeatherDataSets");

            migrationBuilder.AlterColumn<decimal>(
                name: "Temperature",
                table: "WeatherDataSets",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Humidity",
                table: "WeatherDataSets",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "WeatherDataSets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherDataSets_UserCities_CityId",
                table: "WeatherDataSets",
                column: "CityId",
                principalTable: "UserCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherDataSets_UserCities_CityId",
                table: "WeatherDataSets");

            migrationBuilder.AlterColumn<double>(
                name: "Temperature",
                table: "WeatherDataSets",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Humidity",
                table: "WeatherDataSets",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "WeatherDataSets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherDataSets_UserCities_CityId",
                table: "WeatherDataSets",
                column: "CityId",
                principalTable: "UserCities",
                principalColumn: "Id");
        }
    }
}
