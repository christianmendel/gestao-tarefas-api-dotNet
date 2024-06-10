using GestaoTarefas.Data;
using GestaoTarefas.Dto.Request;
using GestaoTarefas.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoTarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly ConfigDbContext _configDbContext;
        public UsuarioController(ConfigDbContext configDbContext)
        {
            _configDbContext = configDbContext;
        }

        [HttpGet]
        public async Task<List<Usuario>> ListarUsuarios()
        {
            var usuarios = _configDbContext.Usuarios.ToList();

            return usuarios;
        }

        [HttpPost]
        public IActionResult CriarUsuario([FromBody] UsuarioRequest usuarioRequest)
        {
            var usuario = new Usuario(usuarioRequest.Nome);
            _configDbContext.Usuarios.Add(usuario);
            _configDbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario([FromRoute] int id)
        {
            var usuario = await _configDbContext.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            _configDbContext.Usuarios.Remove(usuario);
            _configDbContext.SaveChanges();

            return Ok();
        }
    }
}
