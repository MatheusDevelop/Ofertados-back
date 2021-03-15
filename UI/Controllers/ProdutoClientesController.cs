using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Context;
using UI.ViewModels;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoClientesController : ControllerBase
    {
        private readonly OfertadosContext _context;

        public ProdutoClientesController(OfertadosContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListarCompras")]
        public async Task<ActionResult<List<ComprasViewModelResult>>> ListarCompras(Guid id_cliente)
        {
            var lista =  await _context.ProdutoClientes.Include(e => e.Produto).Include(e => e.Vendedor).Where(e => e.Cliente_id == id_cliente).ToListAsync();
            var listaResult = new List<ComprasViewModelResult>();
            foreach(var item in lista)
            {
                listaResult.Add(new ComprasViewModelResult(item.Estrelas,item.Produto.Nome));
            }
            return listaResult;
        }
        [HttpGet]
        [Route("ListarVendas")]
        public async Task<ActionResult<List<ProdutoCliente>>> ListarVendas(Guid id_vendedor)
        {
            return await _context.ProdutoClientes.Include(e=> e.Produto).Include(e=> e.Cliente).Where(e => e.Vendedor_id == id_vendedor).ToListAsync();
        }
        [HttpPost]
        [Route("Comprar")]
        public async Task<ActionResult<ProdutoCliente>> PostProdutoCliente(ProdutoClienteInsertViewModel produtoCliente)
        {
            var searchProduto = _context.Produtos.FirstOrDefault(e => e.Id == produtoCliente.Produto_id);
            if (searchProduto == null)
                return NotFound("Produto nao encontrado");
            if (searchProduto.Quantidade == 0)
                return BadRequest("Produto sem estoque");
            var produto = new ProdutoCliente(produtoCliente.Cliente_id, produtoCliente.Produto_id, produtoCliente.Vendedor_id);

            _context.ProdutoClientes.Add(produto);
            await _context.SaveChangesAsync();

            searchProduto.Quantidade = searchProduto.Quantidade - 1;
            _context.Produtos.Update(searchProduto);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpPut]
        [Route("Avaliar")]
        public async Task<ActionResult<ProdutoCliente>> PostProdutoCliente(ProdutoClienteAvaliateViewModel produtoCliente)
        {
            var produto = _context.ProdutoClientes.Find(produtoCliente.ProdutoCliente_id);
            produto.Estrelas = produtoCliente.Estrelas;
            _context.ProdutoClientes.Update(produto);
            await _context.SaveChangesAsync();

            return Ok();
        }


        private bool ProdutoClienteExists(Guid id)
        {
            return _context.ProdutoClientes.Any(e => e.Id == id);
        }
    }
}
