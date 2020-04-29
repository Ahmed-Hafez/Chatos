using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

/// <summary>
/// Author  : Ahmed Hafez 
/// Job     : Software Engineering Student 
/// Country : Egypt
/// </summary>
namespace ChatosServer
{
    /// <summary>
    /// 
    /// Acting as server side
    /// 
    /// </summary>
    class Server
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
        /// Fires when client end the connection with the server
        /// </summary>
        public event Action clientLeaved;

        /// <summary>
        /// Fires when new client connecting to the server
        /// </summary>
        public event Action newClientConnected;

        /// <summary>
        /// Listener to accept new clients
        /// </summary>
        private TcpListener listener;

        /// <summary>
        /// 
        /// Container for accepted clients
        /// 
        /// Key : Name for each client to get it back as necessary
        /// 
        /// Value : Accepted client
        /// 
        /// </summary>
        private Dictionary<string, Client> clients;

        public string serverName;

        /// <summary>
        /// Default Constructor to initialize
        /// the private fields
        /// </summary>
        /// <param name="serverName">The name of the server user</param>
        /// <param name="port">Port number for listening to connections</param>
        public Server(string serverName = "Server", int port = 5000)
        {
            this.serverName = serverName;

            /// initialize the listener for listening to connections 
            /// on the local IP and port 5000
            IPAddress localIP = getServerIP();
            listener = new TcpListener(localIP, port);

            clients = new Dictionary<string, Client>();
        }

        ~Server()
        {
            listener.Stop();
        }

        /// <summary>
        /// Retrive the IPv6 for the server user
        /// </summary>
        /// <returns> User IP </returns>
        private IPAddress getServerIP()
        {
            // Retrive the Name of local host
            string hostName = Dns.GetHostName();

            // Get the IP
            IPAddress serverIP = Dns.GetHostEntry(hostName).AddressList[0];

            return serverIP;
        }

        public void closeServer()
        {
            sendMessageToAll($"#{serverName} is closed#");
        }

        /// <summary>
        /// Listen to connections
        /// </summary>
        public void listen()
        {
            listener.Start();
            Task.Run(() => AcceptConnections());
        }

        /// <summary>
        /// Accept clients connection to the server
        /// </summary>
        private void AcceptConnections()
        {
            while (true)
            {
                try
                {
                    Client acceptedClient = new Client(listener.AcceptTcpClient());
                    if (clients.ContainsKey(acceptedClient.Name))
                    {
                        // Express that this name was taken by another client.
                        acceptedClient.sendMessage("#Invalid#");
                    }
                    else
                    {
                        addClient(acceptedClient);

                        // Express that this name is available.
                        acceptedClient.sendMessage("#Valid#");

                        // Getting the event from Client Class
                        acceptedClient.messageRecieved += MessageRecieved;

                        acceptedClient.connectionEnded += AcceptedClient_connectionEnded;

                        newClientConnected?.Invoke();

                        Task.Run(() => acceptedClient.recieveMessage());
                    }
                }
                catch
                {
                    MessageBox.Show("Error in Namespace: ChainnetServer,\nClass: Server," +
                        "\nAcceptConnections()", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Express the actions when the connection to the server was lost
        /// </summary>
        /// <param name="clientName"></param>
        private void AcceptedClient_connectionEnded(string clientName)
        {
            clients.Remove(clientName);
            clientLeaved?.Invoke();
        }
        
        /// <summary>
        /// Add accepted clients to the server clients list
        /// </summary>
        /// <param name="acceptedClient"></param>
        private void addClient(Client acceptedClient)
        {
            clients.Add(acceptedClient.Name, acceptedClient);
            sendServerInfo(acceptedClient);
        }

        /// <summary>
        /// Send message to all clients
        /// </summary>
        /// <param name="message">The message to be sent</param>
        public void sendMessageToAll(string message)
        {
            foreach (var client in clients.Values)
            {
                client.sendMessage($"{serverName} send : {message}\r\n");
            }
        }

        /// <summary>
        /// Send message to all clients
        /// </summary>
        /// <param name="message">The message to be sent</param>
        /// <param name="client">The desired client to send message to</param>
        public void sendMessageToClient(string message, string clientName)
        {
            Client client = clients[clientName];
            client.sendMessage($"{serverName} send : {message}\r\n");
        }

        private void sendServerInfo(Client client)
        {
            client.sendMessage($"#Server name: {serverName}#");
            Thread.Sleep(10);
        }

        /// <summary>
        /// Return specified client using its name
        /// on the server
        /// </summary>
        /// <param name="name">Client name</param>
        /// <returns>The specified client</returns>
        public Client getClient(string name)
        {
            return clients[name];
        }

        /// <summary>
        /// Returns all clients on the server
        /// </summary>
        public List<string> getAllClients()
        {
            return new List<string>(clients.Keys);
        }
    }
}
