namespace Evelin.Embeds
{
    using Discord;
    using Discord.WebSocket;

    /// <summary>
    /// A custom embed builder to prevent repetitive code.
    /// </summary>
    internal class EvelinEmbedBuilder : EmbedBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EvelinEmbedBuilder"/> class.
        /// </summary>
        public EvelinEmbedBuilder()
        {
            this.WithColor(new Color(148, 54, 178));
        }
    }
}
