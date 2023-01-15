using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using Connection_Twitter_GUI;

namespace TweetAndBuy
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            StreamReader sr = new StreamReader("connection_data.txt");
            var line = sr.ReadLine();
            while (line != null)
            {
                textBox1.Text = line;
                line = sr.ReadLine();
            }
            sr.Close();

            //string consumer_key = "wNvgwbfz4rdx4o9lPXwv8jUTE";
            //string consumer_key_secret = "eHc6mooipwwSXlKvCluC61TrkZDWNPzWRRhYoyHM1baPXqVW9F";
            //string acces_token = "1358431620068425731-RwpIYNKT3Wh7Uc1whaRoEJxwgxz6PF";
            //string acces_token_secret = "f8pnZLsk08fx2DF6rOPdo6mz6PjJrcJkkZ7yvdK7Ze3IW";

            //TwitterAPI_RetrieveData twitterData = new TwitterAPI_RetrieveData(consumer_key, consumer_key_secret, acces_token, acces_token_secret); //compozitie

            //try
            //{
            //    string username = twitterData.username;
            //    var user = await twitterData.userClient.Users.GetUserAsync(username);
            //    await twitterData.retrieveNumberOfTweets();
            //    int numberOfTweets = twitterData.getNumberOfTweets();
            //    //textBox1.Text = twitterData.timelineTweets[numberOfTweets - 1].ToString();

            //}
            //catch (Exception ex)
            //{
            //    //textBox1.Text = ex.Message.Split('(')[0];
            //}


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
