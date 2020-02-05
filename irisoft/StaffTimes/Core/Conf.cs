using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Core
{
    [Serializable]
    public class Conf
    {
        const string ConfData = "Conf.data";

        public string Login { get; set; }

        public bool SavePassword { get; set; }


        public string Password { get; set; }

        public string ConnectionInfo { get; set; }

        private Conf Load()
        {
            Conf conf = this;
            if (File.Exists(ConfData))
            {
                XmlSerializer reader = new XmlSerializer(typeof(Conf));
                var file = new StreamReader(ConfData);
                conf = (Conf) reader.Deserialize(file);
                file.Close();
            }
            return conf;
        }

        public void Save()
        {
            try
            {
                FileStream stream = new FileStream(ConfData, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(Conf));
                serializer.Serialize(stream, this);
                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка создания файла!");
            }
        }

        public static void Write(string login, string password, bool savePassword = false)
        {
            var configuration = new Conf {Login = login, Password = password, SavePassword = savePassword};
            configuration.Save();
        }

        public static Tuple<string, string> ReadLoginPassword()
        {
            var configuration = new Conf().Load();

            return new Tuple<string, string>(configuration.Login, configuration.SavePassword ? configuration.Password : "");
        }
    }
}
