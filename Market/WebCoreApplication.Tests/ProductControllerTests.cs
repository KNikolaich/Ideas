using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebCoreApplication.Models;
using WebCoreApplication.Tests.FakeAndMock;
using Xunit;

namespace WebCoreApplication.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void List2_Get_Paginate()
        {
            // arrange
            var controller = new Controllers.ProductController (new ModelCompleteFakeRepository() );
            controller.PageSize = 3;
            // act
            var viewResult = controller.List(2) as ViewResult;
            var model = viewResult?.ViewData.Model as IEnumerable<Product>;
            var prodArr = model.ToArray();

            // assert
            Assert.Equal(3, prodArr.Length);
            Assert.Equal("Clock on wall", prodArr[1].Name);
            Assert.Equal("Lamp on table", prodArr[2].Name);

        }
    }
}
