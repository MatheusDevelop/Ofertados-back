using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoClientes_Cliente_Cliente_id",
                table: "ProdutoClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoClientes_Vendedores_Vendedor_id",
                table: "ProdutoClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categoria_Categoria_id",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Vendedores_Vendedor_id",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendedores",
                table: "Vendedores");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categorias");

            migrationBuilder.RenameTable(
                name: "Vendedores",
                newName: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url_imagem",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoClientes_Usuarios_Cliente_id",
                table: "ProdutoClientes",
                column: "Cliente_id",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoClientes_Usuarios_Vendedor_id",
                table: "ProdutoClientes",
                column: "Vendedor_id",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_Categoria_id",
                table: "Produtos",
                column: "Categoria_id",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Usuarios_Vendedor_id",
                table: "Produtos",
                column: "Vendedor_id",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoClientes_Usuarios_Cliente_id",
                table: "ProdutoClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoClientes_Usuarios_Vendedor_id",
                table: "ProdutoClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_Categoria_id",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Usuarios_Vendedor_id",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Url_imagem",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Categoria");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Vendedores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendedores",
                table: "Vendedores",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo_perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoClientes_Cliente_Cliente_id",
                table: "ProdutoClientes",
                column: "Cliente_id",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoClientes_Vendedores_Vendedor_id",
                table: "ProdutoClientes",
                column: "Vendedor_id",
                principalTable: "Vendedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categoria_Categoria_id",
                table: "Produtos",
                column: "Categoria_id",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Vendedores_Vendedor_id",
                table: "Produtos",
                column: "Vendedor_id",
                principalTable: "Vendedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
