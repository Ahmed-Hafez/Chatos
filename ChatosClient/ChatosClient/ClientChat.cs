using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatosClient
{
    public partial class ClientChat : Form
    {
        Client client;
        SynchronizationContext context;
        public ClientChat()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
        }

        private void ClientChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            client?.sendMessage($"#{client.Name} is closed#");
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(hostNameTxtbox.Text) ||
                string.IsNullOrWhiteSpace(hostNameTxtbox.Text)) ||
               (string.IsNullOrEmpty(usernameTxtbox.Text) ||
                string.IsNullOrWhiteSpace(usernameTxtbox.Text)))
            {
                MessageBox.Show("Host name and Your name are not specified",
                                "Build error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(hostNameTxtbox.Text) ||
               string.IsNullOrWhiteSpace(hostNameTxtbox.Text))
            {
                MessageBox.Show("Host name is not specified", "Build error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(usernameTxtbox.Text) ||
                     string.IsNullOrWhiteSpace(usernameTxtbox.Text))
            {
                MessageBox.Show("Your name is not specified", "Build error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Regex.IsMatch(usernameTxtbox.Text, @"[\W]"))
            {
                MessageBox.Show("Your name can only contain characters, numbers and underscores",
                                "Build error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Task.Run(() =>
                {
                    client = new Client();
                    bool connectionSuccessful = client.connect(hostNameTxtbox.Text,
                                                               usernameTxtbox.Text, 3);
                    if (connectionSuccessful)
                    {
                        client.messageRecieved += Client_messageRecieved;
                        client.serverClosed += Client_serverClosed;
                        context.Post((object obj) =>
                        {
                            serverNameLbl.Text = $"You connected to : {client.ServerName}";
                            connectBtn.Enabled = false;
                            sendBtn.Enabled = true;
                            messageTxtBox.Enabled = true;
                        }, null);
                    }
                    else
                    {
                        context.Post((object obj) => MessageBox.Show("Server not available", "Connection Erorr",
                                                     MessageBoxButtons.OK, MessageBoxIcon.Error), null);
                        client = null;
                    }
                });
            }
        }

        private void Client_serverClosed(string message)
        {
            context.Post((object obj) =>
            {
                serverNameLbl.Text = "No Connection right now";
                connectBtn.Enabled = true;
                sendBtn.Enabled = false;
                messageTxtBox.Enabled = false;
                textBoxServerMSG.Text += message + "\r\n";
                client = null;
            }, null);
        }

        private void Client_messageRecieved(string message)
        {
            context.Post((object obj) => textBoxServerMSG.Text += message, null);
        }

        private void messageTxtBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sendMessage();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void sendMessage()
        {
            client.sendMessage(messageTxtBox.Text);
            textBoxClientMSG.Text += string.Format("You sent: {0}\r\nAt: {1}\r\n",
                                     messageTxtBox.Text,
                                     DateTime.Now.ToShortTimeString());
        }
    }
}
