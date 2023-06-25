using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoscowWeather.Host.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    RelativeHumidity = table.Column<float>(type: "real", nullable: false),
                    DewPoint = table.Column<float>(type: "real", nullable: false),
                    AtmospherePressure = table.Column<int>(type: "int", nullable: false),
                    WindSpeed = table.Column<byte>(type: "tinyint", nullable: true),
                    Cloudiness = table.Column<byte>(type: "tinyint", nullable: false),
                    CloudBase = table.Column<int>(type: "int", nullable: true),
                    HorizontalVisibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Directions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherLogs");
        }
    }
}
