using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

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

    }
}
