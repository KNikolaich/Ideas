using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreApplication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCoreApplication.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart _cart;

        public CartSummaryViewComponent(Cart cart)
        {
            _cart = cart;
        }

        /// <summary>
        /// Состояние корзины на экран
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync() => View(_cart);
    }
}
