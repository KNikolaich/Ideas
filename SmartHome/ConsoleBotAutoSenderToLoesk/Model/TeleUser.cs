using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBotAutoSenderToLoesk.Model
{
    internal class TeleUser
    {
        internal long Id { get; }

        public TeleUser(string firstName, long id)
        {
            NickName = firstName;
            Id = id;
        }

        public object NickName { get; private set; }

        public override bool Equals(object obj)
        {
            var teleUser = (TeleUser)obj;
            return teleUser.NickName.Equals(NickName) && teleUser.Id.Equals(Id);
        }

        public override string ToString()
        {
            return NickName + " id: " + Id;
        }
    }
}
