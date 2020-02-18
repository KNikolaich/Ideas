using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using Telegram.Bot;
using WcfBot.Model;
using WcfBot.Properties;

namespace WcfBot
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public async Task GetUpdateAsync(Update update)
        {
            
            var bot = new TelegramBotClient(Settings.Default.token);
            if (update.message != null && update.message.text.ToLower().Contains("привет"))
            {
                try
                {
                    var msg = await bot.SendTextMessageAsync(update.message.chat.id,
                        "Привет," + update.message.from.first_name).ConfigureAwait(false);
                    Debug.WriteLine(msg);
                }
                catch (Exception ex)
                {
                    var msg = ex.Message + ex.InnerException?.Message + ex.InnerException?.InnerException?.Message;
                    Debug.WriteLine(msg);
                }
            }
        }
    }
}
