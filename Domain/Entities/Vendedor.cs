using Newtonsoft.Json;
using Shared.DomainShared;
using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Vendedor:Usuario
    {
        public Vendedor(
            string email,
            string senha,
            string nome,
            DateTime data_nascimento,
            string cnpj,
            string razao_social,
            string chave_pix) : base(email, senha, nome, data_nascimento)
        {
            Cnpj = cnpj;
            Razao_social = razao_social;
            Chave_pix = chave_pix;
            Tipo_perfil = EnTipoPerfil.Vendedor;
        }
        public string Cnpj { get; set; }
        public string Razao_social { get; set; }
        public string Chave_pix { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<ProdutoCliente> Vendas { get; set; }
    }
}
