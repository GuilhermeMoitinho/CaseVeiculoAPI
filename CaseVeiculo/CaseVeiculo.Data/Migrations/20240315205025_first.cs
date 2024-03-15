using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseVeiculo.Data.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarcaDoVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditoriaDoVeiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HistoricoDeEstados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriaDoVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditoriaDoVeiculo_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaDoVeiculo_VeiculoId",
                table: "AuditoriaDoVeiculo",
                column: "VeiculoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditoriaDoVeiculo");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
