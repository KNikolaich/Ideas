using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Configuration.Helpers;

namespace Configuration.Controls.Editors
{
    public partial class ContainerConfigControl : ElementBaseControl
    {
        #region Fields

        private bool _initialized = false; // уже проинициализировано
        private static readonly SignInfo signIUL = new SignInfo("signIUL", "", "Необязательный тег; При экспорте спец-пакетов Севмаш, добавлять ли подписанные информационно-удостоверяющие листы (ИУЛ) в комплекты документов; допустимые значения 'true' (signContent д.б. = false) или 'false' (по-умолчанию)");
        private static readonly SignInfo signContent = new SignInfo("signContent", "", "Необязательный тег; При экспорте спец-пакетов Севмаш, добавлять ли открепленные цифровые подписи (ЭЦП) для файлов в комплектах документов; допустимые значения 'true' (signIUL д.б. = false) или 'false' (по-умолчанию)  -->");


        public XElement CurrentConteiner { get; private set; }

        public EventHandler DeleteEventHandler;

        #endregion

        #region Инициализация

        public ContainerConfigControl()
        {
            InitializeComponent();
        }


        public override void SetElement(XElement xElement, int locationEditorX = 180)
        {
            CurrentConteiner = xElement;
            LocationEditorX = locationEditorX;
            SuspendLayout();
            
            AddEditControl(xElement);
            AddLabel(xElement);
            ReadRadioButon();
            ResumeLayout(false);
            PerformLayout();
            _initialized = true;
        }

        protected void AddLabel(XElement xElement)
        {
            _lContainerConfig.DataBindings.Add("Text", xElement, "Name");
            /*var textToolTip = */AddToolTipText(xElement, _lContainerConfig);
        }

        protected override void AddEditControl(XElement xElement)
        {
            var elementName = xElement.Elements("containerName").First();
            _textBoxName.DataBindings.Add("Text", elementName, "Value");
            _textBoxName.Validated += _textBoxElement_Validated;

            AddToolTipText(_bRemove, "Удаление ветки ContainerConfig");
            _gridControl.SetElement(xElement);
        }

        #endregion

        #region Обработчики событий

        private void bRemove_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show($"Вы уверены, что хотите дуалить строку '{_textBoxName.Text}'?", "Удаление строки",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CurrentConteiner.Remove();
                DeleteEventHandler?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region RadioButton обработчик

        private void ReadRadioButon()
        {
            var signIULElement = CurrentConteiner.Element(signIUL.TagName);
            if (signIULElement != null && signIULElement.Value.ToLower() == "true")
            {
                _rbSignIUL.Checked = true;
            }
            else
            {
                var signContentElement = CurrentConteiner.Element(signContent.TagName);
                if (signContentElement != null && signContentElement.Value.ToLower() == "true")
                {
                    _rbSignContent.Checked = true;
                }
            }
        }

        private void _rbSignIUL_CheckedChanged(object sender, EventArgs e)
        {
            if (_initialized && _rbSignIUL.Checked)
            {
                AddElement(signIUL);
                RemoveElement(signContent);
            }
        }

        private void _rbSignContent_CheckedChanged(object sender, EventArgs e)
        {

            if (_initialized && _rbSignContent.Checked)
            {
                AddElement(signContent);
                RemoveElement(signIUL);
            }
        }

        private void _radioButtonOff_CheckedChanged(object sender, EventArgs e)
        {
            if (_initialized && _radioButtonOff.Checked)
            {
                RemoveElement(signIUL);
                RemoveElement(signContent);
            }
        }


        private void RemoveElement(SignInfo signInfo)
        {
            var signElement = CurrentConteiner.Element(signInfo.TagName);
            if(signElement?.PreviousNode is XComment)
            {
                var commentElement = (XComment) signElement.PreviousNode;
                while (commentElement != null)
                {
                    var prevComment = commentElement.PreviousNode as XComment;
                    commentElement.Remove();
                    commentElement = prevComment;
                }
                
            }
            signElement?.Remove();
        }

        private void AddElement(SignInfo signInfo)
        {
            var signElement = CurrentConteiner.Element(signInfo.TagName);
            if (signElement == null)
            {
                var contNameEl = CurrentConteiner.Element("containerName");
                contNameEl.AddAfterSelf(new XComment(signInfo.Comment), new XElement(signInfo.TagName, true));
                //CurrentConteiner.AddSubElement(signInfo.TagName, true, signInfo.Comment);
            }
        }

        #endregion
    }
}
