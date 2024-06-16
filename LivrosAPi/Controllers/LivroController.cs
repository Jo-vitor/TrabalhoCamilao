using LivrosAPi.Models;
using LivrosAPi.Daos;
using Microsoft.AspNetCore.Mvc;

namespace LivrosAPi.Controllers
{
    [ApiController]
    [Route("livro/[controller]")]
    public class LivroController : Controller
    {
        public LivroDAO dao;
        public LivroController()
        {
            dao = new LivroDAO();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetAsync()
        {
            var objetos = await dao.RetornarTodosAsync();

            if (objetos == null)
                return NotFound();

            return Ok(objetos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetId(int id)
        {
            var obj = await dao.RetornarPorIdAsync(id);

            if (obj == null)
                return NotFound();

            return obj;
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> PostAsync(Livro obj)
        {
            await dao.InserirAsync(obj);

            return CreatedAtAction(
                nameof(GetId),
                new { id = obj.Id },
                obj
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Livro obj)
        {
            if (id != obj.Id)
                return BadRequest();
        
            var objOrig = await dao.RetornarPorIdAsync(id);

            if (objOrig == null)
                return NotFound();

            objOrig.Titulo = obj.Titulo;
            objOrig.Categoria = obj.Categoria;
            objOrig.Descricao = obj.Descricao;
            objOrig.Autor = obj.Autor;

            await dao.AlterarAsync(obj);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var obj = await dao.RetornarPorIdAsync(id);
        
            if (obj == null)
                return NotFound();
        
            await dao.ExcluirAsync(id);

            return NoContent();
        }
    }
}
