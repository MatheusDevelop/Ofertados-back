using Shared.DomainShared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class ProdutoCliente:Entity
    {
        public ProdutoCliente(Guid cliente_id, Guid produto_id,  Guid vendedor_id)
        {
            Cliente_id = cliente_id;
            Produto_id = produto_id;
            Vendedor_id = vendedor_id;
            Data_compra = DateTime.Now;
        }

        public DateTime Data_compra { get; private set; }
        public Guid Cliente_id { get; set; }
        [ForeignKey("Cliente_id")]
        public Cliente Cliente { get; set; }
        public Guid Produto_id { get; set; }
        [ForeignKey("Produto_id")]
        public Produto Produto { get; set; }
        public Guid Vendedor_id { get; set; }
        [ForeignKey("Vendedor_id")]
        public Vendedor Vendedor { get; set; }
        public int Estrelas { get; set; }

    }
}
