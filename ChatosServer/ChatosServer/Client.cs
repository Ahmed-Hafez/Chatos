using System;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Author  : Ahmed Hafez 
/// Job     : Software Engineering Student 
/// Country : Egypt
/// </summary>
namespace ChatosServer
{
    class Client
    {
        /// <summary>
        /// Fires when new messages recieved from the clients
        /// </summary>
        private event Action<string> MessageRecieved;
        public event Action<string> messageRecieved
        {
            add { MessageRecieved += value; }
            remove { MessageRecieved -= value; }
        }

        /// <summary>
        /// Fires when the client ended the connection to the server
        /// </summary>
        public event Action<string> connectionEnded;

        /// <summary>
        /// Express the client
        /// </summary>
        private TcpClient client;

        /// <summary>
        /// Message reader for the client's messages
        /// </summary>
        private StreamReader reader;

        /// <summary>
        /// Message writer for sending messages to the client
        /// </summary>
        private StreamWriter writer;

        /// <summary>
        /// Information about the client,
        /// Such as : Name, Desired room number
        /// </summary>
        private string infoMessage;

        /// <summary>
        /// Client name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Desired room number
        /// </summary>
        public int RoomNumber { get; private set; }


        /// <summary>
        /// Default constructor to initialize the private fields
        /// </summary>
        /// <param name="client">The connected client</param>
        public Client(TcpClient client)
        {
            this.client = client;

            NetworkStream stream = client.GetStream();

            writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            reader = new StreamReader(stream);

            // Initializing "Name" and "RoomNumber"
            infoMessage = recieveInfoMessage();
            getClientInfo();
        }

        ~Client()
        {
            client.Close();
            reader.Close();
            writer.Close();
        }


        /// <summary>
        /// Returns the recieved information message from client.
        /// </summary>
        /// <returns>The Client's information message</returns>
        private string recieveInfoMessage()
        {
            char[] messageBuffer = new char[10000];
            reader.Read(messageBuffer, 0, 10000);

            return new string(messageBuffer);
        }

        /// <summary>
        /// Recieve messages from the client.
        /// </summary>
        public void recieveMessage()
        {
            while (true)
            {
                // Reading the message from the stream.
                char[] messageBuffer = new char[10000];
                reader.Read(messageBuffer, 0, 10000);
                string message = new string(messageBuffer);

                if (isClosed(message))
                {
                    // Getting the whole message without (#)
                    message = Regex.Match(message, "#(.+)#").Groups[1].Value + "\r\n";
                    MessageRecieved?.Invoke(message);
                    connectionEnded?.Invoke(this.Name);
                    return;
                }

                if (messageBuffer[0] != '\0')
                {
                    message += "\r\n";

                    // Firing the event.
                    MessageRecieved?.Invoke(message);
                }
                else return;
            }
        }

        /// <summary>
        /// Send messages to the client.
        /// </summary>
        /// <param name="message">Message to send</param>
        public void sendMessage(string message)
        {
            writer.Write(message);
            Thread.Sleep(100);
        }

        /// <summary>
        /// Get client information which are his name and his desired room.
        /// Item1 : Name,
        /// Item2 : Room number.
        /// </summary>
        /// <param name="infoMessage">The message which held information for each client</param>
        /// <returns>Tuple of username and room number</returns>
        private void getClientInfo()
        {
            Match resolveMessage = Regex.Match(infoMessage, @"#([\w ]+)#(\d+)#");
            Name = resolveMessage.Groups[1].Value;
            RoomNumber = int.Parse(resolveMessage.Groups[2].Value);
        }

        /// <summary>
        /// Check if the client leaves the server.
        /// 
        /// <!--Closing pattern is : "#ClientName is closed#"-->
        /// </summary>
        /// <param name="message">Check if this message contains closing pattern</param>
        private bool isClosed(string message)
        {
            return (Regex.IsMatch(message, @"#(.+) is closed#"));
        }
    }
}
