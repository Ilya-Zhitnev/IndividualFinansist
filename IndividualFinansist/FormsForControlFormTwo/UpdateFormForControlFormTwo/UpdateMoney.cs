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
    public partial class UpdateMoney : MetroForm
    {
        public UpdateMoney()
        {
            InitializeComponent();
        }

        private void UpdateMoney_Load(object sender, EventArgs e)
        {

        }

        ManipulationDB manipulationDB = new ManipulationDB();
        ControlFormTwo controlFormTwo = new ControlFormTwo();

        private void UpdMoney()
        {
            try
            {
                string query_UpdMoney = "UPDATE Валюта SET Наименование='" + metroTextBoxFullName.Text + "', " +
                    "[Сокращенное наименование]='" + metroTextBoxMiniName.Text + "' WHERE ИД=";
                manipulationDB.Update(query_UpdMoney);
                manipulationDB.Select(manipulationDB.queryMoney, controlFormTwo.metroGridMoney);
            }
            catch(SqlException exSql)
            {
                MessageBox.Show(exSql.Message, "Ошибка с БД:");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка приложения:");
            }
        }

        private void UpdateMoney_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }

        private void metroButUpdAndClose_Click(object sender, EventArgs e)
        {
            UpdMoney();
            Close();
        }
    }
}
