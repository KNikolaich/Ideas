using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using Configuration.Helpers;

namespace Configuration.Controls.Editors
{
    public partial class SmSignedGroupControl : ElementBaseControl
    {
        /// <summary>
        /// словарь таких вот контролов SmSignedGroupControl
        /// </summary>
        private static readonly Dictionary<XElement, SmSignedGroupControl> DictControls = new Dictionary<XElement, SmSignedGroupControl>();
        /// <summary>
        /// Словарь уже прибиндиных элементов
        /// </summary>
        private readonly Dictionary<string, XElement> _dictElements = new Dictionary<string, XElement>();

        private static readonly SignInfo signActivity = new SignInfo("signActivity", "Подписание наряда", "Необязательный тег; Название задания в рабочем процессе, где выполняется подписание наряда (ИУЛ или ЭЦП). Нужен если <signedIUL> = true или <signedContent> = true");
        private static readonly SignInfo signVote = new SignInfo("signVote", "Подписание", "Необязательный тег; Название события задания по подписанию наряда (ИУЛ или ЭЦП). Нужен если <signedIUL> = true или <signedContent> = true");

        private bool _connectToEvents;
        private XElement _xParent;

        private SmSignedGroupControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// берем один такой контрол для родителя. 
        /// </summary>
        /// <param name="parent">сюда спускается именно родитель, а не элемент для биндинга</param>
        /// <returns></returns>
        /*public static ElementBaseControl GetForParent(XElement parent)
        {
            if (!DictControls.ContainsKey(parent))
            {
                DictControls.Add(parent, new SmSignedGroupControl());
            }
            return DictControls[parent];
        }*/

        public override void SetElement(XElement xElement, int locationEditorX = 180)
        {
            LocationEditorX = locationEditorX;
            _dictElements.Add(xElement.Name.LocalName, xElement);
            _xParent = xElement.Parent;
            switch (xElement.Name.LocalName.ToLower())
            {
                case "smsignediul":
                    _smSignedIULControl.SetElement(xElement, LocationEditorX-3);// где 3 - это поправка на groupBox
                    _smSignedIULControl.Height = 24;
                    break;

                case "smsignedcontent":
                    _beSmSignedContentControl.SetElement(xElement, LocationEditorX-3); // где 3 - это поправка на groupBox
                    _beSmSignedContentControl.Height = 24;
                    break;

                case "signactivity":
                    _signActivityControl.SetElement(xElement, LocationEditorX);
                    _signActivityControl.Height = 28;
                    break;

                case "signvote":
                    _signVoteControl.SetElement(xElement, LocationEditorX);
                    _signVoteControl.Height = 28;
                    break;
            }

            if (!_connectToEvents)
            {
                _smSignedIULControl.CheckedChanged += beControl_CheckedChanged;
                _beSmSignedContentControl.CheckedChanged += beControl_CheckedChanged;
                Assistant.GetInstance().BeforeHasDifferents += BeforeHasDifferents;
                _connectToEvents = true;
            }
        }

        private void beControl_CheckedChanged(object sender, EventArgs e)
        {
            
            var enabled = _beSmSignedContentControl.CheckedState || _smSignedIULControl.CheckedState;
            _signActivityControl.Enabled = enabled;
            _signVoteControl.Enabled = enabled;
            if (enabled )
            {
                if (!_dictElements.ContainsKey(signActivity.TagName))
                {
                    var xActivity = _xParent.AddSubElement(signActivity.TagName, signActivity.ValueDefault, signActivity.Comment);
                    SetElement(xActivity, LocationEditorX);
                }

                if (!_dictElements.ContainsKey(signVote.TagName))
                {
                    var xVote = _xParent.AddSubElement(signVote.TagName, signVote.ValueDefault, signVote.Comment);
                    SetElement(xVote, LocationEditorX);
                }
            }

            // обработка случая, когда включается один тэг, а нужно выключить другой.
            var checkBox = (CheckBox)sender;
            if (checkBox.CheckState == CheckState.Checked)
            {
                switch (((XElement)checkBox.DataBindings[0].DataSource).Name.LocalName)
                {
                    case "smSignedIUL":
                        _beSmSignedContentControl.CheckedState = false;
                        break;
                    case "smSignedContent":
                        _smSignedIULControl.CheckedState = false;
                        break;
                }
            }
        }

        protected override void BeforeHasDifferents(object sender, EventArgs e)
        {
            // вариант, когда все элементы были, - простой, они все прибиндены и должны оставаться.
            // когда каких то тэгов нет, - надо их создать + подчистить комментарии, которые были для этих тэгов
            var enabled = _beSmSignedContentControl.CheckedState || _smSignedIULControl.CheckedState;
            if (!enabled)
            {
                //HideSignTag(signActivity);
                //HideSignTag(signVote);
            }
            else
            {
                ShowSignTag(signActivity);
                ShowSignTag(signVote);
            }
        }

        private void ShowSignTag(SignInfo sign)
        {
            var commentElement = _xParent.FindCommentElement($"<{sign.TagName}>");
            var previewComment = commentElement?.PreviousNode as XComment;
            previewComment?.Remove();
            commentElement?.Remove();
            // найти существующие строки в cfg файле. нашел, - все ок, нет ->
            // но при этом есть соответсвующие тэги в _dictElements, добавляем их в конец
            var foundElement = _xParent.Element(sign.TagName);
            if (foundElement == null)
            {
                _xParent.AddSubElement(sign.TagName, 
                    _dictElements.ContainsKey(sign.TagName) 
                    ? _dictElements[sign.TagName].Value 
                    : sign.ValueDefault, sign.Comment);
            }
        }

        private void HideSignTag(SignInfo sign)
        {
            XElement elsignactivity = _xParent.Element(sign.TagName);
            if (elsignactivity != null) // находим этот тег, если он не закомментирован
            {
                if(_xParent.FindCommentElement(sign.Comment) == null) // если не было такого комментария (ну вдруг)
                    elsignactivity.AddBeforeSelf(new XComment(sign.Comment));
                elsignactivity.AddBeforeSelf(
                    new XComment($"<{sign.TagName}>{sign.ValueDefault}</{sign.TagName}>")); 
                elsignactivity.Remove();
            }
            else //if () // если не нашли его, ищем закомментированный, и создаем, если тоже не нашли
            {
                XComment commentElement = _xParent.FindCommentElement($"<{sign.TagName}>");
                if (commentElement == null)
                {
                    _xParent.AddSubElement(sign.TagName, sign.ValueDefault, sign.Comment);
                }
            }
        }

        protected override void AddEditControl(XElement xElement)
        {
            
        }
    }

    internal class SignInfo
    {
        public SignInfo(string tagName, string valueDefault, string comment)
        {
            TagName = tagName;
            ValueDefault = valueDefault;
            Comment = comment;
        }

        public string TagName { get; set; }
        public string ValueDefault { get; set; }
        public string Comment { get; set; }
    }
}

