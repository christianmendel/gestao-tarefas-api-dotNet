namespace GestaoTarefas.Entity
{
    public class Tarefa
    {
        public Tarefa(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
            Finalizada = false;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }    
        public string Descricao { get; private set; }
        public bool Finalizada { get; private set; }
        public int UsuarioId { get; private set; }

        // Propriedade de navegação para o relacionamento "muitos para um"
        public Usuario Usuario { get; set; }

        public Tarefa AtribuirUsuarioId(int id)
        {
            this.UsuarioId = id;
            return this;
        }

        public Tarefa AlterarFinalizada(bool finalizada)
        {
            this.Finalizada = finalizada;
            return this;
        }
    }
}
