using DonaLaura.Domain.Features.Products;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace DonaLaura.Domain.Tests.Features
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        public void Test_ProductValidate()
        {
            Product product = new Product()
            {
                
            };

            Action action = product.Validate;
            action.Should().NotThrow<Exception>();
        }
    }
}
