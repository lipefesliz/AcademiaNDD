using MediaProva.Domain.Features.Alunos;
using MediaProva.Domain.Features.Avaliacoes;
using MediaProva.Domain.Features.Resultados;
using MediaProva.Infra.Data.Features.Alunos;
using MediaProva.Infra.Data.Features.Avaliacoes;
using MediaProva.Infra.Data.Features.Resultados;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MediaProva.Infra.Data.Base
{
    public class MediaProvaContext : DbContext
    {
        public MediaProvaContext() : base("DBMediaProva")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                   .Where(p => p.Name == p.ReflectedType.Name + "Id")
                   .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new AvaliacaoConfiguration());
            modelBuilder.Configurations.Add(new ResultadoConfiguration());
            modelBuilder.Configurations.Add(new AlunoConfiguration());
        }
    }
}
