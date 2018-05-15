using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features.Sales;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Sales;
using DonaLaura.Infra.Data.Features.Sales;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DonaLaura.Infra.Data.Tests.Features.Sales
{
    [TestFixture]
    public class SaleIntegrationDataTest
    {
        private ISaleRepository _repository;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new SaleRepository();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_SaleIntegrationData_Add_ShouldBeOk()
        {
            Sale sale = ObjectMother.CreateValidSale();

            Sale newSale = _repository.Add(sale);
            newSale.Id.Should().Be(2);
        }

        [Test]
        [Order(2)]
        public void Test_SaleIntegrationData_Get_ShouldBeOk()
        {
            Sale sale = _repository.Get(1);
            sale.Should().NotBeNull();
            sale.Id.Should().Be(1);
        }

        [Test]
        [Order(3)]
        public void Test_SaleIntegrationData_Update_ShouldBeOk()
        {
            //Sale sale = _repository.Get(1);
            Sale sale = ObjectMother.CreateValidSale();
            sale.Customer = "Mario";
            _repository.Update(sale);

            Sale updatedSale = _repository.Get(sale.Id);
            updatedSale.Customer.Should().Be(sale.Customer);
        }

        [Test]
        [Order(4)]
        public void Test_SaleIntegrationData_Delete_ShouldBeOk()
        {
            _repository.Delete(1);

            Sale deletedSale = _repository.Get(1);
            deletedSale.Should().Be(null);
        }

        [Test]
        [Order(5)]
        public void Test_SaleIntegrationData_GetAll_ShouldBeOk()
        {
            IList<Sale> sales = _repository.GetAll();
            sales.Count().Should().Be(1);
            sales.First().Customer.Should().Be("Juca");
        }

        [Test]
        [Order(6)]
        public void Test_SaleIntegrationData_GetByCustumer_ShouldBeOk()
        {
            Sale sale = _repository.GetByCustomer("Lara");
            sale.Should().Be(null);
        }

        [Test]
        [Order(7)]
        public void Test_SaleIntegrationData_GetProductsFromSale_ShouldBeOk()
        {
            long id = 1;
            IList<Product> products = _repository.GetProductsFromSale(id);
            products.Count().Should().Be(1);
            products.First().Name.Should().Be("Sabonete");
        }
    }
}
