namespace BancoTabajara.Infra.ORM.Migrations
{
    using BancoTabajara.Infra.ORM.Contexts;
    using System.Data.Entity.Migrations;

    public class MigrationConfiguration : DbMigrationsConfiguration<BancoTabajaraDbContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BancoTabajaraDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
