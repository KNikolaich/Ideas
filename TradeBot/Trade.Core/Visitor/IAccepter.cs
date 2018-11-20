using System.Configuration;
using DevExpress.Data.Async.Helpers;
using DevExpress.Xpo;

namespace Trader.Visitor
{
    /// <summary> интерфейс принимающего </summary>
    internal interface IAccepter<T> where T : IAccepter<T>
    {
        /// <summary> просто чтобы определить, что этот класс имеет диспетчера для визитеров </summary>
        /// <returns></returns>
        IDispatcher<T> GetDispatcher();

        void Destroy();
    }
}