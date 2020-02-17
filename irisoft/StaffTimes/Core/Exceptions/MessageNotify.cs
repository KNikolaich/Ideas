using System;

namespace Core.Exceptions
{
    public static class MessageNotify
    {
        public static EventHandler<MessageNotifyArgument> AddNotify;

        internal static void AddMessage(object sender, string message, string title, NotifyEnum notifyEnum = NotifyEnum.Info)
        {
            AddNotify?.Invoke(sender , new MessageNotifyArgument(message, title) { Notify = notifyEnum});
        }

        internal static void Show(string message, string title, NotifyEnum notifyEnum = NotifyEnum.Info)
        {
            AddMessage(null, message, title, notifyEnum);
        }
    }
}
