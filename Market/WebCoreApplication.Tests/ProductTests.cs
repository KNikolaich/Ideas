using System;
using WebCoreApplication.Models;
using Xunit;

namespace WebCoreApplication.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            // организация Arrange
            var p = new Product { Name = "Test", Price = 1200M };

            //Действие Act
            p.Name = "New Name";

            //Утверждение Assert
            Assert.Equal("New Name", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            // организация Arrange
            var p = new Product { Name = "Test", Price = 1200M };

            //Действие Act
            p.Price = 200M;

            //Утверждение Assert
            Assert.Equal(200M, p.Price);
        }
    }
}
