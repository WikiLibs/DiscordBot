using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WikiLibsDiscordBot.Commands
{
    public class CommandRegistry
    {
        private Dictionary<string, ICommand> _dic = new Dictionary<string, ICommand>();

        public CommandRegistry()
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetExportedTypes())
            {
                if (type.GetCustomAttribute<Command>() != null)
                    _dic[type.GetCustomAttribute<Command>().Name] = (ICommand)Activator.CreateInstance(type);
            }
        }

        public ICommand GetCommand(string name)
        {
            if (!_dic.ContainsKey(name))
                return (null);
            return (_dic[name]);
        }
    }
}
