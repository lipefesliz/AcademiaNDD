using Anderson.ORM.Domain.Features.Dependentes;
using System.Data.Entity.ModelConfiguration;

namespace Anderson.ORM.Infra.Data.Features.Dependentes
{
    public class DependenteConfiguration : EntityTypeConfiguration<Dependente>
    {
        public DependenteConfiguration()
        {
            ToTable("TBDependentes");

            HasKey(d => d.Id);

            Property(d => d.Nome).IsRequired();
            Property(d => d.Idade).IsRequired();
        }
    }
}
