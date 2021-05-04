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
    public partial class UpdatePlus : MetroForm
    {

        string IDStartPass = "";
        string IDStartOrganization = "";
        string IDStartValution = "";
        string startSum = "";
        bool clickInfo = false;

        public UpdatePlus()
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

        private void UpdPlus()
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

                if(ID_Bank ==null || ID_Bank=="")
                {
                    MessageBox.Show("Ошибка:банка не существует!","Банка с указанными параметрами(держателем, организацией, валютой) не существует! ");
                }

                string query_UpdPlus = "UPDATE Приход SET Банк=@bank, Наименование=@nameOper, Описание=@opis, Сумма=@sum, Валюта=@val WHERE ИД=";
                connect.Open();
                try
                {      //чтение файла
                    string[] allText = File.ReadAllLines("index.txt"); //чтение всех строк файла в массив строк
                    foreach (string s in allText)
                    {   //вывод всех строк на консоль
                        query_UpdPlus = query_UpdPlus + s;
                        SqlCommand SQLcmd = new SqlCommand(query_UpdPlus, connect);
                        SQLcmd.Parameters.AddWithValue("@bank", ID_Bank);
                        SQLcmd.Parameters.AddWithValue("@nameOper", metroComboBoxNameOper.SelectedValue);
                        SQLcmd.Parameters.AddWithValue("@opis", metroTextBoxInfo.Text);
                        SQLcmd.Parameters.AddWithValue("@sum", metroTextBoxSum.Text);
                        SQLcmd.Parameters.AddWithValue("@val", metroComboBoxVal.SelectedValue);
                        SQLcmd.ExecuteScalar();
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message, "Ошибка:");
                }

                connect.Close();

                string newStrWithPoint = metroTextBoxSum.Text.Replace(",", "."); // замена в строке денег , на . (для корректности чтения в БД)
                string queryPlusInBank = "UPDATE Банк SET Сумма=Сумма+@money WHERE ИД=@id";
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

        private void UpdatePlus_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }

        private void metroButInsAndClose_Click(object sender, EventArgs e)
        {

            UpdPlus();
            clickInfo = true;
            Close();
        }

        private void metroComboBoxPass_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ResultFindOnIDInPass();
        }

        private void UpdatePlus_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clickInfo==false)
            {
                string ID_Bank = manipulationDB.generationID("SELECT ИД FROM Банк WHERE Паспорт='" + IDStartPass + "' " +
                    "AND Организация='" + IDStartOrganization + "' AND Валюта='" + IDStartValution + "'");
                string queryPlusInBank = "UPDATE Банк SET Сумма=Сумма+@money WHERE ИД=@id";
                connect.Open();
                SqlCommand commBankPlus = new SqlCommand(queryPlusInBank, connect);
                commBankPlus.Parameters.AddWithValue("@money", startSum);
                commBankPlus.Parameters.AddWithValue("@id", ID_Bank);
                commBankPlus.ExecuteScalar();
                connect.Close();
            }
        }

        private void UpdatePlus_Shown(object sender, EventArgs e)
        {
            IDStartPass = Convert.ToString(metroComboBoxPass.SelectedValue);
            IDStartOrganization = Convert.ToString(metroComboBoxOrg.SelectedValue);
            IDStartValution = Convert.ToString(metroComboBoxVal.SelectedValue);
            startSum = metroTextBoxSum.Text.Replace(",", ".");
        }
    }
}
