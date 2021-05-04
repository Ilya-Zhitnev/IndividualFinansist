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
using System.IO;

namespace IndividualFinansist.Administration
{
    public partial class UpdateFormRegistration : MetroForm
    {
        public UpdateFormRegistration()
        {
            InitializeComponent();
        }

        private void UpdateFormRegistration_Load(object sender, EventArgs e)
        {

        }

        ShowAllUsers showAllUsers = new ShowAllUsers();

        private void btRegisterUser_Click(object sender, EventArgs e)
        {
            try
            {
                ManipulationDB manipulationDB = new ManipulationDB();
                int adm = 0;
                if (chbAdmin.Checked == true)
                {
                    adm = 1;
                }
                else
                {
                    adm = 0;
                }

                string query = "UPDATE Пользователь SET " +
                    "Логин = '" + tbUser.Text + "', Пароль = '" + shifr_PBKDF2.Encrypt(Convert.ToString(tbPassword.Text), "204503") + "', Администрирование = '" + adm + "'" +
                    " WHERE ИД =";
                manipulationDB.Update(query);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void UpdateFormRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }
    }
}
