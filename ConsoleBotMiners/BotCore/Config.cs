using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace BotCore
{
    [Serializable]
    public class Config
    {

        internal Config()
        {
            Subscribers = new Subscriber[0];
        }
        static string _fileName = "config.xml";
        public Subscriber[] Subscribers { get; set; }


        public static Config Load()
        {
            var config = new Config();
            if (!File.Exists(_fileName))
            {
                Save(config);
            }
            XmlSerializer formatter = new XmlSerializer(typeof(Config));
            using (var fs = new FileStream(_fileName, FileMode.Open))
            {
                config = (Config)formatter.Deserialize(fs);
            }
            return config;
        }

        static void Save(Config config)
        {
            if (File.Exists(_fileName))
                File.Delete(_fileName);
            using (FileStream fs = new FileStream(_fileName, FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Config));
                formatter.Serialize(fs, config);
            }
        }

        internal void Save()
        {
            Save(this);
        }

        internal bool Remove(long idChat)
        {

            var list = Subscribers.ToList();
            // удаляем строку
            var ss = list.FirstOrDefault(s => s.ChatId == idChat);
            if (ss != null)
            {
                list.Remove(ss);
                Subscribers = list.ToArray();
                Save();
                return true;
            }
            return false;
        }

        internal bool SetOrCreate(long idChat, SubscribeLevelEnum level)
        {
            bool result = false;
            Subscriber ss = GetSubscribes(idChat);
            if (ss != null)
            {
                if (ss.Level != level)
                {
                    ss.Level = level;
                    result = true;
                }
            }
            else
            {
                var list = Subscribers.ToList();
                list.Add(new Subscriber { ChatId = idChat, Level = level });
                Subscribers = list.ToArray();
                result = true;
            }
            if (result)
                Save();
            return result;
        }

        internal Subscriber GetSubscribes(long idChat)
        {
            var list = Subscribers.ToList();
            return list.FirstOrDefault(s => s.ChatId == idChat);
        }
    }
}
