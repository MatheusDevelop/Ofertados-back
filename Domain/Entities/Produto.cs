using Shared.DomainShared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Produto:Entity
    {
        protected Produto()
        {

        }
        public Produto(float preco_desconto,
            float preco,
            string nome,
            string descricao,
            string url_imagem,
            Guid vendedor_id,
            int quantidade,
            bool desconto_aplicado,
            DateTime oferta_inicio,
            DateTime oferta_fim,
            int desconto_porcentagem,
            Guid categoria_id)
        {
            Preco_desconto = preco_desconto;
            Preco = preco;
            Nome = nome;
            Descricao = descricao;
            Url_imagem = url_imagem;
            Vendedor_id = vendedor_id;
            Quantidade = quantidade;
            Desconto_aplicado = desconto_aplicado;
            Oferta_inicio = oferta_inicio;
            Oferta_fim = oferta_fim;
            Desconto_porcentagem = desconto_porcentagem;
            Categoria_id = categoria_id;
        }

        public float Preco_desconto { get; set; }
        public float Preco { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Url_imagem { get; set; }
        public Guid Vendedor_id { get; set; }
        [ForeignKey("Vendedor_id")]
        public Vendedor Vendedor { get; set; }
        public int Quantidade { get; set; }
        public bool Desconto_aplicado { get; set; }
        public DateTime Oferta_inicio { get; set; }
        public DateTime Oferta_fim { get; set; }
        public int Desconto_porcentagem { get; set; }
        public Guid Categoria_id { get; set; }
        [ForeignKey("Categoria_id")]
        public Categoria Categoria { get; set; }
    }

}
