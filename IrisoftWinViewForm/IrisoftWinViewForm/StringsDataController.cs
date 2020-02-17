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

        private float CalcAnswer()
        {
            // собираем первую строку в таблицу
            var listFromOneStr = _model.ArticleOne.Split(GetSeparator(_model.ArticleOne), StringSplitOptions.RemoveEmptyEntries).ToList();
            var listFromTwoStr = _model.ArticleTwo.Split(GetSeparator(_model.ArticleTwo), StringSplitOptions.RemoveEmptyEntries).ToList();
          
            int maxCountWords = listFromTwoStr.Count > listFromOneStr.Count ? listFromTwoStr.Count : listFromOneStr.Count;
  
            var countWithoutChangeWords = 0; // кол-во оставленных без изменения слов
            foreach (string str in listFromTwoStr)
            {
                if (listFromOneStr.Contains(str))
                {
                    listFromOneStr.Remove(str);
                    countWithoutChangeWords++;
                }
            }

            if (Equals(maxCountWords, 0f))
            {
                return 1;
            }
            return countWithoutChangeWords / maxCountWords;

        }

        /// <summary>
        /// калькулируем разделительные символы с входных строк
        /// </summary>
        /// <returns>список разделителе не входящих в разрешенные символы</returns>
        private char[] GetSeparator(string article)
        {
            var separatorSet = new SortedSet<char>();

            foreach (char c in article)
            {
                if (!_allowed.Contains(c) && !separatorSet.Contains(c))
                    separatorSet.Add(c);
            }
            return separatorSet.ToArray();
        }

        public float GetAnswer() { return _model.Answer; }
    }
}