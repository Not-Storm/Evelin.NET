namespace Infrastructure
{
    using System;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class which intializes PostgresSQL DB.
    /// </summary>
    public class EvelinContext : DbContext
    {
        private readonly string databaseUrl = Environment.GetEnvironmentVariable("PostgresSQL_Database");
        private readonly string databaseUsername = Environment.GetEnvironmentVariable("PostgresSQL_Username");
        private readonly string databasePassword = Environment.GetEnvironmentVariable("PostgresSQL_Password");
        private readonly string databaseName = Environment.GetEnvironmentVariable("PostgresSQL_DatabaseName");

        /// <summary>
        /// Gets or sets tables of server class.
        /// </summary>
        public DbSet<Server> Servers { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql($"Server={this.databaseUrl};Port=5432;Database={this.databaseName};User Id={this.databaseUsername};Password={this.databasePassword};");
    }

    /// <summary>
    /// Class which contains information about server members.
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Gets or sets server's unique id.
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// Gets or sets server's used prefix.
        /// </summary>
        public string Prefix { get; set; }
    }
}
