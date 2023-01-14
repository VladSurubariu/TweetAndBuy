using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Client;
using Tweetinvi.Models;

namespace ClassLibrary_TwitterAPIClient
{
    public class TwitterAPIConnection
    {
        private static string consumer_key = "wNvgwbfz4rdx4o9lPXwv8jUTE";
        private static string consumer_key_secret = "eHc6mooipwwSXlKvCluC61TrkZDWNPzWRRhYoyHM1baPXqVW9F";
        private static string acces_token = "1358431620068425731-RwpIYNKT3Wh7Uc1whaRoEJxwgxz6PF";
        private static string acces_token_secret = "f8pnZLsk08fx2DF6rOPdo6mz6PjJrcJkkZ7yvdK7Ze3IW";
        internal static string username = "vladsrb11";

        public async Task RetrieveTweets()
        {
            var userClient = new TwitterClient(consumer_key, consumer_key_secret, acces_token, acces_token_secret);
            var timelineIterator = userClient.Timelines.GetUserTimelineIterator(username);
            List<ITweet> timelineTweets = new List<ITweet>();
            int numberOfTweets = 0;

            while (!timelineIterator.Completed)
            {
                var page = await timelineIterator.NextPageAsync();
                timelineTweets.AddRange(page);
                numberOfTweets = Math.Max(page.Count(), numberOfTweets);
            }

            for (var index = 0; index < numberOfTweets; index++)
            {
                var tweet = timelineTweets[index];
                Console.WriteLine(tweet.ToString());
            }

        }
    }
}
