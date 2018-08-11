using BancoTabajara.Domain.Features.Contas;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace BancoTabajara.Infra.ORM.Features.Contas
{
    [ExcludeFromCodeCoverage]
    public class ContaEntityConfiguration : EntityTypeConfiguration<Conta>
    {
        public ContaEntityConfiguration()
        {
            ToTable("TBContas");

            HasKey(c => c.Id);

            Property(c => c.Ativada).IsRequired();
            Property(c => c.Limite).IsRequired();
            Property(c => c.Numero).IsRequired();
            Property(c => c.Saldo).IsRequired();
            Ignore(c => c.SaldoTotal);

            HasRequired(c => c.Cliente);
        }
    }
}
