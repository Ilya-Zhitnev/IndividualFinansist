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

namespace IndividualFinansist.InsertFormForControlForm
{
    public partial class BankInsert : MetroForm
    {
        public BankInsert()
        {
            InitializeComponent();
            manipulationDB.SelectComboBox("SELECT * FROM Организация", metroComboBoxOrg, "Наименование", "ИД");
            manipulationDB.SelectComboBox("SELECT * FROM Валюта", metroComboBoxVal, "Сокращенное наименование", "ИД");
            manipulationDB.SelectComboBox("SELECT * FROM Паспорт", metroComboBoxBank, "ФИО", "ИД");
            ResultFindOnIDInPass();
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        private void InsNewBank()
        {
            string queryInsBank = "INSERT INTO Банк " +
                "VALUES('" + metroComboBoxBank.SelectedValue + "','"+ metroComboBoxOrg.SelectedValue + "'," +
                "'" + metroTextBoxRank.Text + "','" + metroTextBoxDateReg.Text + "','" + metroTextBoxSum.Text + "','"+ metroComboBoxVal.SelectedValue + "')";
            manipulationDB.Insert(queryInsBank);
            metroTextBoxRank.Text = null;
            metroTextBoxDateReg.Text = null;
            metroTextBoxSum.Text = null;
        }

        private void metroButIns_Click(object sender, EventArgs e)
        {
            InsNewBank();
        }

        private void metroButInsAndClose_Click(object sender, EventArgs e)
        {
            InsNewBank();
            Close();
        }

        private void ResultFindOnIDInPass()
        {
            string querySelSINPlus = "SELECT СиН FROM Паспорт WHERE ИД=@ID";
            connect.Open();
            SqlCommand commSIN = new SqlCommand(querySelSINPlus, connect);
            commSIN.Parameters.AddWithValue("@ID", metroComboBoxBank.SelectedValue);
            metroTextBoxSiN.Text = Convert.ToString(commSIN.ExecuteScalar());
            connect.Close();

            string querySelIDENTIFITYPlus = "SELECT Идентификатор FROM Паспорт WHERE ИД=@ID";
            connect.Open();
            SqlCommand commID = new SqlCommand(querySelIDENTIFITYPlus, connect);
            commID.Parameters.AddWithValue("@ID", metroComboBoxBank.SelectedValue);
            metroTextBoxIdentificator.Text = Convert.ToString(commID.ExecuteScalar());
            connect.Close();
        }

        private void metroComboBoxBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ResultFindOnIDInPass();
        }
    }
}
