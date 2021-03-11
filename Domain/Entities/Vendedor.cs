using Shared.DomainShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Vendedor:Usuario
    {
        public string Cnpj { get; set; }
        public string Razao_social { get; set; }
        public string Chave_pix { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<ProdutoCliente> Vendas { get; set; }
    }
}
