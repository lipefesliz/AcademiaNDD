using DonaLaura.Common.Tests.Features.Sales;
using DonaLaura.Domain.Features.Products;
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

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(2)]
        public void Test_CreateSale_EmptyName_ShouldFail()
        {
            Sale sale = ObjectMother.CreateInvalidSaleEmptyCustomer();

            Action action = sale.Validate;
            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(3)]
        public void Test_CreateSale_LenghtName_ShouldFail()
        {
            Sale sale = ObjectMother.CreateInvalidSaleLeghtCustomer();

            Action action = sale.Validate;
            action.Should().Throw<NameLenghtException>();
        }
    }
}
