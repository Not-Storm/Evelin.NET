namespace Evelin.Modules
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Discord;
    using Discord.Commands;
    using Discord.WebSocket;
    using Evelin.Embeds;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// General module containing basic commands.
    /// </summary>
    public class General : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// A basic command which replies with "Pong!" upon use.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of Asynchronous Task.</returns>
        [Command("ping")]
        [Alias("latency", "test")]
        public async Task PingAsync()
        {
            await this.Context.Channel.TriggerTypingAsync();
            await this.Context.Channel.SendMessageAsync($"Pong! ms");

            // add latency command ask on discord for DiscordSocketClient.Latency(); or whatever it is
        }

        /// <summary>
        /// A command to get a random quote from zenquote api.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Command("quote")]
        [Alias("inspire")]
        public async Task QuoteAsync()
        {
            await this.Context.Channel.TriggerTypingAsync();
            var client = new HttpClient();
            var result = await client.GetStringAsync("https://zenquotes.io/api/random");
            JArray qarray = JArray.Parse(result);
            string quote = qarray[0]["q"].ToString();
            string author = qarray[0]["a"].ToString();
            var embed = new EvelinEmbedBuilder()
                .WithTitle("Quote")
                .WithDescription($"{quote} - {author}")
                .WithFooter(this.Context.Client.CurrentUser.GetAvatarUrl() ?? this.Context.Client.CurrentUser.GetDefaultAvatarUrl(), $"{this.Context.Client.CurrentUser.Username}#{this.Context.Client.CurrentUser.Discriminator}")
                .Build();
            await this.ReplyAsync(embed: embed);

            // check this command out once its a disaster
        }
    }
}