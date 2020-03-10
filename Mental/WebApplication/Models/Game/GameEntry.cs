using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Game
{
    /// <summary>
    /// игра
    /// </summary>
    public class GameEntry
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование игры
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание игры
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// путь к картинке главного поля игры
        /// </summary>
        public string ImageGeneralField { get; set; }


        /// <summary>
        /// Создатель игры id
        /// </summary>
        [ForeignKey("ApplicationUser")]
        public string OwnerUserId { get; set; }

        /// <summary>
        /// Создатель игры
        /// </summary>
        public virtual ApplicationUser OwnerUser { get; set; }
    }
}