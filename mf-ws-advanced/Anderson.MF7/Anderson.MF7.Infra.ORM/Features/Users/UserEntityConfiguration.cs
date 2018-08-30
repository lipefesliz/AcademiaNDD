using Anderson.MF7.Domain.Features.Users;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace Anderson.MF7.Infra.ORM.Features.Users
{
    [ExcludeFromCodeCoverage]
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            ToTable("TBUsers");

            HasKey(t => t.Id);

            Property(t => t.Username).HasMaxLength(50).IsRequired();
            Property(t => t.Password).HasMaxLength(50).IsRequired();
        }
    }
}
