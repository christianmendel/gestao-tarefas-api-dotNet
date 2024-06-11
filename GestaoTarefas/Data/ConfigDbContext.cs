using GestaoTarefas.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestaoTarefas.Data
{
    public class ConfigDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public ConfigDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("database"));
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().ToTable("Tarefa").HasKey(t => t.Id);
            modelBuilder.Entity<Usuario>().ToTable("Usuario").HasKey(u => u.Id);
            modelBuilder.Entity<Categoria>().ToTable("Categoria").HasKey(u => u.Id);

            modelBuilder.Entity<Tarefa>()
                 .HasOne(t => t.Usuario)
                 .WithMany(u => u.Tarefas)
                 .HasForeignKey(t => t.UsuarioId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tarefa>()
                 .HasOne(t => t.Categoria)
                 .WithMany(c => c.Tarefas)
                 .HasForeignKey(c => c.CategoriaId)
                 .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
