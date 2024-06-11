﻿using System.ComponentModel.DataAnnotations;

namespace GestaoTarefas.Dto.Request
{
    public class CategoriaRequest
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
