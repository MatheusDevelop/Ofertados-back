using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ProdutoCliente
    {
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }
        public Vendedor Vendedor { get; set; }
        public int Estrelas { get; set; }

    }
}
