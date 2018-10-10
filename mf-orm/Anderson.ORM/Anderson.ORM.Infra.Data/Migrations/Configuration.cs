namespace Anderson.ORM.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Anderson.ORM.Infra.Data.Base.AndersonORMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Anderson.ORM.Infra.Data.Base.AndersonORMContext";
        }

        protected override void Seed(Anderson.ORM.Infra.Data.Base.AndersonORMContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
