using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;

namespace ClientUI
{
    public partial class Form1 : Form
    {
        public ClientDriver connection;
        private string otherUsername;
        public Form1(string username)
        {
            InitializeComponent();
            connection = new ClientDriver(username);
            Timer timer = new Timer();
            timer.Interval = (1000); // 1 second
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text != null)
            {
                connection.SendMessage(textBox2.Text);

                AppendText(textBox1, Color.Red, connection.myUsername + ": ");
                AppendText(textBox1, Color.Black, textBox2.Text + "\n");
                textBox2.Text = "";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!connection.serverConnected)
            {
                label2.Text = "Disconnected from server";
                label2.ForeColor = Color.Red;
            }
            List<string> messages = connection.Refresh();
            if (otherUsername == null && messages != null)
            {
                otherUsername = messages.First();
                label3.Text = otherUsername;
                messages.RemoveAt(0);
            }
            else if (messages != null)
            {
                AppendText(textBox1, Color.Blue, otherUsername + ": ");
                while (messages.Count > 0)
                {
                    AppendText(textBox1, Color.Black, messages.First() + "\n");
                    messages.RemoveAt(0);

                }
            }
        }
        public void AppendText(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;
            
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
            }
            box.SelectionLength = 0; // clear
        }
        
    }
}
