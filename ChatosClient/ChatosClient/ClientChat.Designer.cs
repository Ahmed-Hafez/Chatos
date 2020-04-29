namespace ChatosClient
{
    partial class ClientChat
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
            this.messageTxtBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.textBoxServerMSG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxClientMSG = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hostNameTxtbox = new System.Windows.Forms.TextBox();
            this.HostNameLbl = new System.Windows.Forms.Label();
            this.usernameTxtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serverNameLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messageTxtBox
            // 
            this.messageTxtBox.AcceptsReturn = true;
            this.messageTxtBox.Enabled = false;
            this.messageTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageTxtBox.Location = new System.Drawing.Point(12, 423);
            this.messageTxtBox.Name = "messageTxtBox";
            this.messageTxtBox.Size = new System.Drawing.Size(450, 30);
            this.messageTxtBox.TabIndex = 18;
            this.messageTxtBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.messageTxtBox_KeyUp);
            // 
            // sendBtn
            // 
            this.sendBtn.Enabled = false;
            this.sendBtn.Location = new System.Drawing.Point(468, 430);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(117, 23);
            this.sendBtn.TabIndex = 17;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // textBoxServerMSG
            // 
            this.textBoxServerMSG.AcceptsReturn = true;
            this.textBoxServerMSG.Location = new System.Drawing.Point(316, 169);
            this.textBoxServerMSG.Multiline = true;
            this.textBoxServerMSG.Name = "textBoxServerMSG";
            this.textBoxServerMSG.ReadOnly = true;
            this.textBoxServerMSG.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxServerMSG.Size = new System.Drawing.Size(267, 241);
            this.textBoxServerMSG.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(316, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "Server send : ";
            // 
            // textBoxClientMSG
            // 
            this.textBoxClientMSG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxClientMSG.Location = new System.Drawing.Point(12, 169);
            this.textBoxClientMSG.Multiline = true;
            this.textBoxClientMSG.Name = "textBoxClientMSG";
            this.textBoxClientMSG.ReadOnly = true;
            this.textBoxClientMSG.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxClientMSG.Size = new System.Drawing.Size(298, 241);
            this.textBoxClientMSG.TabIndex = 8;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(388, 12);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(197, 51);
            this.connectBtn.TabIndex = 13;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 29);
            this.label1.TabIndex = 19;
            this.label1.Text = "You send : ";
            // 
            // hostNameTxtbox
            // 
            this.hostNameTxtbox.Location = new System.Drawing.Point(149, 12);
            this.hostNameTxtbox.Name = "hostNameTxtbox";
            this.hostNameTxtbox.Size = new System.Drawing.Size(214, 22);
            this.hostNameTxtbox.TabIndex = 30;
            // 
            // HostNameLbl
            // 
            this.HostNameLbl.AutoSize = true;
            this.HostNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostNameLbl.Location = new System.Drawing.Point(4, 9);
            this.HostNameLbl.Name = "HostNameLbl";
            this.HostNameLbl.Size = new System.Drawing.Size(128, 24);
            this.HostNameLbl.TabIndex = 29;
            this.HostNameLbl.Text = "Host name : ";
            // 
            // usernameTxtbox
            // 
            this.usernameTxtbox.Location = new System.Drawing.Point(149, 41);
            this.usernameTxtbox.Name = "usernameTxtbox";
            this.usernameTxtbox.Size = new System.Drawing.Size(214, 22);
            this.usernameTxtbox.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 31;
            this.label3.Text = "Your name : ";
            // 
            // serverNameLbl
            // 
            this.serverNameLbl.AutoSize = true;
            this.serverNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverNameLbl.Location = new System.Drawing.Point(46, 91);
            this.serverNameLbl.Name = "serverNameLbl";
            this.serverNameLbl.Size = new System.Drawing.Size(242, 24);
            this.serverNameLbl.TabIndex = 33;
            this.serverNameLbl.Text = "No Connection right now";
            // 
            // ClientChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 462);
            this.Controls.Add(this.serverNameLbl);
            this.Controls.Add(this.usernameTxtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hostNameTxtbox);
            this.Controls.Add(this.HostNameLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageTxtBox);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.textBoxServerMSG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxClientMSG);
            this.Controls.Add(this.connectBtn);
            this.Name = "ClientChat";
            this.Text = "ClientChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientChat_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageTxtBox;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox textBoxServerMSG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxClientMSG;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hostNameTxtbox;
        private System.Windows.Forms.Label HostNameLbl;
        private System.Windows.Forms.TextBox usernameTxtbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label serverNameLbl;
    }
}