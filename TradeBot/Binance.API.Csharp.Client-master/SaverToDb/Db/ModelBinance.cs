using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.Helpers;

namespace SaverToDb.Db
{
    public partial class ModelBinance : DbContext
    {

        public DbSet<Candlestick> Candlesticks { get; set; }

        static ModelBinance()
        {
            Database.SetInitializer<ModelBinance>(null);
        }

        public ModelBinance()
            : base("name=ModelBinance")
        {
            
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static List<Binance.API.Csharp.Client.Models.Market.Candlestick> GetCandleSticks(string paramPair, TimeInterval paramPeriod, DateTime paramStart, DateTime paramEnd)
        {
            var modelBinance = new ModelBinance();
            var dStarte = Converters.GeDateTime(paramStart);
            var dEnd = Converters.GeDateTime(paramEnd);

            var candlesticks = modelBinance.Candlesticks.Where(c =>

                c.Symbol == paramPair && c.TimeInterval == paramPeriod.ToString() &&
                c.OpenTime >= dStarte && c.CloseTime <= dEnd
            ).ToList();//
            //var candlesticks = modelBinance.Candlesticks.ToList();
            return candlesticks.Select(c=>c.MapToStick()).ToList();
        }
    }
}
