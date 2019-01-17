using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebCoreApplication.Models;
using WebCoreApplication.Models.ViewModel;
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
            var model = controller.List(null, 2).ViewData.Model as ProductsListViewModel;
            var prodArr = model?.Products.ToArray();

            // assert
            Assert.Equal(3, prodArr.Length);
            Assert.Equal("Clock on wall", prodArr[1].Name);
            Assert.Equal("Lamp on table", prodArr[2].Name);

        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            // arrange
            var controller = new Controllers.ProductController (new ModelCompleteFakeRepository() );
            controller.PageSize = 3;
            // act
            var model = controller.List(null, 2).ViewData.Model as ProductsListViewModel;
            var pagingInfo = model?.Paginginfo;

            // assert
            Assert.Equal(2, pagingInfo.CurrentPage);
            Assert.Equal(3, pagingInfo.ItemsPerPage);

            Assert.Equal(6, pagingInfo.TotalItems);
            Assert.Equal(2, pagingInfo.TotalPages);

        }
    }
}
