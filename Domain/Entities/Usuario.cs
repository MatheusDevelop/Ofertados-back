using Newtonsoft.Json;
using Shared.DomainShared;
using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class Usuario:Entity
    {
        public Usuario(string email,
            string senha,
            string nome,
            DateTime data_nascimento)
        {
            Email = email;
            Senha = senha;
            Nome = nome;
            Data_nascimento = data_nascimento;
        }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime Data_nascimento { get; set; }
        public EnTipoPerfil Tipo_perfil { get; set; }
    }
}
