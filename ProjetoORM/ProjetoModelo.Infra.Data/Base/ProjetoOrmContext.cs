using ProjetoORM.Domain.Features.Products;
using ProjetoORM.Domain.Features.Sales;
using ProjetoORM.Infra.Data.Features.Products;
using System.Data.Entity;

namespace ProjetoORM.Infra.Data.Base
{
    public class ProjetoOrmContext : DbContext
    {
        public ProjetoOrmContext() : base("ProjetoOrmContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            //modelBuilder.Configurations.Add(new SaleConfiguration());
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("nvarchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));
        }
    }
}
