using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using CardServer.Util;

namespace CardServer.Networking
{
    internal class Server
    {
        private TcpListener listener;
        private const int PORT = 7777;
        private IPAddress LocalAddress => IPAddress.Parse("127.0.0.1");

        private List<TcpClient> clients = new List<TcpClient>();

        public Server()
        {
            this.listener = new TcpListener(LocalAddress, PORT);

            Debug.Log("Starting server...");
            this.listener.Start();
            Debug.Log("...started.");
        }

        public void AcceptClient()
        {
            Debug.Log("Accepting TCP client...");
            var client = this.listener.AcceptTcpClient();
            Debug.Log("...accepted.");

            this.clients.Add(client);
        }

        public string ReceiveFromClient()
        {
            Debug.Log("Waiting to receive from client...");

            NetworkStream stream = this.clients.First().GetStream();

            string read = null;
            using (var reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: true))
            {
                read = reader.ReadString();
            }

            if (read == null)
            {
                throw new Exception("Couldn't read from stream!");
            }

            return read;
        }

        public void SendToClient(string message)
        {
            Debug.Log("Sending message to client...");

            NetworkStream stream = this.clients.First().GetStream();

            var formatter = new BinaryFormatter();

            using (var writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: true))
            {
                writer.Write(message);
            }

            Debug.Log("...sent.");
        }

        public void Flush()
        {
            this.clients.First().GetStream().Flush();
        }
    }
}