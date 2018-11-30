using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebCoreApplication.Models;
using Xunit;

namespace WebCoreApplication.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionModelIsComplete()
        {
            // arrange
            var controller = new Controllers.HomeController();
            controller.Repository = new ModelCompleteFakeRepository();

            // act
            var viewResult = controller.Index() as ViewResult;
            var model = viewResult?.ViewData.Model as IEnumerable<Product>;

            // assert
            var comparer = Comparer.Get<Product>(((product1, product2) => product1.Name == product2.Name && product1.Price == product2.Price));
            Assert.Equal(SimpleRepository.SharedRepository.Products.OrderBy(p =>p.Name), model?.OrderBy(p => p.Name), comparer);
        }

        [Fact]
        public void IndexActionModelIsCompletePricesUnder50()
        {
            // arrange

            var fakeRepository = new ModelCompleteFakeRepository(p => p.Price < 50m);

            var controller = new Controllers.HomeController();
            controller.Repository = fakeRepository;

            // act
            var viewResult = controller.Index() as ViewResult;

            var listFromModel = (viewResult?.ViewData.Model as IEnumerable<Product>)?.OrderBy(p => p.Name);
            var list1 = fakeRepository.Products.OrderBy(p => p.Name);

            // assert
            var comparer = Comparer.Get<Product>(((product1, product2) => product1.Name == product2.Name && product1.Price == product2.Price));
            Assert.Equal(list1, listFromModel, comparer);
        }

        [Theory]
        [InlineData(275, 48.95, 19.5, 24.95)]
        [InlineData(5, 48.95, 19.5, 24.95)]
        public void IndexActionManyModelIsComplete(decimal price1, decimal price2, decimal price3, decimal price4)
        {
            // arrange
            var products = new List<Product>
            {
                new Product {Name = "P1", Price = price1},
                new Product {Name = "P2", Price = price2},
                new Product {Name = "P3", Price = price3},
                new Product {Name = "P4", Price = price4},
            };

            var fakeRepository = new ModelCompleteFakeRepository(products);
            
            var controller = new Controllers.HomeController
            {
                Repository = fakeRepository
            };


            // act
            var viewResult = controller.Index() as ViewResult;
            var listFromModel = (viewResult?.ViewData.Model as IEnumerable<Product>)?.OrderBy(p => p.Name);
            var list1 = fakeRepository.Products.OrderBy(p => p.Name);

            // assert
            var comparer = Comparer.Get<Product>(((product1, product2) => product1.Name == product2.Name && product1.Price == product2.Price));
            Assert.Equal(list1, listFromModel, comparer);
        }
    }
}
