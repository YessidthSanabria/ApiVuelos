using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightsHumano.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdDestino = table.Column<int>(type: "integer", nullable: false),
                    NombreDestino = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Origen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdOrigen = table.Column<int>(type: "integer", nullable: false),
                    NombreOrigen = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NumeroAsiento = table.Column<int>(type: "integer", nullable: false),
                    NombreUsuario = table.Column<string>(type: "text", nullable: false),
                    MailUsuario = table.Column<string>(type: "text", nullable: false),
                    IdVuelo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdOrigen = table.Column<int>(type: "integer", nullable: false),
                    IdDestino = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destino");

            migrationBuilder.DropTable(
                name: "Origen");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Vuelos");
        }
    }
}
