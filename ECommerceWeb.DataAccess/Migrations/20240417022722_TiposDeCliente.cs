using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TiposDeCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TipoCliente",
                columns: new[] { "Id", "Descripcion", "Estado" },
                values: new object[,]
                {
                    { 1, "Cliente Normal", true },
                    { 2, "Cliente Especial", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipoCliente",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoCliente",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
