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
    public partial class UpdateMinus : MetroForm
    {

        string IDStartPass = "";
        string IDStartOrganization = "";
        string IDStartValution = "";
        string startSum = "";
        bool clickInfo = false;

        public UpdateMinus()
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

        private void UpdMinus()
        {
            try
            {
                string findBankSel = "SELECT ИД FROM Банк WHERE Паспорт=@pass AND Организация=@org AND Валюта=@val"; //проверка имеется ли такой банк в БД
                connect.Open();
                SqlCommand commBank = new SqlCommand(findBankSel, connect);
                commBank.Parameters.AddWithValue("@pass", metroComboBoxPass.SelectedValue);
                commBank.Parameters.AddWithValue("@org", metroComboBoxOrg.SelectedValue);
                commBank.Parameters.AddWithValue("@val", metroComboBoxVal1.SelectedValue);
                string ID_Bank = Convert.ToString(commBank.ExecuteScalar());
                connect.Close();

                if (ID_Bank == null || ID_Bank == "")
                {
                    MessageBox.Show("Ошибка:банка не существует!", "Банка с указанными параметрами(держателем, организацией, валютой) не существует! ");
                }

                string query_UpdMinus = "UPDATE Расход SET Банк=@bank, Наименование=@nameOper, Описание=@opis, Сумма=@sum, Валюта=@val WHERE ИД=";
                connect.Open();

                string newStrWithPoint = metroTextBoxSum1.Text.Replace(",", ".");

                try
                {
                    
                    //чтение файла
                    string[] allText = File.ReadAllLines("index.txt"); //чтение всех строк файла в массив строк
                    foreach (string s in allText)
                    {   //вывод всех строк на консоль
                        query_UpdMinus = query_UpdMinus + s;
                        SqlCommand SQLcmd = new SqlCommand(query_UpdMinus, connect);
                        SQLcmd.Parameters.AddWithValue("@bank", ID_Bank);
                        SQLcmd.Parameters.AddWithValue("@nameOper", metroComboBoxNameOper1.SelectedValue);
                        SQLcmd.Parameters.AddWithValue("@opis", metroTextBoxInfo1.Text);
                        SQLcmd.Parameters.AddWithValue("@sum", newStrWithPoint);
                        SQLcmd.Parameters.AddWithValue("@val", metroComboBoxVal1.SelectedValue);
                        SQLcmd.ExecuteScalar();
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }

                connect.Close();

                // замена в строке денег , на . (для корректности чтения в БД)
                string queryPlusInBank = "UPDATE Банк SET Сумма=Сумма-@money WHERE ИД=@id";
                connect.Open();
                SqlCommand commBankPlus = new SqlCommand(queryPlusInBank, connect);
                commBankPlus.Parameters.AddWithValue("@money", newStrWithPoint);
                commBankPlus.Parameters.AddWithValue("@id", ID_Bank);
                commBankPlus.ExecuteScalar();
                connect.Close();
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

        private void UpdateMinus_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }

        private void metroButInsAndClose_Click(object sender, EventArgs e)
        {
            UpdMinus();
            clickInfo = true;
            Close();
        }

        private void UpdateMinus_Load(object sender, EventArgs e)
        {

        }

        private void metroComboBoxPass_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ResultFindOnIDInPass();
        }

        private void UpdateMinus_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clickInfo == false)
            {
                string ID_Bank = manipulationDB.generationID("SELECT ИД FROM Банк WHERE Паспорт='" + IDStartPass + "' " +
                    "AND Организация='" + IDStartOrganization + "' AND Валюта='" + IDStartValution + "'");
                string queryPlusInBank = "UPDATE Банк SET Сумма=Сумма-@money WHERE ИД=@id";
                connect.Open();
                SqlCommand commBankPlus = new SqlCommand(queryPlusInBank, connect);
                commBankPlus.Parameters.AddWithValue("@money", startSum);
                commBankPlus.Parameters.AddWithValue("@id", ID_Bank);
                commBankPlus.ExecuteScalar();
                connect.Close();
            }
        }

        private void UpdateMinus_Shown(object sender, EventArgs e)
        {
            IDStartPass = Convert.ToString(metroComboBoxPass.SelectedValue);
            IDStartOrganization = Convert.ToString(metroComboBoxOrg.SelectedValue);
            IDStartValution = Convert.ToString(metroComboBoxVal1.SelectedValue);
            startSum = metroTextBoxSum1.Text.Replace(",", ".");
        }
    }
}
