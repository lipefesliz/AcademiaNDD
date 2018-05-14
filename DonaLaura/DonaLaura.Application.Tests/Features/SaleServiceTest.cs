using DonaLaura.Application.Features;
using DonaLaura.Common.Tests.Features.Sales;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Sales;
using DonaLaura.Domain.Features.Sales;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonaLaura.Application.Tests.Features
{
    [TestFixture]
    public class SaleServiceTest
    {
        private SaleService _service;
        private Mock<ISaleRepository> _mockRepository;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<ISaleRepository>();
            _service = new SaleService(_mockRepository.Object);
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_SaleService_Add_ShouldBeOk()
        {
            Sale sale = ObjectMother.CreateValidSale();

            _mockRepository
                .Setup(sr => sr.Add(sale))
                .Returns(new Sale { Id = 1 });

            Sale s = _service.Add(sale);

            _mockRepository.Verify(sr => sr.Add(sale));
            s.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(1)]
        public void Test_SaleService_Update_ShouldBeOk()
        {
            Sale sale = ObjectMother.CreateValidSale();

            _mockRepository
                .Setup(sr => sr.Update(sale))
                .Returns(new Sale { Id = 1 });

            Sale s = _service.Update(sale);

            _mockRepository.Verify(sr => sr.Update(sale));
            s.Id.Should().Equals(sale.Id);
        }

        [Test]
        [Order(3)]
        public void Test_SaleService_Delete_ShouldBeOk()
        {
            Sale sale = ObjectMother.CreateValidSale();

            _mockRepository.Setup(sr => sr.Delete(sale.Id));

            _service.Delete(sale);

            _mockRepository.Verify(sr => sr.Delete(sale.Id));
        }

        [Test]
        [Order(4)]
        public void Test_SaleService_Get_ShouldBeOk()
        {
            Sale sale = ObjectMother.CreateValidSale();

            _mockRepository
                .Setup(sr => sr.Get(sale.Id))
                .Returns(new Sale { Id = 1 });

            Sale p = _service.Get(sale.Id);

            _mockRepository.Verify(sr => sr.Get(sale.Id));
            p.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(5)]
        public void Test_SaleService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.GetAll())
                .Returns(new List<Sale> { new Sale { Id = 1 }, new Sale { Id = 2 } });

            IList<Sale> sales = _service.GetAll();

            _mockRepository.Verify(sr => sr.GetAll());
            sales.Count.Should().BeGreaterThan(0);
            sales.First().Id.Should().Be(1);
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(7)]
        public void Test_SaleService_AddEmptyCustomer_ShouldFail()
        {
            Sale sale = ObjectMother.CreateInvalidSaleEmptyCustomer();

            _mockRepository
                .Setup(sr => sr.Add(sale))
                .Returns(new Sale { Id = 1 });

            Action action = () => _service.Add(sale);
            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(8)]
        public void Test_SaleService_AddLenghtCustomer_ShouldFail()
        {
            Sale sale = ObjectMother.CreateInvalidSaleLeghtCustomer();

            _mockRepository
                .Setup(sr => sr.Add(sale))
                .Returns(new Sale { Id = 1 });

            Action action = () => _service.Add(sale);
            action.Should().Throw<NameLenghtException>();
        }

        [Test]
        [Order(9)]
        public void Test_SaleService_UpdateUndefinedId_ShouldFail()
        {
            Sale sale = ObjectMother.CreateValidSale();
            sale.Id = 0;

            Action action = () => { _service.Update(sale); };
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(10)]
        public void Test_SaleService_DeleteteUndefinedId_ShouldFail()
        {
            Sale sale = ObjectMother.CreateValidSale();
            sale.Id = 0;

            Action action = () => { _service.Delete(sale); };
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(11)]
        public void Test_SaleService_GetUndefinedId_ShouldFail()
        {
            long Id = 0;

            Action action = () => { _service.Get(Id); };
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
