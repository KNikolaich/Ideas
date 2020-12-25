using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Configuration.Helpers
{
    public static class ElementHelper
    {
        /// <summary>
        /// Добавляем комментарий существующему элементу
        /// </summary>
        internal static void SetCommentForElement(this XElement element, string comments)
        {
            var commentEl = element.PreviousNode as XComment;
            if (commentEl == null)
            {
                if (!string.IsNullOrEmpty(comments))
                    element.AddBeforeSelf(new XComment(comments));
            }
            else if (commentEl.Value != comments)
            {
                commentEl.Value = comments;
            }
        }

        /// <summary>
        /// Добавляем элемент внутрь существующего (если надо, с комментарием)
        /// </summary>
        internal static XElement AddSubElement(this XElement owner, string elementName, Object subSubElement, string comments)
        {
            if (!string.IsNullOrEmpty(comments))
                owner.Add(new XComment(comments));

            var xElement = new XElement(elementName, subSubElement);
            owner.Add(xElement);
            return xElement;
        }

        /// <summary>
        /// Удаляем элемент и его комментарий
        /// </summary>
        internal static void RemoveElementAndComment(this XElement strEl)
        {
            if (strEl.PreviousNode?.NodeType == XmlNodeType.Comment)
            {
                strEl.PreviousNode.Remove();
            }
            strEl.Remove();
        }

        /// <summary> Поиск элемента-комментария </summary>
        internal static XComment FindCommentElement(this XElement strEl, string commentForFind)
        {
            if (strEl == null || string.IsNullOrEmpty(commentForFind))
            {
                return null;
            }
            return strEl.Nodes().
                Where(n => n.NodeType == XmlNodeType.Comment).OfType<XComment>().
                FirstOrDefault(comment => comment.Value.Contains(commentForFind));
        }
    }
}
