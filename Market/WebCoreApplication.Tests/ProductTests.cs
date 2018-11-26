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
            // �����������
            var p = new Product { Name = "Test", Price = 1200M };

            //��������
            p.Name = "New Name";

            //�����������
            Assert.Equal("New Name", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            // �����������
            var p = new Product { Name = "Test", Price = 1200M };

            //��������
            p.Price = 200M;

            //�����������
            Assert.Equal(200M, p.Price);
        }
    }
}
