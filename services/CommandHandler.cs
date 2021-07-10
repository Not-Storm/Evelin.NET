namespace Evelin.services
{
    using Discord.Addons.Hosting;
    using Discord.Commands;
    using Discord.WebSocket;
    using Discord;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Reflection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Class responsible for handling commands and events
    /// </summary>
    public class CommandHandler : DiscordClientService
    {
        private readonly IServiceProvider _provider;
        private readonly CommandService _commandService;
        private readonly IConfiguration _config;

        /// <summary>
        /// Initilize a new instance of <see cref="CommandHandler"/> class
        /// </summary>
        /// <param name="client">For injecting <see cref="DiscordSocketClient"/></param>
        /// <param name="logger">For injecting <see cref="ILogger"/></param>
        /// <param name="provider">For injecting <see cref="IServiceProvider"/></param>
        /// <param name="commandService">For injecting <see cref="CommandService"/></param>
        /// <param name="config">For injecting <see cref="IConfiguration"/></param>
        public CommandHandler(DiscordSocketClient client, ILogger<CommandHandler> logger, IServiceProvider provider, CommandService commandService, IConfiguration config) : base(client, logger)
        {
            _provider = provider;
            _commandService = commandService;
            _config = config;
        }

        /// <inheritdoc/>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Client.MessageReceived += this.OnMessageReceived;
            _commandService.CommandExecuted += this.OnCommandExecuted;
            await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);
        }

        private async Task OnCommandExecuted(Optional<CommandInfo> commandInfo, ICommandContext commandContext, IResult result)
        {
            if (result.IsSuccess)
            {
                return;
            }

            await commandContext.Channel.SendMessageAsync(result.ErrorReason);
        }

        private async Task OnMessageReceived(SocketMessage socketMessage)
        {
            if (socketMessage is not SocketUserMessage message)
            {
                return;
            }
            if (message.Source != MessageSource.User)
            {
                return;
            }

            var argPos = 0;
            if (!message.HasStringPrefix(_config["Prefix"], ref argPos) && !message.HasMentionPrefix(Client.CurrentUser, ref argPos))
            {
                return;
            }

            var context = new SocketCommandContext(Client, message);
            await _commandService.ExecuteAsync(context, argPos, _provider);
        }
    }
}