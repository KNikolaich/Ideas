using System.Collections.Generic;

namespace Trader.Visitor
{
    /// <summary> базовый класс паттерна Визитер </summary>
    /// <remarks> визитер, - делает обход по классам, для которых он предназначен
    /// Во время обхода он их обрабатывает и собирает результаты обхода</remarks>
    internal abstract class VisitorBase<T> where T: IAccepter<T>
    {
        /// <summary>
        /// базовый класс паттерна Визитер
        /// </summary>
        internal VisitorBase()
        {
            Messages = new List<string>();
            NeedAccept = false; // умолчания можно сохранять в БД, но пока мы только нужных визитеров пишем.
        }

        /// <summary> массив сообщений от визитера </summary>
        internal List<string> Messages { get; }

        /// <summary>
        /// Необходимо посещение
        /// </summary>
        public virtual bool NeedAccept { get; set; }

        /// <summary> добавить сообщение </summary>
        /// <remarks>на случай более крутой обработки добавления сообщения</remarks>
        protected void AddMessage(string message)
        {
            Messages.Add(message);
        }

        /// <summary> Посетить </summary>
        /// <param name="iAccepted">посещаемый</param>
        internal abstract void Accept(T iAccepted);
    }
}
