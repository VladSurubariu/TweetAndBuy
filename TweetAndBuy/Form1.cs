﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary_TwitterAPIClient;
using Tweetinvi.Core.Models;

namespace TweetAndBuy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string consumer_key = "wNvgwbfz4rdx4o9lPXwv8jUTE";
            string consumer_key_secret = "eHc6mooipwwSXlKvCluC61TrkZDWNPzWRRhYoyHM1baPXqVW9F";
            string acces_token = "1358431620068425731-RwpIYNKT3Wh7Uc1whaRoEJxwgxz6PF";
            string acces_token_secret = "f8pnZLsk08fx2DF6rOPdo6mz6PjJrcJkkZ7yvdK7Ze3IW";

            TwitterAPI_RetrieveData twitterData = new TwitterAPI_RetrieveData(consumer_key, consumer_key_secret, acces_token, acces_token_secret); //compozitie
            
            try
            {
                string username = twitterData.username;
                var user = await twitterData.userClient.Users.GetUserAsync(username);
                await twitterData.retrieveNumberOfTweets();
                int numberOfTweets = twitterData.getNumberOfTweets();
                textBox1.Text = twitterData.timelineTweets[numberOfTweets - 1].ToString();

            }catch (Exception ex)
            {
                textBox1.Text = ex.Message.ToString();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
