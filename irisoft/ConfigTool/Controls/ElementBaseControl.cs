using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Configuration.Helpers;
using Configuration.Properties;

namespace Configuration.Controls
{
    public partial class ElementBaseControl : UserControl
    {
        internal int LocationEditorX; // координата X редактора
        protected CheckBox _cbOptional;
        protected Control _textBoxElement;
        private string _textToolTip;
        protected XElement _parent;
        protected XElement _currentElement;

        public ElementBaseControl()
        {
            InitializeComponent();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _textBoxElement?.Focus();
        }

        public virtual void SetElement(XElement xElement, int locationEditorX = 180)
        {
            _currentElement = xElement;
            _parent = xElement.Parent;
            LocationEditorX = locationEditorX;
            SuspendLayout();
            if (xElement.HasElements)
            {
                foreach (var subXElement in xElement.Elements())
                {
                    if (Assistant.ExceptionNodeList.Contains(subXElement.Name.ToString().ToLower()))
                    {
                        AddEditControl(subXElement);
                    }
                    else
                    {
                        var elemControl =
                            ControlCreator.GetSubElemControl(subXElement, Controls.Count.ToString(), locationEditorX);
                        elemControl.Dock = DockStyle.Bottom;
                        Controls.Add(elemControl);
                        Size = new Size(Size.Width, Size.Height + elemControl.Height);
                    }
                }
            }
            else
            {
                AddEditControl(xElement);
            }
            AddLabel();

            ResumeLayout(false);
            PerformLayout();
        }

        protected virtual void AddEditControl(XElement xElement)
        {
            _textBoxElement = new TextBox
            {
                Margin = new Padding(2),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font(Assistant.FontName, Assistant.FontSize, FontStyle.Regular, GraphicsUnit.Point, 204),
                Location = new Point(190, 3),
                Name = "_textBoxElement",
                Size = new Size(155, 20),
                TabIndex = 1,
                Text = "",
                Dock = DockStyle.Fill,
            };
            Padding = new Padding(0, 3, 5, 0);
            Controls.Add(_textBoxElement);
            _textBoxElement.DataBindings.Add("Text", xElement, "Value");
            _textBoxElement.Validated += _textBoxElement_Validated;
            Assistant.GetInstance().BeforeHasDifferents += BeforeHasDifferents;  
        }

        protected void _textBoxElement_Validated(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (!string.IsNullOrEmpty(tb?.Text))
            {
                tb.Text = tb.Text.Trim();
                tb.Update();
            }
        }

        protected virtual void BeforeHasDifferents(object sender, EventArgs eventArgs)
        {
            if (_textBoxElement != null && _cbOptional != null) // это скрываемый элемент
            {
                // комментарий найти везде пригодится
                var commentElement = _parent.FindCommentElement(_textToolTip); 
                //Проверяем, что элемент содержит текст
                var xName = _currentElement.Name.LocalName;
                if (_cbOptional.Checked)
                {
                    /*Сохраняем, в виде тэга XElement 
                                     Находит такой элемент в родительской ветке,
                                     ДА - сохраняем как есть (он должен быть прибиндин)
                                     НЕТ - ищим комментарий с таким элементом, 
                                               ищим к нему коммент  (удаляем)
                                               заменяем комментарий на наш элемент и коммент перед */
                    var elementInPrent = _parent.Element(xName);
                    if (elementInPrent == null)
                    {
                        var findCommentElement = _parent.FindCommentElement($"<{xName}/>") ??
                                                 _parent.FindCommentElement($"</{xName}>");
                        if (findCommentElement != null)
                        {
                            findCommentElement.ReplaceWith(_currentElement);
                        }
                    }
                }
                else
                {
/* Сохраняем в виде коммента
                 Находим такой элемент коммента 
                       ДА  (оставляем как есть)
                      НЕТ  ищим Хэлемент и коммент к нему, заменяем их на наши комментарии */
                    var findCommentElement = _parent.FindCommentElement($"<{xName}/>") ??
                                             _parent.FindCommentElement($"</{xName}>");
                    if (findCommentElement == null)
                    {
                        var xElement = _parent.Element(xName);
                        if (xElement != null)
                        {
                            var elementToCommentText = $"<{xName}/>";
                            if (!string.IsNullOrEmpty(_textBoxElement.Text))
                            {
                                elementToCommentText = $"<{xName}>{_textBoxElement.Text}</{xName}>";
                            }
                            var xComment = new XComment(elementToCommentText);
                            xElement.ReplaceWith(xComment);
                            /*if (commentElement == null && !string.IsNullOrEmpty(_textToolTip))
                            {
                                xComment.AddBeforeSelf(new XComment(_textToolTip));
                            }*/
                        }
                    }
                }
            }
        }

        internal void AddLabel()
        {
            AddChackBoxOptional();

            var panelLabel = new Panel();
            panelLabel.SuspendLayout();
            var labelElement = GetLabelElement();
            labelElement.DataBindings.Add("Text", _currentElement, "Name");

            var textToolTip = AddToolTipText(_currentElement, labelElement);

            var widthPanel = 200;
            if (_currentElement.Document == null || _parent != _currentElement.Document.Root)
                widthPanel = LocationEditorX;
            panelLabel.Controls.Add(labelElement);
            panelLabel.Controls.Add(_cbOptional);
            panelLabel.Dock = DockStyle.Left;
            panelLabel.Location = new Point(0, 20);
            panelLabel.Name = "panelLabel";
            panelLabel.Size = new Size(widthPanel, 23);
            panelLabel.TabIndex = 1;
            panelLabel.ResumeLayout(false);
            panelLabel.PerformLayout();

            Controls.Add(panelLabel);

            var differenceLine = "====";
            if (textToolTip.Contains(differenceLine))
            {
                // выбираем из коммента только строки до разделительной линии
                var tttSplit = textToolTip.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                var resultTtt = "";
                foreach (var str in tttSplit)
                {
                    if (str.Contains(differenceLine))
                    {
                        break;
                    }
                    resultTtt += !string.IsNullOrEmpty(resultTtt) ? Environment.NewLine + str : str;
                }

                var line = "";
                for (var i = 0; i < 300; i++)
                {
                    line += '-';
                }
                var labelLine = GetLabelElement(line);
                AddToolTipText(labelLine, resultTtt);
                labelLine.Font = new Font(labelLine.Font.FontFamily, 14.0f);
                labelLine.ForeColor = Color.Gray;
                labelLine.Location = new Point(0, 0);
                labelLine.Dock = DockStyle.Top;
                Controls.Add(labelLine);
                //Controls.SetChildIndex(labelLine, 0);
                Size = new Size(Size.Width, Size.Height + 15);

                labelLine.PerformLayout();
            }
            
            Size = new Size(Size.Width, Size.Height + panelLabel.Height);
        }

        protected void AddChackBoxOptional()
        {
            if (Settings.Default.HiddenTags.Contains(_currentElement.Name.LocalName) && _cbOptional == null)
            {
                _cbOptional = new CheckBox
                {
                    Margin = new Padding(2),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    Font = new Font(Assistant.FontName, Assistant.FontSize, FontStyle.Regular, GraphicsUnit.Point, 204),
                    Location = new Point(190, 3),
                    Name = "_cbOptional",
                    Size = new Size(20, 20),
                    TabIndex = 1,
                    Text = "",
                    Dock = DockStyle.Left
                };
                AddToolTipText(_cbOptional, "Включение необзятаельного тэга");

                _textBoxElement.DataBindings.Add("Enabled", _cbOptional, "Checked");
                _cbOptional.Checked = !(_currentElement.Parent == null || _currentElement.Parent.Name == "hidden");
            }
        }

        protected static Label GetLabelElement(string text = "")
        {
            var labelElement = new Label();

            labelElement.AutoSize = true;
            labelElement.Font = new Font(Assistant.FontName, Assistant.FontSize, FontStyle.Regular, GraphicsUnit.Point,
                204);
            labelElement.Dock = DockStyle.Fill;
            labelElement.Location = new Point(18, 8);
            labelElement.Name = "_labelElement";
            labelElement.Size = new Size(49, 10);
            labelElement.TabIndex = 0;
            labelElement.Text = text;
            return labelElement;
        }

        internal string AddToolTipText(XElement xElement, Control labelElement)
        {
            var textToolTip = GetCommentText(xElement);
            if (!string.IsNullOrEmpty(textToolTip))
            {
                AddToolTipText(labelElement, textToolTip);
            }
            return textToolTip;
        }

        protected static string GetCommentText(XElement xElement)
        {
            var textToolTip = "";
            var prevNode = xElement.PreviousNode;

            while (prevNode?.NodeType == XmlNodeType.Comment || prevNode?.NodeType == XmlNodeType.Text)
            {
                if (prevNode.NodeType != XmlNodeType.Text)
                {
                    var validNode = ValidCommentForHiddenTag((XComment) prevNode);
                    if (validNode != prevNode)
                    {
                        prevNode = validNode;
                        continue;
                    }
                    textToolTip = ((XComment) prevNode).Value + Environment.NewLine + textToolTip;
                }
                prevNode = prevNode.PreviousNode;
            }
            return textToolTip;
        }

        protected static XNode ValidCommentForHiddenTag(XComment xNode)
        {
            var hiddenTag = ContainsHiddenTag(xNode);
            if (!string.IsNullOrEmpty(hiddenTag))
            {
                XNode previuosNode;
                do
                {
                    previuosNode = FindCommentForHiddenTag(xNode);
                    if (previuosNode?.NodeType == XmlNodeType.Comment)
                        previuosNode = ValidCommentForHiddenTag((XComment) previuosNode);
                    // если нарвались на простой коммент, -> сохраняем в очередь 
                    //и выплевываем xNode наружу
                } while (previuosNode?.NodeType == XmlNodeType.Comment);
                

                return previuosNode;
            }
            return xNode;
        }

        private static XNode FindCommentForHiddenTag(XComment xComment)
        {
            var comment = "";

            var prevNode = xComment.PreviousNode;
            while (prevNode is XComment && string.IsNullOrEmpty(ContainsHiddenTag((XComment)prevNode))) // до тех пор, пока это комментарий и не очоердной скрытый тэг
            {
                var value = ((XComment)prevNode).Value;
                comment += !string.IsNullOrEmpty(comment) ? Environment.NewLine + value : value;
                prevNode = prevNode.PreviousNode;
            }
            Assistant.GetInstance().QueueHiddenTag.Enqueue(new KeyValuePair<string, string>(ContainsHiddenTag(xComment), comment));
            return prevNode;
        }

        private static string ContainsHiddenTag(XComment xNode)
        {
            string hiddenTag = "";
            foreach (var tag in Settings.Default.HiddenTags)
            {
                if (xNode.Value.Contains($"<{tag}/>") || xNode.Value.Contains($"<{tag}>") && xNode.Value.Contains($"</{tag}>")) // нашли скрытый тэг
                {
                    hiddenTag = tag;
                    break;
                }
            }
            return hiddenTag;
        }

        internal void AddToolTipText(Control labelElement, string textToolTip)
        {
            var toolTip = new ToolTip
            {
                IsBalloon = true,
                ShowAlways = true,
                AutomaticDelay = 100, // 1/10 секунды перед отображением
                AutoPopDelay = 10000 // 10 сек отображения
            };
            var differenceLine = "====";
            if (textToolTip.Contains(differenceLine))
            {
                // выбираем из коммента только строки после разделительной линии
                var tttSplit = textToolTip.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                var catchDiffLine = false;
                textToolTip = "";
                foreach (var str in tttSplit)
                {
                    if (catchDiffLine)
                    {
                        textToolTip += !string.IsNullOrEmpty(textToolTip) ? Environment.NewLine + str : str;
                    }
                    if (str.Contains(differenceLine))
                    {
                        catchDiffLine = true;
                    }
                }
            }
            if(labelElement is TextBox)
                _textToolTip = textToolTip; // завершенный вариант
            toolTip.SetToolTip(labelElement, textToolTip);
        }

        /// <summary>
        /// установка иного родителя (нужна для скрытых контролов, которые были созданы фейковым способом)
        /// </summary>
        /// <param name="parent"></param>
        public void SetOtherParent(XElement parent)
        {
            _parent = parent;
        }
    }
}