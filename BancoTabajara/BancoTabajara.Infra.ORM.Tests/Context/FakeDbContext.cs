using BancoTabajara.Infra.ORM.Contexts;
using System.Data.Common;

namespace BancoTabajara.Infra.ORM.Tests.Context
{
    public class FakeDbContext : BancoTabajaraDbContext
    {
        public FakeDbContext(DbConnection connection) : base(connection)
        {

        }
    }
}
