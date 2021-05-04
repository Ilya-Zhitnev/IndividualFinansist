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

namespace IndividualFinansist.UpdateFormForControlForm
{
    public partial class UpdateBank : MetroForm
    {
        public UpdateBank()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

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

        private void UpdBank()
        {
            try
            {
                //string ID_Org = manipulationDB.generationID("SELECT ИД FROM Организация WHERE Наименование='" + metroComboBoxOrganization.Text + "'");
                //string ID_Val = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='" + metroComboBoxVal.Text + "'");

                string query_UpdBank = "UPDATE Банк SET Паспорт=@pass, Организация=@org, Должность=@rank, [Дата регистрации]=@dateReg, Сумма=@sum, Валюта=@val WHERE ИД=";
                connect.Open();
                try
                {      //чтение файла
                    string[] allText = File.ReadAllLines("index.txt"); //чтение всех строк файла в массив строк
                    foreach (string s in allText)
                    {   //вывод всех строк на консоль
                        query_UpdBank = query_UpdBank + s;
                        SqlCommand SQLcmd = new SqlCommand(query_UpdBank, connect);
                        SQLcmd.Parameters.AddWithValue("@pass", metroComboBoxPass.SelectedValue);
                        SQLcmd.Parameters.AddWithValue("@org", metroComboBoxOrganization.SelectedValue);
                        SQLcmd.Parameters.AddWithValue("@rank", metroTextBoxRank.Text);
                        SQLcmd.Parameters.AddWithValue("@dateReg", metroTextBoxDateOfReg.Text);
                        SQLcmd.Parameters.AddWithValue("@sum", metroTextBoxSum.Text);
                        SQLcmd.Parameters.AddWithValue("@val", metroComboBoxVal.SelectedValue);
                        SQLcmd.ExecuteScalar();
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка программы");
            }
            finally
            {
                connect.Close();
            }
        }

        private void UpdateBank_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }

        private void metroButInsAndClose_Click(object sender, EventArgs e)
        {
            UpdBank();
            Close();
        }

        private void metroComboBoxPass_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ResultFindOnIDInPass();
        }
    }
}
