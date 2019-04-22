using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WikiLibsDiscordBot.Commands;

namespace WikiLibsDiscordBot
{
    public class ServiceQueue
    {
        public ConcurrentQueue<Message> Messages = new ConcurrentQueue<Message>();
    }

    public class Startup
    {
        private CancellationTokenSource _stop = new CancellationTokenSource();
        private DiscordSocketClient _discordClient;
        private DiscordConfig _config = new DiscordConfig();
        private CommandRegistry _reg;
        private IMessageChannel _cmdChannel;
        private ServiceQueue _queue = new ServiceQueue();
        private Dictionary<string, ulong> _channels = new Dictionary<string, ulong>();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(o =>
            {
                return (_queue);
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseMvc();
            Task.Factory.StartNew(DiscordBotTask, TaskCreationOptions.LongRunning);
        }

        private async Task DiscordBotTask()
        {
            _discordClient = new DiscordSocketClient();
            _reg = new CommandRegistry();

            Configuration.Bind("Discord", _config);
            foreach (var hook in _config.AzureHooks)
                _channels[hook.Name] = hook.Channel;
            await _discordClient.LoginAsync(TokenType.Bot, _config.Token);
            _discordClient.MessageReceived += _socket_MessageReceived;
            bool ready = false;
            _discordClient.Ready += () =>
            {
                ready = true;
                return (Task.CompletedTask);
            };
            await _discordClient.StartAsync();
            while (!ready) ;
            _cmdChannel = _discordClient.GetChannel(_config.CmdChannel) as IMessageChannel;
            if (_cmdChannel == null)
            {
                Console.WriteLine("Could not connect with command channel");
                return;
            }
            await _cmdChannel.SendMessageAsync("WikiLibs Discord Bot Initialized");
            while (!_stop.IsCancellationRequested)
            {
                Message msg;
                while (_queue.Messages.TryDequeue(out msg))
                {
                    var ch = _discordClient.GetChannel(_channels[msg.HookName]) as IMessageChannel;
                    CommandTemplate.SendAzureCommit(_discordClient, ch, msg);
                }
            }
        }

        private async Task _socket_MessageReceived(SocketMessage arg)
        {
            if (_discordClient == null || _reg == null)
                return;
            if (arg.Channel.Id == _config.CmdChannel)
            {
                arg.Content.StartsWith("!");
                var args = arg.Content.Split(" ");
                var cmd = _reg.GetCommand(args[0].Substring(1));
                if (cmd == null)
                    return;
                var response = cmd.Execute(_discordClient, _cmdChannel, arg.Content, args);
                if (response != null)
                    await _cmdChannel.SendMessageAsync(response);
            }
        }
    }
}
