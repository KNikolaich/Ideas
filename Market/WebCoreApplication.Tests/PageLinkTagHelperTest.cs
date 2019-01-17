using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using WebCoreApplication.Infrastructure;
using WebCoreApplication.Models.ViewModel;
using Xunit;

namespace WebCoreApplication.Tests
{
    public class PageLinkTagHelperTest
    {
        [Fact]
        public void Can_Generate_Page_Links()
        {
            var urlHelper = new Mock<IUrlHelper>();
            urlHelper.SetupSequence(x => x.Action(It.IsAny<UrlActionContext>()))
                .Returns("Test/Pagel")
                .Returns("Test/Page2")
                .Returns("Test/PageЗ");
            var urlHelperFactory = new Mock<IUrlHelperFactory>();
            urlHelperFactory.Setup(f =>
                    f.GetUrlHelper(It.IsAny<ActionContext>()))
                .Returns(urlHelper.Object);
            PageLinkTagHelper helper =
                new PageLinkTagHelper(urlHelperFactory.Object)
                {
                    PageModel = new PagingInfo
                    {
                        CurrentPage = 2,
                        TotalItems = 28,
                        ItemsPerPage = 10,
                    },
                    PageAction = "Test"
                };

            TagHelperContext ctx = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "");
            var content = new Mock<TagHelperContent>();
            TagHelperOutput output = new TagHelperOutput("div", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult(content.Object));
            //Действие"+
            helper.Process(ctx, output);
            // Утверждение <a href="Test/Pagel">1</a><a href="Test/Page2">2</a><a href="Test/Page&#x417;">3</a><a href="Test/Pagel">1</a><a href="Test/Page2">2</a><a href="Test/Page&#x417;">3</a><a href="Test/Pagel">1</a><a href="Test/Page2">2</a><a href="Test/Page&#x417;">3</a>
            Assert.Equal(@"<a href=""Test/Pagel""></a><a href=""Test/Page2""></a><a href=""Test/Page&#x417;""></a>",
                output.Content.GetContent());

        }
    }
}
