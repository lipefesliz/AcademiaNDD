using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoModelo.Application.Sales;
using ProjetoORM.Common.Tests.Features.Sales;
using ProjetoORM.Domain.Exceptions;
using ProjetoORM.Domain.Features.Products;
using ProjetoORM.Domain.Features.Sales;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoORM.Application.Tests.Features.Sales
{
    [TestFixture]
    public class SaleServiceTests
    {
        private SaleService _service;
        private Mock<ISaleRepository> _mockRepository;
        private Sale _sale;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<ISaleRepository>();
            _service = new SaleService(_mockRepository.Object);
            _sale = SaleObjectMother.CreateValidSale();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_Sale_AppService_Add_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.Add(_sale))
                .Returns(new Sale { Id = 1 });

            Sale s = _service.Add(_sale);

            _mockRepository.Verify(sr => sr.Add(_sale));
            s.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(2)]
        public void Test_Sale_AppService_Update_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.Update(_sale))
                .Returns(new Sale { Id = 1 });

            Sale s = _service.Update(_sale);

            _mockRepository.Verify(sr => sr.Update(_sale));
            s.Id.Should().Equals(_sale.Id);
        }

        [Test]
        [Order(3)]
        public void Test_Sale_AppService_Delete_ShouldBeOk()
        {
            _mockRepository.Setup(sr => sr.Delete(_sale));

            _service.Delete(_sale);

            var deleted = _service.Get(_sale.Id);

            _mockRepository.Verify(sr => sr.Delete(_sale));
            deleted.Should().BeNull();
        }

        [Test]
        [Order(4)]
        public void Test_Sale_AppService_Get_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.Get(_sale.Id))
                .Returns(new Sale { Id = 1 });

            Sale p = _service.Get(_sale.Id);

            _mockRepository.Verify(sr => sr.Get(_sale.Id));
            p.Id.Should().BeGreaterThan(0);
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(5)]
        public void Test_Sale_AppService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(sr => sr.GetAll())
                .Returns(new List<Sale> { new Sale { Id = 1 }, new Sale { Id = 2 } });

            IList<Sale> sales = _service.GetAll();

            _mockRepository.Verify(sr => sr.GetAll());
            sales.Count.Should().BeGreaterThan(0);
            sales.First().Id.Should().Be(1);
            _mockRepository.VerifyNoOtherCalls();
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(7)]
        public void Test_Sale_AppService_Add_Throws_NameIsNullOrEmptyException()
        {
            _sale.Customer = String.Empty;

            _mockRepository
                .Setup(sr => sr.Add(_sale))
                .Returns(new Sale { Id = 1 });

            Action action = () => _service.Add(_sale);

            action.Should().Throw<NameIsNullOrEmptyException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(8)]
        public void Test_Sale_AppService_Add_Throws_NameLenghtException()
        {
            _sale.Customer = "aaa";

            _mockRepository
                .Setup(sr => sr.Add(_sale))
                .Returns(new Sale { Id = 1 });

            Action action = () => _service.Add(_sale);

            action.Should().Throw<NameLenghtException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(9)]
        public void Test_Sale_AppService_Update_Throws_IdentifierUndefinedException()
        {
            _sale.Id = 0;

            Action action = () => { _service.Update(_sale); };
            action.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(10)]
        public void Test_Sale_AppService_Delete_Throws_IdentifierUndefinedException()
        {
            _sale.Id = 0;

            Action action = () => _service.Delete(_sale);

            action.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(11)]
        public void Test_Sale_AppService_Get_Throws_IdentifierUndefinedException()
        {
            long Id = 0;

            Action action = () => _service.Get(Id);

            action.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}
