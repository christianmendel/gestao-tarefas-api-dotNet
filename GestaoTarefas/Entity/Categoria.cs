namespace GestaoTarefas.Entity
{
    public class Categoria
    {
        public Categoria(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            CriadoEm = DateTime.UtcNow;
            AlteradoEm = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime AlteradoEm { get; set; } = DateTime.UtcNow;
        public List<Tarefa> Tarefas { get; set; }
    }
}
