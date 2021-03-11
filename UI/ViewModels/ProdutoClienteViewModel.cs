using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class ProdutoClienteInsertViewModel
    {
        public Guid Vendedor_id { get; set; }
        public Guid Cliente_id { get; set; }
        public Guid Produto_id { get; set; }

    }
    public class ProdutoClienteAvaliateViewModel
    {
        public Guid ProdutoCliente_id { get; set; }
        public int Estrelas { get; set; }

    }
}
