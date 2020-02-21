using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using BotWebApp.Models;
using Telegram.Bot.Types;

namespace BotWebApp.Controllers
{
    [System.Web.Mvc.Route("api/message/update")]
    public class MessageController : ApiController
    {
        // GET api/values
//    ...

    // POST api/values
        [System.Web.Mvc.HttpPost]
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
