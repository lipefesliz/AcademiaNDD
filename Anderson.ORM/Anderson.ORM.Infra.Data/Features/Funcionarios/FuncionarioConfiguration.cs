using Anderson.ORM.Domain.Features.Funcionarios;
using System.Data.Entity.ModelConfiguration;

namespace Anderson.ORM.Infra.Data.Features.Funcionarios
{
    public class FuncionarioConfiguration : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfiguration()
        {
            ToTable("TBFuncionarios");

            HasKey(f => f.Id);

            Property(f => f.Nome).IsRequired();

            HasRequired(f => f.Cargo);
            HasRequired(f => f.Departamento);
            HasRequired(f => f.Endereco);
        }
    }
}
