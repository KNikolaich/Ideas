using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using Telegram.Bot.Types;
using WebBotApp.Models;

namespace WebBotApp.Controllers
{
    public class MessageController : ApiController
    {
        // GET api/values
        //    ...

        // POST api/values
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/message/update")]
        public async Task<OkResult> Post([FromBody] Update update)
        {
            if (update == null) return Ok();

            var commands = Bot.Commands;
            var message = update.Message;
            var botClient = await Bot.GetBotClientAsync();

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, botClient);
                    break;
                }
            }
            return Ok();
        }
    }
}
