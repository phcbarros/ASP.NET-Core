using Estudos.Service;
using Estudos.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Estudos.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly ClienteService _service;

        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult ObterTodosAtivos()
        {
            var clientes = _service.ObterAtivos();
            if (clientes == null)
                return NotFound();
            return Ok(clientes);
        }

        [HttpGet("{id}", Name = "ObterCliente")]
        public IActionResult ObterClientePorId(long id)
        {
            var cliente = _service.ObterClienteAtivo(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpGet("inativo/{id}")]
        public IActionResult ObterClienteInativoPorId(long id)
        {
            var cliente = _service.ObterCliente(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cli = _service.Cadastrar(cliente);

            return CreatedAtRoute("ObterCliente", new { id = cli.Id }, cli);
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(long id, [FromBody] ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = _service.Atualizar(id, cliente);

            if (item == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Inativar(long id)
        {
            var inativou = _service.Inativar(id);

            if (inativou)
                return NoContent();
            return NotFound();
        }
    }
}
