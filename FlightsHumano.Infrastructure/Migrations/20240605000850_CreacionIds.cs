using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightsHumano.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreacionIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {     

            migrationBuilder.AddColumn<int>(
                name: "IdVuelo",
                table: "Vuelos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdReserva",
                table: "Reserva",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdVuelo",
                table: "Vuelos");

            migrationBuilder.DropColumn(
                name: "IdReserva",
                table: "Reserva");
        }
    }
}
