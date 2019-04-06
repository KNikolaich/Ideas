using System;

namespace WebCoreApplication.Infrastructure
{
    /// <summary> атрибутируем лайаут </summary>
    public class ViewLayoutAttribute : Attribute
    {
        /// <summary> ограничиваем наш атрибут одним конструктором </summary>
        /// <param name="layoutName"></param>
        public ViewLayoutAttribute(string layoutName)
        {
            LayoutName = layoutName;
        }

        /// <summary> имя лайаута </summary>
        public string LayoutName { get; }
    }
}
