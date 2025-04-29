using Microsoft.AspNetCore.Mvc;
using VendasOnline.Dominio.Entidades;
using VendasOnline.Dominio.Interfaces;

namespace VendasOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController(IServicoProduto servicoProduto) : ControllerBase
    {
        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            var produtos = await servicoProduto.ObterTodosAsync();
            return Ok(produtos);
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var produto = await servicoProduto.ObterPorIdAsync(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        // GET: api/Produtos/nome/notebook
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetByName(string nome)
        {
            var produtos = await servicoProduto.ObterPorNomeAsync(nome);
            return Ok(produtos);
        }

        // GET: api/Produtos/contar
        [HttpGet("contar")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await servicoProduto.ContarTodosAsync();
            return Ok(count);
        }

        // POST: api/Produtos
        [HttpPost]
        public async Task<ActionResult<Produto>> Post([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await servicoProduto.AdicionarAsync(produto);

            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await servicoProduto.AtualizarAsync(produto);

            return NoContent();
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await servicoProduto.ObterPorIdAsync(id);

            if (produto == null)
                return NotFound();

            await servicoProduto.RemoverAsync(id);

            return NoContent();
        }
    }
}
