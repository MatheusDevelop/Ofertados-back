using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Cliente:Usuario
    {
        public string Cpf { get; set; }
        public List<ProdutoCliente> Compras { get; set; }
    }
}
