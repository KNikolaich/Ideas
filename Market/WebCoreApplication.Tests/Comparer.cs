using System;
using System.Collections.Generic;
using System.Text;

namespace WebCoreApplication.Tests
{
    public class Comparer
    {
        public static Comparer<U> Get<U>(Func<U, U, bool> func)
        {
            return new Comparer<U>(func);
        }
    }

    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> comparisionFunction;

        public Comparer(Func<T, T, bool> func)
        {
            comparisionFunction = func;
        }

        public bool Equals(T x, T y)
        {
            return comparisionFunction(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}
