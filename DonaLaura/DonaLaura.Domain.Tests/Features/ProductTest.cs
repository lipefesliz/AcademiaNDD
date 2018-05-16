using DonaLaura.Common.Tests.Features.Products;
using DonaLaura.Domain.Features.Products;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace DonaLaura.Domain.Tests.Features
{
    [TestFixture]
    public class ProductTest
    {
        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_CreateProduct_ShouldBeOk()
        {
            Product product = ObjectMother.CreateValidProduct();

            Action action = product.Validate;
            action.Should().NotThrow<Exception>();
        }

        [Test]
        [Order(2)]
        public void Test_ToStringIsAvailableTrue_ShouldBeOk()
        {
            Product product = ObjectMother.CreateValidProduct();

            string text = product.ToString();
            text.Should().Equals("Produto: Creme - Em estoque: Sim");
        }

        [Test]
        [Order(3)]
        public void Test_ToStringIsAvailableFalse_ShouldBeOk()
        {
            Product product = ObjectMother.CreateValidProduct();
            product.IsAvailable = false;

            string text = product.ToString();
            text.Should().Equals("Produto: Creme - Em estoque: Não");
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(4)]
        public void Test_CreateProduct_EmptyName_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductEmptyName();

            Action action = product.Validate;
            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(5)]
        public void Test_CreateProduct_LenghtName_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductLenghName();

            Action action = product.Validate;
            action.Should().Throw<NameLenghtException>();
        }

        [Test]
        [Order(6)]
        public void Test_CreateProduct_NegativeCostPrice_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductNegativeCostPrice();

            Action action = product.Validate;
            action.Should().Throw<CostPriceNegativeException>();
        }

        [Test]
        [Order(7)]
        public void Test_CreateProduct_SalePrice_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductLowerThanSalePrice();

            Action action = product.Validate;
            action.Should().Throw<SalePriceLowerThanException>();
        }

        [Test]
        [Order(8)]
        public void Test_CreateProduct_ExpirationLowerThan_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductExpirationLowerThan();

            Action action = product.Validate;
            action.Should().Throw<ExpirationLowerThanException>();
        }
    }
}
