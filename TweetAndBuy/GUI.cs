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

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;

            connection connection = new connection();
            connection.writeUsername(username);
            connection.deleteUsername();
            connection.connectGUIToTwitterAPI();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
