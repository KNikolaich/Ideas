using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Game
{
    public class GameDbInitializer: DropCreateDatabaseAlways<ContextGame>
    {
        protected override void Seed(ContextGame db)
        {

            db.Walkers.Add(new Walker { Name = "First", Description = "Ходим по шагам, просаем кубики.", ImageGeneralField = "/Content/img/game1/field1.jpg" });
            base.Seed(db);
        }
    }
}