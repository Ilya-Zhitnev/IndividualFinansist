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
    public partial class MinusInsert : MetroForm
    {
        public MinusInsert()
        {
            InitializeComponent();
            manipulationDB.SelectComboBox("SELECT * FROM Паспорт", metroComboBoxPass, "ФИО", "ИД");
            manipulationDB.SelectComboBox("SELECT * FROM Операция", metroComboBoxNameOper, "Наименование", "ИД");
            manipulationDB.SelectComboBox("SELECT * FROM Валюта", metroComboBoxVal, "Сокращенное наименование", "ИД");
            manipulationDB.SelectComboBox("SELECT * FROM Организация", metroComboBoxOrg, "Наименование", "ИД");
            ResultFindOnIDInPass();
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        private void InsMinus()
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
                    string query_Minus = "INSERT INTO Расход VALUES (@id, @operation, @info, @sum, @val)";
                    connect.Open();
                    SqlCommand commMinus = new SqlCommand(query_Minus, connect);
                    string newStrWithPoint = metroTextBoxSum.Text.Replace(",", ".");
                    commMinus.Parameters.AddWithValue("@id", ID_Bank);
                    commMinus.Parameters.AddWithValue("@operation", metroComboBoxNameOper.SelectedValue);
                    commMinus.Parameters.AddWithValue("@info", metroTextBoxInfo.Text);
                    commMinus.Parameters.AddWithValue("@sum", newStrWithPoint);
                    commMinus.Parameters.AddWithValue("@val", metroComboBoxVal.SelectedValue);
                    commMinus.ExecuteScalar();
                    connect.Close();

                    string queryMinusInBank = "UPDATE Банк SET Сумма=Сумма-@money WHERE ИД=@id";
                    connect.Open();
                    SqlCommand commBankMinus = new SqlCommand(queryMinusInBank, connect);
                    commBankMinus.Parameters.AddWithValue("@money", newStrWithPoint);
                    commBankMinus.Parameters.AddWithValue("@id", ID_Bank);
                    commBankMinus.ExecuteScalar();
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
            catch (Exception ex)
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
            InsMinus();
        }

        private void metroButInsAndClose_Click(object sender, EventArgs e)
        {
            InsMinus();
            Close();
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

        private void metroComboBoxBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ResultFindOnIDInPass();
        }
    }
}
