using System;
using WebCoreApplication.Models;
using Xunit;

namespace WebCoreApp.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            // организация
            var p = new Product {Name = "Test", Price = 1200M};

            //Действие
            p.Name = "New Name";

            //Утверждение
            Assert.Equal("New Name", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            // организация
            var p = new Product { Name = "Test", Price = 1200M };

            //Действие
            p.Price = 200M;

            //Утверждение
            Assert.Equal(200M, p.Price);
        }
    }
}
