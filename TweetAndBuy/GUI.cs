using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Connection_Twitter_GUI;
using SpotifyAPI.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TweetAndBuy
{
    public partial class GUI : Form
    {
        connection connection = new connection();
        SpotifyClient spotify = new SpotifyClient("BQCkKeekZrmJcJ6Xncm6WmVBOgV8kNgG6FCi7vmyT-4FTIO_OjtUyluvqNsJeWLOjTM3U3B08DJWkVi-YmHLhfbreLxoIRWFKiY_yKo956fZF8WThO_A3ShXL6Zw0H0x8QQgP36cviTP-6gH1LCway2shaVO5HVxoiSd_MCE6EF0_uthfIZGceV9wsCERo3o-XKZaL2SvUrkI5NObMfCbisZCFmMEbZkWis");
        string username;
        BackgroundWorker bw;
        IList<string> uris = new List<string>();

        public GUI()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            connection.connectGUIToTwitterAPI();
            username = textBox2.Text;
            connection.twitterData.username = username;
            bw = new BackgroundWorker();
            
            try
            {
                var user = await connection.twitterData.userClient.Users.GetUserAsync(username);
                textBox1.Text = "Conectat";
                button1.Enabled = false;

                bw.DoWork += (obj, ea) => TaskAsync();
                bw.RunWorkerAsync();
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

        private async void TaskAsync()
        {
            while (true)
            {
                await connection.getNumberOfTweetsForUser();

                SearchRequest search_request = new SearchRequest(SearchRequest.Types.Track, connection.twitterData.timelineTweets[0].ToString());
                search_request.Market = "RO";
                search_request.Limit = 1;
                search_request.Offset = 0;

                var track_info = await spotify.Search.Item(search_request);
                var track_uri = track_info.Tracks.Items[0].Uri;
                if (uris.Contains(track_uri) == false)
                {
                    uris.Add(track_uri);

                    IList<string> uri = new List<string>();
                    uri.Add(uris.ElementAt(uris.Count()-1));
                    PlaylistAddItemsRequest add_items_playlist_request = new PlaylistAddItemsRequest(uri);
                    await spotify.Playlists.AddItems("5LnH39HnW4H4tncQMVdQzO", add_items_playlist_request);
                    uri.Clear();
                }
                Thread.Sleep(1000);
            }
        }
    }
}
