using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebCoreApplication.Data;
using WebCoreApplication.Infrastructure;

namespace WebCoreApplication.Models
{
    public class SessionCart : Cart
    {
        private const string SessionKey = "Cart";

        [JsonIgnore]
        public ISession Session { get; private set; }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson(SessionKey, this);
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson(SessionKey, this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove(SessionKey);
        }

        public static Cart GetCart(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var cart = session?.GetJson<SessionCart>(SessionKey) ?? new SessionCart();
            cart.Session = session;

            var timer = services.GetRequiredService<ITimerStarter>();
            return cart;
        }
    }
}
