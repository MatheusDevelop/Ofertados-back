using Shared.DomainShared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Categoria:Entity
    {
        public string Nome { get; set; }
        public string Url_imagem { get; set; }
    }
}
