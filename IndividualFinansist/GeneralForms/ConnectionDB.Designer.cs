namespace IndividualFinansist.GeneralForms
{
    partial class ConnectionDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionDB));
            this.labelPass = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelBD = new System.Windows.Forms.Label();
            this.labelServ = new System.Windows.Forms.Label();
            this.tbPassword = new MetroFramework.Controls.MetroTextBox();
            this.tbUser = new MetroFramework.Controls.MetroTextBox();
            this.tbDB = new MetroFramework.Controls.MetroTextBox();
            this.tbServer = new MetroFramework.Controls.MetroTextBox();
            this.comboBoxConnect = new MetroFramework.Controls.MetroComboBox();
            this.btConnect = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelPass.Location = new System.Drawing.Point(93, 273);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(87, 30);
            this.labelPass.TabIndex = 19;
            this.labelPass.Text = "Пароль";
            this.labelPass.Visible = false;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelUser.Location = new System.Drawing.Point(93, 230);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(159, 30);
            this.labelUser.TabIndex = 18;
            this.labelUser.Text = "Пользователь";
            this.labelUser.Visible = false;
            // 
            // labelBD
            // 
            this.labelBD.AutoSize = true;
            this.labelBD.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelBD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelBD.Location = new System.Drawing.Point(93, 187);
            this.labelBD.Name = "labelBD";
            this.labelBD.Size = new System.Drawing.Size(139, 30);
            this.labelBD.TabIndex = 17;
            this.labelBD.Text = "База данных";
            this.labelBD.Visible = false;
            // 
            // labelServ
            // 
            this.labelServ.AutoSize = true;
            this.labelServ.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelServ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelServ.Location = new System.Drawing.Point(93, 144);
            this.labelServ.Name = "labelServ";
            this.labelServ.Size = new System.Drawing.Size(86, 30);
            this.labelServ.TabIndex = 16;
            this.labelServ.Text = "Сервер";
            this.labelServ.Visible = false;
            // 
            // tbPassword
            // 
            // 
            // 
            // 
            this.tbPassword.CustomButton.Image = null;
            this.tbPassword.CustomButton.Location = new System.Drawing.Point(278, 1);
            this.tbPassword.CustomButton.Name = "";
            this.tbPassword.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.tbPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbPassword.CustomButton.TabIndex = 1;
            this.tbPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbPassword.CustomButton.UseSelectable = true;
            this.tbPassword.CustomButton.Visible = false;
            this.tbPassword.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbPassword.Lines = new string[0];
            this.tbPassword.Location = new System.Drawing.Point(279, 273);
            this.tbPassword.MaxLength = 32767;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '●';
            this.tbPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbPassword.SelectedText = "";
            this.tbPassword.SelectionLength = 0;
            this.tbPassword.SelectionStart = 0;
            this.tbPassword.ShortcutsEnabled = true;
            this.tbPassword.Size = new System.Drawing.Size(314, 37);
            this.tbPassword.TabIndex = 15;
            this.tbPassword.UseSelectable = true;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.Visible = false;
            this.tbPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbPassword.Click += new System.EventHandler(this.tbPassword_Click);
            // 
            // tbUser
            // 
            // 
            // 
            // 
            this.tbUser.CustomButton.Image = null;
            this.tbUser.CustomButton.Location = new System.Drawing.Point(278, 1);
            this.tbUser.CustomButton.Name = "";
            this.tbUser.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.tbUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbUser.CustomButton.TabIndex = 1;
            this.tbUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbUser.CustomButton.UseSelectable = true;
            this.tbUser.CustomButton.Visible = false;
            this.tbUser.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbUser.Lines = new string[0];
            this.tbUser.Location = new System.Drawing.Point(279, 230);
            this.tbUser.MaxLength = 32767;
            this.tbUser.Name = "tbUser";
            this.tbUser.PasswordChar = '\0';
            this.tbUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbUser.SelectedText = "";
            this.tbUser.SelectionLength = 0;
            this.tbUser.SelectionStart = 0;
            this.tbUser.ShortcutsEnabled = true;
            this.tbUser.Size = new System.Drawing.Size(314, 37);
            this.tbUser.TabIndex = 14;
            this.tbUser.UseSelectable = true;
            this.tbUser.Visible = false;
            this.tbUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbUser.Click += new System.EventHandler(this.tbUser_Click);
            // 
            // tbDB
            // 
            // 
            // 
            // 
            this.tbDB.CustomButton.Image = null;
            this.tbDB.CustomButton.Location = new System.Drawing.Point(278, 1);
            this.tbDB.CustomButton.Name = "";
            this.tbDB.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.tbDB.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbDB.CustomButton.TabIndex = 1;
            this.tbDB.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbDB.CustomButton.UseSelectable = true;
            this.tbDB.CustomButton.Visible = false;
            this.tbDB.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbDB.Lines = new string[] {
        "Финансист"};
            this.tbDB.Location = new System.Drawing.Point(279, 187);
            this.tbDB.MaxLength = 32767;
            this.tbDB.Name = "tbDB";
            this.tbDB.PasswordChar = '\0';
            this.tbDB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbDB.SelectedText = "";
            this.tbDB.SelectionLength = 0;
            this.tbDB.SelectionStart = 0;
            this.tbDB.ShortcutsEnabled = true;
            this.tbDB.Size = new System.Drawing.Size(314, 37);
            this.tbDB.TabIndex = 13;
            this.tbDB.Text = "Финансист";
            this.tbDB.UseSelectable = true;
            this.tbDB.Visible = false;
            this.tbDB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbDB.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbDB.Click += new System.EventHandler(this.tbDB_Click);
            // 
            // tbServer
            // 
            // 
            // 
            // 
            this.tbServer.CustomButton.Image = null;
            this.tbServer.CustomButton.Location = new System.Drawing.Point(278, 1);
            this.tbServer.CustomButton.Name = "";
            this.tbServer.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.tbServer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbServer.CustomButton.TabIndex = 1;
            this.tbServer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbServer.CustomButton.UseSelectable = true;
            this.tbServer.CustomButton.Visible = false;
            this.tbServer.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbServer.Lines = new string[] {
        "BOEHKOMAT"};
            this.tbServer.Location = new System.Drawing.Point(279, 144);
            this.tbServer.MaxLength = 32767;
            this.tbServer.Name = "tbServer";
            this.tbServer.PasswordChar = '\0';
            this.tbServer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbServer.SelectedText = "";
            this.tbServer.SelectionLength = 0;
            this.tbServer.SelectionStart = 0;
            this.tbServer.ShortcutsEnabled = true;
            this.tbServer.Size = new System.Drawing.Size(314, 37);
            this.tbServer.TabIndex = 12;
            this.tbServer.Text = "BOEHKOMAT";
            this.tbServer.UseSelectable = true;
            this.tbServer.Visible = false;
            this.tbServer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbServer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbServer.Click += new System.EventHandler(this.tbServer_Click);
            // 
            // comboBoxConnect
            // 
            this.comboBoxConnect.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.comboBoxConnect.FormattingEnabled = true;
            this.comboBoxConnect.ItemHeight = 29;
            this.comboBoxConnect.Items.AddRange(new object[] {
            "По подлинности Windows",
            "По подлинности SQL Server"});
            this.comboBoxConnect.Location = new System.Drawing.Point(279, 102);
            this.comboBoxConnect.Name = "comboBoxConnect";
            this.comboBoxConnect.Size = new System.Drawing.Size(314, 35);
            this.comboBoxConnect.TabIndex = 11;
            this.comboBoxConnect.UseSelectable = true;
            this.comboBoxConnect.SelectedIndexChanged += new System.EventHandler(this.comboBoxConnect_SelectedIndexChanged);
            // 
            // btConnect
            // 
            this.btConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btConnect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btConnect.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btConnect.ForeColor = System.Drawing.Color.Blue;
            this.btConnect.Location = new System.Drawing.Point(0, 413);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(800, 37);
            this.btConnect.TabIndex = 10;
            this.btConnect.Text = "ПОДКЛЮЧИТЬСЯ";
            this.btConnect.UseCustomBackColor = true;
            this.btConnect.UseCustomForeColor = true;
            this.btConnect.UseSelectable = true;
            this.btConnect.Visible = false;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // ConnectionDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelBD);
            this.Controls.Add(this.labelServ);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbDB);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.comboBoxConnect);
            this.Controls.Add(this.btConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConnectionDB";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.Text = "Подключения к базе данных";
            this.Load += new System.EventHandler(this.ConnectionDB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelBD;
        private System.Windows.Forms.Label labelServ;
        private MetroFramework.Controls.MetroTextBox tbPassword;
        private MetroFramework.Controls.MetroTextBox tbUser;
        private MetroFramework.Controls.MetroTextBox tbDB;
        private MetroFramework.Controls.MetroTextBox tbServer;
        private MetroFramework.Controls.MetroComboBox comboBoxConnect;
        private MetroFramework.Controls.MetroButton btConnect;
    }
}