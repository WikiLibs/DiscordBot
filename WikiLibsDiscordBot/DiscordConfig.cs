using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WikiLibsDiscordBot
{
    public class DiscordConfig
    {
        public class Hook
        {
            public string Name { get; set; }
            public ulong Channel { get; set; }
        }

        public string Token { get; set; }
        public ulong CmdChannel { get; set; }
        public List<Hook> AzureHooks { get; set; }
    }
}
