using BancoTabajara.Domain.Features.Usuarios;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace BancoTabajara.Infra.ORM.Features.Usuarios
{
    [ExcludeFromCodeCoverage]
    public class UsuarioEntityConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioEntityConfiguration()
        {
            ToTable("TBUsuarios");

            HasKey(u => u.Id);

            Property(u => u.Nome).HasMaxLength(100).IsRequired();
            Property(u => u.Senha).HasMaxLength(1000).IsRequired();
        }
    }
}
