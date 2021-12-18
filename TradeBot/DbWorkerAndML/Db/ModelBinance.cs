using System;
using System.Collections.Generic;
using System.Linq;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.Helpers;
using DbWorkerAndML.Model;
using Microsoft.EntityFrameworkCore;

namespace DbWorkerAndML.Db
{
    public partial class ModelBinance : DbContext
    {

        public DbSet<Candlestick> Candlesticks { get; set; }


        public ModelBinance()
        {
            //CreateIfNotExists();
        }

        public ModelBinance(bool withValidDb = true): this()
        {
            if(withValidDb)
                CreateIfNotExists();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constants.SqlConnectionIntegratedSecurity);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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

        public void CreateIfNotExists()
        {
            bool isAvalaible = Database.CanConnect();
            // bool isAvalaible2 = await db.Database.CanConnectAsync();
            if (isAvalaible) Console.WriteLine("База данных доступна");
            else Console.WriteLine("База данных не доступна");

            bool isCreated = Database.EnsureCreated();
            // bool isCreated2 = await db.Database.EnsureCreatedAsync();
            if (isCreated) Console.WriteLine("База данных была создана");
            else Console.WriteLine("База данных уже существует");
        }
    }
}
