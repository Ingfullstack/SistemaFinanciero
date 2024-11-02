using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFinanciero.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class MigracionTablaTipoPrestamos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoPrestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TasaInteresAnual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlazoMaximoMeses = table.Column<int>(type: "int", nullable: false),
                    MontoMaximo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorcentajeRefinanciamiento = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPrestamos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoPrestamos");
        }
    }
}
