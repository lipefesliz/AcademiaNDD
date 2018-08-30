using MF6.Infra.ORM.Contexts;
using MF6.Infra.ORM.Migrations;
using System.Data.Entity;

namespace MF6.Infra.ORM.Initializer
{
    public class DbInitializer : MigrateDatabaseToLatestVersion<MF6Context, Configuration>
    {
    }
}
