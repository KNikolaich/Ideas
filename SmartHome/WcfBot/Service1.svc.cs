using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Telegram.Bot;
using WcfBot.Model;
using WcfBot.Model.WcfBot;
using WcfBot.Properties;

namespace WcfBot
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void GetUpdate(Update update)
        {
            
            var bot = ProxyFinder.GetBot();
            if (update.message.text == "Привет")
            {
                bot.SendTextMessage(update.message.chat.id, "Привет," + update.message.from.first_name);
            }
        }
    }
}
