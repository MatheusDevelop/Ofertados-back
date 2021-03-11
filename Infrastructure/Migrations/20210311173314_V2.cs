using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoCliente_Cliente_Cliente_id",
                table: "ProdutoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoCliente_Produtos_Produto_id",
                table: "ProdutoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoCliente_Vendedores_Vendedor_id",
                table: "ProdutoCliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoCliente",
                table: "ProdutoCliente");

            migrationBuilder.RenameTable(
                name: "ProdutoCliente",
                newName: "ProdutoClientes");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoCliente_Vendedor_id",
                table: "ProdutoClientes",
                newName: "IX_ProdutoClientes_Vendedor_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoCliente_Produto_id",
                table: "ProdutoClientes",
                newName: "IX_ProdutoClientes_Produto_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoCliente_Cliente_id",
                table: "ProdutoClientes",
                newName: "IX_ProdutoClientes_Cliente_id");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_compra",
                table: "ProdutoClientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoClientes",
                table: "ProdutoClientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoClientes_Cliente_Cliente_id",
                table: "ProdutoClientes",
                column: "Cliente_id",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoClientes_Produtos_Produto_id",
                table: "ProdutoClientes",
                column: "Produto_id",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoClientes_Vendedores_Vendedor_id",
                table: "ProdutoClientes",
                column: "Vendedor_id",
                principalTable: "Vendedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoClientes_Cliente_Cliente_id",
                table: "ProdutoClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoClientes_Produtos_Produto_id",
                table: "ProdutoClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoClientes_Vendedores_Vendedor_id",
                table: "ProdutoClientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoClientes",
                table: "ProdutoClientes");

            migrationBuilder.DropColumn(
                name: "Data_compra",
                table: "ProdutoClientes");

            migrationBuilder.RenameTable(
                name: "ProdutoClientes",
                newName: "ProdutoCliente");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoClientes_Vendedor_id",
                table: "ProdutoCliente",
                newName: "IX_ProdutoCliente_Vendedor_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoClientes_Produto_id",
                table: "ProdutoCliente",
                newName: "IX_ProdutoCliente_Produto_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoClientes_Cliente_id",
                table: "ProdutoCliente",
                newName: "IX_ProdutoCliente_Cliente_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoCliente",
                table: "ProdutoCliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoCliente_Cliente_Cliente_id",
                table: "ProdutoCliente",
                column: "Cliente_id",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoCliente_Produtos_Produto_id",
                table: "ProdutoCliente",
                column: "Produto_id",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoCliente_Vendedores_Vendedor_id",
                table: "ProdutoCliente",
                column: "Vendedor_id",
                principalTable: "Vendedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
