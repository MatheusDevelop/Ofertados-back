using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo_perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Razao_social = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chave_pix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo_perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Preco_desconto = table.Column<float>(type: "real", nullable: false),
                    Preco = table.Column<float>(type: "real", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url_imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendedor_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Desconto_aplicado = table.Column<bool>(type: "bit", nullable: false),
                    Oferta_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Oferta_fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Desconto_porcentagem = table.Column<int>(type: "int", nullable: false),
                    Categoria_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categoria_Categoria_id",
                        column: x => x.Categoria_id,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Vendedores_Vendedor_id",
                        column: x => x.Vendedor_id,
                        principalTable: "Vendedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cliente_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Produto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vendedor_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estrelas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoCliente_Cliente_Cliente_id",
                        column: x => x.Cliente_id,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProdutoCliente_Produtos_Produto_id",
                        column: x => x.Produto_id,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProdutoCliente_Vendedores_Vendedor_id",
                        column: x => x.Vendedor_id,
                        principalTable: "Vendedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoCliente_Cliente_id",
                table: "ProdutoCliente",
                column: "Cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoCliente_Produto_id",
                table: "ProdutoCliente",
                column: "Produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoCliente_Vendedor_id",
                table: "ProdutoCliente",
                column: "Vendedor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Categoria_id",
                table: "Produtos",
                column: "Categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Vendedor_id",
                table: "Produtos",
                column: "Vendedor_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoCliente");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Vendedores");
        }
    }
}
