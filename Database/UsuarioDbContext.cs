using Microsoft.EntityFrameworkCore;
using csharpagencia.Model;

namespace csharpagencia.Database
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext>
        options) : base(options) { 

        }

        public DbSet<Usuario> Usuarios {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            var usuario = modelBuilder.Entity<Usuario>();
            usuario.ToTable("usuario");
            usuario.HasKey(x => x.Id);
            usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            usuario.Property(x => x.Telefone).HasColumnName("telefone").IsRequired();
            usuario.Property(x => x.Endereco).HasColumnName("endereco").IsRequired();
            usuario.Property(x => x.Cpf).HasColumnName("cpf").IsRequired();
            usuario.Property(x => x.Email).HasColumnName("email").IsRequired();
            usuario.Property(x => x.Senha).HasColumnName("senha").IsRequired();
            
        }
    } 
}
