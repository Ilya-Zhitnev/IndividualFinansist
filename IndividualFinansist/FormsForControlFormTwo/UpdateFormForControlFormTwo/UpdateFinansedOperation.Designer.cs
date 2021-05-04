namespace IndividualFinansist.FormsForControlFormTwo.UpdateFormForControlFormTwo
{
    partial class UpdateFinansedOperation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateFinansedOperation));
            this.metroButUpdAndClose = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxNamFinOperation = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // metroButUpdAndClose
            // 
            this.metroButUpdAndClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.metroButUpdAndClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroButUpdAndClose.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButUpdAndClose.Location = new System.Drawing.Point(0, 250);
            this.metroButUpdAndClose.Name = "metroButUpdAndClose";
            this.metroButUpdAndClose.Size = new System.Drawing.Size(775, 40);
            this.metroButUpdAndClose.TabIndex = 30;
            this.metroButUpdAndClose.Text = "Изменить и закрыть";
            this.metroButUpdAndClose.UseCustomBackColor = true;
            this.metroButUpdAndClose.UseSelectable = true;
            this.metroButUpdAndClose.Click += new System.EventHandler(this.metroButUpdAndClose_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(43, 151);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(249, 19);
            this.metroLabel1.TabIndex = 29;
            this.metroLabel1.Text = "Наименование финансовой операции";
            // 
            // metroTextBoxNamFinOperation
            // 
            // 
            // 
            // 
            this.metroTextBoxNamFinOperation.CustomButton.Image = null;
            this.metroTextBoxNamFinOperation.CustomButton.Location = new System.Drawing.Point(372, 1);
            this.metroTextBoxNamFinOperation.CustomButton.Name = "";
            this.metroTextBoxNamFinOperation.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxNamFinOperation.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxNamFinOperation.CustomButton.TabIndex = 1;
            this.metroTextBoxNamFinOperation.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxNamFinOperation.CustomButton.UseSelectable = true;
            this.metroTextBoxNamFinOperation.CustomButton.Visible = false;
            this.metroTextBoxNamFinOperation.Lines = new string[0];
            this.metroTextBoxNamFinOperation.Location = new System.Drawing.Point(361, 151);
            this.metroTextBoxNamFinOperation.MaxLength = 32767;
            this.metroTextBoxNamFinOperation.Name = "metroTextBoxNamFinOperation";
            this.metroTextBoxNamFinOperation.PasswordChar = '\0';
            this.metroTextBoxNamFinOperation.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxNamFinOperation.SelectedText = "";
            this.metroTextBoxNamFinOperation.SelectionLength = 0;
            this.metroTextBoxNamFinOperation.SelectionStart = 0;
            this.metroTextBoxNamFinOperation.ShortcutsEnabled = true;
            this.metroTextBoxNamFinOperation.Size = new System.Drawing.Size(394, 23);
            this.metroTextBoxNamFinOperation.TabIndex = 28;
            this.metroTextBoxNamFinOperation.UseSelectable = true;
            this.metroTextBoxNamFinOperation.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxNamFinOperation.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UpdateFinansedOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 290);
            this.Controls.Add(this.metroButUpdAndClose);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTextBoxNamFinOperation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateFinansedOperation";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Изменение финансовой операции";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpdateFinansedOperation_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton metroButUpdAndClose;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroTextBox metroTextBoxNamFinOperation;
    }
}