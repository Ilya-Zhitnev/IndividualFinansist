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
    public partial class UpdateFinansedOperation : MetroForm
    {
        public UpdateFinansedOperation()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        ControlFormTwo controlFormTwo = new ControlFormTwo();

        private void UpdFinansedOperation()
        {
            try
            {
                string query_UpdFinOperation = "UPDATE Операция SET Наименование='" + metroTextBoxNamFinOperation.Text + "' WHERE ИД=";
                manipulationDB.Update(query_UpdFinOperation);
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
            UpdFinansedOperation();
            Close();
        }

        private void UpdateFinansedOperation_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }
    }
}
