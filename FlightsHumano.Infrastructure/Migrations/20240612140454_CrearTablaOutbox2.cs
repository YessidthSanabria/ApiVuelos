using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightsHumano.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaOutbox2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Outbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IdReserva = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Origen = table.Column<string>(type: "text", nullable: false),
                    Destino = table.Column<string>(type: "text", nullable: false),
                    NumeroAsiento = table.Column<int>(type: "integer", nullable: false),
                    TipoOutbox = table.Column<string>(type: "text", nullable: false),
                    Enviado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outbox", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Outbox");
        }
    }
}
