using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Data.SqlClient;

namespace IndividualFinansist.GeneralForms
{
    public partial class ConnectionDB : MetroForm
    {
        public ConnectionDB()
        {
            InitializeComponent();
        }

        private void ConnectionDB_Load(object sender, EventArgs e)
        {

        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            string connStr = "";

            if (comboBoxConnect.Text == "По подлинности Windows")
            {
                connStr = "Data Source=" + tbServer.Text + ";Initial Catalog=" + tbDB.Text + ";Integrated Security=True";
                ConnDB.conn = connStr;
            }
            if (comboBoxConnect.Text == "По подлинности SQL Server")
            {
                connStr = "Data Source =" + tbServer.Text + "; Initial Catalog =" + tbDB.Text + "; Integrated Security = SSPI; User ID =" + tbUser.Text + "; Password =" + tbPassword.Text;
                ConnDB.conn = connStr;
            }

            using (SqlConnection myConnection = new SqlConnection(connStr))
            {
                try
                {
                    myConnection.Open();
                    AvtorizationForm av = new AvtorizationForm();
                    av.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Подключение не удалось!");
                }
                finally
                {
                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Close();
                    }
                }
            }
        }

        private void tbPassword_Click(object sender, EventArgs e)
        {

        }

        private void tbUser_Click(object sender, EventArgs e)
        {

        }

        private void tbDB_Click(object sender, EventArgs e)
        {

        }

        private void tbServer_Click(object sender, EventArgs e)
        {

        }


        private void comboBoxConnect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxConnect.Text == "По подлинности SQL Server")
            {
                labelPass.Visible = true;
                labelUser.Visible = true;
                tbUser.Visible = true;
                tbPassword.Visible = true;
                labelBD.Visible = true;
                labelServ.Visible = true;
                tbServer.Visible = true;
                tbDB.Visible = true;
                btConnect.Visible = true;
            }
            else if (comboBoxConnect.Text == "По подлинности Windows")
            {
                labelPass.Visible = false;
                labelUser.Visible = false;
                tbUser.Visible = false;
                tbPassword.Visible = false;
                labelBD.Visible = true;
                labelServ.Visible = true;
                tbServer.Visible = true;
                tbDB.Visible = true;
                btConnect.Visible = true;
            }
            else
            {
                labelPass.Visible = false;
                labelUser.Visible = false;
                labelBD.Visible = false;
                labelServ.Visible = false;
                tbServer.Visible = false;
                tbDB.Visible = false;
                tbUser.Visible = false;
                tbPassword.Visible = false;
                btConnect.Visible = false;
            }
        }
    }
}
