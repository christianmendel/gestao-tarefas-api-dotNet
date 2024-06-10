using System.ComponentModel.DataAnnotations;

namespace GestaoTarefas.Dto.Request
{
    public class TarefaRequest
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int UsuarioId { get; set; }
    }
}
