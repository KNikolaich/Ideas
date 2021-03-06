﻿using System;
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
                {"", ""},
                {"полное совпадение", "полное совпадение"},
                {"полное совпадение", "совпадение полное"},
                {"полнОе совпАдение", "СОвпадение пОлное"},
                {"[полное!~~~$%^****совпадение]", "(полное№;%::()*совпадение("},
                {"Съешь же ещё этих мягких французских булок да выпей чаю", "мягких ЖЕ франЦузских булОк ещЁ этИх Съешь да выПей ЧАЮ"},
            };
        }


        /// <summary>
        /// тут коллекция на половину совпадающих строк
        /// все тесты должны давать cовпадение = 0.5
        /// </summary>
        public static TheoryData<string, string> Differents50PercentStrings()
        {
            return new TheoryData<string, string>
            {
                {"1 2", "1;№$"},
                {"1 2", ";№$2]["},
                {"1 2", "1;№$2][3()*&!   4"},
                {"1 2", "()*4&!   3;№$2][1"},
                {"1.2", "1"},
                {"1.2", "2"},
                {"1.2", "1.2.3.4"},
                {"1.2", "4 1  3 2 "},

                {"1", "1.1"},
                {"1 1", "1.1 1.1"},
                {"1", "1.2"},
                {"2", "1.2"},
                {"1.2.3.4", "1.2"},
                {"4 1  3 2 ", "1.2"},
            };
        }

        /// <summary>
        /// тут коллекция полностью не совпадающих строк
        /// все тесты должны давать cовпадение = 0
        /// </summary>
        public static TheoryData<string, string> FullDifferentsStrings()
        {
            return new TheoryData<string, string>
            {
                {"1 2", "3;№$"},
                {"1 3", ";№$─©2]["},
                {"9 5", "1;№$2][3()*&!   4"},
                {"9 4321", "()*4&!   3;№$2][1"},
                {"2.2", "1"},
                {"1.3", "2"},
                {"34.12", "1.2.3.4"},
                {"12.34", "4 1  3 2 "},
                {"3412", "1.2.3.4"},
                {"1234", "4 1  3 2 "},
            };
        }
    }
}
