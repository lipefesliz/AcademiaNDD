using MediaProva.Domain.Features.Alunos;
using System.Data.Entity.ModelConfiguration;

namespace MediaProva.Infra.Data.Features.Alunos
{
    public class AlunoConfiguration : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfiguration()
        {
            ToTable("TBAlunos");

            HasKey(a => a.Id);

            Property(a => a.Nome).IsRequired();
            Property(a => a.Idade).IsRequired();
            Property(a => a.Media).IsRequired();

            HasMany(a => a.Resultados)
                .WithRequired(r => r.Aluno)
                .Map(m => m.MapKey("AlunoId")
                .ToTable("TBResultados"))
                .WillCascadeOnDelete();
        }
    }
}
