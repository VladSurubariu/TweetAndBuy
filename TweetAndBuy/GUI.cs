using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Connection_Twitter_GUI;
using SpotifyAPI.Web;

namespace TweetAndBuy
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        public async Task<string> connect_Spotify()
        {
            var spotify = new SpotifyClient("BQDPk1ceS4wDVrHIwgjIezDMceakSe-y6tmFNISXeLeT3-4vB48-67CGZf4S73d013AJiYpkfZTif4reA7ZInt0PBAq8PDwXy9ZVUyQajRlwSROi14Vm5oI5wy-rgGKF_0cHRlEtfg97Shh4OIprJydQT2Ldj7vAMVqEhdXPG2hKYj7TWoC9C-tt0sSILpJIV2L1tB1w6YG7JQpJMUJ4PqjsF_ypDMWwGvA");
            var track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");
            var user = spotify.UserProfile.Current();

            return track.Name;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            connection connection = new connection();
            //connection.deleteUsername();
            //connection.writeUsername(username);

            connection.connectGUIToTwitterAPI();
            try
            {
                var user = await connection.twitterData.userClient.Users.GetUserAsync(username);
                connection.twitterData.username = username;

                await connection.getNumberOfTweetsForUser();

                //my user id = 31227ybtxt3kqclie7aaxxojuvsi



                var spotify = new SpotifyClient("BQAKnaGN3WCZUnYJjvKqbG7-E6BgN7I9zvKND9kkclhLKpyBij1Cv6AkkdX4dD3fWcNBXR0G5pvaxX4jNMGKrjhAGu76FNvFA0TkQrb1lbHUIeWZ5UGDTu_-Bnkw4-gtaQk_LWyBSUFINhDaPJzf-wMTiW5NO4QYqWr8BIRrE55NOGJmns-SGKsup3pmSlPuWf2Gf71QzgaAPxBUSFFS2H4kxyExbUQWZUOuKHI5FAvUcaXM4wztw9DDDJBgdj3SdSrsjnoilu0");

                //PlaylistCreateRequest request = new PlaylistCreateRequest("Tweeted");
                //request.Public = true;
                //var playlist = await spotify.Playlists.Create("31227ybtxt3kqclie7aaxxojuvsi", request);

                SearchRequest search_request = new SearchRequest(SearchRequest.Types.Track, connection.twitterData.timelineTweets[0].ToString());
                search_request.Market = "RO";
                search_request.Limit= 1;
                search_request.Offset = 0;
                var track_info = await spotify.Search.Item(search_request);


                var track_uri = track_info.Tracks.Items[0].Uri;
                IList<string> uris = new List<string>();
                uris.Add(track_uri);

                PlaylistAddItemsRequest add_items_playlist_request = new PlaylistAddItemsRequest(uris);
                await spotify.Playlists.AddItems("5LnH39HnW4H4tncQMVdQzO", add_items_playlist_request);

                //textBox1.Text = connection.twitterData.timelineTweets[0].ToString();
                textBox1.Text = "Adaugat";


            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message.ToString().Split('(')[0];
                username = "vladsrb11";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
