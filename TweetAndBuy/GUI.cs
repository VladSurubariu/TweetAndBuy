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

            connection connection = new connection();
            try
            {
                connection.connectGUIToTwitterAPI();
            }
            catch(Exception ex)
            {
                textBox1.Text = ex.Message;
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
