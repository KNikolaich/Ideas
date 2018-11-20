using System.Collections.Generic;

namespace Trader.Visitor
{
    /// <summary>
    /// Диспетчера интерфейс
    /// </summary>
    internal interface IDispatcher<T>  where T : IAccepter<T>
    {

        /// <summary> словарь сообщений от всех визитеров </summary>
        Dictionary<VisitorBase<T>, List<string>> VisiterToMessages { get; }

        /// <summary> Прием </summary>
        /// <param name="acceptedObject"></param>
        void Accept(T acceptedObject);

        /// <summary>
        /// обязаны поддержать самоуничтожение (чистим сообщений листы)
        /// </summary>
        void Destroy();
    }
}