using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.ViewModel;
using Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Utils;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly OfertadosContext context;
        private readonly Jwt jwtService;
        public UsuarioController(OfertadosContext context, Jwt jwtService)
        {
            this.context = context;
            this.jwtService = jwtService;
        }


        [HttpPost]
        [Route("/Login")]
        public ActionResult Login(LoginViewModel model)
        {
            model.Senha = Crypto.Encriptar(model.Senha);
            var user = context.Usuarios.FirstOrDefault(e => e.Email == model.Email && e.Senha == model.Senha);
            if (user == null)
                return BadRequest("Usuario invalido");
            return Ok(new { token = jwtService.GerarToken(user) });
        }

        [HttpPost]
        [Route("/Cadastrar")]
        public ActionResult Cadastro(ClienteViewModel model)
        {
            var user = context.Usuarios.FirstOrDefault(e => e.Email == model.Email);
            if (user != null)
                return BadRequest("Usuario já existente");

            model.Senha = Crypto.Encriptar(model.Senha);

            var novoCliente = new Cliente(model.Email,model.Senha,model.Nome,model.Data_nascimento,model.Cpf,model.Cep);
            context.Clientes.Add(novoCliente);
            context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("/Cadastrar/Vendedor")]
        public ActionResult Cadastro(VendedorViewModel model)
        {
            var user = context.Usuarios.FirstOrDefault(e => e.Email == model.Email);
            if (user != null)
                return BadRequest("Usuario já existente");

            model.Senha = Crypto.Encriptar(model.Senha);

            var novoVendedor = new Domain.Entities.Vendedor(model.Email, model.Senha, model.Nome, model.Data_nascimento, model.Cnpj, model.Razao_social, model.Chave_pix);
            context.Vendedores.Add(novoVendedor);
            context.SaveChanges();

            return Ok();
        }

    }

}
