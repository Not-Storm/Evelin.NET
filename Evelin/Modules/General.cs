namespace Evelin.Modules
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Discord;
    using Discord.Commands;
    using Evelin.Embeds;
    using Infrastructure;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// General module containing basic commands.
    /// </summary>
    public class General : ModuleBase<SocketCommandContext>
    {
        private readonly Servers _servers;

        public General(Servers servers)
        {
            _servers = servers;
        }

        /// <summary>
        /// A command to get client to gateway latency.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of Asynchronous Task.</returns>
        [Command("ping")]
        [Summary("Get bot to gateway latency")]
        [Alias("latency", "test")]
        public async Task PingAsync()
        {
            await this.Context.Channel.TriggerTypingAsync();
            int ping = this.Context.Client.Latency;
            await this.Context.Channel.SendMessageAsync($"Pong! {ping}ms");
        }

        /// <summary>
        /// A command to get a quote from zenquotes api.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Command("quote", RunMode = RunMode.Async)]
        [Summary("Get an inspirational quote from zenquotes api")]
        [Alias("inspire")]
        public async Task QuoteAsync()
        {
            await this.Context.Channel.TriggerTypingAsync();
            var client = new HttpClient();
            var result = await client.GetStringAsync("https://zenquotes.io/api/random");
            JArray array = JArray.Parse(result);
            string quote = array[0]["q"].ToString();
            string author = array[0]["a"].ToString();
            var embed = new EvelinEmbedBuilder()
                .WithTitle("Quote")
                .WithDescription($"{quote} - {author}")
                .WithFooter($"{this.Context.User}", this.Context.User.GetAvatarUrl() ?? this.Context.User.GetDefaultAvatarUrl())
                .Build();
            await this.ReplyAsync(embed: embed);
        }

        /// <summary>
        /// Command to change prefix of the bot.
        /// </summary>
        /// <param name="newprefix">the new prefix.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Command("prefix", RunMode = RunMode.Async)]
        [Summary("Change bot's default prefix")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task PrefixAsync(string newprefix = null)
        {
            if (newprefix is null)
            {
                var guildprefix = await _servers.GetGuildPrefix(Context.Guild.Id) ?? "-";
                await ReplyAsync($"The current prefix of bot is `{guildprefix}`");
                return;
            }

            if (newprefix.Length > 8)
            {
                await this.ReplyAsync("The prefix needs to be shorter then 8 characters");
                return;
            }

            if ( newprefix == "def" || newprefix == "default")
            {
                await this._servers.ModifyGuildPrefix(this.Context.Guild.Id, "-")
                await this.ReplyAsync($"The prefix was changed back to the default prefix `-`")
            }

            await this._servers.ModifyGuildPrefix(this.Context.Guild.Id, newprefix);
            await this.ReplyAsync($"Bot's prefix for the guild was changed to `{newprefix}`");
        }
    }
}