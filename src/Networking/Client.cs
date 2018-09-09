using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using CardServer.Util;

namespace CardServer.Networking
{
    /// A dummy client for testing purposes
    internal class Client
    {
        private TcpClient client;
        private const string HOSTNAME = "localhost";
        private const int PORT = 7777;

        public Client()
        {
            Debug.Log("Client starting...");
            this.client = new TcpClient(HOSTNAME, PORT);
            Debug.Log("...client connected.");
        }

        public string ReceiveFromServer()
        {
            Debug.Log("Receiving from server...");
            NetworkStream stream = this.client.GetStream();

            string read;
            using (var reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: true))
            {
                read = reader.ReadString();
            }

            Debug.Log("Received this:");
            Debug.Log($"\t{read}");

            return read;
        }

        public T ReceiveFromServer<T>()
        {
            string received = this.ReceiveFromServer();

            T obj = CardServer.Util.Json.Deserialize<T>(received);

            if (obj == null)
            {
                throw new Exception($"Unable to generate object of type {typeof(T)} from json {received}");
            }

            return obj;
        }

        public void SendToServer(string message)
        {
            Debug.Log("Sending message to server...");

            NetworkStream stream = this.client.GetStream();

            using (var writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: true))
            {
                writer.Write(message);
            }

            Debug.Log("...sent.");
        }
    }
}