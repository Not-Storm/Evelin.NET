namespace Evelin.Modules
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Discord;
    using Discord.Commands;
    using Evelin.Embeds;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A class containing commands which interact with reddit api.
    /// </summary>
    public class Reddit : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Command to get a meme from reddit api.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Command("meme", RunMode = RunMode.Async)]
        public async Task MemeAsync()
        {
            string[] subreddits = { "https://reddit.com/r/memes/", "https://reddit.com/r/dankmemes/", "https://www.reddit.com/r/wholesomememes/" };
            Random rand = new Random();
            var number = rand.Next(0, subreddits.Length);
            var selectedSubreddit = subreddits[number];
            var client = new HttpClient();
            var result = await client.GetStringAsync($"{selectedSubreddit}random.json?limit=1");
            JArray memearray = JArray.Parse(result);
            JObject post = JObject.Parse(memearray[0]["data"]["children"][0]["data"].ToString());

            var meme = new EvelinEmbedBuilder()
                .WithImageUrl(post["url"].ToString())
                .WithTitle(post["title"].ToString())
                .WithFooter($"{this.Context.User}", this.Context.User.GetAvatarUrl() ?? this.Context.User.GetDefaultAvatarUrl())
                .Build();
            await this.ReplyAsync(embed: meme);
        }

        /// <summary>
        /// Command to get a anime meme from reddit api.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Command("animememe", RunMode = RunMode.Async)]
        [Alias("animeme")]
        public async Task AnimememeAsync()
        {
            string[] redditNames = { "https://www.reddit.com/r/goodanimemes/", "https://www.reddit.com/r/Animemes/", "https://www.reddit.com/r/anime_memes/", "https://www.reddit.com/r/animememes/", "https://www.reddit.com/r/wholesomeanimemes/" };
            Random rand = new Random();
            var number = rand.Next(0, redditNames.Length);
            var selectedreddit = redditNames[number];
            var client = new HttpClient();
            var result = await client.GetStringAsync($"{selectedreddit}random.json?limit=1");
            JArray animemearray = JArray.Parse(result);
            JObject post = JObject.Parse(animemearray[0]["data"]["children"][0]["data"].ToString());

            var meme = new EvelinEmbedBuilder()
                .WithImageUrl(post["url"].ToString())
                .WithTitle(post["title"].ToString())
                .WithFooter($"{this.Context.User}", this.Context.User.GetAvatarUrl() ?? this.Context.User.GetDefaultAvatarUrl())
                .Build();
            await this.ReplyAsync(embed: meme);
        }

        /// <summary>
        /// Command to get a cs meme from reddit api.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Command("csmeme", RunMode = RunMode.Async)]
        public async Task CsmemeAsync()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync("https://www.reddit.com/r/ProgrammerHumor/random.json?limit=1");
            JArray memearray = JArray.Parse(result);
            JObject post = JObject.Parse(memearray[0]["data"]["children"][0]["data"].ToString());

            var meme = new EvelinEmbedBuilder()
                .WithImageUrl(post["url"].ToString())
                .WithTitle(post["title"].ToString())
                .WithFooter($"{this.Context.User}", this.Context.User.GetAvatarUrl() ?? this.Context.User.GetDefaultAvatarUrl())
                .Build();
            await this.ReplyAsync(embed: meme);
        }

        /// <summary>
        /// A command to get the latest post from a subreddit.
        /// </summary>
        /// <param name="searchquery">The subreddit to be searched.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [Command("reddit", RunMode = RunMode.Async)]
        [Alias("r")]
        public async Task RedditAsync(string searchquery)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync($"https://www.reddit.com/r/{searchquery}/random.json?limit=1");
            if (!result.StartsWith("["))
            {
                await this.ReplyAsync("The requested subreddit wasn't found");
                return;
            }

            JArray memearray = JArray.Parse(result);
            JObject post = JObject.Parse(memearray[0]["data"]["children"][0]["data"].ToString());
            if ((bool)post["over_18"])
            {
                if (this.Context.IsPrivate)
                {
                    await this.ReplyAsync("The reddit resulted in a NSFW result, Kindly use a NSFW channel in a server to see it");
                }
                else
                {
                    if ((this.Context.Channel as ITextChannel).IsNsfw)
                    {
                        var meme = new EvelinEmbedBuilder()
                            .WithImageUrl(post["url"].ToString())
                            .WithTitle(post["title"].ToString())
                            .WithFooter($"{this.Context.User}", this.Context.User.GetAvatarUrl() ?? this.Context.User.GetDefaultAvatarUrl())
                            .Build();
                        await this.ReplyAsync(embed: meme);
                    }
                    else
                    {
                        await this.ReplyAsync("The resulting post was NSFW, kindly use a NSFW channel to see it or use a different subreddit");
                    }
                }
            }
            else
            {
                var meme = new EvelinEmbedBuilder()
                    .WithImageUrl(post["url"].ToString())
                    .WithTitle(post["title"].ToString())
                    .WithFooter($"{this.Context.User}", this.Context.User.GetAvatarUrl() ?? this.Context.User.GetDefaultAvatarUrl())
                    .Build();
                await this.ReplyAsync(embed: meme);
            }
        }
    }
}
