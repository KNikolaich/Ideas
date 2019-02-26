using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebCoreApplication.Controllers;
using WebCoreApplication.Models;
using Xunit;

namespace WebCoreApplication.Tests
{
    public class OrderControllerTests
    {
        [Fact]
        public void Cannot_Checkout_Empty_Cart()
        {
            // Организация - создание имитированн ого хранилища заказов
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            // Организация - создание пустой корзины
            Cart cart = new Cart();
            // Организация - создание заказа
            Order order = new Order();
            // Организация - создание экземпля р а контроллера
            OrderController target = new OrderController(mock.Object, cart);
            // Действие
            ViewResult result = target.Checkout(order) as ViewResult;
            // Утверждение - проверка , что заказ не был сохранен
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
            // Утверждение - проверка , что метод возвращает стандартное
            // представление
            Assert.True(string.IsNullOrEmpty(result.ViewName));
            // Утверждение - проверка , что представлению передана
            // недопустимая модель
            Assert.False(result.ViewData.ModelState.IsValid);
        }

        [Fact]
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            //Организация - создание имитированного хранилища заказов
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            // Организация - создание корзины с одним элементом
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            //Организация - создание экземпляра контроллера
            OrderController target = new OrderController(mock.Object, cart);
            //Организация - добавление ошибки в мо д ель
            target.ModelState.AddModelError("error", "error");
            // Действие - попытка перехода к оплате
            ViewResult result = target.Checkout(new Order()) as ViewResult;
            // Утверждение - проверка , что заказ не был сохранен
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
            //Утверждение - проверка , что метод возвращает стандартное
            //представление
            Assert.True(string.IsNullOrEmpty(result.ViewName));
            //Утверждение - проверка , что представлению передается
            //не д опустимая модель
            Assert.False(result.ViewData.ModelState.IsValid);
        }

        [Fact]
        public void CanCheckout_And_Submit_Order()
        {
            //Организация - создание имитированного хранилища заказов
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            //Организация - создание корзины с одним элементом
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            //Организация - соз д ание экземпляра контроллера
            OrderController target = new OrderController(mock.Object, cart);
            // Действие - попытка перехода к оплате
            RedirectToActionResult result =
                target.Checkout(new Order()) as RedirectToActionResult;
            //Утверждение - проверка , что заказ был сохранен
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Once);
            //Утверждение - проверка , что ме т од перенаправляется на действие Completed
            Assert.Equal("Completed", result.ActionName);
        }
    }
}
