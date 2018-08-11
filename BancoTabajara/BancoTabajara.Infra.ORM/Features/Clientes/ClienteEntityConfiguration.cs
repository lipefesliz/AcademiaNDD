using BancoTabajara.Domain.Features.Clientes;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace BancoTabajara.Infra.ORM.Features.Clientes
{
    [ExcludeFromCodeCoverage]
    public class ClienteEntityConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteEntityConfiguration()
        {
            ToTable("TBClientes");

            HasKey(c => c.Id);

            Property(c => c.Nome).HasMaxLength(100);
            Property(c => c.Cpf).HasMaxLength(50);
            Property(c => c.Rg).HasMaxLength(50);
            Property(c => c.Nascimento).IsRequired();
        }
    }
}
