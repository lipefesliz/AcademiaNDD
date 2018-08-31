using Anderson.MF7.Domain.Features.Users;
using System.Data.Entity.ModelConfiguration;

namespace Anderson.MF7.Infra.ORM.Features.Users
{
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            ToTable("TBUsers");

            HasKey(u => u.Id);

            Property(u => u.Name).HasMaxLength(50).IsRequired();
            Property(u => u.Email).HasMaxLength(50).IsRequired();
            Property(u => u.Password).HasMaxLength(50).IsRequired();
        }
    }
}
