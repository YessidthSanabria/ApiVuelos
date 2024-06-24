using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightsHumano.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IncluirFechasVuelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaLlegada",
                table: "Vuelos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSalida",
                table: "Vuelos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaLlegada",
                table: "Vuelos");

            migrationBuilder.DropColumn(
                name: "FechaSalida",
                table: "Vuelos");
        }
    }
}
