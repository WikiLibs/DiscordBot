using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WikiLibsDiscordBot.Commands
{
    public interface ICommand
    {
        string Execute(DiscordSocketClient client, IMessageChannel cmdChannel, string msg, string[] args);
    }
}
