using Microsoft.Extensions.Configuration;

namespace WebCoreApp2.Models
{
    public class AppSettings
    {
        public AppSettings(string name, string token, string hookUrl)
        {
            Name = name;
            Key = token;
            Url = hookUrl;
            Single = this;
        }

        public static IConfiguration AppConfig { get; set; }


        public string Url { get; }
        public string Name { get; } 
        public string Key { get; }

        public static AppSettings Single { get; private set; }
    }
}
