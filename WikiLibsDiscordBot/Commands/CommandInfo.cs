using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace WikiLibsDiscordBot.Commands
{
    [Command(Name = "info")]
    public class CommandInfo : ICommand
    {
        public string Execute(DiscordSocketClient client, IMessageChannel cmdChannel, string msg, string[] args)
        {
            return (Assembly.GetExecutingAssembly().ToString());
        }
    }
}
