using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControllerTest
{
    public partial class StringsDataControllerTest
    {

        /// <summary>
        /// тут коллекция совпадающих строк
        /// все тесты должны давать полное повпадение = 1
        /// </summary>
        public static TheoryData<string, string> EqualsStrings()
        {
            return new TheoryData<string, string>
            {
                {"полное совпадение", "полное совпадение"},
                {"полное совпадение", "совпадение полное"},
            };
        }
    }
}
