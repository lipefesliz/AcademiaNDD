using MediaProva.Domain.Features.Avaliacoes;
using System.Data.Entity.ModelConfiguration;

namespace MediaProva.Infra.Data.Features.Avaliacoes
{
    public class AvaliacaoConfiguration : EntityTypeConfiguration<Avaliacao>
    {
        public AvaliacaoConfiguration()
        {
            ToTable("TBAvaliacoes");

            HasKey(a => a.Id);

            Property(a => a.Assunto).IsRequired();
            Property(a => a.Data).IsRequired();
        }
    }
}
