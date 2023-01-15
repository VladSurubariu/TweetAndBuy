using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
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
            string username = textBox2.Text;

            connection connection = new connection();
            //connection.deleteUsername();
            //connection.writeUsername(username);

            connection.connectGUIToTwitterAPI();

            try
            {
                var user = await connection.twitterData.userClient.Users.GetUserAsync(username);
                textBox1.Text = username;

            }catch (Exception ex)
            {
                textBox1.Text = ex.Message.ToString().Split('(')[0];
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
