using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Configuration.Exceptions
{

    /// <summary>
    /// Исключение типа "не уникальное значение"
    /// </summary>
    internal class UnuniqueValueException : Exception
    {
        public UnuniqueValueException(string message) : base(message)
        {
        }

        /// <summary>
        /// Проверка на уникальность значений
        /// </summary>
        /// <param name="values">список значений</param>
        /// <param name="collectionName">название проверяемой коллекции</param>
        /// <param name="onlyWarning">ограничиваться предупреждением</param>
        public static bool Validate(IEnumerable<string> values, string collectionName, bool onlyWarning = false)
        {
            List<string> exceptionList = new List<string>();
            
            List<string> oldValues = new List<string>();
            foreach (var value in values)
            {
                if(!oldValues.Contains(value))
                    oldValues.Add(value);
                else if(!exceptionList.Contains(value))
                {
                    exceptionList.Add(value);
                }
            }
            if (exceptionList.Count > 0)
            {
                var message = $"Коллекция '{collectionName}' не прошла проверку уникальности{Environment.NewLine}" +
                              $"Есть {(exceptionList.Count > 1 ? "повторные значения" : "повторное значение")} {exceptionList.Aggregate("", (current, valEx) => current + (" " + valEx + ",")).TrimEnd(',')}." +
                              $"{Environment.NewLine}Сохранение невозможно.";
                if (!onlyWarning)
                {
                    throw new UnuniqueValueException(message);
                }
                return MessageBox.Show(message, "Исправьте значение.", MessageBoxButtons.OK) == DialogResult.OK;
            }
            return true;
        }
    }
}
