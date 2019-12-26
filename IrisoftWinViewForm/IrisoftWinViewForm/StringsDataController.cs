using System;
using System.Collections.Generic;
using System.Linq;

namespace IrisoftWinViewForm
{
    public class StringsDataController
    {
        private readonly StringsDataModel _model;
        private readonly List<char> _allowed;

        public StringsDataController(StringsDataModel model)
        {
            _model = model;
            _allowed = new List<char> { 'ё' }; // забыли про неё чтоли в майкрософте
            _allowed.AddRange(Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c));
            _allowed.AddRange(Enumerable.Range('0', '9' - '0' + 1).Select(c => (char)c));
            _allowed.AddRange(Enumerable.Range('а', 'я' - 'а' + 1).Select(c => (char)c));
            
            _model.Answer = CalcAnswer();
        }

        private double CalcAnswer()
        {
            var separator = GetSeparator();

            // собираем первую строку в таблицу
            var listFromOneStr = _model.ArticleOne.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            var stringsTwo = _model.ArticleTwo.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            // выкидываем полные совпадения
            //var stringsTwoCount = stringsTwo.Count; // изначальное кол-во слов
            var countWithoutChangeWords = 0; // кол-во оставленных без изменения слов
            for (int index = stringsTwo.Count - 1; index >= 0; index--)
            {
                string str = stringsTwo[index];
                if (listFromOneStr.Contains(str))
                {
                    listFromOneStr.Remove(str);
                    //stringsTwo.RemoveAt(index);
                    countWithoutChangeWords++;
                }
            }
            
            double maxCountWords = stringsTwo.Count > listFromOneStr.Count ? stringsTwo.Count : listFromOneStr.Count;

            if (Equals(maxCountWords, (double)0))
            {
                return 1;
            }
            return countWithoutChangeWords / maxCountWords;
/*            if (hs.Count > 0) // были удалены/заменены какие то слова
            {
                
            }
            if (stringsTwo.Count > 0) // были добавлены/заменены какие то слова
            {
                
            }
            */

        }

        /// <summary>
        /// калькулируем разделительные символы с входных строк
        /// </summary>
        /// <returns></returns>
        private char[] GetSeparator()
        {
            var separatorSet = new SortedSet<char>();

            foreach (char c in _model.ArticleOne)
            {
                if (!_allowed.Contains(c) && !separatorSet.Contains(c))
                    separatorSet.Add(c);
            }
            foreach (char c in _model.ArticleTwo)
            {
                if (!_allowed.Contains(c) && !separatorSet.Contains(c))
                    separatorSet.Add(c);
            }
            var separator = separatorSet.ToArray();
            return separator;
        }

        public double GetAnswer() { return _model.Answer; }
    }
}