using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Context;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly OfertadosContext _context;

        public ProdutosController(OfertadosContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListarProdutos")]
        public async Task<ActionResult<IEnumerable<Produto>>> ListarProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        [HttpGet]
        [Route("Desconto")]
        public async Task<ActionResult<IEnumerable<Produto>>> BuscarPorPorcentagem(int porcentagem)
        {
            return await _context.Produtos.Where(e => e.Desconto_porcentagem == porcentagem).ToListAsync();
        }
        [HttpGet]
        [Route("Categoria")]
        public async Task<ActionResult<IEnumerable<Produto>>> BuscarPorCategoria(Guid categoria_id)
        {
            return await _context.Produtos.Where(e => e.Categoria_id == categoria_id).ToListAsync();
        }
        [HttpGet]
        [Route("Nome")]
        public async Task<ActionResult<IEnumerable<Produto>>> BuscarPorNome(string nome)
        {
            return await _context.Produtos.Where(e => e.Nome.Contains(nome)).ToListAsync();
        }
        [HttpGet]
        [Route("ListarOfertados")]
        public async Task<ActionResult<IEnumerable<Produto>>> BuscarOfertados()
        {
            return await _context.Produtos.Where(e => e.Desconto_aplicado).ToListAsync();
        }
        [HttpPut]
        [Route("RemoverOferta")]
        public async Task<IActionResult> RemoverOferta(Guid idProduto)
        {
            if(!ProdutoExists(idProduto))
                return NotFound();

            var produto = await _context.Produtos.FindAsync(idProduto);
            produto.Desconto_aplicado = false;
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(Guid id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(Guid id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

     
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> DeleteProduto(Guid id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        private bool ProdutoExists(Guid id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
