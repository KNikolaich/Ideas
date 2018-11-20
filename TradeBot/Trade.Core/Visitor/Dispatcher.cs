using System.Collections.Generic;

namespace Trader.Visitor
{
    /// <summary>
    /// Диспетчер визитеров
    /// </summary>
    /// <typeparam name="T">тип объектов для визита</typeparam>
    /// <remarks>направляет каждому объекту нужных/полезных ему визитеров</remarks>
    internal class Dispatcher<T> : List<VisitorBase<T>>, IDispatcher<T> where T : IAccepter<T>
    {
        internal Dispatcher()
        {
            VisiterToMessages = new Dictionary<VisitorBase<T>, List<string>>();
        }


        /// <summary> словарь сообщений от всех визитеров </summary>
        public Dictionary<VisitorBase<T>, List<string>> VisiterToMessages { get; }

        /// <summary> запуск посещений </summary>
        /// <param name="acceptedObject">посещаемый объект</param>
        public void Accept(T acceptedObject)
        {
            foreach (var visitor in this)
            {
                if (visitor.NeedAccept)
                {
                    visitor.Accept(acceptedObject);
                    if (visitor.Messages.Count > 0)
                    {
                        if (VisiterToMessages.ContainsKey(visitor))
                        {
                            VisiterToMessages[visitor] = visitor.Messages;
                        }
                        else
                        {
                            VisiterToMessages.Add(visitor, visitor.Messages);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// разрушение диспетчера
        /// </summary>
        public void Destroy()
        {
            foreach (var visiterToMessage in VisiterToMessages)
            {
                visiterToMessage.Key.Messages.Clear();
                visiterToMessage.Value.Clear();
            }

            VisiterToMessages.Clear();
            Clear();
        }
    }
}
