using MF6.Domain.Features.Impressoras;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace MF6.Infra.ORM.Features.Impressoras
{
    [ExcludeFromCodeCoverage]
    public class ImpressoraEntityConfiguration : EntityTypeConfiguration<Impressora>
    {
        public ImpressoraEntityConfiguration()
        {
            ToTable("TBimpressoras");

            HasKey(i => i.Id);

            Property(i => i.EmUso).IsRequired();
            Property(i => i.Marca).HasMaxLength(100).IsRequired();
            Property(i => i.Rede).HasMaxLength(100).IsRequired();
            Property(i => i.TonerColorido.Nivel).HasColumnName("TonerColorido").IsRequired();
            Property(i => i.TonerPreto.Nivel).HasColumnName("TonerPreto").IsRequired();
        }
    }
}
