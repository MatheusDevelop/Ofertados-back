using Newtonsoft.Json;
using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Cliente:Usuario
    {
        public Cliente(string email,
            string senha,
            string nome,
            DateTime data_nascimento,
            string cpf, string cep) : base(email, senha, nome, data_nascimento)
        {
            Cpf = cpf;
            Cep = cep;
            Tipo_perfil = EnTipoPerfil.Cliente;
        }

        public string Cep { get; set; }
        public string Cpf { get; set; }
        public List<ProdutoCliente> Compras { get; set; } = new List<ProdutoCliente>();
    }
}
