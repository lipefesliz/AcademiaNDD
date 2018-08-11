using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace BancoTabajara.Infra.ORM.Contexts
{
    [ExcludeFromCodeCoverage]
    public class DbContextFactory : IDbContextFactory<BancoTabajaraDbContext>
    {
        public BancoTabajaraDbContext Create()
        {
            return new BancoTabajaraDbContext();
        }
    }
}
