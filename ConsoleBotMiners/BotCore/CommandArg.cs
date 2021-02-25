using System;
using System.Collections.Generic;
using System.Text;

namespace BotCore
{
    public class CommandArg : EventArgs
    {
        public CommandArg(CommandsEnum commands, Subscriber subscriber) : this(commands)
        {
            Subscriber = subscriber;
        }

        internal CommandArg(CommandsEnum commands)
        {
            Commands = commands;
        }
        public Subscriber Subscriber { get; private set; }

        public CommandsEnum Commands { get; private set; }
    }


    public enum CommandsEnum
    {
        Start,
        Stop,
        Info
    }
}
