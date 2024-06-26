﻿namespace GestaoTarefas.Entity
{
    public class Usuario
    {
        public Usuario(string nome)
        {
            Nome = nome;
            CriadoEm = DateTime.UtcNow;
            AlteradoEm = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; } 
        public List<Tarefa> Tarefas { get; set; }
    }
}
