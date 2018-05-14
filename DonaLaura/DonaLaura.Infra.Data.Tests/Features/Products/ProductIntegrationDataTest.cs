using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features.Products;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Infra.Data.Features.Products;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonaLaura.Infra.Data.Tests.Features.Products
{
    [TestFixture]
    public class ProductIntegrationDataTest
    {
        private IProductRepository _repository;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new ProductRepository();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_ProductIntegrationData_Add_ShouldBeOk()
        {
            Product product = ObjectMother.CreateValidProduct();

            Product newProduct = _repository.Add(product);
            newProduct.Id.Should().Be(2);
        }

        [Test]
        [Order(2)]
        public void Test_ProductIntegrationData_Get_ShouldBeOk()
        {
            Product product = _repository.Get(1);
            product.Should().NotBeNull();
            product.Id.Should().Be(1);
        }

        [Test]
        [Order(3)]
        public void Test_ProductIntegrationData_Update_ShouldBeOk()
        {
            Product product = _repository.Get(1);
            product.Name = "Creme";
            _repository.Update(product);

            Product updatedProduct = _repository.Get(product.Id);
            updatedProduct.Name.Should().Be(product.Name);
        }

        [Test]
        [Order(4)]
        public void Test_ProductIntegrationData_Delete_ShouldBeOk()
        {
            _repository.Delete(11);

            Product deletedProduct = _repository.Get(11);
            deletedProduct.Should().Be(null);
        }

        [Test]
        [Order(5)]
        public void Test_ProductIntegrationData_GetAll_ShouldBeOk()
        {
            IList<Product> products = _repository.GetAll();
            products.Count().Should().Be(1);
            products.First().Name.Should().Be("Sabonete");
        }

        [Test]
        [Order(6)]
        public void Test_ProductIntegrationData_Exist_ShouldBeOk()
        {
            bool result = _repository.Exist("Sabonete");
            result.Should().Be(true);
        }

        //[Test]
        //[Order(7)]
        public void Test_ProductIntegrationData_GetByName_ShouldBeOk()
        {
            string name = "Sabonete";

            Product product = _repository.GetByName(name);
            product.Should().NotBeNull();
            product.Name.Should().Be("Sabonete");
        }

        [Test]
        [Order(8)]
        public void Test_ProductIntegrationData_IsTiedTo_ShouldBeOk()
        {
            bool result = _repository.IsTiedTo(1);
            result.Should().Be(true);
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(9)]
        public void Test_ProductIntegrationData_AddEmptyName_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductEmptyName();

            Action action = () => _repository.Add(product);
            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(10)]
        public void Test_ProductIntegrationData_AddLenghName_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductLenghName();

            Action action = () => { _repository.Add(product); };
            action.Should().Throw<NameLenghtException>();
        }

        [Test]
        [Order(11)]
        public void Test_ProductIntegrationData_AddNegativeCostPrice_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductNegativeCostPrice();

            Action action = () => { _repository.Add(product); };
            action.Should().Throw<CostPriceNegativeException>();
        }

        [Test]
        [Order(12)]
        public void Test_ProductIntegrationData_AddSalePriceLowerThan_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductLowerThanSalePrice();

            Action action = () => { _repository.Add(product); };
            action.Should().Throw<SalePriceLowerThanException>();
        }

        [Test]
        [Order(13)]
        public void Test_ProductIntegrationData_AddExpirationLowerThan_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductExpirationLowerThan();

            Action action = () => { _repository.Add(product); };
            action.Should().Throw<ExpirationLowerThanException>();
        }

        [Test]
        [Order(14)]
        public void Test_ProductIntegrationData_GetUndefinedId_ShouldFail()
        {
            long Id = 0;

            Product product = _repository.Get(Id);
            product.Should().Be(null);
        }

        [Test]
        [Order(15)]
        public void Test_ProductIntegrationData_DeleteUndefinedId_ShouldFail()
        {
            Action action = () => { _repository.Delete(0); };
            action.Should().NotThrow<Exception>();
        }
    }
}
