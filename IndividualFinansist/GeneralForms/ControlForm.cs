using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IndividualFinansist.Administration;
using IndividualFinansist.GeneralForms;
using IndividualFinansist.InsertFormForControlForm;
using IndividualFinansist.UpdateFormForControlForm;
using MetroFramework.Forms;

namespace IndividualFinansist
{
    public partial class ControlForm : MetroForm
    {
        public ControlForm()
        {
            InitializeComponent();
            manipulationDB.Select(manipulationDB.queryPlus, metroGridPlus);
            manipulationDB.Select(manipulationDB.queryMinus, metroGridMinus);
            manipulationDB.Select(manipulationDB.queryBank, metroGridBank);

            for (int i = 0; i < metroGridBank.RowCount; i++)
            {
                metroGridBank[3, i].Value = shifr_PBKDF2.Decrypt(Convert.ToString(metroGridBank[3, i].Value), "204503");
            }

            for (int i = 0; i < metroGridPlus.RowCount; i++)
            {
                metroGridPlus[3, i].Value = shifr_PBKDF2.Decrypt(Convert.ToString(metroGridPlus[3, i].Value), "204503");
            }

            for (int i = 0; i < metroGridMinus.RowCount; i++)
            {
                metroGridMinus[3, i].Value = shifr_PBKDF2.Decrypt(Convert.ToString(metroGridMinus[3, i].Value), "204503");
            }

            menuControl.Visible = false;
            metroButtonMenuOpen.Text = "<";
        }

        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);

        ManipulationDB manipulationDB = new ManipulationDB();
        ManipulationProgramm manipulationProgramm = new ManipulationProgramm();

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (menuControl.Visible == true)
            {
                menuControl.Visible = false;
                metroButtonMenuOpen.Text = "<";
            }
            else if(menuControl.Visible == false)
            {
                menuControl.Visible = true;
                metroButtonMenuOpen.Text = ">";
            }
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            //Обработка подачи/скрытия калькулятора из области видимости
            //if (menuControl.Visible == true)
            //{
            //    menuControl.Visible = false;
            //    metroButtonCalculator.Text = "∨";
            //}
            //else if (menuControl.Visible == false)
            //{
            //    menuControl.Visible = true;
            //    metroButtonCalculator.Text = "∧";
            //}
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {

        }

        private void generalMenu_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void metroTabControlCF_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuControl_Enter(object sender, EventArgs e)
        {

        }

        private void btBack_Click(object sender, EventArgs e)
        {
            NavigationForm navigationForm = new NavigationForm();
            navigationForm.Show();
            this.Hide();
        }

        private void backUp1_Click(object sender, EventArgs e)
        {
            manipulationProgramm.BackUp(metroGridPlus);
        }

        private void backUp2_Click(object sender, EventArgs e)
        {
            manipulationProgramm.BackUp(metroGridMinus);
        }

        private void backUp3_Click(object sender, EventArgs e)
        {
            manipulationProgramm.BackUp(metroGridBank);
        }

        private void Back1_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Back(metroGridPlus);
        }

        private void Back2_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Back(metroGridMinus);
        }

        private void Back3_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Back(metroGridBank);
        }

        private void Next3_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Next(metroGridBank);
        }

        private void Next2_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Next(metroGridMinus);
        }

        private void Next1_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Next(metroGridPlus);
        }

        private void NextUP3_Click(object sender, EventArgs e)
        {
            manipulationProgramm.NextUp(metroGridBank);
        }

        private void NextUP2_Click(object sender, EventArgs e)
        {
            manipulationProgramm.NextUp(metroGridMinus);
        }

        private void NextUP1_Click(object sender, EventArgs e)
        {
            manipulationProgramm.NextUp(metroGridPlus);
        }

        private void bindingNavigatorDeleteItem1_Click(object sender, EventArgs e)
        {
            string ID_Money = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='" + Convert.ToString(metroGridMinus.CurrentRow.Cells[8].Value) + "'");
            string ID_Pass = manipulationDB.generationID("SELECT ИД FROM Паспорт WHERE ФИО='" + Convert.ToString(metroGridMinus.CurrentRow.Cells[1].Value) + "' " +
                "AND СиН='" + Convert.ToString(metroGridMinus.CurrentRow.Cells[2].Value) + "'" +
                " AND Идентификатор='" + Convert.ToString(metroGridMinus.CurrentRow.Cells[3].Value) + "'");
            string ID_Org = manipulationDB.generationID("SELECT ИД FROM Организация WHERE Наименование='" + Convert.ToString(metroGridMinus.CurrentRow.Cells[4].Value) + "'");
            string ID_Bank = manipulationDB.generationID("SELECT ИД FROM Банк " +
                "WHERE Паспорт='" + ID_Pass + "' AND Организация='" + ID_Org + "' AND Валюта='" + ID_Money + "'");
            string ID_Operation = manipulationDB.generationID("SELECT ИД FROM Операция " +
                "WHERE Наименование='" + Convert.ToString(metroGridMinus.CurrentRow.Cells[5].Value) + "'");
            string newStrWithPoint = Convert.ToString(metroGridMinus.CurrentRow.Cells[7].Value).Replace(",", ".");
            string queryIdDelMinus = manipulationDB.generationID("SELECT ИД FROM Расход WHERE Банк='" + ID_Bank + "' " +
                "AND Наименование='" + ID_Operation + "' AND Описание='" + Convert.ToString(metroGridMinus.CurrentRow.Cells[6].Value) + "'" +
                " AND Сумма='" + newStrWithPoint + "' " +
                "AND Валюта='" + ID_Money + "'");

            manipulationDB.Delete(metroGridMinus, manipulationDB.queryMinusDel, queryIdDelMinus);

            try
            {
                string queryMoneyBankPlus = "UPDATE Банк SET Сумма=Сумма+@money WHERE ИД=@id";

                connect.Open();
                SqlCommand commBankPlus = new SqlCommand(queryMoneyBankPlus, connect);
                commBankPlus.Parameters.AddWithValue("@money", newStrWithPoint);
                commBankPlus.Parameters.AddWithValue("@id", ID_Bank);
                commBankPlus.ExecuteScalar();
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка:");
            }
            finally
            {
                connect.Close();
            }
            manipulationDB.Select(manipulationDB.queryMinus, metroGridMinus);

        }

        private void Delete1_Click(object sender, EventArgs e)
        {
            string ID_Money = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='" + Convert.ToString(metroGridPlus.CurrentRow.Cells[8].Value) + "'");
            string ID_Pass = manipulationDB.generationID("SELECT ИД FROM Паспорт WHERE ФИО='" + Convert.ToString(metroGridPlus.CurrentRow.Cells[1].Value) + "' " +
                "AND СиН='" + Convert.ToString(metroGridPlus.CurrentRow.Cells[2].Value)  + "'" +
                " AND Идентификатор='" + Convert.ToString(metroGridPlus.CurrentRow.Cells[3].Value) + "'");
            string ID_Org = manipulationDB.generationID("SELECT ИД FROM Организация WHERE Наименование='" + Convert.ToString(metroGridPlus.CurrentRow.Cells[4].Value) + "'");
            string ID_Bank = manipulationDB.generationID("SELECT ИД FROM Банк " +
                "WHERE Паспорт='" + ID_Pass + "' AND Организация='" + ID_Org + "' AND Валюта='" + ID_Money + "'");
            string ID_Operation = manipulationDB.generationID("SELECT ИД FROM Операция " +
                "WHERE Наименование='" + Convert.ToString(metroGridPlus.CurrentRow.Cells[5].Value) + "'");
            string newStrWithPoint = Convert.ToString(metroGridPlus.CurrentRow.Cells[7].Value).Replace(",", ".");
            string queryIdDelPlus = manipulationDB.generationID("SELECT ИД FROM Приход WHERE Банк='" + ID_Bank + "' " +
                "AND Наименование='" + ID_Operation + "' AND Описание='" + Convert.ToString(metroGridPlus.CurrentRow.Cells[6].Value) + "'" +
                " AND Сумма='" + newStrWithPoint + "' " +
                "AND Валюта='" + ID_Money + "'");

            manipulationDB.Delete(metroGridPlus, manipulationDB.queryPlusDel, queryIdDelPlus);

            try
            {
                string queryMoneyBankPlus = "UPDATE Банк SET Сумма=Сумма-@money WHERE ИД=@id";

                connect.Open();
                SqlCommand commBankPlus = new SqlCommand(queryMoneyBankPlus, connect);
                commBankPlus.Parameters.AddWithValue("@money", newStrWithPoint);
                commBankPlus.Parameters.AddWithValue("@id", ID_Bank);
                commBankPlus.ExecuteScalar();
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка:");
            }
            finally
            {
                connect.Close();
            }

            manipulationDB.Select(manipulationDB.queryPlus, metroGridPlus);
        }

        private void Delete3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы точно хотите удалить банк и все записи о нем в базе данных?","Сообщение", MessageBoxButtons.YesNo);


            string ID_Money = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='"+ Convert.ToString(metroGridBank.CurrentRow.Cells[8].Value) + "'");

            string ID_Organiz = manipulationDB.generationID("SELECT ИД FROM Организация " +
                "WHERE Наименование='" + Convert.ToString(metroGridBank.CurrentRow.Cells[4].Value) + "'");

            string ID_Pass = manipulationDB.generationID("SELECT ИД FROM Паспорт WHERE ФИО='" + Convert.ToString(metroGridBank.CurrentRow.Cells[1].Value) + "' " +
                "AND СиН='" + Convert.ToString(metroGridBank.CurrentRow.Cells[2].Value) + "' " +
                "AND Идентификатор='" + Convert.ToString(metroGridBank.CurrentRow.Cells[3].Value)  + "'");

            string query_Bank = "SELECT ИД FROM Банк WHERE Паспорт=@id " +
                "AND Организация=@organiz AND Должность=@rank " +
                "AND [Дата регистрации]=@dateReg " +
                "AND Сумма=@sum " +
                "AND Валюта=@money";

            string ID_Bank = "";
            try
            {
                if (dialogResult == DialogResult.Yes)
                {
                    SqlCommand comm = new SqlCommand(query_Bank, connect);
                    connect.Open();
                    comm.Parameters.AddWithValue("@id", ID_Pass);
                    comm.Parameters.AddWithValue("@organiz", ID_Organiz);
                    comm.Parameters.AddWithValue("@rank", metroGridBank.CurrentRow.Cells[5].Value);
                    comm.Parameters.AddWithValue("@dateReg", metroGridBank.CurrentRow.Cells[6].Value);
                    comm.Parameters.AddWithValue("@sum", metroGridBank.CurrentRow.Cells[7].Value);
                    comm.Parameters.AddWithValue("@money", ID_Money);
                    ID_Bank = Convert.ToString(comm.ExecuteScalar());
                    connect.Close();

                    string del_Bank = "DELETE FROM Банк WHERE ИД=@id";

                    connect.Open();
                    SqlCommand SQLcmdBank = new SqlCommand(del_Bank, connect);
                    SQLcmdBank.Parameters.AddWithValue("@id", ID_Bank);
                    SQLcmdBank.ExecuteScalar();
                    connect.Close();

                    string del_Plus = "DELETE FROM Приход WHERE Банк=@id";

                    connect.Open();
                    SqlCommand SQLcmdPlus = new SqlCommand(del_Plus, connect);
                    SQLcmdPlus.Parameters.AddWithValue("@id", ID_Bank);
                    SQLcmdPlus.ExecuteScalar();
                    connect.Close();

                    string del_Minus = "DELETE FROM Расход WHERE Банк=@id";

                    connect.Open();
                    SqlCommand SQLcmdMinus = new SqlCommand(del_Minus, connect);
                    SQLcmdMinus.Parameters.AddWithValue("@id", ID_Bank);
                    SQLcmdMinus.ExecuteScalar();
                    connect.Close();

                    manipulationDB.Select(manipulationDB.queryMinus, metroGridMinus);
                    manipulationDB.Select(manipulationDB.queryPlus, metroGridPlus);
                    manipulationDB.Select(manipulationDB.queryBank, metroGridBank);

                }
            }
            catch (SqlException exSQL)
            {
                MessageBox.Show(exSQL.Message, "Ошибка работы с базой данных:");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с приложением:");
            }
            finally
            {
                connect.Close();
            }

            //string queryViborPrihod = "SELECT * FROM Приход WHERE Банк=";

            //manipulationDB.DeleteWithVibor(metroGridBank, queryViborPrihod, manipulationDB.queryBankDel, ID_Bank);

            //string queryViborRashod = "SELECT * FROM Расход WHERE Банк=";

            //manipulationDB.DeleteWithVibor(metroGridBank, queryViborRashod, manipulationDB.queryBankDel, ID_Bank);

            //manipulationDB.Select(manipulationDB.queryBank, metroGridBank);
        }

        private void просмотрИИзменениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAllUsers showAllUsers = new ShowAllUsers();
            showAllUsers.Show();
        }

        private void регистрацияНовогоПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrationUser registrationUser = new RegistrationUser();
            registrationUser.Show();
        }

        private void toolStripButFindPlus_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Find(metroGridPlus, toolStripTextBoxFindPlus);
        }

        private void toolStripButFindMinus_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Find(metroGridMinus, toolStripTextBoxFindMinus);
        }

        private void toolStripButFindBank_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Find(metroGridBank, toolStripTextBoxFindBank);
        }

        private void resetPlus_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryPlus, metroGridPlus);
            manipulationDB.Select(manipulationDB.queryBank, metroGridBank);
        }

        private void resetMinus_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryMinus, metroGridMinus);
            manipulationDB.Select(manipulationDB.queryBank, metroGridBank);
        }

        private void resetBank_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryBank, metroGridBank);
        }

        private void metroButInsertForControlForm_Click(object sender, EventArgs e)
        {
            try
            {
                if(metroTabControlCF.SelectedTab.Text=="Приход")
                {
                    PlusInsert plusIns = new PlusInsert();
                    plusIns.Show();
                }
                else if(metroTabControlCF.SelectedTab.Text == "Расход")
                {
                    MinusInsert minusIns = new MinusInsert();
                    minusIns.Show();
                }
                else if(metroTabControlCF.SelectedTab.Text == "Банк")
                {
                    BankInsert bankIns = new BankInsert();
                    bankIns.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка:");
            }
        }

        private void metroButUpdateForControlForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (metroTabControlCF.SelectedTab.Text == "Приход")
                {
                    if (metroGridPlus.SelectedCells.Count != 0)
                    {
                        string ID_Pass = manipulationDB.generationID("SELECT ИД FROM Паспорт WHERE ФИО='" + metroGridPlus.CurrentRow.Cells[1].Value + "' AND СиН ='" + metroGridPlus.CurrentRow.Cells[2].Value + "' AND Идентификатор='" + metroGridPlus.CurrentRow.Cells[3].Value + "'");
                        string ID_Organization = manipulationDB.generationID("SELECT ИД FROM Организация WHERE Наименование='" + metroGridPlus.CurrentRow.Cells[4].Value + "'");
                        string ID_Valute = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='" + metroGridPlus.CurrentRow.Cells[8].Value + "'");
                        string ID_Bank = manipulationDB.generationID("SELECT ИД FROM Банк WHERE Паспорт='" + ID_Pass + "' AND Организация='" + ID_Organization + "' AND Валюта='" + ID_Valute + "'");

                        string ID_Operation = manipulationDB.generationID("SELECT ИД FROM Операция WHERE Наименование='" + metroGridPlus.CurrentRow.Cells[5].Value + "'");

                        if (ID_Bank == null || ID_Bank == "")
                        {
                            MessageBox.Show("Ошибка: банк не найден!", "Банка с заданными параметрами в базе данных более не существует. Удалите данную запись или перепишите операцию на имя другого банка!");
                        }
                        else
                        {
                            string newStrWithPoint = Convert.ToString(metroGridPlus.CurrentRow.Cells[7].Value).Replace(",", ".");
                            string queryPlusInBank = "UPDATE Банк SET Сумма=Сумма-@money WHERE ИД=@id";
                            connect.Open();
                            SqlCommand commBankPlus = new SqlCommand(queryPlusInBank, connect);
                            commBankPlus.Parameters.AddWithValue("@money", newStrWithPoint);
                            commBankPlus.Parameters.AddWithValue("@id", ID_Bank);
                            commBankPlus.ExecuteScalar();
                            connect.Close();
                        }
                        string query_Plus = "SELECT ИД FROM Приход WHERE Банк=@bank AND Наименование=@oper AND Описание=@info AND Сумма=@sum AND Валюта=@val";

                        string ID_Plus = "";
                        try
                        {
                            SqlCommand comm = new SqlCommand(query_Plus, connect);
                            connect.Open();
                            comm.Parameters.AddWithValue("@bank", ID_Bank);
                            comm.Parameters.AddWithValue("@oper", ID_Operation);
                            comm.Parameters.AddWithValue("@info", metroGridPlus.CurrentRow.Cells[6].Value);
                            comm.Parameters.AddWithValue("@sum", metroGridPlus.CurrentRow.Cells[7].Value);
                            comm.Parameters.AddWithValue("@val", ID_Valute);

                            if (comm.ExecuteScalar() != null)
                            {
                                ID_Plus = comm.ExecuteScalar().ToString();
                            }
                            else
                            {
                                ID_Plus = "";
                            }
                            connect.Close();

                            manipulationProgramm.ZapisIndex(ID_Plus);

                            UpdatePlus updatePlus = new UpdatePlus();
                            updatePlus.Show();
                            manipulationDB.SelectComboBox("SELECT * FROM Паспорт", updatePlus.metroComboBoxPass, "ФИО", "ИД");
                            manipulationDB.SelectComboBox("SELECT * FROM Организация", updatePlus.metroComboBoxOrg, "Наименование", "ИД");
                            manipulationDB.SelectComboBox("SELECT * FROM Операция", updatePlus.metroComboBoxNameOper, "Наименование", "ИД");
                            manipulationDB.SelectComboBox("SELECT * FROM Валюта", updatePlus.metroComboBoxVal, "Сокращенное наименование", "ИД");

                            updatePlus.metroComboBoxPass.Text = Convert.ToString(metroGridPlus.CurrentRow.Cells[1].Value);

                            string querySelSINPlus = "SELECT СиН FROM Паспорт WHERE ИД=@ID";
                            connect.Open();
                            SqlCommand commSIN = new SqlCommand(querySelSINPlus, connect);
                            commSIN.Parameters.AddWithValue("@ID", updatePlus.metroComboBoxPass.SelectedValue);
                            updatePlus.metroTextBoxSiN.Text = Convert.ToString(commSIN.ExecuteScalar());
                            connect.Close();

                            string querySelIDENTIFITYPlus = "SELECT Идентификатор FROM Паспорт WHERE ИД=@ID";
                            connect.Open();
                            SqlCommand commID = new SqlCommand(querySelIDENTIFITYPlus, connect);
                            commID.Parameters.AddWithValue("@ID", updatePlus.metroComboBoxPass.SelectedValue);
                            updatePlus.metroTextBoxIdentificator.Text = Convert.ToString(commID.ExecuteScalar());
                            connect.Close();

                            updatePlus.metroComboBoxNameOper.Text = Convert.ToString(metroGridPlus.CurrentRow.Cells[5].Value);
                            updatePlus.metroTextBoxInfo.Text = Convert.ToString(metroGridPlus.CurrentRow.Cells[6].Value);
                            updatePlus.metroTextBoxSum.Text = Convert.ToString(metroGridPlus.CurrentRow.Cells[7].Value);
                            updatePlus.metroComboBoxVal.Text = Convert.ToString(metroGridPlus.CurrentRow.Cells[8].Value);//nen
                        }
                        catch (SqlException exSQL)
                        {
                            MessageBox.Show(exSQL.Message, "Ошибка работы с базой данных:");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка работы с приложением:");
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                    }
                }
                else if (metroTabControlCF.SelectedTab.Text == "Расход")
                {
                    if (metroGridMinus.SelectedCells.Count != 0)
                    {
                        string ID_Pass = manipulationDB.generationID("SELECT ИД FROM Паспорт WHERE ФИО='" + metroGridMinus.CurrentRow.Cells[1].Value + "' AND СиН ='" + metroGridMinus.CurrentRow.Cells[2].Value + "' AND Идентификатор='" + metroGridMinus.CurrentRow.Cells[3].Value + "'");
                        string ID_Organization = manipulationDB.generationID("SELECT ИД FROM Организация WHERE Наименование='" + metroGridMinus.CurrentRow.Cells[4].Value + "'");
                        string ID_Valute = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='" + metroGridMinus.CurrentRow.Cells[8].Value + "'");
                        string ID_Bank = manipulationDB.generationID("SELECT ИД FROM Банк WHERE Паспорт='" + ID_Pass + "' AND Организация='" + ID_Organization + "' AND Валюта='" + ID_Valute + "'");

                        string ID_Operation = manipulationDB.generationID("SELECT ИД FROM Операция WHERE Наименование='" + metroGridMinus.CurrentRow.Cells[5].Value + "'");

                        if (ID_Bank == null || ID_Bank == "")
                        {
                            MessageBox.Show("Ошибка: банк не найден!", "Банка с заданными параметрами в базе данных более не существует. Удалите данную запись или перепишите операцию на имя другого банка!");
                        }
                        else
                        {
                            string newStrWithPoint = Convert.ToString(metroGridMinus.CurrentRow.Cells[7].Value).Replace(",", ".");
                            string queryPlusInBank = "UPDATE Банк SET Сумма=Сумма+@money WHERE ИД=@id";
                            connect.Open();
                            SqlCommand commBankPlus = new SqlCommand(queryPlusInBank, connect);
                            commBankPlus.Parameters.AddWithValue("@money", newStrWithPoint);
                            commBankPlus.Parameters.AddWithValue("@id", ID_Bank);
                            commBankPlus.ExecuteScalar();
                            connect.Close();
                        }

                        string query_Minus = "SELECT ИД FROM Расход WHERE Банк=@bank AND Наименование=@oper " +
                            "AND Описание=@info AND Сумма=@sum AND Валюта=@val";

                        string ID_Minus = "";
                        try
                        {
                            SqlCommand comm = new SqlCommand(query_Minus, connect);
                            connect.Open();
                            comm.Parameters.AddWithValue("@bank", ID_Bank);
                            comm.Parameters.AddWithValue("@oper", ID_Operation);
                            comm.Parameters.AddWithValue("@info", metroGridMinus.CurrentRow.Cells[6].Value);
                            comm.Parameters.AddWithValue("@sum", metroGridMinus.CurrentRow.Cells[7].Value);
                            comm.Parameters.AddWithValue("@val", ID_Valute);

                            if (comm.ExecuteScalar() != null)
                            {
                                ID_Minus = comm.ExecuteScalar().ToString();
                            }
                            else
                            {
                                ID_Minus = "";
                            }
                            connect.Close();

                            manipulationProgramm.ZapisIndex(ID_Minus);

                            UpdateMinus updateMinus = new UpdateMinus();
                            updateMinus.Show();
                            manipulationDB.SelectComboBox("SELECT * FROM Паспорт", updateMinus.metroComboBoxPass, "ФИО", "ИД");
                            manipulationDB.SelectComboBox("SELECT * FROM Организация", updateMinus.metroComboBoxOrg, "Наименование", "ИД");
                            manipulationDB.SelectComboBox("SELECT * FROM Операция", updateMinus.metroComboBoxNameOper1, "Наименование", "ИД");
                            manipulationDB.SelectComboBox("SELECT * FROM Валюта", updateMinus.metroComboBoxVal1, "Сокращенное наименование", "ИД");

                            updateMinus.metroComboBoxPass.Text = Convert.ToString(metroGridMinus.CurrentRow.Cells[1].Value);

                            string querySelSINPlus = "SELECT СиН FROM Паспорт WHERE ИД=@ID";
                            connect.Open();
                            SqlCommand commSIN = new SqlCommand(querySelSINPlus, connect);
                            commSIN.Parameters.AddWithValue("@ID", updateMinus.metroComboBoxPass.SelectedValue);
                            updateMinus.metroTextBoxSiN.Text = Convert.ToString(commSIN.ExecuteScalar());
                            connect.Close();

                            string querySelIDENTIFITYPlus = "SELECT Идентификатор FROM Паспорт WHERE ИД=@ID";
                            connect.Open();
                            SqlCommand commID = new SqlCommand(querySelIDENTIFITYPlus, connect);
                            commID.Parameters.AddWithValue("@ID", updateMinus.metroComboBoxPass.SelectedValue);
                            updateMinus.metroTextBoxIdentificator.Text = Convert.ToString(commID.ExecuteScalar());
                            connect.Close();

                            updateMinus.metroComboBoxNameOper1.Text = Convert.ToString(metroGridMinus.CurrentRow.Cells[5].Value);
                            updateMinus.metroTextBoxInfo1.Text = Convert.ToString(metroGridMinus.CurrentRow.Cells[6].Value);
                            updateMinus.metroTextBoxSum1.Text = Convert.ToString(metroGridMinus.CurrentRow.Cells[7].Value);
                            updateMinus.metroComboBoxVal1.Text = Convert.ToString(metroGridMinus.CurrentRow.Cells[8].Value);//nen
                        }
                        catch (SqlException exSQL)
                        {
                            MessageBox.Show(exSQL.Message, "Ошибка работы с базой данных:");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка работы с приложением:");
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                    }
                }
                else if (metroTabControlCF.SelectedTab.Text == "Банк")
                {
                    if (metroGridBank.SelectedCells.Count != 0)
                    {
                        string ID_Pass = manipulationDB.generationID("SELECT ИД FROM Паспорт WHERE ФИО='" + metroGridBank.CurrentRow.Cells[1].Value + "' AND СиН ='" + metroGridBank.CurrentRow.Cells[2].Value + "' AND Идентификатор='" + metroGridBank.CurrentRow.Cells[3].Value + "'");
                        string ID_Organization = manipulationDB.generationID("SELECT ИД FROM Организация WHERE Наименование='" + metroGridBank.CurrentRow.Cells[4].Value + "'");
                        string ID_Valute = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='" + metroGridBank.CurrentRow.Cells[8].Value + "'");

                        try
                        {
                            string query_Bank = "SELECT ИД FROM Банк WHERE Паспорт=@pass AND Организация=@organiz " +
                                "AND Должность=@rank AND [Дата регистрации]=@dateRef AND Сумма=@sum AND Валюта=@val";

                            string ID_Bank = "";

                            SqlCommand comm = new SqlCommand(query_Bank, connect);
                            connect.Open();
                            comm.Parameters.AddWithValue("@pass", ID_Pass);
                            comm.Parameters.AddWithValue("@organiz", ID_Organization);
                            comm.Parameters.AddWithValue("@rank", metroGridBank.CurrentRow.Cells[5].Value);
                            comm.Parameters.AddWithValue("@dateRef", metroGridBank.CurrentRow.Cells[6].Value);
                            comm.Parameters.AddWithValue("@sum", metroGridBank.CurrentRow.Cells[7].Value);
                            comm.Parameters.AddWithValue("@val", ID_Valute);

                            if (comm.ExecuteScalar() != null)
                            {
                                ID_Bank = comm.ExecuteScalar().ToString();
                            }
                            else
                            {
                                ID_Bank = "";
                            }
                            connect.Close();

                            manipulationProgramm.ZapisIndex(ID_Bank);

                            UpdateBank updateBank = new UpdateBank();
                            updateBank.Show();

                            manipulationDB.SelectComboBox("SELECT * FROM Организация", updateBank.metroComboBoxOrganization, "Наименование", "ИД");
                            manipulationDB.SelectComboBox("SELECT * FROM Валюта", updateBank.metroComboBoxVal, "Сокращенное наименование", "ИД");
                            manipulationDB.SelectComboBox("SELECT * FROM Паспорт", updateBank.metroComboBoxPass, "ФИО", "ИД");

                            updateBank.metroComboBoxPass.Text = Convert.ToString(metroGridBank.CurrentRow.Cells[1].Value);
                            updateBank.metroTextBoxSiN.Text = Convert.ToString(metroGridBank.CurrentRow.Cells[2].Value);
                            updateBank.metroTextBoxIdentificator.Text = Convert.ToString(metroGridBank.CurrentRow.Cells[3].Value);
                            updateBank.metroComboBoxOrganization.Text = Convert.ToString(metroGridBank.CurrentRow.Cells[4].Value);
                            updateBank.metroTextBoxRank.Text = Convert.ToString(metroGridBank.CurrentRow.Cells[5].Value);
                            updateBank.metroTextBoxDateOfReg.Text = Convert.ToString(metroGridBank.CurrentRow.Cells[6].Value);
                            updateBank.metroTextBoxSum.Text = Convert.ToString(metroGridBank.CurrentRow.Cells[7].Value);
                            updateBank.metroComboBoxVal.Text = Convert.ToString(metroGridBank.CurrentRow.Cells[8].Value);
                        }
                        catch (SqlException exSQL)
                        {
                            MessageBox.Show(exSQL.Message, "Ошибка работы с базой данных:");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка работы с приложением:");
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                else
                {
                    MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                }
                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка:");
            }
        }
    }
}