using Anderson.ORM.Domain.Features.Projetos;
using System.Data.Entity.ModelConfiguration;

namespace Anderson.ORM.Infra.Data.Features.Projetos
{
    public class ProjetoConfiguration : EntityTypeConfiguration<Projeto>
    {
        public ProjetoConfiguration()
        {
            ToTable("TBProjetos");

            HasKey(p => p.Id);

            Property(p => p.Nome).IsRequired();
            Property(p => p.DataInicio).IsRequired();

            //HasRequired(p => p.Funcionarios);
        }
    }
}
