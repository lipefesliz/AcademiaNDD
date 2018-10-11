using MF6.Domain.Features.Impressoras;
using MF6.Domain.Features.Toners;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics.CodeAnalysis;

namespace MF6.Infra.ORM.Contexts
{
    [ExcludeFromCodeCoverage]
    public class MF6Context : DbContext
    {
        public MF6Context(string connection = "Name=Anderson_MF6Context") : base(connection)
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.Initialize(true);
        }

        protected MF6Context(DbConnection connection) : base(connection, true) { }

        public DbSet<Impressora> Impressoras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
