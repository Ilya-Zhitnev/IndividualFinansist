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
    public partial class AvtorizationForm : MetroForm
    {
        public AvtorizationForm()
        {
            InitializeComponent();
        }

        private void AvtorizationForm_Load(object sender, EventArgs e)
        {
            manipulationDB.SelectComboBox("SELECT * FROM Пользователь", comboBoxUsers, "Логин", "ИД");

            this.btBack.FlatAppearance.BorderSize = 0;
            this.btBack.FlatStyle = FlatStyle.Flat;
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        private void btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string queryNameUser = "SELECT Логин FROM Пользователь WHERE Логин=@nameUser"; // поиск ид из личной инф
                connect.Open();
                SqlCommand comm = new SqlCommand(queryNameUser, connect);
                comm.Parameters.AddWithValue("@nameUser", comboBoxUsers.Text);
                string nameUser = comm.ExecuteScalar().ToString();
                connect.Close();

                string queryPassUser = "SELECT Пароль FROM Пользователь WHERE Логин=@nameUser"; // поиск ид из личной инф
                connect.Open();
                SqlCommand comm1 = new SqlCommand(queryPassUser, connect);
                comm1.Parameters.AddWithValue("@nameUser", comboBoxUsers.Text);
                string passUser = comm1.ExecuteScalar().ToString();
                passUser = shifr_PBKDF2.Decrypt(Convert.ToString(passUser), "204503");
                //passUser = Convert.ToString(passUser); для строки, если не закодирована
                connect.Close();

                string queryAdminUser = "SELECT Администрирование FROM Пользователь WHERE Логин=@nameUser"; // поиск ид из личной инф
                connect.Open();
                SqlCommand comm2 = new SqlCommand(queryAdminUser, connect);
                comm2.Parameters.AddWithValue("@nameUser", comboBoxUsers.Text);
                bool admin = Convert.ToBoolean(comm2.ExecuteScalar());
                connect.Close();

                if (comboBoxUsers.Text == "Администратор" && admin == true)
                {
                    UsersTF.user = 1;
                }
                else if (admin == true && comboBoxUsers.Text != "Администратор")
                {
                    UsersTF.user = 2;
                }
                else
                {
                    UsersTF.user = 3;
                }

                if (comboBoxUsers.Text == nameUser)
                {
                    if (password.Text == passUser)
                    {
                        NavigationForm navigationForm = new NavigationForm();
                        navigationForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Проверьте правильность введенного пароля.", "Ошибка авторизации");
                    }
                }
                else
                {
                    label1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при авторизации.");
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            ConnectionDB cDB = new ConnectionDB();
            cDB.Show();
            this.Hide();
        }

        private void btBack_Enter(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.SetToolTip(btBack, "Назад");
        }

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            ConnectionDB cDB = new ConnectionDB();
            cDB.Show();
            this.Hide();
        }
    }
}
