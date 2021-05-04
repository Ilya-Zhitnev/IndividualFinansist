namespace IndividualFinansist.GeneralForms
{
    partial class AvtorizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvtorizationForm));
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.btConnect = new MetroFramework.Controls.MetroButton();
            this.password = new MetroFramework.Controls.MetroTextBox();
            this.comboBoxUsers = new MetroFramework.Controls.MetroComboBox();
            this.btBack = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(176, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Выберите пользователя для входа в систему!";
            this.label1.UseCustomBackColor = true;
            this.label1.UseCustomForeColor = true;
            this.label1.Visible = false;
            // 
            // btConnect
            // 
            this.btConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btConnect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btConnect.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btConnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btConnect.Location = new System.Drawing.Point(0, 331);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(717, 36);
            this.btConnect.TabIndex = 8;
            this.btConnect.Text = "ВОЙТИ";
            this.btConnect.UseCustomBackColor = true;
            this.btConnect.UseCustomForeColor = true;
            this.btConnect.UseSelectable = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // password
            // 
            // 
            // 
            // 
            this.password.CustomButton.Image = null;
            this.password.CustomButton.Location = new System.Drawing.Point(284, 2);
            this.password.CustomButton.Name = "";
            this.password.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.password.CustomButton.TabIndex = 1;
            this.password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.password.CustomButton.UseSelectable = true;
            this.password.CustomButton.Visible = false;
            this.password.Lines = new string[0];
            this.password.Location = new System.Drawing.Point(202, 214);
            this.password.MaxLength = 32767;
            this.password.Name = "password";
            this.password.PasswordChar = '●';
            this.password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.password.SelectedText = "";
            this.password.SelectionLength = 0;
            this.password.SelectionStart = 0;
            this.password.ShortcutsEnabled = true;
            this.password.Size = new System.Drawing.Size(312, 30);
            this.password.TabIndex = 7;
            this.password.UseSelectable = true;
            this.password.UseSystemPasswordChar = true;
            this.password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.password.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.ItemHeight = 29;
            this.comboBoxUsers.Location = new System.Drawing.Point(202, 167);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(312, 35);
            this.comboBoxUsers.TabIndex = 6;
            this.comboBoxUsers.UseSelectable = true;
            // 
            // btBack
            // 
            this.btBack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btBack.BackgroundImage = global::IndividualFinansist.Properties.Resources.back_1689836_1280;
            this.btBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btBack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btBack.ForeColor = System.Drawing.Color.Transparent;
            this.btBack.Location = new System.Drawing.Point(0, 367);
            this.btBack.Margin = new System.Windows.Forms.Padding(0);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(717, 35);
            this.btBack.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btBack.TabIndex = 5;
            this.btBack.Tag = "Кнопка возврата назад";
            this.btBack.UseMnemonic = false;
            this.btBack.UseSelectable = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            this.btBack.Enter += new System.EventHandler(this.btBack_Enter);
            // 
            // AvtorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 402);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.password);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.btBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AvtorizationForm";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Tag = "Форма для авторизации в системе";
            this.Text = "Авторизация";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.AvtorizationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroButton btConnect;
        private MetroFramework.Controls.MetroTextBox password;
        private MetroFramework.Controls.MetroComboBox comboBoxUsers;
        private MetroFramework.Controls.MetroButton btBack;
    }
}