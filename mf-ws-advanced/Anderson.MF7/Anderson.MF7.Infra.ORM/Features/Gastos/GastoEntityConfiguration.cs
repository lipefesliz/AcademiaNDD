using Anderson.MF7.Domain.Features.Gastos;
using System.Data.Entity.ModelConfiguration;

namespace Anderson.MF7.Infra.ORM.Features.Gastos
{
    public class GastoEntityConfiguration : EntityTypeConfiguration<Gasto>
    {
        public GastoEntityConfiguration()
        {
            ToTable("TBGastos");

            HasKey(c => c.Id);

            Property(g => g.Descricao).HasMaxLength(100).IsRequired();
            Property(g => g.Data).IsRequired();
            Property(g => g.Preco).IsRequired();
            Property(g => g.Tipo).IsRequired();

            HasRequired(g => g.Funcionario);
        }
    }
}
