using DonaLaura.Applications.Features;
using DonaLaura.Common.Tests.Features.Products;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Products.Exceptions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonaLaura.Application.Tests.Features
{
    [TestFixture]
    class ProductServiceTest
    {
        private ProductService _service;
        private Mock<IProductRepository> _mockRepository;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IProductRepository>();
            _service = new ProductService(_mockRepository.Object);
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_ProductService_Add_ShouldBeOk()
        {
            Product product = ObjectMother.CreateValidProduct();

            _mockRepository
                .Setup(pr => pr.Add(product))
                .Returns(new Product { Id = 1 });

            Product p = _service.Add(product);

            _mockRepository.Verify(pr => pr.Add(product));
            p.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(2)]
        public void Test_ProductService_Update_ShouldBeOk()
        {
            Product product = ObjectMother.CreateValidProduct();

            _mockRepository
                .Setup(pr => pr.Update(product))
                .Returns(new Product { Id = 1 });

            Product p = _service.Update(product);

            _mockRepository.Verify(pr => pr.Update(product));
            p.Id.Should().Equals(product.Id);
        }

        [Test]
        [Order(3)]
        public void Test_ProductService_Delete_ShouldBeOk()
        {
            Product product = ObjectMother.CreateValidProduct();

            _mockRepository.Setup(pr => pr.Delete(product.Id));

            _service.Delete(product);

            _mockRepository.Verify(pr => pr.Delete(product.Id));
        }

        [Test]
        [Order(4)]
        public void Test_ProductService_Get_ShouldBeOk()
        {
            Product product = ObjectMother.CreateValidProduct();

            _mockRepository
                .Setup(pr => pr.Get(product.Id))
                .Returns(new Product { Id = 1 });

            Product p = _service.Get(product.Id);

            _mockRepository.Verify(pr => pr.Get(product.Id));
            p.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(5)]
        public void Test_ProductService_GetAll_ShouldBeOk()
        {
            _mockRepository
                .Setup(pr => pr.GetAll())
                .Returns(new List<Product> { new Product { Id = 1 }, new Product { Id = 2 } });

            IList<Product> products = _service.GetAll();

            _mockRepository.Verify(pr => pr.GetAll());
            products.Count.Should().BeGreaterThan(0);
            products.First().Id.Should().Be(1);
        }

        [Test]
        [Order(6)]
        public void Test_ProductService_IsTiedTo_ShouldBeOk()
        {
            _mockRepository
                .Setup(pr => pr.IsTiedTo(1))
                .Returns(false);

            bool result = _service.IsTiedTo(1);
            result.Should().Be(false);
            
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(7)]
        public void Test_ProductService_AddEmptyName_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductEmptyName();

            Action action = () => { _service.Add(product); };
            action.Should().Throw<NameIsNullOrEmptyException>();
        }

        [Test]
        [Order(8)]
        public void Test_ProductService_AddLenghName_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductLenghName();

            Action action = () => { _service.Add(product); };
            action.Should().Throw<NameLenghtException>();
        }

        [Test]
        [Order(9)]
        public void Test_ProductService_AddNegativeCostPrice_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductNegativeCostPrice();

            Action action = () => { _service.Add(product); };
            action.Should().Throw<CostPriceNegativeException>();
        }

        [Test]
        [Order(10)]
        public void Test_ProductService_AddSalePriceLowerThan_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductLowerThanSalePrice();

            Action action = () => { _service.Add(product); };
            action.Should().Throw<SalePriceLowerThanException>();
        }

        [Test]
        [Order(11)]
        public void Test_ProductService_AddExpirationLowerThan_ShouldFail()
        {
            Product product = ObjectMother.CreateInvalidProductExpirationLowerThan();

            Action action = () => { _service.Add(product); };
            action.Should().Throw<ExpirationLowerThanException>();
        }

        [Test]
        [Order(12)]
        public void Test_ProductService_AddDuplicatedName_ShouldFail()
        {
            Product product = ObjectMother.CreateValidProduct();

            _mockRepository
                .Setup(pr => pr.Add(product))
                .Throws<DuplicatedNameException>();

            Action action = () => { _service.Add(product); };
            action.Should().Throw<DuplicatedNameException>();
        }

        [Test]
        [Order(13)]
        public void Test_ProductService_UpdateUndefinedId_ShouldFail()
        {
            Product product = ObjectMother.CreateValidProduct();
            product.Id = 0;

            Action action = () => { _service.Update(product); };
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(14)]
        public void Test_ProductService_UpdateDuplicatedName_ShouldFail()
        {
            Product product = ObjectMother.CreateValidProduct();

            _mockRepository
                .Setup(pr => pr.Update(product))
                .Throws<DuplicatedNameException>();

            Action action = () => { _service.Update(product); };
            action.Should().Throw<DuplicatedNameException>();
        }

        [Test]
        [Order(15)]
        public void Test_ProductService_DeleteteUndefinedId_ShouldFail()
        {
            Product product = ObjectMother.CreateValidProduct();
            product.Id = 0;

            Action action = () => { _service.Delete(product); };
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(16)]
        public void Test_ProductService_DeleteTiedProduct_ShouldFail()
        {
            Product product = ObjectMother.CreateValidProduct();

            _mockRepository
                .Setup(pr => pr.Delete(product.Id))
                .Throws<TiedException>();

            Action action = () => { _service.Delete(product); };
            action.Should().Throw<TiedException>();
        }

        [Test]
        [Order(17)]
        public void Test_ProductService_GetUndefinedId_ShouldFail()
        {
            long Id = 0;

            Action action = () => { _service.Get(Id); };
            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        [Order(18)]
        public void Test_ProductService_IsTiedToUndefinedId_ShouldFail()
        {
            long Id = 0;

            Action action = () => { _service.IsTiedTo(Id); };
            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}
