using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Configuration.Models
{
    public class Entry : IComparable<Entry>
    {
        public int Queue { get; set; }
        public string StrValue { get; set; }
        
        public string Comment { get; set; }
        public string CommentForValue { get; set; }

        public string CommentForQueue { get; set; }

        //        [XmlElement(Type = typeof(string)),
        //         XmlElement(Type = typeof(int))]
        //        public object[] StringsAndInts;


        public int CompareTo(Entry other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            var compareQueue = Queue.CompareWith(other.Queue);
            if (compareQueue != 0) return compareQueue;

            var strValueComparison = string.Compare(StrValue, other.StrValue, StringComparison.Ordinal);
            if (strValueComparison != 0) return strValueComparison;
            var commentComparison = string.Compare(Comment, other.Comment, StringComparison.Ordinal);
            if (commentComparison != 0) return commentComparison;
            var commentForValueComparison = string.Compare(CommentForValue, other.CommentForValue, StringComparison.Ordinal);
            if (commentForValueComparison != 0) return commentForValueComparison;
            return string.Compare(CommentForQueue, other.CommentForQueue, StringComparison.Ordinal);
        }

        public string InvalidMessage()
        {
            var strRes = "";
            if (this.Queue < -1 || Queue > 100 || Queue == 0)
                strRes += $"Ошибка в строке {Queue} - номер не может выходить за границы значений или быть = 0";
            foreach (var valCh in StrValue)
            {
                if (!char.IsLetter(valCh) || valCh.Equals(' '))
                {
                    strRes += (string.IsNullOrEmpty(strRes) ? $"Ошибка в строке {Queue}" : Environment.NewLine + "\t\t\t") +" - текст должен состоять из букв латиницы и не иметь пробелов";
                }
            }
            return strRes;
        }

        public override string ToString()
        {
            return $"{Queue} - {StrValue} {InvalidMessage()}";
        }
    }
}
