using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPLogger
{
    public class UDPListener : IDisposable
    {
        private int Port;
        private Socket ServerSocket;
        private byte[] PacketStream = new byte[100];
        public delegate void ProcessUDPMessageDelegate(string udpmessage);
        private ProcessUDPMessageDelegate processUDPMessageDelegate = null;
        
        IPEndPoint server;
        IPEndPoint client;
        EndPoint epSender;

        public UDPListener(int port, ProcessUDPMessageDelegate ProcessMessage)
        {
            Port = port;
            this.processUDPMessageDelegate = ProcessMessage;
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server = new IPEndPoint(IPAddress.Any, Port);
            ServerSocket.Bind(server);
            client = new IPEndPoint(IPAddress.Any, 0);
            epSender = (EndPoint)client;
        }

        public void ServerLoad(object sender, EventArgs e)
        {
            try
            {
                ServerSocket.BeginReceiveFrom(this.PacketStream, 0, this.PacketStream.Length, SocketFlags.None, ref epSender, new AsyncCallback(ReceiveData), epSender);
            }
            catch (Exception ex)
            {
            }
        }

        private void ReceiveData(IAsyncResult asyncResult)
        {
            try
            {
                Packet sendData = new Packet(this.PacketStream);
                IPEndPoint clients = new IPEndPoint(IPAddress.Any, 0);
                EndPoint epSender = (EndPoint)clients;
                ServerSocket.EndReceiveFrom(asyncResult, ref epSender);
                ServerSocket.BeginReceiveFrom(this.PacketStream, 0, this.PacketStream.Length, SocketFlags.None, ref epSender, new AsyncCallback(this.ReceiveData), epSender);
                Array.Clear(this.PacketStream, 0, this.PacketStream.Length);
                processUDPMessageDelegate(sendData.ReceivedMsg);
            }
            catch (Exception ex)
            {
            }
        }

        public void ServerLoad(object sender)
        {
            try
            {
                ServerSocket.BeginReceiveFrom(this.PacketStream, 0, this.PacketStream.Length, SocketFlags.None, ref epSender, new AsyncCallback(ReceiveData), epSender);
            }
            catch (Exception ex)
            {
            }
        }

        public void Close()
        {
            ServerSocket.Close();
        }

        public void Dispose()
        {
            this.Close();
        }
    }
    public class Packet
    {
        #region Private Members
        private string message;
        #endregion

        #region Public Properties
        public string ReceivedMsg
        {
            get
            {
                if (!String.IsNullOrEmpty(message))
                {
                    message = message.Replace("\0", "");
                }
                return message;
            }
            set { message = value; }
        }
        #endregion

        #region Methods
        public Packet()
        {
            this.message = null;
        }

        public Packet(byte[] dataStream)
        {
            int msgLength = BitConverter.ToInt32(dataStream, 0);
            if (msgLength > 0)
                this.message = Encoding.UTF8.GetString(dataStream);
            else
                this.message = null;
        }

        #endregion
    }
}
