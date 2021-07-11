namespace Evelin.Modules
{
    using System.Threading.Tasks;
    using Discord.Commands;

    /// <summary>
    /// Maths module containing Maths commands.
    /// </summary>
    public class Maths : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// A command to add 2 given numbers.
        /// </summary>
        /// <param name="num1">First number.</param>
        /// <param name="num2">Second number.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Command("add")]
        [Alias("plus")]
        public async Task AddAsync(int num1, int num2)
        {
            await this.Context.Channel.TriggerTypingAsync();
            await this.ReplyAsync($"{num1} + {num2} = {num1 + num2}");
        }
    }
}
