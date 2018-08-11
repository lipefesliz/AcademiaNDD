using ProjetoORM.Domain.Features.Products;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoORM.Infra.Data.Features.Products
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("TBProducts");

            HasKey(p => p.Id);

            Property(p => p.Id).IsRequired();
            Property(p => p.Name).HasMaxLength(150).IsRequired();
            Property(p => p.CostPrice).HasColumnType("decimal").IsRequired();
            Property(p => p.SalePrice).HasColumnType("decimal").IsRequired();
            Property(p => p.IsAvailable).HasColumnType("bit").IsRequired();
            Property(p => p.Expiration).HasColumnType("date").IsRequired();
            Property(p => p.Fabrication).HasColumnType("date").IsRequired();
        }
    }
    }
}
