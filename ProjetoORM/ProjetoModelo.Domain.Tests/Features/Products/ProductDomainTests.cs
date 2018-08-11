using FluentAssertions;
using NUnit.Framework;
using ProjetoORM.Common.Tests.Features.Products;
using ProjetoORM.Domain.Features.Products;
using System;

namespace ProjetoORM.Domain.Tests.Features.Products
{
    [TestFixture]
    public class ProductDomainTests
    {
        Product _product;

        [SetUp]
        public void SetUp()
        {
            _product = ProductObjectMother.CreateValidProduct();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_Product_Domain_Create_ShouldBeOk()
        {
            Action action = _product.Validate;

            action.Should().NotThrow<Exception>();
        }

        [Test]
        [Order(2)]
        public void Test_Product_Domain_ToString_AvailableProduct_ShouldBeOk()
        {
            string text = _product.ToString();

            text.Should().NotBeEmpty();
        }

        [Test]
        [Order(3)]
        public void Test_Product_Domain_ToString_NotAvailableProduct_ShouldBeOk()
        {
            _product.IsAvailable = false;

            string text = _product.ToString();

            text.Should().NotBeEmpty();
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(4)]
        public void Test_Product_Domain_Create_Throws_NameIsNullOrEmptyException()
        {
            _product.Name = String.Empty;

            Action action = _product.Validate;

            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(5)]
        public void Test_Product_Domain_Create_Throws_NameLenghtException()
        {
            _product.Name = "aaa";

            Action action = _product.Validate;

            action.Should().Throw<NameLenghtException>();
        }

        [Test]
        [Order(6)]
        public void Test_Product_Domain_Create_Throws_CostPriceNegativeException()
        {
            _product.CostPrice = 0;

            Action action = _product.Validate;

            action.Should().Throw<CostPriceNegativeException>();
        }

        [Test]
        [Order(7)]
        public void Test_Product_Domain_Create_Throws_SalePriceLowerThanException()
        {
            _product.SalePrice = 0;

            Action action = _product.Validate;

            action.Should().Throw<SalePriceLowerThanException>();
        }

        [Test]
        [Order(8)]
        public void Test_Product_Domain_Create_Throws_ExpirationLowerThanException()
        {
            _product.Expiration = DateTime.Now.AddDays(-2);

            Action action = _product.Validate;

            action.Should().Throw<ExpirationLowerThanException>();
        }
    }
}
