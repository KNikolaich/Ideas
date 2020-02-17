using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class MessageNotifyArgument : EventArgs
    {
        public MessageNotifyArgument(string message, string title)
        {
            Message = message;
            Title = title;
        }

        public string Title { get; set; }

        public string Message { get; set; }

        public NotifyEnum Notify { get; set; }
    }
}
