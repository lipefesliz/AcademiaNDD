using Anderson.ORM.Domain.Features.Enderecos;
using System.Data.Entity.ModelConfiguration;

namespace Anderson.ORM.Infra.Data.Features.Enderecos
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            ToTable("TBEnderecos");

            HasKey(e => e.Id);

            Property(e => e.Bairro).IsRequired();
            Property(e => e.Cep).IsRequired();
            Property(e => e.Cidade).IsRequired();
            Property(e => e.Estado).IsRequired();
            Property(e => e.Numero).IsRequired();
            Property(e => e.Rua).IsRequired();
        }
    }
}
