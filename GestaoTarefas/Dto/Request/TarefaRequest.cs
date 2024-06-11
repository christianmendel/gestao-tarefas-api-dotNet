using GestaoTarefas.Enums;
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
        public int Prioridade { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public int CategoriaId { get; set; }
    }
}
