using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Configuration.Helpers;
using Configuration.Properties;

namespace Configuration.Controls
{
    public partial class AbonentControl : ElementBaseControl
    {
        // в словаре положены скрытые элементы, к которым биндятся контролы key - предыдущий элемент; value - список идущих подряд скрытых
//        readonly List<XElement> _dictHiddenElements = new List<XElement>();

        public AbonentControl()
        {
            InitializeComponent();
        }

        public override void SetElement(XElement xElement, int locationEditorX = 180)
        {
            _currentElement = xElement;
            ValidateHiddenLastElements();
            EnqueueHiddenElements(Assistant.GetInstance());
            var subXElements = xElement.Elements().Reverse();
            AddControllsByElements(subXElements);
        }

        /// <summary>
        /// Проверяем нет ли скрытых последни элементов
        /// </summary>
        private void ValidateHiddenLastElements()
        {
            var last = _currentElement.Nodes().Last();
            if (last is XComment)
            {
                ValidCommentForHiddenTag((XComment)last);
            }
            //var nodes = _currentElement.Nodes().Reverse();
//
//            foreach (var node in nodes)
//            {
//                if (node is XComment)
//                {
//                    ValidCommentForHiddenTag((XComment) node);
//                }
//                else
//                {
//                    break;
//                }
//            }
        }

        internal void AddControllsByElements(IEnumerable<XElement> subXElements)
        {

            var assistant = Assistant.GetInstance();
            SuspendLayout();
            foreach (var subXElement in subXElements)
            {
                InsertControlForXElement(subXElement);
                EnqueueHiddenElements(assistant);
            }
            ResumeLayout(false);
            PerformLayout();
        }

        private void EnqueueHiddenElements(Assistant assistant)
        {
            if (assistant.QueueHiddenTag.Count > 0)
            {
                var list = FillListHiddenElement(assistant);
                //_dictHiddenElements.AddRange(list);
                foreach (var xNode in list)
                {
                    InsertControlForXElement(xNode.LastNode as XElement);
                }
            }
        }

        private  List<XElement> FillListHiddenElement(Assistant assistant)
        {
            List<XElement> elements = new List<XElement>();
            var count = assistant.QueueHiddenTag.Count;
            for (int index = 0; index < count; index++)
            {
                var hidPair = assistant.QueueHiddenTag.Dequeue();
                string value = null;
                if (_currentElement != null)
                {
                    var openTag = $"<{hidPair.Key}>";
                    var closeTag = $"</{hidPair.Key}>";
                    var commentHiddenTag = _currentElement.FindCommentElement(closeTag); // ищим коммент с закрывающим тэгом, это значит, данный стрытый тэг, сцука, со значением
                    if (commentHiddenTag != null)
                    {
                        value = commentHiddenTag.Value.Replace(openTag, "").Replace(closeTag, "").Trim();
                    }
                }
                if (!string.IsNullOrEmpty(hidPair.Value))
                {
                    elements.Add(new XElement("hidden", new XComment(hidPair.Value), new XElement(hidPair.Key, value)));
                }
                else
                {
                    elements.Add(new XElement("hidden", new XElement(hidPair.Key, value)));
                }
            }
            return elements;
        }

        private void InsertControlForXElement(XElement subXElement)
        {
            var subElemControl = ControlCreator.GetSubElemControl(subXElement, Controls.Count.ToString(), 140);
            subElemControl.Dock = DockStyle.Top;
            if (Settings.Default.HiddenTags.Contains(subXElement.Name.LocalName))
            {
                subElemControl.SetOtherParent(_currentElement ?? _parent);
            }
            if (!Controls.Contains(subElemControl))
            {
                var subElementH = subElemControl.Height;
                Size = new Size(Size.Width, Size.Height + subElementH);
                Controls.Add(subElemControl);
            }
        }
    }
}