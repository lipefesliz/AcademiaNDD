using DonaLaura.Application.Features;
using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features.Sales;
using DonaLaura.Domain.Features.Products.Exceptions;
using DonaLaura.Domain.Features.Sales;
using DonaLaura.Infra.Data.Features.Sales;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonaLaura.Integration.Tests.Features.Sales
{
    [TestFixture]
    public class SaleIntegrationTest
    {
        SaleRepository _saleRepository;
        SaleService _saleService;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _saleRepository = new SaleRepository();
            _saleService = new SaleService(_saleRepository);
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_SaleIntegration_Add_ShouldBeOk()
        {
            Sale sale = ObjectMother.CreateValidSale();

            _saleService.Add(sale);

            IList<Sale> sales = _saleService.GetAll();
            sales[1].Should().NotBeNull();
            sales[1].Customer.Should().Be(sale.Customer);
        }

        [Test]
        [Order(2)]
        public void Test_SaleIntegration_Update_ShouldBeOk()
        {
            Sale sale = ObjectMother.CreateValidSale();

            _saleService.Update(sale);

            Sale newSale = _saleService.Get(sale.Id);
            newSale.Customer.Should().Be("Zeca");
        }

        [Test]
        [Order(3)]
        public void Test_SaleIntegration_Delete_ShouldBeOk()
        {
            Sale sale = ObjectMother.CreateValidSale();
            sale.Id = 11;

            _saleService.Delete(sale);

            sale = _saleService.Get(11);
            sale.Should().Be(null);
        }

        [Test]
        [Order(4)]
        public void Test_SaleIntegration_Get_ShouldBeOk()
        {
            Sale sale = _saleService.Get(1);
            sale.Should().NotBeNull();
            sale.Id.Should().Be(1);
        }

        [Test]
        [Order(5)]
        public void Test_SaleIntegration_GetAll_ShouldBeOk()
        {
            IList<Sale> sales = _saleService.GetAll();
            sales.Count.Should().Be(1);
            sales.First().Id.Should().Be(1);
        }
    }
}
