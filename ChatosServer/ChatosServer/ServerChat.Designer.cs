namespace ChatosServer
{
    partial class ServerChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.messageBox = new System.Windows.Forms.TextBox();
            this.textBoxClientMSG = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxServerMSG = new System.Windows.Forms.TextBox();
            this.devicesConnected = new System.Windows.Forms.Label();
            this.listenBtn = new System.Windows.Forms.Button();
            this.ClientsComboBox = new System.Windows.Forms.ComboBox();
            this.HostNameLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serverName = new System.Windows.Forms.Label();
            this.serverNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hostNameTxtbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // messageBox
            // 
            this.messageBox.AcceptsReturn = true;
            this.messageBox.Enabled = false;
            this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBox.Location = new System.Drawing.Point(12, 491);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(450, 30);
            this.messageBox.TabIndex = 21;
            this.messageBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.messageBox_KeyUp);
            // 
            // textBoxClientMSG
            // 
            this.textBoxClientMSG.AcceptsReturn = true;
            this.textBoxClientMSG.Location = new System.Drawing.Point(469, 205);
            this.textBoxClientMSG.Multiline = true;
            this.textBoxClientMSG.Name = "textBoxClientMSG";
            this.textBoxClientMSG.ReadOnly = true;
            this.textBoxClientMSG.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxClientMSG.Size = new System.Drawing.Size(393, 241);
            this.textBoxClientMSG.TabIndex = 20;
            // 
            // sendBtn
            // 
            this.sendBtn.Enabled = false;
            this.sendBtn.Location = new System.Drawing.Point(745, 491);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(117, 33);
            this.sendBtn.TabIndex = 19;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(464, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 29);
            this.label2.TabIndex = 18;
            this.label2.Text = "Client send : ";
            // 
            // textBoxServerMSG
            // 
            this.textBoxServerMSG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServerMSG.Location = new System.Drawing.Point(12, 205);
            this.textBoxServerMSG.Multiline = true;
            this.textBoxServerMSG.Name = "textBoxServerMSG";
            this.textBoxServerMSG.ReadOnly = true;
            this.textBoxServerMSG.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxServerMSG.Size = new System.Drawing.Size(450, 241);
            this.textBoxServerMSG.TabIndex = 17;
            // 
            // devicesConnected
            // 
            this.devicesConnected.AutoSize = true;
            this.devicesConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devicesConnected.Location = new System.Drawing.Point(290, 115);
            this.devicesConnected.Name = "devicesConnected";
            this.devicesConnected.Size = new System.Drawing.Size(316, 36);
            this.devicesConnected.TabIndex = 16;
            this.devicesConnected.Text = "0 Devices Connected";
            // 
            // listenBtn
            // 
            this.listenBtn.Location = new System.Drawing.Point(612, 12);
            this.listenBtn.Name = "listenBtn";
            this.listenBtn.Size = new System.Drawing.Size(250, 90);
            this.listenBtn.TabIndex = 15;
            this.listenBtn.Text = "Listen";
            this.listenBtn.UseVisualStyleBackColor = true;
            this.listenBtn.Click += new System.EventHandler(this.listenBtn_Click);
            // 
            // ClientsComboBox
            // 
            this.ClientsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientsComboBox.Enabled = false;
            this.ClientsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ClientsComboBox.FormattingEnabled = true;
            this.ClientsComboBox.Location = new System.Drawing.Point(469, 491);
            this.ClientsComboBox.Name = "ClientsComboBox";
            this.ClientsComboBox.Size = new System.Drawing.Size(270, 33);
            this.ClientsComboBox.Sorted = true;
            this.ClientsComboBox.TabIndex = 22;
            // 
            // HostNameLbl
            // 
            this.HostNameLbl.AutoSize = true;
            this.HostNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostNameLbl.Location = new System.Drawing.Point(12, 9);
            this.HostNameLbl.Name = "HostNameLbl";
            this.HostNameLbl.Size = new System.Drawing.Size(128, 24);
            this.HostNameLbl.TabIndex = 23;
            this.HostNameLbl.Text = "Host name : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Listen to server and use the provided host name to get access to the server";
            // 
            // serverName
            // 
            this.serverName.AutoSize = true;
            this.serverName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverName.Location = new System.Drawing.Point(12, 74);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(147, 24);
            this.serverName.TabIndex = 25;
            this.serverName.Text = "Server name : ";
            // 
            // serverNameTextBox
            // 
            this.serverNameTextBox.Location = new System.Drawing.Point(157, 75);
            this.serverNameTextBox.Name = "serverNameTextBox";
            this.serverNameTextBox.Size = new System.Drawing.Size(449, 22);
            this.serverNameTextBox.TabIndex = 26;
            this.serverNameTextBox.Text = "Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 29);
            this.label3.TabIndex = 27;
            this.label3.Text = "You send : ";
            // 
            // hostNameTxtbox
            // 
            this.hostNameTxtbox.Location = new System.Drawing.Point(157, 12);
            this.hostNameTxtbox.Name = "hostNameTxtbox";
            this.hostNameTxtbox.ReadOnly = true;
            this.hostNameTxtbox.Size = new System.Drawing.Size(449, 22);
            this.hostNameTxtbox.TabIndex = 28;
            // 
            // ServerChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 531);
            this.Controls.Add(this.hostNameTxtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.serverNameTextBox);
            this.Controls.Add(this.serverName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HostNameLbl);
            this.Controls.Add(this.ClientsComboBox);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.textBoxClientMSG);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxServerMSG);
            this.Controls.Add(this.devicesConnected);
            this.Controls.Add(this.listenBtn);
            this.Name = "ServerChat";
            this.Text = "ServerChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerChat_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.TextBox textBoxClientMSG;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxServerMSG;
        private System.Windows.Forms.Label devicesConnected;
        private System.Windows.Forms.Button listenBtn;
        private System.Windows.Forms.ComboBox ClientsComboBox;
        private System.Windows.Forms.Label HostNameLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label serverName;
        private System.Windows.Forms.TextBox serverNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hostNameTxtbox;
    }
}