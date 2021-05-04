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
    public partial class UpdateMoneySize : MetroForm
    {
        public UpdateMoneySize()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();
        ControlFormTwo controlFormTwo = new ControlFormTwo();

        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        private void UpdMoneySize()
        {
            try
            {
                string ID_Val1 = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='" + metroComboBoxVal1.Text + "'");
                string ID_Val2 = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='" + metroComboBoxVal2.Text + "'");
                string query_UpdOrgnization = "UPDATE [Курс валют] SET Единица1=@ed1, Валюта1=@val1, Единица2=@ed2, Валюта2=@val2 WHERE ИД=";

                connect.Open();
                try
                {      //чтение файла
                    string[] allText = File.ReadAllLines("index.txt"); //чтение всех строк файла в массив строк
                    foreach (string s in allText)
                    {   //вывод всех строк на консоль
                        query_UpdOrgnization = query_UpdOrgnization + s;
                        SqlCommand SQLcmd = new SqlCommand(query_UpdOrgnization, connect);
                        SQLcmd.Parameters.AddWithValue("@ed1", metroTextBoxSizeMoney1.Text);
                        SQLcmd.Parameters.AddWithValue("@val1", ID_Val1);
                        SQLcmd.Parameters.AddWithValue("@ed2", metroTextBoxSizeMoney2.Text);
                        SQLcmd.Parameters.AddWithValue("@val2", ID_Val2);
                        SQLcmd.ExecuteScalar();
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (SqlException exSql)
            {
                MessageBox.Show(exSql.Message, "Ошибка с БД:");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка приложения:");
            }
            finally
            {
                connect.Close();
            }
        }

        private void UpdateMoneySize_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("index.txt");
        }

        private void metroButUpdAndClose_Click(object sender, EventArgs e)
        {
            UpdMoneySize();
            Close();
        }
    }
}
