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
    public class TwitterAPI_Connection
    {

        public TwitterClient userClient;

        private static string consumer_key { get; }
        private static string consumer_key_secret { get; }
        private static string acces_token { get; }
        private static string acces_token_secret { get; }

        public TwitterAPI_Connection(string consumer_key, string consumer_key_secret, string acces_token, string acces_token_secret)
        {
            userClient = new TwitterClient(consumer_key, consumer_key_secret, acces_token, acces_token_secret);
        }
        
    }
    public class TwitterAPI_RetrieveData : TwitterAPI_Connection // mostenire
    {

        public List<ITweet> timelineTweets = new List<ITweet>();

        public int numberOfTweets;

        public string username
        {
            get { return "vladsrb11"; }
        }

        protected string exceptionMessage = "None";
        protected bool checkException = false;

        public TwitterAPI_RetrieveData(string consumer_key, string consumer_key_secret, string acces_token, string acces_token_secret)
            : base(consumer_key, consumer_key_secret, acces_token, acces_token_secret)
        {
        }


        public int getNumberOfTweets()
        {
            if (checkException)
            {
                return 1000;
            }
            else
            {
                return numberOfTweets;
            }
        }

        public async Task countTweets()
        {
            var timelineIterator = userClient.Timelines.GetUserTimelineIterator(username);

            while (!timelineIterator.Completed)
            {
                var page = await timelineIterator.NextPageAsync();
                timelineTweets.AddRange(page);
                numberOfTweets = Math.Max(page.Count(), numberOfTweets);
            }
        }
    }
}
