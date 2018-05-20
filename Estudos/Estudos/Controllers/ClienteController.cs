using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estudos.Data;
using Estudos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Estudos.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly EstudosContext _context;

        public ClienteController(EstudosContext context)
        {
            _context = context;

            CadastrarClientes();
        }

        private void CadastrarClientes()
        {
            if (_context.Cliente.Any()) return;
            _context.Cliente.Add(new Cliente { Nome = "JBC", Email = "jbc@jbc.com.br", Ativo = true });
            _context.Cliente.Add(new Cliente { Nome = "Microsoft", Email = "microsoft@microsoft.com.br", Ativo = true });
            _context.Cliente.Add(new Cliente { Nome = "IBM", Email = "ibm@ibm.com.br", Ativo = true });
            _context.Cliente.Add(new Cliente { Nome = "Oracle", Email = "oracle@oracle.com.br", Ativo = true });
            _context.Cliente.Add(new Cliente { Nome = "Semar", Email = "oracle@oracle.com.br", Ativo = false });
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult ObterTodosAtivos()
        {
            var clientes = _context.Cliente.Where(c => c.Ativo == true);
            if (clientes == null)
                return NotFound();
            return Ok(clientes);
        }

        [HttpGet("{id}", Name = "ObterCliente")]
        public IActionResult ObterClientePorId(long id)
        {
            var cliente = _context.Cliente.Find(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Cliente cliente)
        {
            cliente.Ativo = true;
            _context.Cliente.Add(cliente);
            _context.SaveChanges();

            return CreatedAtRoute("ObterCliente", new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(long id, [FromBody] Cliente cliente)
        {
            var item = _context.Cliente.Find(id);

            if (item == null)
                return NotFound();

            item.Nome = cliente.Nome;
            item.Email = cliente.Email;

            _context.Cliente.Update(item);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Inativar(long id)
        {
            var cliente = _context.Cliente.Find(id);

            if (cliente == null)
                return NotFound();

            cliente.Ativo = false;

            _context.Cliente.Update(cliente);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
