using ProjetoORM.Common.Tests.Features.Products;
using ProjetoORM.Common.Tests.Features.Sales;
using ProjetoORM.Infra.Data.Base;
using System.Data.Entity;

namespace ProjetoORM.Common.Tests.Base
{
    public class BaseSqlTest : DropCreateDatabaseAlways<ProjetoOrmContext>
    {
        protected override void Seed(ProjetoOrmContext context)
        {
            var products = ProductObjectMother.CreateValidProduct();
            var sales = SaleObjectMother.CreateValidSale();

            context.Products.Add(products);
            context.Sales.Add(sales);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
