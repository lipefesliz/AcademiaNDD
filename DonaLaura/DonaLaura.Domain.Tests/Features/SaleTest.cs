using DonaLaura.Common.Tests.Features.Sales;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Products.Exceptions;
using DonaLaura.Domain.Features.Sales;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace DonaLaura.Domain.Tests.Features
{
    [TestFixture]
    public class SaleTest
    {
        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_CreateSale_ShouldBeOk()
        {
            Sale sale = ObjectMother.CreateValidSale();

            Action action = sale.Validate;
            action.Should().NotThrow<Exception>();
        }

        [Test]
        [Order(2)]
        public void Test_ToString_ShouldBeOk()
        {
            Sale sale = ObjectMother.CreateValidSale();

            string text = sale.ToString();
            text.Should().Equals("Zeca - 1000");
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(3)]
        public void Test_CreateSale_EmptyName_ShouldFail()
        {
            Sale sale = ObjectMother.CreateInvalidSaleEmptyCustomer();

            Action action = sale.Validate;
            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(4)]
        public void Test_CreateSale_LenghtName_ShouldFail()
        {
            Sale sale = ObjectMother.CreateInvalidSaleLeghtCustomer();

            Action action = sale.Validate;
            action.Should().Throw<NameLenghtException>();
        }

        [Test]
        [Order(5)]
        public void Test_CreateSale_EmptyProduct_ShouldFail()
        {
            Sale sale = ObjectMother.CreateInvalidSaleEmptyProduct();

            Action action = sale.Validate;
            action.Should().Throw<EmptyProductsException>();
        }
    }
}
