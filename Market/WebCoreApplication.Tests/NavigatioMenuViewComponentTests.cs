using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Routing;
using Moq;
using WebCoreApplication.Components;
using WebCoreApplication.Models;
using WebCoreApplication.Models.ViewModel;
using WebCoreApplication.Tests.FakeAndMock;
using Xunit;

namespace WebCoreApplication.Tests
{
    public class NavigatioMenuViewComponentTests
    {
        [Theory]
        [InlineData("Cat1")]
        [InlineData("Cat2")]
        [InlineData("Cat3")]
        public void Indicates_Selected_Category(string categoryToSelect)
        {
            // arrange
            var mockRep = new ModelCompleteFakeRepository();
            var target = new NavigationMenuViewComponent(mockRep)
            {
                ViewComponentContext = new ViewComponentContext
                {
                    ViewContext = new ViewContext
                    {
                        RouteData = new RouteData()
                    }
                }
            };

            target.RouteData.Values["category"] = categoryToSelect;

            // act

            string result = (string)(target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];

            // assert
            Assert.Equal(categoryToSelect, result);

        }
    }
}
