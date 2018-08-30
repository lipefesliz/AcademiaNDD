namespace MF6.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class MigrationConfiguration : DbMigrationsConfiguration<MF6.Infra.ORM.Contexts.MF6Context>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MF6.Infra.ORM.Contexts.MF6Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
