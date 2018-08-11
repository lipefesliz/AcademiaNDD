using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoORM.Common.Tests.Features.Products;
using ProjetoORM.Application.Products;
using ProjetoORM.Domain.Exceptions;
using ProjetoORM.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoORM.Application.Tests.Features.Products
{
    [TestFixture]
    public class ProductServiceTests
    {
        private ProductService _service;
        private Mock<IProductRepository> _mockRepository;
        private Product _product;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IProductRepository>();
            _service = new ProductService(_mockRepository.Object);
            _product = ProductObjectMother.CreateValidProduct();
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_Product_AppService_Add_ShouldBeOk()
        {
            _mockRepository
                .Setup(pr => pr.Add(_product))
                .Returns(_product);

            var added = _service.Add(_product);

            _mockRepository.Verify(pr => pr.Add(_product));
            added.Id.Should().Be(_product.Id);
        }

        [Test]
        [Order(2)]
        public void Test_Product_AppService_Update_ShouldBeOk()
        {
            _mockRepository
                .Setup(pr => pr.GetByName(_product.Name))
                .Returns(new Product { Id = 1 });

            _mockRepository
                .Setup(pr => pr.Update(_product))
                .Returns(new Product { Id = 1 });

            Product p = _service.Update(_product);

            _mockRepository.Verify(pr => pr.Update(_product));
            p.Id.Should().Equals(_product.Id);
        }

        [Test]
        [Order(3)]
        public void Test_Product_AppService_Delete_ShouldBeOk()
        {
            _mockRepository.Setup(pr => pr.Delete(_product));

            _service.Delete(_product);

            var deleted = _service.Get(_product.Id);

            _mockRepository.Verify(pr => pr.Delete(_product));
            deleted.Should().BeNull();
        }

        [Test]
        [Order(4)]
        public void Test_Product_AppService_Get_ShouldBeOk()
        {
            _mockRepository
                .Setup(pr => pr.Get(_product.Id))
                .Returns(new Product { Id = 1 });

            Product p = _service.Get(_product.Id);

            _mockRepository.Verify(pr => pr.Get(_product.Id));
            p.Id.Should().BeGreaterThan(0);
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(5)]
        public void Test_Product_AppService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(pr => pr.GetAll())
                .Returns(new List<Product> { new Product { Id = 1 }, new Product { Id = 2 } });

            IList<Product> products = _service.GetAll();

            _mockRepository.Verify(pr => pr.GetAll());
            products.Count.Should().BeGreaterThan(0);
            products.First().Id.Should().Be(1);
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(6)]
        public void Test_Product_AppService_IsTiedTo_ShouldBeOk()
        {
            _mockRepository
                .Setup(pr => pr.IsTiedTo(_product))
                .Returns(false);

            bool result = _service.IsTiedTo(_product);

            result.Should().Be(false);
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(7)]
        public void Test_Product_AppService_Add_Throws_NameIsNullOrEmptyException()
        {
            _product.Name = String.Empty;

            Action action = () => _service.Add(_product);

            action.Should().Throw<NameIsNullOrEmptyException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(8)]
        public void Test_Product_AppService_Add_Throws_NameLenghtException()
        {
            _product.Name = "aaa";

            Action action = () => _service.Add(_product);

            action.Should().Throw<NameLenghtException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(9)]
        public void Test_Product_AppService_Add_Throws_CostPriceNegativeException()
        {
            _product.CostPrice = 0;

            Action action = () => _service.Add(_product);

            action.Should().Throw<CostPriceNegativeException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(10)]
        public void Test_Product_AppService_Add_Throws_SalePriceLowerThanException()
        {
            _product.SalePrice = 0;

            Action action = () => _service.Add(_product);

            action.Should().Throw<SalePriceLowerThanException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(11)]
        public void Test_Product_AppService_Add_Throws_ExpirationLowerThanException()
        {
            _product.Expiration = DateTime.Now.AddDays(-2);

            Action action = () => _service.Add(_product);

            action.Should().Throw<ExpirationLowerThanException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(12)]
        public void Test_Product_AppService_Add_Throws_DuplicatedNameException()
        {
            _mockRepository
                .Setup(pr => pr.Add(_product))
                .Throws<DuplicatedNameException>();

            Action action = () => _service.Add(_product);

            action.Should().Throw<DuplicatedNameException>();
        }

        [Test]
        [Order(13)]
        public void Test_Product_AppService_Update_Throws_IdentifierUndefinedException()
        {
            _product.Id = 0;

            Action action = () => _service.Update(_product);

            action.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(14)]
        public void Test_Product_AppService_Update_Throws_DuplicatedNameException()
        {

            _mockRepository
                .Setup(pr => pr.GetByName(_product.Name))
                .Returns(new Product { Id = 2 });

            _mockRepository
                .Setup(pr => pr.Update(_product))
                .Throws<DuplicatedNameException>();

            Action action = () => _service.Update(_product);

            action.Should().Throw<DuplicatedNameException>();
        }

        [Test]
        [Order(15)]
        public void Test_Product_AppService_Delete_Throws_IdentifierUndefinedException()
        {
            _product.Id = 0;

            Action action = () => _service.Delete(_product);

            action.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        [Order(16)]
        public void Test_Product_AppService_Delete_Throws_IsTiedException()
        {
            _mockRepository
                .Setup(pr => pr.IsTiedTo(_product))
                .Returns(true);

            _mockRepository
                .Setup(pr => pr.Delete(_product))
                .Throws<IsTiedException>();

            Action action = () => _service.Delete(_product);

            action.Should().Throw<IsTiedException>();
        }

        [Test]
        [Order(17)]
        public void Test_Product_AppService_Get_Throws_IdentifierUndefinedException()
        {
            long Id = 0;

            Action action = () => { _service.Get(Id); };

            action.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}
