namespace Evelin.Modules
{
    using System.Threading.Tasks;
    using Discord;
    using Discord.Commands;
    using Discord.WebSocket;

    /// <summary>
    /// A class which contains all the moderation commands.
    /// </summary>
    public class Modstuff : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// A command to delete a selected number of messages.
        /// </summary>
        /// <param name="amount">Number of messages to be deleted.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Command("purge")]
        [Alias("clear")]
        [RequireUserPermission(ChannelPermission.ManageMessages)]
        [RequireContext(ContextType.Guild)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]
        public async Task PurgeAsync(int amount)
        {
            if (amount <= 500)
            {
                var messages = await this.Context.Channel.GetMessagesAsync(amount + 1).FlattenAsync();
                await (this.Context.Channel as SocketTextChannel).DeleteMessagesAsync(messages);

                var confirm = await this.ReplyAsync($"{amount} messages have been deleted");
                await Task.Delay(2500);
                await confirm.DeleteAsync();
            }
            else
            {
                var error = await this.ReplyAsync("the maximum limit for a purge is 500 messages");
                await Task.Delay(2500);
                await error.DeleteAsync();
            }
        }
    }
}
