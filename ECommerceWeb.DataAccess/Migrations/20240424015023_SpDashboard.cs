using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SpDashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE uspDashboard
                    AS
                    BEGIN
	                    
	                    SELECT
		                    SUM(V.Total) AS TotalVenta,
		                    COUNT(V.ID) AS CantidadVentas,
		                    (SELECT COUNT(C.ID) FROM Cliente C (NOLOCK) WHERE C.Estado = 1) CantidadClientes,
		                    (SELECT COUNT(P.ID) FROM Producto P (NOLOCK) WHERE P.Estado = 1) CantidadProductos
	                    FROM VENTA V (NOLOCK)
	                    WHERE V.Estado = 1

                    END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROC uspDashboard");
        }
    }
}
