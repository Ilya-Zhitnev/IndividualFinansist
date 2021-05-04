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
using IndividualFinansist.GeneralForms;

namespace IndividualFinansist.FormsForControlFormTwo.UpdateFormForControlFormTwo
{
    public partial class UpdateOrganization : MetroForm
    {
        public UpdateOrganization()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        ControlFormTwo controlFormTwo = new ControlFormTwo();

        private void UpdOrgnization()
        {
            try
            {
                string query_UpdOrgnization = "UPDATE Организация SET Наименование='" + metroTextBoxNamOrg.Text + "', " +
                    "[Дата регистрации]='" + metroTextBoxDateReg.Text + "', [Юридический адрес]='" + metroTextBoxUrAddress.Text + "'," +
                    "[Фактический адрес]='" + metroTextBoxFactAdress.Text + "' WHERE ИД=";
                manipulationDB.Update(query_UpdOrgnization);
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

        private void UpdateOrganization_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }

        private void metroButUpdAndClose_Click(object sender, EventArgs e)
        {
            UpdOrgnization();
            Close();
        }
    }
}
