using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exApiCompras.Migrations
{
    /// <inheritdoc />
    public partial class PedidoProdutoCrud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PedidosProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    produtoId = table.Column<int>(type: "int", nullable: true),
                    categoriaId = table.Column<int>(type: "int", nullable: true),
                    quantidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosProdutos_Categorias_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidosProdutos_Produtos_produtoId",
                        column: x => x.produtoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProdutos_categoriaId",
                table: "PedidosProdutos",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProdutos_produtoId",
                table: "PedidosProdutos",
                column: "produtoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosProdutos");
        }
    }
}
