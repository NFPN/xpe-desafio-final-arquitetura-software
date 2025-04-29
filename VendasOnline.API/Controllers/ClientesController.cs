using Microsoft.AspNetCore.Mvc;
using VendasOnline.Dominio.Entidades;
using VendasOnline.Dominio.Interfaces;

namespace VendasOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController(IServicoCliente servicoCliente) : ControllerBase
    {

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            var clientes = await servicoCliente.ObterTodosAsync();
            return Ok(clientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await servicoCliente.ObterPorIdAsync(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        // GET: api/Clientes/nome/joao
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetByName(string nome)
        {
            var clientes = await servicoCliente.ObterPorNomeAsync(nome);
            return Ok(clientes);
        }

        // GET: api/Clientes/contar
        [HttpGet("contar")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await servicoCliente.ContarTodosAsync();
            return Ok(count);
        }
        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> Post([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await servicoCliente.AdicionarAsync(cliente);

            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await servicoCliente.AtualizarAsync(cliente);

            return NoContent();
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await servicoCliente.ObterPorIdAsync(id);

            if (cliente == null)
                return NotFound();

            await servicoCliente.RemoverAsync(id);

            return NoContent();
        }
    }
}
