using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightsHumano.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MOdificarTipoCampoIdOrigenDestino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(
              "ALTER TABLE \"Vuelos\" " +
              "ALTER COLUMN \"IdOrigen\" TYPE uuid USING (md5(\"IdOrigen\"::text)::uuid);");

            migrationBuilder.Sql(
                "ALTER TABLE \"Vuelos\" " +
                "ALTER COLUMN \"IdDestino\" TYPE uuid USING (md5(\"IdDestino\"::text)::uuid);");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdOrigen",
                table: "Vuelos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<int>(
                name: "IdDestino",
                table: "Vuelos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }
    }
}
