using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_TwitterAPIClient;

namespace Connection_Twitter_GUI
{
    public class data_file
    {
        public string fileName = "connection_data.txt";
        public data_file() { }
        public string readConnectionFile()
        {
            string text = File.ReadAllText(fileName);

            return text;
            
        }
    }


    public class Connection_Twitter_GUI
    {
        private async void connectGUIToTwitterAPI(object sender, EventArgs e)
        {
            string consumer_key = "wNvgwbfz4rdx4o9lPXwv8jUTE";
            string consumer_key_secret = "eHc6mooipwwSXlKvCluC61TrkZDWNPzWRRhYoyHM1baPXqVW9F";
            string acces_token = "1358431620068425731-RwpIYNKT3Wh7Uc1whaRoEJxwgxz6PF";
            string acces_token_secret = "f8pnZLsk08fx2DF6rOPdo6mz6PjJrcJkkZ7yvdK7Ze3IW";



        }
    }
}
