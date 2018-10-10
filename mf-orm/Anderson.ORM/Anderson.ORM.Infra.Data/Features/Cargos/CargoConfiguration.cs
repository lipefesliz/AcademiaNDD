using Anderson.ORM.Domain.Features.Cargos;
using System.Data.Entity.ModelConfiguration;

namespace Anderson.ORM.Infra.Data.Features.Cargos
{
    public class CargoConfiguration : EntityTypeConfiguration<Cargo>
    {
        public CargoConfiguration()
        {
            ToTable("TBCargos");

            HasKey(c => c.Id);

            Property(c => c.Descricao).IsRequired();
        }
    }
}
