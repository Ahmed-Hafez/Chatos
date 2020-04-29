using System;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// Author  : Ahmed Hafez 
/// Job     : Software Engineering Student 
/// Country : Egypt
/// </summary>
namespace ChatosClient
{
    class Client
    {
        /// <summary>
        /// Event handler to messages recieved.
        /// </summary>
        public event Action<string> messageRecieved;

        /// <summary>
        /// Fires when connection to server was lost.
        /// </summary>
        public event Action<string> serverClosed;

        /// <summary>
        /// Express the client.
        /// </summary>
        private TcpClient client;

        /// <summary>
        /// Message reader for the server messages.
        /// </summary>
        private StreamReader reader;

        /// <summary>
        /// Message writer for sending messages to the server.
        /// </summary>
        private StreamWriter writer;

        /// <summary>
        /// Client name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Desired room number.
        /// </summary>
        public int RoomNumber { get; private set; }

        /// <summary>
        /// The server which was the client connected to.
        /// </summary>
        public string ServerName { get; private set; }

        /// <summary>
        /// Destructor to close the connection, writer, reader
        /// </summary>
        ~Client()
        {
            client?.Close();
            writer?.Close();
            reader?.Close();
        }

        /// <summary>
        /// Connect to the specified Host
        /// <para>Returns true if connection is successful</para>
        /// </summary>
        public bool connect(string hostname, string name,
                            int roomNumber, int port = 5000)
        {
            try
            {
                client = new TcpClient(hostname, port);

                NetworkStream stream = client.GetStream();

                writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                reader = new StreamReader(stream);
            }
            catch
            {
                return false;
            }

            Name = name;
            RoomNumber = roomNumber;

            sendClientInfo();

            recieveServerInfo();

            if (validClientName())
            {
                Task.Run(() => recieveMessage());

                return true;
            }
            else return false;
        }

        private bool validClientName()
        {
            char[] messageBuffer = new char[10000];
            reader.Read(messageBuffer, 0, 10000);
            string message = new string(messageBuffer);

            return Regex.IsMatch(message, "#Valid#");
        }

        /// <summary>
        /// Recieve messages from the Server.
        /// </summary>
        public void recieveMessage()
        {
            while (true)
            {
                try
                {
                    // Reading the message from the stream.
                    char[] messageBuffer = new char[10000];
                    reader.Read(messageBuffer, 0, 10000);
                    string message = new string(messageBuffer);

                    // Check if the server ended the connection
                    if (isConnectionEnded(message))
                    {
                        message = Regex.Match(message, "#(.+)#").Groups[1].Value;
                        serverClosed?.Invoke(message);
                        client.Close();
                        client.Dispose();
                    }
                    else
                    {
                        message += "\r\n";

                        // Firing the event.
                        messageRecieved?.Invoke(message);
                    }
                }
                catch
                {
                    // Just for handling the disposed object(reader) when closing the program.
                    // when the program is closing the reader throws an exception because the client object
                    // is disposed and the reader still try to read messages in another thread so, 
                    // this "try - catch" block just for handling this. 
                }
            }
        }

        /// <summary>
        /// Check if the server is closed.
        /// 
        /// <!--Closing pattern is : "#ServerName is closed#"-->
        /// </summary>
        /// <param name="message">Check if this message contains the closing pattern</param>
        private bool isConnectionEnded(string message)
        {
            return (Regex.IsMatch(message, @"#(.+) is closed#"));
        }

        /// <summary>
        /// Send messages to the server.
        /// </summary>
        /// <param name="message">Message to send</param>
        public void sendMessage(string message)
        {
            writer?.Write($"{Name} sent : {message}\r\n");
        }

        /// <summary>
        /// Send client information which are his name and his desired room.
        /// Item1 : Name,
        /// Item2 : Room number.
        /// </summary>
        /// <param name="infoMessage">The message which held information for each client</param>
        /// <returns>Tuple of username and room number</returns>
        private void sendClientInfo()
        {
            writer.Write($"#{Name}#{RoomNumber}#");
        }

        /// <summary>
        /// Recieve information about the server.
        /// </summary>
        private void recieveServerInfo()
        {
            char[] messageBuffer = new char[10000];
            reader.Read(messageBuffer, 0, 10000);
            string message = new string(messageBuffer);
            
            ServerName = Regex.Match(message, @"#Server name: (.+)#").Groups[1].Value;
        }
    }
}
