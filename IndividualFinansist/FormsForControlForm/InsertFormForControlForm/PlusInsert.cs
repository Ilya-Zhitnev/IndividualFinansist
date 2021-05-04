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
    public partial class PlusInsert : MetroForm
    {
        public PlusInsert()
        {
            InitializeComponent();
            manipulationDB.SelectComboBox("SELECT * FROM Паспорт", metroComboBoxPass, "ФИО", "ИД");
            manipulationDB.SelectComboBox("SELECT * FROM Операция", metroComboBoxNameOper, "Наименование", "ИД");
            manipulationDB.SelectComboBox("SELECT * FROM Валюта", metroComboBoxVal, "Сокращенное наименование", "ИД");
            manipulationDB.SelectComboBox("SELECT * FROM Организация", metroComboBoxOrg, "Наименование", "ИД");
            ResultFindOnIDInPass();
        }

        private void ResultFindOnIDInPass()
        {
            string querySelSINPlus = "SELECT СиН FROM Паспорт WHERE ИД=@ID";
            connect.Open();
            SqlCommand commSIN = new SqlCommand(querySelSINPlus, connect);
            commSIN.Parameters.AddWithValue("@ID", metroComboBoxPass.SelectedValue);
            metroTextBoxSiN.Text = Convert.ToString(commSIN.ExecuteScalar());
            connect.Close();

            string querySelIDENTIFITYPlus = "SELECT Идентификатор FROM Паспорт WHERE ИД=@ID";
            connect.Open();
            SqlCommand commID = new SqlCommand(querySelIDENTIFITYPlus, connect);
            commID.Parameters.AddWithValue("@ID", metroComboBoxPass.SelectedValue);
            metroTextBoxIdentificator.Text = Convert.ToString(commID.ExecuteScalar());
            connect.Close();
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        private void InsPlus()
        {
            try
            {
                string findBankSel = "SELECT ИД FROM Банк WHERE Паспорт=@pass AND Организация=@org AND Валюта=@val"; //проверка имеется ли такой банк в БД
                connect.Open();
                SqlCommand commBank = new SqlCommand(findBankSel, connect);
                commBank.Parameters.AddWithValue("@pass", metroComboBoxPass.SelectedValue);
                commBank.Parameters.AddWithValue("@org", metroComboBoxOrg.SelectedValue);
                commBank.Parameters.AddWithValue("@val", metroComboBoxVal.SelectedValue);
                string ID_Bank = Convert.ToString(commBank.ExecuteScalar());
                connect.Close();

                if (ID_Bank != null)
                {
                    string query_Plus = "INSERT INTO Приход VALUES (@id, @operation, @info, @sum, @val)";
                    connect.Open();
                    SqlCommand commPlus = new SqlCommand(query_Plus, connect);
                    string newStrWithPoint = metroTextBoxSum.Text.Replace(",", ".");
                    commPlus.Parameters.AddWithValue("@id", ID_Bank);
                    commPlus.Parameters.AddWithValue("@operation", metroComboBoxNameOper.SelectedValue);
                    commPlus.Parameters.AddWithValue("@info", metroTextBoxInfo.Text);
                    commPlus.Parameters.AddWithValue("@sum", newStrWithPoint);
                    commPlus.Parameters.AddWithValue("@val", metroComboBoxVal.SelectedValue);
                    commPlus.ExecuteScalar();
                    connect.Close();

                    string queryPlusInBank = "UPDATE Банк SET Сумма=Сумма+@money WHERE ИД=@id";
                    connect.Open();
                    SqlCommand commBankPlus = new SqlCommand(queryPlusInBank, connect);
                    commBankPlus.Parameters.AddWithValue("@money", newStrWithPoint);
                    commBankPlus.Parameters.AddWithValue("@id", ID_Bank);
                    commBankPlus.ExecuteScalar();
                    connect.Close();

                    metroTextBoxInfo.Text = null;
                    metroTextBoxSum.Text = null;
                }
                else
                {
                    MessageBox.Show("Данные не добавлены, " +
                        "т.к. не существует такого банка! Проверьте во вкладке \"Банк\" имеется ли такая строка " +
                        "с такими же паспортными данными, организацией и валютой! ", "Ошибка:");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка:");
            }
            finally
            {
                connect.Close();
            }
        }

        private void metroButIns_Click(object sender, EventArgs e)
        {
            InsPlus();
        }

        private void metroButInsAndClose_Click(object sender, EventArgs e)
        {
            InsPlus();
            Close();
        }

        private void metroComboBoxBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ResultFindOnIDInPass();
        }

    }
}
