using BancoTabajara.Domain.Features.Movimentacoes;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace BancoTabajara.Infra.ORM.Features.Movimentacoes
{
    [ExcludeFromCodeCoverage]
    public class MovimentacaoEntityConfiguration : EntityTypeConfiguration<Movimentacao>
    {
        public MovimentacaoEntityConfiguration()
        {
            ToTable("TBMovimentacoes");

            HasKey(m => m.Id);

            Property(m => m.Data).IsRequired();
            Property(m => m.Tipo).IsRequired();
            Property(m => m.Valor).IsRequired();

            HasRequired(m => m.Conta);
        }
    }
}
