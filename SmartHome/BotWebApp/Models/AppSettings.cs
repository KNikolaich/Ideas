using System.Web.Configuration;

namespace BotWebApp.Models
{
    public class AppSettings
    {
        private static AppSettings _single;

        public AppSettings(string name, string token, string hookUrl)
        {
            Name = name;
            Key = token;
            Url = hookUrl;
        }
        
        public string Url { get; }
        public string Name { get; } 
        public string Key { get; }

        public static AppSettings Single
        {
            get
            {
                if (_single == null)
                {
                    var settings = WebConfigurationManager.AppSettings;
                    _single = new AppSettings(settings["name"], settings["token"], settings["Url"]);
                }
                return _single;
            }
        }
    }
}
