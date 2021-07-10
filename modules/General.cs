namespace Evelin.modules
{
    using Discord;
    using Discord.Commands;
    using Discord.WebSocket;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// General module containing basic commands.
    /// </summary>
    public class General : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// A basic command which replies with "Pong!" upon use.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of Asynchronous Task</returns>
        [Command("ping")]
        [Alias("latency" , "test")]
        public async Task PingAsync()
        {
            await this.Context.Channel.TriggerTypingAsync();
            await this.Context.Channel.SendMessageAsync("Pong!");

           // enable discord presence intents
           //  enable server intent too sire
           //  and read description of s2 ep 3 for presence intent ig

           // Install Stylecop.Analyzer uwu~ for conventions
           // also push the changes lmao the currect repo shouldnt work if i am correct
           // Check out Discord.NET analyzer uwu~
           // also good night to anyone reading this uwu~
        }
    }
}
