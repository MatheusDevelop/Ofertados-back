using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Context
{
    public class OfertadosContext:DbContext
    {
        public OfertadosContext(DbContextOptions<OfertadosContext> options)
        : base(options)
        {
        }

        public DbSet<Produto> Produtos{ get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<ProdutoCliente> ProdutoClientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

    }
}
