namespace Infrastructure
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class which allows Getting and setting data of Server table.
    /// </summary>
    public class Servers
    {
        private readonly EvelinContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Servers"/> class.
        /// </summary>
        /// <param name="context">Parameter for using EvelinContext Class.</param>
        public Servers(EvelinContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Task which modifies the got prefix.
        /// </summary>
        /// <param name="id">Id of the server.</param>
        /// <param name="prefix">Prefix of the server.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task ModifyGuildPrefix(ulong id, string prefix)
        {
            var server = await this.context.Servers
                .FindAsync(id);

            if (server is null)
            {
                this.context.Servers.Add(new Server { Id = id, Prefix = prefix });
            }
            else
            {
                server.Prefix = prefix;
            }

            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets server's perfix.
        /// </summary>
        /// <param name="id">Id of the server.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<string> GetGuildPrefix(ulong id)
        {
            var prefix = await this.context.Servers
                .Where(x => x.Id == id)
                .Select(x => x.Prefix)
                .FirstOrDefaultAsync();

            return await Task.FromResult(prefix);
        }
    }
}