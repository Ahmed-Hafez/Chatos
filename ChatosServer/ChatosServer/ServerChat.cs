using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace ChatosServer
{
    public partial class ServerChat : Form
    {
        Server server;
        SynchronizationContext context;
        public ServerChat()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
            server = new Server();
            server.messageRecieved += Server_messageRecieved;
            server.newClientConnected += Server_newClientConnected;
            server.clientLeaved += Server_clientLeaved;
        }

        private void Server_clientLeaved()
        {
            context.Post((obj) =>
            {
                if (server.getAllClients().ToArray().Length == 0)
                {
                    ClientsComboBox.Items.Clear();
                    ClientsComboBox.Enabled = false;
                    sendBtn.Enabled = false;
                    messageBox.Enabled = false;
                    devicesConnected.Text = $"{server.getAllClients().Count} Devices Connected";
                }
                else
                {
                    ClientsComboBox.Enabled = true;
                    ClientsComboBox.Items.Clear();
                    ClientsComboBox.Items.AddRange(server.getAllClients().ToArray());
                    ClientsComboBox.Items.Add("All");
                    ClientsComboBox.SelectedItem = "All";
                    sendBtn.Enabled = true;
                    messageBox.Enabled = true;
                    devicesConnected.Text = $"{server.getAllClients().Count} Devices Connected";
                }
            }, null);
        }

        private void ServerChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.closeServer();
        }

        private void Server_newClientConnected()
        {
            context.Post((obj) =>
            {
                ClientsComboBox.Enabled = true;
                ClientsComboBox.Items.Clear();
                ClientsComboBox.Items.AddRange(server.getAllClients().ToArray());
                ClientsComboBox.Items.Add("All");
                ClientsComboBox.SelectedItem = "All";
                sendBtn.Enabled = true;
                messageBox.Enabled = true;
                devicesConnected.Text = $"{server.getAllClients().Count} Devices Connected";
            }, null);
        }

        private void Server_messageRecieved(string message)
        {
            context.Post((obj) =>
            {
                textBoxClientMSG.Text += message;
            }, null);
        }

        private void listenBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(serverNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(serverNameTextBox.Text))
            {
                MessageBox.Show("Server name is not specified", "Build error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                server.serverName = serverNameTextBox.Text;
                hostNameTxtbox.Text = Dns.GetHostName();
                serverNameTextBox.ReadOnly = true;
                server.listen();
                context.Post((obj) =>
                {
                    listenBtn.Enabled = false;
                }, null);
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void messageBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sendMessage();
        }

        private void sendMessage()
        {
            context.Post((obj) =>
            {
                if (ClientsComboBox.SelectedItem.Equals("All"))
                {
                    server.sendMessageToAll(messageBox.Text);
                    textBoxServerMSG.Text += string.Format("You sent: {0}\r\nAt: {1}\r\n",
                                             messageBox.Text,
                                             DateTime.Now.ToShortTimeString());
                }
                else
                {
                    string selectedClient = (string)ClientsComboBox.SelectedItem;
                    server.sendMessageToClient(messageBox.Text, selectedClient);
                    textBoxServerMSG.Text += string.Format("You sent: {0} -> to -> {1}\r\nAt: {2}\r\n",
                                             messageBox.Text, selectedClient,
                                             DateTime.Now.ToShortTimeString());
                }
            }, null);
        }
    }
}
