using Anderson.ORM.Domain.Features.Departamentos;
using System.Data.Entity.ModelConfiguration;

namespace Anderson.ORM.Infra.Data.Features.Departamentos
{
    public class DepartamentoConfiguration : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoConfiguration()
        {
            ToTable("TBDepartamentos");

            HasKey(d => d.Id);

            Property(d => d.Descricao).IsRequired();
        }
    }
}
