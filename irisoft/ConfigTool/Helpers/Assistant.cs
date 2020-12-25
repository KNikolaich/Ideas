using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Configuration.Controls;

namespace Configuration.Helpers
{
    public class Assistant
    {
        internal static string FontName = "Microsoft Sans Serif"; //Consolas";
        internal static float FontSize = 9.75F;

        public Queue<KeyValuePair<string,string>> QueueHiddenTag { get; set; }
        
        internal static List<string> ExceptionNodeList = new List<string> {"name", "softtype"};
        private XDocument _xDocument;
        internal EventHandler BeforeHasDifferents;
        private static Assistant _instance;
        private bool _initialized;

        private Assistant()
        {
            SharedFolders = new DataTable("SharedFolders");

            SharedFolders.Columns.Add("IsActive", typeof(bool));
            SharedFolders.Columns.Add("FolderName");
            SharedFolders.Columns.Add("SharedStatus");

            HiddenTags = new DataTable("HiddenTags");
            HiddenTags.Columns.Add("Value");

            QueueHiddenTag = new Queue<KeyValuePair<string, string>>();
        }

        public string CfgFolder => Properties.Settings.Default.FolderCfg;

        public string SourceFileName { get; set; }

        public DataTable SharedFolders { get; set; }

        internal DataTable HiddenTags { get; set; }

        public GeneralTabControl LoadControls(string fileName)
        {
            GeneralTabControl generalTabControl = null;
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                _xDocument = XDocument.Load(stream);

                if (_xDocument.Root != null)
                {
                    generalTabControl = new GeneralTabControl
                    {
                        Name = "Abonents_control",
                        Dock = DockStyle.Bottom
                    };

                    // таб c общими для всех полями
                    var commonFieldsControl = new AbonentControl();
                    commonFieldsControl.SetOtherParent(_xDocument.Root);
                    // отображение контролов должно набираться в обратном порядке, т.к. иначе нет стролла
                    commonFieldsControl.AddControllsByElements(_xDocument.Root.Elements().Reverse().Where(el=>el.Name != "Abonents"));
                    
                    generalTabControl.InsertCommonFieldsTab(commonFieldsControl);
                    foreach (var element in _xDocument.Root.Elements().Where(el => el.Name == "Abonents"))
                    {
                        // var elemControl = ControlCreator.GetSubElemControl(element, commonFieldsControl.Controls.Count.ToString());
                        generalTabControl.SetElement(element);
                    }
                }
            }
            return generalTabControl;
        }

        public void SaveFile(bool showMsg = true)
        {
            SaveProperties();

            if (!HasDifferent()) // нет изменений, нечего сохранять
            {
                if(showMsg)
                    MessageBox.Show("Изменений не найдено", "Сохранение");
                return;
            }

            var directSource = Path.GetDirectoryName(SourceFileName);
            var backupFileName = Path.GetFileNameWithoutExtension(SourceFileName) + "_" +
                                 DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xml";
            File.Copy(SourceFileName, Path.Combine(directSource, backupFileName));

            try
            {
                File.SetAttributes(SourceFileName, File.GetAttributes(SourceFileName) & ~FileAttributes.ReadOnly);
                _xDocument.Save(SourceFileName);
                
                /*using (var writer = XmlWriter.Create(SourceFileName))
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.IndentChars = "\t";
                    writer.SeSettings = settings;
                }*/
                

                if(showMsg)
                    MessageBox.Show("Файл сохранен", "Сохранение");
            }
            catch (Exception e)
            {
                if (showMsg)
                    MessageBox.Show(e.Message, "Сохранение");
            }
        }

        public void FillShardeFolders()
        {

            SharedFolders.Rows.Clear();

            foreach (var folderName in Properties.Settings.Default.FolderForSharing)
            {
                SharedFolders.Rows.Add(true, folderName, SharedStatusEnum.Undefine.GetDescription());
            }
        }


        public void FillHiddenTags()
        {
            HiddenTags.Rows.Clear();
            foreach (var value in Properties.Settings.Default.HiddenTags)
            {
                HiddenTags.Rows.Add(value);
            }
        }

        public void ValidateFolders()
        {
            SaveProperties();
            //            var fileName = Path.GetFileName(SourceFileName);
            foreach (DataRow folder in SharedFolders.Rows)
            {
                if (!Directory.Exists(folder["FolderName"].ToString()))
                {
                    folder["SharedStatus"] = SharedStatusEnum.HasntFolder.GetDescription();
                }
                else
                {
                    folder["SharedStatus"] = SharedStatusEnum.Success.GetDescription();
                }
            }
        }

        public void SendFile()
        {
            SaveFile(false);

            string msg = string.Empty;
            var fileName = Path.GetFileName(SourceFileName);
            foreach (DataRow folder in SharedFolders.Rows)
            {
                if (folder["IsActive"] == DBNull.Value || (bool) folder["IsActive"])
                {
                    if (!Directory.Exists(folder["FolderName"].ToString()))
                    {
                        folder["SharedStatus"] = SharedStatusEnum.HasntFolder.GetDescription();
                    }
                    else
                    {
                        var fullTargetPath = Path.Combine(folder["FolderName"].ToString(), fileName);
                        try
                        {
                            if (File.Exists(fullTargetPath))
                                File.SetAttributes(fullTargetPath,
                                    File.GetAttributes(fullTargetPath) & ~FileAttributes.ReadOnly);

                            File.Copy(SourceFileName, fullTargetPath, true);
                            folder["SharedStatus"] = SharedStatusEnum.Success.GetDescription();
                        }
                        catch (Exception ex)
                        {
                            folder["SharedStatus"] = SharedStatusEnum.Denied.GetDescription() +" " + ex.Message;
                            msg += ex.Message;
                        }
                    }
                }
                else
                {
                    folder["SharedStatus"] = SharedStatusEnum.Undefine.GetDescription();
                }
            }
        }

        /// <summary>
        /// Имеются изменения в файле
        /// </summary>
        /// <returns></returns>
        public bool HasDifferent()
        {
            OnBeforeHasDifferents();
            // считываем исходный файл и текст из измененной xml
            var oldFileTxt = File.ReadAllText(SourceFileName, Encoding.Default);
            var newFileText = _xDocument.ToString();
            // все совпадает, - значит нет различий
            return !CompareTwoTexts(oldFileTxt, newFileText);
        }

        /// <summary> Перед поиском различий </summary>
        private void OnBeforeHasDifferents()
        {
            BeforeHasDifferents?.Invoke(_xDocument, EventArgs.Empty);
        }

        public void SaveProperties()
        {
            var folderForSharing = new StringCollection();
            foreach (DataRow folder in SharedFolders.Rows)
            {
                var name = folder["FolderName"].ToString();
                if (!string.IsNullOrEmpty(name))
                    folderForSharing.Add(name);
            }
            Properties.Settings.Default.FolderForSharing = folderForSharing;


            var hiddenTag = new StringCollection();
            foreach (DataRow folder in HiddenTags.Rows)
            {
                var value = folder["Value"].ToString();
                if (!string.IsNullOrEmpty(value))
                    hiddenTag.Add(value);
            }
            Properties.Settings.Default.HiddenTags = hiddenTag;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Сравнение двух текстов
        /// </summary>
        /// <returns>true в случае, если изменений нет</returns>
        public bool CompareTwoTexts(string oldDocument, string secondFileText)
        {
            //Разбить по пробелу
            var firstDirtyWords =
                oldDocument.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] secondDirtyWords =
                secondFileText.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            // первая строка в файле не отображается в результирующем XML
            int addItem = 0;
            if (firstDirtyWords[0].Contains("<?xml version="))
            {
                firstDirtyWords.RemoveAt(0);
            }
            var oldDocArr = firstDirtyWords.ToArray();

            if (oldDocArr.Length - 1 == secondDirtyWords.Length) // 
            {
                addItem += 1;
            }

            //Тут как-то анализировать полученные слова в переменных firstDirtyWords и secondDirtyWords
            for (int i = 0; i < secondDirtyWords.Length; i++)
            {
                // встречаются теги, где то есть пробел , то нет его
                if (string.Compare(firstDirtyWords[i + addItem].Replace("//>", "").Trim(),
                        secondDirtyWords[i].Replace("//>", "").Trim(), StringComparison.OrdinalIgnoreCase) != 0)
                    return false; // нашли одно отличие, прекращаем проверку.
            }
            return true;
        }

/*
        private static void CleanText(string[] firstDirtyWords)
        {
            for (int i = 0; i < firstDirtyWords.Length; i++)
            {
                firstDirtyWords[i] = firstDirtyWords[i].Trim();
                /*if (!Char.IsLetterOrDigit(firstDirtyWords[i][0]))
                    firstDirtyWords[i] = firstDirtyWords[i].Substring(1, firstDirtyWords[i].Length - 2);
                if (!Char.IsLetterOrDigit(firstDirtyWords[i][firstDirtyWords[i].Length - 1]))
                    firstDirtyWords[i] = firstDirtyWords[i].Substring(0, firstDirtyWords[i].Length - 2);#1#
            }
        }*/
        public static Assistant GetInstance()
        {
            return _instance ?? (_instance = new Assistant());
        }

        public void Initialize()
        {
            if (!_initialized)
            {
                FillShardeFolders();
                FillHiddenTags();
            }
            _initialized = true;
        }
    }
}