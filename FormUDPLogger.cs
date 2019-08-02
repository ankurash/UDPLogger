using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guiapp
{
    public partial class FormUDPLogger : Form
    {
        public FormUDPLogger()
        {
            InitializeComponent();
            Thread UDPListenerthr = new Thread(new ThreadStart(UDPListener));
            UDPListenerthr.Start();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        //public void udplistnercaller()
        //{
        //    var udpClient = new UdpClient(13102);
        //    UDPListener(udpClient, textBox1);
        //}
        
        private static void UDPListener() //UdpClient udpC, TextBox tb)
        {
            Task.Run(async () =>
            {
                using (var udpClient = new UdpClient(13102))
                {
                    while (true)
                    {
                        var receivedResults = await udpClient.ReceiveAsync();
                        string msg = Encoding.ASCII.GetString(receivedResults.Buffer);
                        Console.WriteLine(msg);
                        //tb.Text = tb.Text + msg;      //<-this is the goal
                    }
                }
            });
        }

        private void ButtonCheck1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("btn1 press received", Environment.NewLine);
            textBoxLogger.Text = textBoxLogger.Text  + "btn1 press received" + Environment.NewLine;
        }

        private void ButtonCheck2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("btn2 press received", Environment.NewLine);
            textBoxLogger.Text = textBoxLogger.Text + "btn2 press received" + Environment.NewLine;
        }
    }
}
