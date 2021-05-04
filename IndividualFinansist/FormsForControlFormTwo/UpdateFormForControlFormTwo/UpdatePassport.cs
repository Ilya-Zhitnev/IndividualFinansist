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
using System.IO;

namespace IndividualFinansist.FormsForControlFormTwo.UpdateFormForControlFormTwo
{
    public partial class UpdatePassport : MetroForm
    {
        public UpdatePassport()
        {
            InitializeComponent();
        }

        private void UpdatePassport_Load(object sender, EventArgs e)
        {

        }

        ManipulationDB manipulationDB = new ManipulationDB();

        private void UpdatePass()
        {
            try
            {
                string query_UpdPass = "UPDATE Паспорт SET ФИО='" + metroTextBoxFio.Text + "', " +
                    "СиН='" + metroTextBoxSin.Text + "', Идентификатор='" + shifr_PBKDF2.Encrypt(Convert.ToString(metroTextBoxIdentifity.Text), "204503") + "' WHERE ИД=";
                manipulationDB.Update(query_UpdPass);
            }
            catch (SqlException exSql)
            {
                MessageBox.Show(exSql.Message, "Ошибка с БД:");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка приложения:");
            }
        }

        private void metroButUpdAndClose_Click(object sender, EventArgs e)
        {
            UpdatePass();
            Close();
        }

        private void UpdatePassport_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }
    }
}
