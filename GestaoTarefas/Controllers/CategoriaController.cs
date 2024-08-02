using GestaoTarefas.Data;
using GestaoTarefas.Dto.Request.Categoria;
using GestaoTarefas.Entity;
using Microsoft.AspNetCore.Mvc;

namespace GestaoTarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ConfigDbContext _configDbContext;
        public CategoriaController(ConfigDbContext configDbContext)
        {
            _configDbContext = configDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCategoria([FromBody] CategoriaRequest categoriaRequest)
        {
            var categoria = new Categoria(categoriaRequest.Nome, categoriaRequest.Descricao);

            _configDbContext.Categorias.Add(categoria);
            _configDbContext.SaveChanges();

            return Ok();
        }
    }
}
