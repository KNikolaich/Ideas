using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Game
{
    /// <summary>
    /// Игра - Бродилка
    /// </summary>
    public class Walker : GameEntry
    {
        public virtual List<PointMap> PointsList { get; set; }
    }
}