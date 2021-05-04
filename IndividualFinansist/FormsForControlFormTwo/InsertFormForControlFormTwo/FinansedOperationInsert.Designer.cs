namespace IndividualFinansist.FormsForControlFormTwo.InsertFormForControlFormTwo
{
    partial class FinansedOperationInsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinansedOperationInsert));
            this.metroTextBoxNamFinOperation = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButIns = new MetroFramework.Controls.MetroButton();
            this.metroButInsAndClose = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
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
            this.metroTextBoxNamFinOperation.Location = new System.Drawing.Point(349, 130);
            this.metroTextBoxNamFinOperation.MaxLength = 32767;
            this.metroTextBoxNamFinOperation.Name = "metroTextBoxNamFinOperation";
            this.metroTextBoxNamFinOperation.PasswordChar = '\0';
            this.metroTextBoxNamFinOperation.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxNamFinOperation.SelectedText = "";
            this.metroTextBoxNamFinOperation.SelectionLength = 0;
            this.metroTextBoxNamFinOperation.SelectionStart = 0;
            this.metroTextBoxNamFinOperation.ShortcutsEnabled = true;
            this.metroTextBoxNamFinOperation.Size = new System.Drawing.Size(394, 23);
            this.metroTextBoxNamFinOperation.TabIndex = 0;
            this.metroTextBoxNamFinOperation.UseSelectable = true;
            this.metroTextBoxNamFinOperation.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxNamFinOperation.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(51, 130);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(249, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Наименование финансовой операции";
            // 
            // metroButIns
            // 
            this.metroButIns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.metroButIns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroButIns.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButIns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.metroButIns.Location = new System.Drawing.Point(0, 210);
            this.metroButIns.Name = "metroButIns";
            this.metroButIns.Size = new System.Drawing.Size(775, 40);
            this.metroButIns.TabIndex = 27;
            this.metroButIns.Text = "Добавить";
            this.metroButIns.UseCustomBackColor = true;
            this.metroButIns.UseSelectable = true;
            this.metroButIns.Click += new System.EventHandler(this.metroButIns_Click);
            // 
            // metroButInsAndClose
            // 
            this.metroButInsAndClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.metroButInsAndClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroButInsAndClose.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButInsAndClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.metroButInsAndClose.Location = new System.Drawing.Point(0, 250);
            this.metroButInsAndClose.Name = "metroButInsAndClose";
            this.metroButInsAndClose.Size = new System.Drawing.Size(775, 40);
            this.metroButInsAndClose.TabIndex = 26;
            this.metroButInsAndClose.Text = "Добавить и закрыть";
            this.metroButInsAndClose.UseCustomBackColor = true;
            this.metroButInsAndClose.UseSelectable = true;
            this.metroButInsAndClose.Click += new System.EventHandler(this.metroButInsAndClose_Click);
            // 
            // FinansedOperationInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 290);
            this.Controls.Add(this.metroButIns);
            this.Controls.Add(this.metroButInsAndClose);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTextBoxNamFinOperation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FinansedOperationInsert";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Добавление финансовой операции";
            this.Load += new System.EventHandler(this.FinansedOperationInsert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox metroTextBoxNamFinOperation;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButIns;
        private MetroFramework.Controls.MetroButton metroButInsAndClose;
    }
}