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
            var controller = new Controllers.HomeController();
            controller.Repository = new ModelCompleteFakeRepository(p=>p.Price <50m);

            // act
            var viewResult = controller.Index() as ViewResult;
            var model = viewResult?.ViewData.Model as IEnumerable<Product>;

            // assert
            var comparer = Comparer.Get<Product>(((product1, product2) => product1.Name == product2.Name && product1.Price == product2.Price));
            Assert.Equal(new ModelCompleteFakeRepository(p => p.Price < 50m).Products.OrderBy(p => p.Name), model?.OrderBy(p => p.Name), comparer);
        }
    }
}
