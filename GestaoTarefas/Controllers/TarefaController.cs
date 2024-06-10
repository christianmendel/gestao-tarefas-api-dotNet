using GestaoTarefas.Data;
using GestaoTarefas.Dto.Request;
using GestaoTarefas.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoTarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : Controller
    {

        private readonly ConfigDbContext _configDbContext;
        public TarefaController(ConfigDbContext configDbContext)
        {
            _configDbContext = configDbContext;
        }

        [HttpGet("{usuarioId}")]
        public async Task<List<Tarefa>> ListarTarefasPorUsuario([FromRoute] int usuarioId)
        {

            var tarefas = _configDbContext.Tarefas.Where(t => t.UsuarioId == usuarioId).ToList();

            tarefas.ForEach(async tarefa =>
                {

                    var usuario = await _configDbContext.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == tarefa.UsuarioId);

                    if (usuario != null)
                    {
                        tarefa.Usuario = usuario;
                    }
                }
            );

            return tarefas;
        }

        [HttpPost]
        public async Task<IActionResult> CriarTarefa([FromBody] TarefaRequest tarefaRequest)
        {
            var tarefa = new Tarefa(tarefaRequest.Titulo, tarefaRequest.Descricao);

            var usuario = await _configDbContext.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == tarefaRequest.UsuarioId);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            tarefa.AtribuirUsuarioId(tarefaRequest.UsuarioId);

            _configDbContext.Tarefas.Add(tarefa);
            _configDbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario([FromRoute] int id)
        {
            var tarefa = await _configDbContext.Tarefas.FirstOrDefaultAsync(usuario => usuario.Id == id);

            if (tarefa == null)
            {
                return NotFound("Tarefa não encontrado");

            }

            _configDbContext.Tarefas.Remove(tarefa);
            _configDbContext.SaveChanges();

            return Ok();
        }
    }
}
