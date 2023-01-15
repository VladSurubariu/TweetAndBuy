using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_TwitterAPIClient;
using Tweetinvi.Parameters.V2;

namespace Connection_Twitter_GUI
{
    public class data_file
    {
        public string dataFileName = @"../../connection_data.txt";
        List<string> list_connection_info = new List<string>();

        public data_file() { }


        public List<string> readConnectionFile()
        {
            StreamReader sr = new StreamReader(dataFileName);

            string line = sr.ReadLine();
            while (line != null)
            {
                list_connection_info.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();

            return list_connection_info;
        }

        
        public void writeUsername (string given_username)
        {
           StreamWriter sw = File.AppendText(dataFileName);
           sw.WriteLine("username:"+given_username);
           sw.Close();
        }

        public void deleteUsername()
        {
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(dataFileName).Where(l => l.Contains("username") != true);
            
            File.WriteAllLines(tempFile, linesToKeep);
            File.Delete(dataFileName);
            File.Move(tempFile, dataFileName);
            File.Delete(tempFile);
        }


        public string trimDataEntry(string key_type)
        {
            var s_key = from data in list_connection_info
                               where data.Contains(key_type)
                               select data;

            string s_string = s_key.First();
            string[] s_strings = s_string.Split(':');
            return s_strings[1];
        }
    }


    public class connection : data_file
    {
        private static data_file acces_data = new data_file();
        private List<string> connection_data_list = new List<string>(acces_data.readConnectionFile());

        public TwitterAPI_RetrieveData twitterData = new TwitterAPI_RetrieveData("", "", "", "");

        public void connectGUIToTwitterAPI()
        {
            var consumer_key = acces_data.trimDataEntry("consumer_key");
            var consumer_key_secret = acces_data.trimDataEntry("consumer_key_secret");
            var acces_token = acces_data.trimDataEntry("acces_token");
            var acces_token_secret = acces_data.trimDataEntry("acces_token_secret");

            twitterData = new TwitterAPI_RetrieveData(consumer_key, consumer_key_secret, acces_token, acces_token_secret); //compozitie

        }

        public async Task<int> getNumberOfTweetsForUser()
        {
            await twitterData.countTweets();
            return twitterData.getNumberOfTweets();
        }


    }
}
