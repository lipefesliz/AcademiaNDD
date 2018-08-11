using BancoTabajara.Infra.ORM.Contexts;
using BancoTabajara.Infra.ORM.Migrations;
using System.Data.Entity;

namespace BancoTabajara.Infra.ORM.Initializer
{
    public class DbInitializer : MigrateDatabaseToLatestVersion<BancoTabajaraDbContext, MigrationConfiguration>
    {
    }
}
