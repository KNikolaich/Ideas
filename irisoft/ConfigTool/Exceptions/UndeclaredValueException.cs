using System;

namespace Configuration.Exceptions
{
    /// <summary>
    /// Исключение типа "незадекларированное значение"
    /// </summary>
    internal class UndeclaredValueException : Exception
    {
        public UndeclaredValueException(string message) : base(message)
        {
        }
    }
}
