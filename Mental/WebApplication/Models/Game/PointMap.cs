using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models.Game
{
    /// <summary> Точка на карте </summary>
    public class PointMap
    {
        public PointMap(int x, int y, int? delay = null)
        {
            X = x;
            Y = y;
            Delay = delay;
        }

        public int Id { get; set; }

        [DisplayName("X координата точки")]
        public int X { get; set;}

        [DisplayName("Y координата точки")]
        public int Y { get; set; }

        [DisplayName("Задержка перед следующим ходом")]
        public int? Delay { get; set; }

        [DisplayName("Ссылка на следующую точку"), ForeignKey("PointMap")]
        public int? LinkNextPointMapId { get; set; }

        [DisplayName("Ссылка на следующую точку")]
        public PointMap LinkNextPointMap { get; set; }

        [ForeignKey("Walker")]
        public int GameEntryId { get; set; }

        public virtual GameEntry GameEntry { get; set; }

    }
}