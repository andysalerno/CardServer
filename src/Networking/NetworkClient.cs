using CardServer.Util;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CardServer.Networking
{
    /// <summary>
    /// A simple TCP network client for sending/receiving messages with a <see cref="NetworkGameServer"/>.
    /// </summary>
    internal class NetworkClient
    {
        private TcpClient client;
        private const string HOSTNAME = "localhost";
        private const int PORT = 7777;

        public NetworkClient()
        {
            Debug.Log("Client starting...");
            this.AttemptConnection();
            Debug.Log("...client connected.");
        }

        private void AttemptConnection()
        {
            int attemptsRemaining = 10;
            const int RetryDelayMs = 5000;

            while (attemptsRemaining > 0)
            {
                try
                {
                    this.client = new TcpClient(HOSTNAME, PORT);
                    return;
                }
                catch (Exception)
                {
                    attemptsRemaining--;
                    Debug.Log($"Client failed to connect to server, {attemptsRemaining} attempts remaining");
                    Thread.Sleep(RetryDelayMs);
                }
            }
        }

        public string ReceiveFromServer()
        {
            NetworkStream stream = this.client.GetStream();

            if (!stream.DataAvailable)
            {
                return null;
            }

            return this.WaitUntilReceiveFromServer();
        }

        public string WaitUntilReceiveFromServer()
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