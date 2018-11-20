namespace Binance.API.Csharp.Client.Models.Market
{
    public class OrderBookOffer
    {
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public override string ToString()
        {
            return $"Price: {Price.ToString("G7")}, Quantity: {Quantity.ToString("G7")}";
        }
    }
}
