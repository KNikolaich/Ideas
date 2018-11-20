namespace Trader.Model
{
    public enum StyleCandleEnum
    {
        Dogi,
        Bear,
        Bovine
    }

    public enum KindCandleEnum
    {
        Undefine,
        // топор - тело свечи все вверху и минимум в 2 раза меньше тени внизу. цвет не важен. сам топор внизу графа
        Hammer,

        //повешенный - аналог топора, но наверху графа ()
        Hanged,
        
    }
}
