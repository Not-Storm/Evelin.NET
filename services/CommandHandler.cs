namespace Evelin.Services
{
    using System;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Discord;
    using Discord.Addons.Hosting;
    using Discord.Commands;
    using Discord.WebSocket;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Class responsible for handling commands and events.
    /// </summary>
    public class CommandHandler : DiscordClientService
    {
        private readonly IServiceProvider provider;
        private readonly CommandService commandService;
        private readonly IConfiguration config;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandler"/> class.
        /// </summary>
        /// <param name="client">For injecting <see cref="DiscordSocketClient"/>.</param>
        /// <param name="logger">For injecting <see cref="ILogger"/>.</param>
        /// <param name="provider">For injecting <see cref="IServiceProvider"/>.</param>
        /// <param name="commandService">For injecting <see cref="CommandService"/>.</param>
        /// <param name="config">For injecting <see cref="IConfiguration"/>.</param>
        public CommandHandler(DiscordSocketClient client, ILogger<CommandHandler> logger, IServiceProvider provider, CommandService commandService, IConfiguration config)
            : base(client, logger)
        {
            this.provider = provider;
            this.commandService = commandService;
            this.config = config;
        }

        /// <inheritdoc/>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.Client.MessageReceived += this.OnMessageReceived;
            this.commandService.CommandExecuted += this.OnCommandExecuted;
            await this.commandService.AddModulesAsync(Assembly.GetEntryAssembly(), this.provider);
        }

        private async Task OnCommandExecuted(Optional<CommandInfo> commandInfo, ICommandContext commandContext, IResult result)
        {
            if (result.IsSuccess)
            {
                return;
            }

            var errorembed = new EmbedBuilder()
                .WithTitle("Error")
                .WithDescription(result.ErrorReason)
                .WithColor(new Color(238, 62, 75))
                .Build();

            if (result.ErrorReason != "Unknown command.")
            {
                await commandContext.Channel.SendMessageAsync(embed: errorembed);
            }
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
            if (!message.HasStringPrefix(this.config["Prefix"], ref argPos) && !message.HasMentionPrefix(this.Client.CurrentUser, ref argPos))
            {
                return;
            }

            var context = new SocketCommandContext(this.Client, message);
            await this.commandService.ExecuteAsync(context, argPos, this.provider);
        }
    }
}