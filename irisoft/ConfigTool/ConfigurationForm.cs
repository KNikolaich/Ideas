using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Configuration.Helpers;

namespace Configuration
{
    public partial class ConfigurationForm : Form
    {
        Assistant _assistant;

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppendVersionForText();
            _assistant = Assistant.GetInstance();
            if(!LoadCfgFile())
                Close();
        }

        private bool LoadCfgFile()
        {
            OpenConfigForm();
            if (!ValidateSeouceFile())
                return false;

            SuspendLayout();

            lSourceFileName.Text = "Открытый файл: " + _assistant.SourceFileName;

            _assistant.Initialize();
            _geniralEditCfgControl1.SetAssistant(_assistant);

            _settingEditControl.SetAssistant(_assistant);
            _saveFileControl.SetAssistant(_assistant);
            ResumeLayout(false);
            PerformLayout();
            return true;
        }

        /// <summary>
        /// проверяем файл ресурса
        /// </summary>
        /// <returns></returns>
        private bool ValidateSeouceFile()
        {
            if (string.IsNullOrEmpty(_assistant.SourceFileName))
                return false;
            var fileInfo = new FileInfo(_assistant.SourceFileName);
            if (fileInfo.Attributes.HasFlag(FileAttributes.ReadOnly))
            {
                if (MessageBox.Show(
                        $@"Файл {_assistant.SourceFileName} имеет атрибут ReadOnly.{
                                Environment.NewLine
                            }Хотите снять атрибут и продолжить открытие файла?", "Внимание!",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question) == DialogResult.OK)
                {
                    fileInfo.Attributes = FileAttributes.Normal;
                }
            }
            return true;
        }

        private void AppendVersionForText()
        {
            var assTwo = "";
            var assemblyInfo = Assembly.GetExecutingAssembly().GetName().Version.ToString().Split('.');
            for (short i = 0; i < 2; i++)
            {
                assTwo += assemblyInfo[i] + '.';
            }
            Text += $"    v.{assTwo.Trim('.')}";
#if DEBUG
            Text += " Debug version!";
#endif
        }

        private void OpenConfigForm()
        {
            string cfgFolder = _assistant.CfgFolder;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Config files(*.xml)|*.xml";
                ofd.InitialDirectory = cfgFolder;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _assistant.SourceFileName = ofd.FileName;
                }
            }
        }

        private void _bSave_Click(object sender, EventArgs e)
        {
            _assistant.SaveFile();
        }

        private void _buttonSend_Click(object sender, EventArgs e)
        {
            _assistant.SendFile();
        }

        private void _buttonExit_Click(object sender, EventArgs e)
        {

            if (_assistant.HasDifferent())
            {
                var dlgResult = MessageBox.Show("Сохранить изменения?", "Есть не сохраненные изменени",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dlgResult)
                {
                    case DialogResult.Yes:
                        _assistant.SaveFile(false);
                        Close();
                        break;
                    case DialogResult.No:
                        _assistant.SaveProperties();
                        Close();
                        break;
                }
            }
            else
            {
                _assistant.SaveProperties();
                Close();
            }
        }

        private void _bOpen_Click(object sender, EventArgs e)
        {
            // проверка изменений в старом файле, сохранить, если были или нет?
            _assistant.SaveFile(false);

            // открываем новый файл. 
            // перегенерируем контрол отображения (его ответсвенность за свои контролы)
            LoadCfgFile();
        }
    }
}