using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineWeatherService.Infrastructure.persistence.migrations
{
    /// <inheritdoc />
    public partial class addForecast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ForecastId",
                table: "Weathers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_ForecastId",
                table: "Weathers",
                column: "ForecastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weathers_Forecasts_ForecastId",
                table: "Weathers",
                column: "ForecastId",
                principalTable: "Forecasts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weathers_Forecasts_ForecastId",
                table: "Weathers");

            migrationBuilder.DropTable(
                name: "Forecasts");

            migrationBuilder.DropIndex(
                name: "IX_Weathers_ForecastId",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "ForecastId",
                table: "Weathers");
        }
    }
}
