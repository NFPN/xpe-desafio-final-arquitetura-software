using Microsoft.AspNetCore.Mvc;
using VendasOnline.Dominio.Entidades;
using VendasOnline.Dominio.Interfaces;

namespace VendasOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController(IServicoPedido servicoPedido) : ControllerBase
    {
        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> Get()
        {
            var pedidos = await servicoPedido.ObterTodosAsync();
            return Ok(pedidos);
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> Get(int id)
        {
            var pedido = await servicoPedido.ObterPorIdAsync(id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        // GET: api/Pedidos/nome/cliente
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetByName(string nome)
        {
            var pedidos = await servicoPedido.ObterPorNomeAsync(nome);
            return Ok(pedidos);
        }

        // GET: api/Pedidos/contar
        [HttpGet("contar")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await servicoPedido.ContarTodosAsync();
            return Ok(count);
        }

        // POST: api/Pedidos
        [HttpPost]
        public async Task<ActionResult<Pedido>> Post([FromBody] Pedido pedido)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await servicoPedido.AdicionarAsync(pedido);

            return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
        }

        // PUT: api/Pedidos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pedido pedido)
        {
            if (id != pedido.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await servicoPedido.AtualizarAsync(pedido);

            return NoContent();
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await servicoPedido.ObterPorIdAsync(id);

            if (pedido == null)
                return NotFound();

            await servicoPedido.RemoverAsync(id);

            return NoContent();
        }
    }
}
