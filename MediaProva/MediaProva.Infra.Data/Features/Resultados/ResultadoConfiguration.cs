using MediaProva.Domain.Features.Resultados;
using System.Data.Entity.ModelConfiguration;

namespace MediaProva.Infra.Data.Features.Resultados
{
    public class ResultadoConfiguration : EntityTypeConfiguration<Resultado>
    {
        public ResultadoConfiguration()
        {
            ToTable("TBResultados");

            HasKey(r => r.Id);

            Property(r => r.Nota).IsRequired();

            HasRequired(r => r.Aluno);
            HasRequired(r => r.Avaliacao);
        }
    }
}
