using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDPLogger
{
    public partial class MainForm : Form
    {
        private static List<UDPListener> UDPListeners = new List<UDPListener>();
        private static List<int> UDPListenPorts = new List<int>() { 11000, 11001, 11002};

        public MainForm()
        {
            InitializeComponent();
            foreach(int port in UDPListenPorts)
            {
                Console.WriteLine("Initializing Port " + port);
                UDPListeners.Add(new UDPListener(port, new UDPListener.ProcessUDPMessageDelegate(this.PrintLogs)));
            }
        }

        private void PrintLogs(string message)
        {
            if(this.richTextBoxMessages.InvokeRequired)
            {
                UDPListener.ProcessUDPMessageDelegate d = new UDPListener.ProcessUDPMessageDelegate(PrintLogs);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                if (!String.IsNullOrEmpty(message))
                {
                    richTextBoxMessages.AppendText(message + "\n");
                    richTextBoxMessages.SelectionStart = richTextBoxMessages.TextLength;
                    richTextBoxMessages.ScrollToCaret();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach(UDPListener listener in UDPListeners)
            {
                listener.ServerLoad(sender, e);
            }
        }
    }
}
