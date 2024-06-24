using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightsHumano.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MOdifcarTipoCampoIDVueloReserva : Migration
    {
        /// <inheritdoc />
       
        /// 

        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(
             "ALTER TABLE \"Reserva\" " +
             "ALTER COLUMN \"IdVuelo\" TYPE uuid USING (md5(\"IdVuelo\"::text)::uuid);");



            //migrationBuilder.AlterColumn<Guid>(
            //    name: "IdVuelo",
            //    table: "Reserva",
            //    type: "uuid",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdVuelo",
                table: "Reserva",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }
    }
}
