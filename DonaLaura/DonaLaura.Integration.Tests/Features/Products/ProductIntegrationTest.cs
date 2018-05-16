using DonaLaura.Applications.Features;
using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features.Products;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Products.Exceptions;
using DonaLaura.Infra.Data.Features.Products;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DonaLaura.Integration.Tests.Features.Products
{
    [TestFixture]
    public class ProductIntegrationTest
    {
        ProductRepository _productRepository;
        ProductService _productService;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _productRepository = new ProductRepository();
            _productService = new ProductService(_productRepository);
        }

        /*TESTES CAMINHO FELIZ*/
        [Test]
        [Order(1)]
        public void Test_ProductIntegration_Add_ShouldBeOk()
        {
            Product product = ObjectMother.CreateValidProduct();

            _productService.Add(product);

            IList<Product> products = _productService.GetAll();
            products[1].Should().NotBeNull();
            products[1].Name.Should().Be(product.Name);
        }

        [Test]
        [Order(2)]
        public void Test_ProductIntegration_Update_ShouldBeOk()
        {
            Product product = ObjectMother.CreateValidProduct();

            _productService.Update(product);

            Product newProduct = _productService.Get(product.Id);
            newProduct.Name.Should().Be("Creme");
        }

        [Test]
        [Order(3)]
        public void Test_ProductIntegration_Delete_ShouldBeOk()
        {
            Product product = ObjectMother.CreateValidProduct();
            product.Id = 11;

            _productService.Delete(product);

            product = _productService.Get(11);
            product.Should().Be(null);
        }

        [Test]
        [Order(4)]
        public void Test_ProductIntegration_Get_ShouldBeOk()
        {
            Product product = _productService.Get(1);
            product.Should().NotBeNull();
            product.Name.Should().Be("Sabonete");
        }

        [Test]
        [Order(5)]
        public void Test_ProductIntegration_GetAll_ShouldBeOk()
        {
            IList<Product> products = _productService.GetAll();
            products.Count.Should().Be(1);
            products[0].Name.Should().Be("Sabonete");
        }

        [Test]
        [Order(6)]
        public void Test_ProductIntegration_IsTiedTo_ShouldBeOk()
        {
            bool result = _productService.IsTiedTo(1);
            result.Should().Be(true);
        }

        /*TESTES ALTERNATIVOS*/
        [Test]
        [Order(7)]
        public void Test_ProductIntegrationTest_AddDuplicatedName_ShouldFail()
        {
            Product product = ObjectMother.CreateValidProduct();
            product.Name = "Sabonete";

            Action action = () => _productService.Add(product);
            action.Should().Throw<DuplicatedNameException>();
        }

        [Test]
        [Order(8)]
        public void Test_ProductIntegration_UpdateDuplicatedName_ShouldFail()
        {
            Product product = ObjectMother.CreateValidProduct();
            product = _productRepository.Add(product);
            product.Name = "Sabonete";

            Action action = () => _productService.Update(product);
            action.Should().Throw<DuplicatedNameException>();
        }
    }
}
