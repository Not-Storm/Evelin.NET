namespace Evelin.Modules
{
    using System;
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
        public async Task AddAsync(double num1, double num2)
        {
            await this.Context.Channel.TriggerTypingAsync();
            await this.ReplyAsync($"{num1} + {num2} = {num1 + num2}");
        }

        /// <summary>
        /// A command to subtract a number from another.
        /// </summary>
        /// <param name="num1">The first number.</param>
        /// <param name="num2">The second number.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Command("subtract")]
        [Alias("sub", "minus")]
        public async Task SubtractAsync(double num1, double num2)
        {
            await this.Context.Channel.TriggerTypingAsync();
            await this.ReplyAsync($"{num1} - {num2} = {num1 - num2}");
        }

        /// <summary>
        /// A command to multiply 2 given numbers.
        /// </summary>
        /// <param name="num1">The first number.</param>
        /// <param name="num2">The second number.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Command("multiply")]
        [Alias("into")]
        public async Task MultiplyAsync(double num1, double num2)
        {
            await this.Context.Channel.TriggerTypingAsync();
            await this.ReplyAsync($"{num1} * {num2} = {num1 * num2}");
        }

        /// <summary>
        /// A command to divide 2 given numbers.
        /// </summary>
        /// <param name="num1">The first number.</param>
        /// <param name="num2">The second number.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Command("divide")]
        [Alias("by")]
        public async Task DivideAsync(double num1, double num2)
        {
            await this.Context.Channel.TriggerTypingAsync();
            await this.ReplyAsync($"{num1} / {num2} = {num1 / num2}");
        }

        /// <summary>
        /// gets the remainder after dividing numbers.
        /// </summary>
        /// <param name="num1">the first number.</param>
        /// <param name="num2">the second number.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Command("remainder")]
        public async Task RemainderAsync(double num1, double num2)
        {
            await this.Context.Channel.TriggerTypingAsync();
            await this.ReplyAsync($"({num1} / {num2}) the remainder will be = {num1 % num2}");
        }

        /// <summary>
        /// A command to raise the power of a given number.
        /// </summary>
        /// <param name="num1">the first number.</param>
        /// <param name="num2">the second number.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Command("exponent")]
        [Alias("power")]
        public async Task ExponentAsync(double num1, double num2)
        {
            await this.Context.Channel.TriggerTypingAsync();
            await this.ReplyAsync($"{num1} ^ {num2} = {Math.Pow(num1, num2)}");
        }

        /// <summary>
        /// A command to take the root of a number.
        /// </summary>
        /// <param name="num">the number.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Command("root")]
        public async Task RootAsync(double num)
        {
            await this.Context.Channel.TriggerTypingAsync();
            await this.ReplyAsync($"root of {num} = {Math.Sqrt(num)}");
        }
    }
}
