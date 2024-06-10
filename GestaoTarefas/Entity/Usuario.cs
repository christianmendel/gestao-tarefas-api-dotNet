namespace GestaoTarefas.Entity
{
    public class Usuario
    {
        public Usuario(string nome)
        {
            Nome = nome;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }

        public List<Tarefa> Tarefas { get; set; }
    }
}
