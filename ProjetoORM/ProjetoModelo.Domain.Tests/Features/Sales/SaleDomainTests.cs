using FluentAssertions;
using NUnit.Framework;
using ProjetoORM.Common.Tests.Features.Sales;
using ProjetoORM.Domain.Features.Products;
using ProjetoORM.Domain.Features.Sales;
using System;
using System.Collections.Generic;

namespace ProjetoORM.Domain.Tests.Features.Sales
{
    [TestFixture]
    public class SaleDomainTests
    {
        Sale _sale;

        [SetUp]
        public void SetUp()
        {
            _sale = SaleObjectMother.CreateValidSale();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_Sale_Domain_Create_ShouldBeOk()
        {
            Action action = _sale.Validate;

            action.Should().NotThrow<Exception>();
        }

        [Test]
        [Order(2)]
        public void Test_Sale_Domain_ToString_ShouldBeOk()
        {
            string text = _sale.ToString();

            text.Should().NotBeEmpty();
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(3)]
        public void Test_Sale_Domain_Create_Throws_NameIsNullOrEmptyException()
        {
            _sale.Customer = String.Empty;

            Action action = _sale.Validate;

            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(4)]
        public void Test_Sale_Domain_Create_Throws_NameLenghtException()
        {
            _sale.Customer = "aaa";

            Action action = _sale.Validate;

            action.Should().Throw<NameLenghtException>();
        }

        [Test]
        [Order(5)]
        public void Test_Sale_Domain_Create_Throws_EmptyProductsException()
        {
            _sale.Products = new List<Product> { };

            Action action = _sale.Validate;

            action.Should().Throw<EmptyProductsException>();
        }
    }
}
