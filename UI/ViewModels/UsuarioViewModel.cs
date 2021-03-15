using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
    public class ClienteViewModel {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime Data_nascimento { get; set; }
        public string Cep { get; set; }
        public string Cpf { get; set; }
    }
    public class VendedorViewModel {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime Data_nascimento { get; set; }
        public string Cnpj { get; set; }
        public string Razao_social { get; set; }
        public string Chave_pix { get; set; }
    }

}
