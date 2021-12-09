using Binance.API.Csharp.Client.Models.Enums;

namespace SaverToDb.Db
{
    public class Candlestick
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string TimeInterval { get; set; }
        public long OpenTime { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
        public long CloseTime { get; set; }
        public decimal QuoteAssetVolume { get; set; }
        public int NumberOfTrades { get; set; }
        public decimal TakerBuyBaseAssetVolume { get; set; }
        public decimal TakerBuyQuoteAssetVolume { get; set; }

        public static Candlestick CreateFromStick(Binance.API.Csharp.Client.Models.Market.Candlestick stick, string symbol, TimeInterval timeInterval)
        {
            return new Candlestick
            {
                Symbol = symbol,
                TimeInterval = timeInterval.ToString(),
                Close = stick.Close,
                Open = stick.Open,
                CloseTime = stick.CloseTime,
                High = stick.High,
                Low = stick.Low,
                NumberOfTrades = stick.NumberOfTrades,
                OpenTime = stick.OpenTime,
                QuoteAssetVolume = stick.QuoteAssetVolume,
                TakerBuyBaseAssetVolume = stick.TakerBuyBaseAssetVolume,
                TakerBuyQuoteAssetVolume = stick.TakerBuyQuoteAssetVolume,
                Volume = stick.Volume
            };
        }
        public Binance.API.Csharp.Client.Models.Market.Candlestick MapToStick()
        {
            return new Binance.API.Csharp.Client.Models.Market.Candlestick
            {
                Close = Close,
                Open = Open,
                CloseTime = CloseTime,
                High = High,
                Low = Low,
                NumberOfTrades = NumberOfTrades,
                OpenTime = OpenTime,
                QuoteAssetVolume = QuoteAssetVolume,
                TakerBuyBaseAssetVolume = TakerBuyBaseAssetVolume,
                TakerBuyQuoteAssetVolume = TakerBuyQuoteAssetVolume,
                Volume = Volume
            };
        }
    }
}
