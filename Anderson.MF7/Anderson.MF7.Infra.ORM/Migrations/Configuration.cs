namespace Anderson.MF7.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<Anderson.MF7.Infra.ORM.Contexts.AndersonMF7DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Anderson.MF7.Infra.ORM.Contexts.AndersonMF7DbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
