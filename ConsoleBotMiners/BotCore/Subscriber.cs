
namespace BotCore
{
    public class Subscriber
    {
        public Subscriber()
        {
            Level = SubscribeLevelEnum.Info;
        }

        public long ChatId { get; set; }

        public SubscribeLevelEnum Level { get; set; }

        public override string ToString()
        {
            return $"Установки для подписчика: Уровень информации - {Level};";
        }
    }
}
