using Anderson.MF7.Domain.Features.Funcionarios;
using System.Data.Entity.ModelConfiguration;

namespace Anderson.MF7.Infra.ORM.Features.Funcionarios
{
    public class FuncionarioEntityConfiguration : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioEntityConfiguration()
        {
            ToTable("TBFuncionarios");

            HasKey(c => c.Id);

            Property(f => f.Nome).HasMaxLength(50).IsRequired();
            Property(f => f.Sobrenome).HasMaxLength(50).IsRequired();
            Property(f => f.Usuario).HasMaxLength(50).IsRequired();
            Property(f => f.Senha).HasMaxLength(20).IsRequired();
            Property(f => f.Ativo).IsRequired();
            Property(f => f.Cargo).HasMaxLength(100).IsRequired();
        }
    }
}
