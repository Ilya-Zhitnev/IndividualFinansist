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

namespace IndividualFinansist.FormsForControlFormTwo.InsertFormForControlFormTwo
{
    public partial class MoneySizeInsert : MetroForm
    {
        public MoneySizeInsert()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        private void MoneySizeInsert_Load(object sender, EventArgs e)
        {

        }

        private void InsMoneySize()
        {
            try
            {
                string ID_Val1 = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='" + metroComboBoxVal1.Text + "'");
                string ID_Val2 = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='" + metroComboBoxVal2.Text + "'");
                string query_MoeySize = "INSERT INTO [Курс валют] " +
                    "VALUES (@ed1, @val1, @ed2, @val2)";
                connect.Open();
                SqlCommand comm = new SqlCommand(query_MoeySize, connect);
                comm.Parameters.AddWithValue("@ed1", metroTextBoxSizeMoney1.Text);
                comm.Parameters.AddWithValue("@val1", ID_Val1);
                comm.Parameters.AddWithValue("@ed2", metroTextBoxSizeMoney2.Text);
                comm.Parameters.AddWithValue("@val2", ID_Val2);
                comm.ExecuteScalar();
                connect.Close();
                metroTextBoxSizeMoney1.Text = null;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void metroButIns_Click(object sender, EventArgs e)
        {
            InsMoneySize();
        }

        private void metroButInsAndClose_Click(object sender, EventArgs e)
        {
            InsMoneySize();
            Close();
        }
    }
}
