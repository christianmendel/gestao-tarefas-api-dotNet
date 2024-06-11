using GestaoTarefas.Enums;

namespace GestaoTarefas.Entity
{
    public class Tarefa
    {
        public Tarefa(string titulo, string descricao, Prioridade prioridade)
        {
            Titulo = titulo;
            Descricao = descricao;
            Prioridade = prioridade;
            Finalizada = false;
            CriadoEm = DateTime.UtcNow;
            AlteradoEm = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }    
        public string Descricao { get; private set; }
        public bool Finalizada { get; private set; }
        public Prioridade Prioridade { get; private set; }
        public int UsuarioId { get; private set; }
        public int CategoriaId { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime AlteradoEm { get; private set; }

        // Propriedade de navegação para o relacionamento "muitos para um"
        public Usuario Usuario { get; set; }

        // Propriedade de navegação para o relacionamento "um para um"
        public Categoria Categoria { get; set; }

        public Tarefa AtribuirUsuarioId(int id)
        {
            this.UsuarioId = id;
            return this;
        }

        public Tarefa AtribuirCategoriaId(int id)
        {
            this.CategoriaId = id;
            return this;
        }

        public Tarefa AlterarFinalizada(bool finalizada)
        {
            this.Finalizada = finalizada;
            return this;
        }
    }
}
