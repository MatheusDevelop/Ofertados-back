using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Cliente
    {
        public Usuario Usuario { get; set; }
        public string Cpf { get; set; }
        public List<ProdutoCliente> Compras { get; set; }
    }
}
