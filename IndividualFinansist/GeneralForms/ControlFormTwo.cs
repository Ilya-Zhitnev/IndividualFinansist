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
using IndividualFinansist.Administration;
using IndividualFinansist.FormsForControlFormTwo.InsertFormForControlFormTwo;
using IndividualFinansist.FormsForControlFormTwo.UpdateFormForControlFormTwo;

namespace IndividualFinansist.GeneralForms
{
    public partial class ControlFormTwo : MetroForm
    {
        public ControlFormTwo()
        {
            InitializeComponent();
            manipulationDB.Select(manipulationDB.queryOrganization, metroGridOrganization);
            manipulationDB.Select(manipulationDB.queryMoney, metroGridMoney);
            manipulationDB.Select(manipulationDB.queryMoneySize, metroGridMoneySize);
            manipulationDB.Select(manipulationDB.queryFinOperation, metroGridFinansedOperation);
            manipulationDB.Select(manipulationDB.queryPassport, metroGridPassport);

            for (int i = 0; i < metroGridPassport.RowCount; i++)
            {
                metroGridPassport[3, i].Value = shifr_PBKDF2.Decrypt(Convert.ToString(metroGridPassport[3, i].Value), "204503");
            }
        }

        static string conn = ConnDB.conn;
        SqlConnection connect = new SqlConnection(conn);
        ManipulationDB manipulationDB = new ManipulationDB();
        ManipulationProgramm manipulationProgramm = new ManipulationProgramm();

        private void ControlFormTwo_Load(object sender, EventArgs e)
        {

        }

        private void btBack_Click(object sender, EventArgs e)
        {
            NavigationForm navigationForm = new NavigationForm();
            navigationForm.Show();
            this.Hide();
        }

        private void backUp4_Click(object sender, EventArgs e)
        {
            manipulationProgramm.BackUp(metroGridOrganization);
        }

        private void backUp5_Click(object sender, EventArgs e)
        {
            manipulationProgramm.BackUp(metroGridMoney);
        }

        private void backUp6_Click(object sender, EventArgs e)
        {
            manipulationProgramm.BackUp(metroGridMoneySize);
        }

        private void backUp7_Click(object sender, EventArgs e)
        {
            manipulationProgramm.BackUp(metroGridFinansedOperation);
        }

        private void Back5_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Back(metroGridMoney);
        }

        private void Back4_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Back(metroGridOrganization);
        }

        private void Back6_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Back(metroGridMoneySize);
        }

        private void Back7_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Back(metroGridFinansedOperation);
        }

        private void Next4_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Next(metroGridOrganization);
        }

        private void Next5_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Next(metroGridMoney);
        }

        private void Next6_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Next(metroGridMoneySize);
        }

        private void Next7_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Next(metroGridFinansedOperation);
        }

        private void NextUP4_Click(object sender, EventArgs e)
        {
            manipulationProgramm.NextUp(metroGridOrganization);
        }

        private void NextUP5_Click(object sender, EventArgs e)
        {
            manipulationProgramm.NextUp(metroGridMoney);
        }

        private void NextUP6_Click(object sender, EventArgs e)
        {
            manipulationProgramm.NextUp(metroGridMoneySize);
        }

        private void NextUP7_Click(object sender, EventArgs e)
        {
            manipulationProgramm.NextUp(metroGridFinansedOperation);
        }

        private void Delete4_Click(object sender, EventArgs e)
        {
            string ID_Org = manipulationDB.generationID("SELECT ИД FROM Организация" +
                " WHERE Наименование='"+ Convert.ToString(metroGridOrganization.CurrentRow.Cells[1].Value) + "' " +
                "AND [Дата регистрации]='" +Convert.ToString(metroGridOrganization.CurrentRow.Cells[2].Value)+"'" +
                " AND [Юридический адрес]='" + Convert.ToString(metroGridOrganization.CurrentRow.Cells[3].Value) + "' " +
                "AND [Фактический адрес]='" + Convert.ToString(metroGridOrganization.CurrentRow.Cells[4].Value) + "'");

            string queryViborOrg = "SELECT * FROM Банк WHERE Организация=";

            manipulationDB.DeleteWithVibor(metroGridOrganization, queryViborOrg, manipulationDB.queryOrganizationDel, ID_Org);

            //string queryViborOrg1 = "SELECT * FROM Расход WHERE Наименование=";

            //manipulationDB.DeleteWithVibor(metroGridOrganization, queryViborOrg1, manipulationDB.queryOrganizationDel, ID_Org);
        }

        private void Delete5_Click(object sender, EventArgs e)
        {
            string ID_Money = manipulationDB.generationID("SELECT ИД FROM Валюта" +
                " WHERE Наименование='" + Convert.ToString(metroGridMoney.CurrentRow.Cells[1].Value) + "' " +
                "AND [Сокращенное наименование]='" + Convert.ToString(metroGridMoney.CurrentRow.Cells[2].Value) + "'");

            string queryViborMoney1 = "SELECT * FROM [Курс валют] WHERE Валюта1=";

            manipulationDB.DeleteWithVibor(metroGridMoney, queryViborMoney1, manipulationDB.queryMoneyDel, ID_Money);

            string queryViborMoney2 = "SELECT * FROM [Курс валют] WHERE Валюта2=";

            manipulationDB.DeleteWithVibor(metroGridMoney, queryViborMoney2, manipulationDB.queryMoneyDel, ID_Money);
        }

        private void Delete6_Click(object sender, EventArgs e)
        {
            string ID_Val1 = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='"+ Convert.ToString(metroGridMoneySize.CurrentRow.Cells[2].Value) + "'");
            string ID_Val2 = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='" + Convert.ToString(metroGridMoneySize.CurrentRow.Cells[4].Value) + "'");

            string ID_MoneySize = manipulationDB.generationID("Select ИД FROM [Курс валют] " +
                "WHERE Единица1='"+ Convert.ToString(metroGridMoneySize.CurrentRow.Cells[1].Value) + "' AND Валюта1='"+ ID_Val1 + "' " +
                "AND Единица2='"+ Convert.ToString(metroGridMoneySize.CurrentRow.Cells[3].Value) + "' AND Валюта2='"+ ID_Val2 + "'");

            manipulationDB.Delete(metroGridMoneySize, manipulationDB.queryMoneySizeDel, ID_MoneySize);
        }

        private void Delete7_Click(object sender, EventArgs e)
        {
            string ID_Operation = manipulationDB.generationID("SELECT ИД FROM Операция" +
                " WHERE Наименование='" + Convert.ToString(metroGridFinansedOperation.CurrentRow.Cells[1].Value) + "'");

            string queryViborPrih = "SELECT * FROM Приход WHERE Наименование=";

            manipulationDB.DeleteWithVibor(metroGridFinansedOperation, queryViborPrih, manipulationDB.queryOperationDel, ID_Operation);

            string queryViborRash = "SELECT * FROM Расход WHERE Наименование=";

            manipulationDB.DeleteWithVibor(metroGridFinansedOperation, queryViborRash, manipulationDB.queryOperationDel, ID_Operation);
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

        private void toolStripButFindOrg_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Find(metroGridOrganization, toolStripTextBoxFindOrg);
        }

        private void toolStripButFindMoney_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Find(metroGridMoney, toolStripTextBoxFindMoney);
        }

        private void toolStripButFindSizeMoney_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Find(metroGridMoneySize, toolStripTextBoxFindSizeMoney);
        }

        private void toolStripButFindFinOperation_Click(object sender, EventArgs e)
        {
            manipulationProgramm.Find(metroGridFinansedOperation, toolStripTextBoxFindFinOperation);
        }

        private void resetOrg_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryOrganization, metroGridOrganization);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryMoney, metroGridMoney);
            manipulationDB.Select(manipulationDB.queryMoneySize, metroGridMoneySize);
        }

        private void resetSizeMoney_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryMoneySize, metroGridMoneySize);
        }

        private void resetFinOperation_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryFinOperation, metroGridFinansedOperation);
        }

        private void metroButInsertForControlForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (metroTabControlCF2.SelectedTab.Text == "Организация")
                {
                    OrganizationInsert organizationIns = new OrganizationInsert();
                    organizationIns.Show();
                }
                else if (metroTabControlCF2.SelectedTab.Text == "Валюты")
                {
                    MoneyInsert moneyInsert = new MoneyInsert();
                    moneyInsert.Show();
                }
                else if (metroTabControlCF2.SelectedTab.Text == "Курсы валют")
                {
                    MoneySizeInsert moneySizeInsert = new MoneySizeInsert();
                    moneySizeInsert.Show();
                    manipulationDB.SelectComboBox("SELECT * FROM Валюта", moneySizeInsert.metroComboBoxVal1, "Сокращенное наименование", "ИД");
                    manipulationDB.SelectComboBox("SELECT * FROM Валюта", moneySizeInsert.metroComboBoxVal2, "Сокращенное наименование", "ИД");
                }
                else if (metroTabControlCF2.SelectedTab.Text == "Финансовые операции")
                {
                    FinansedOperationInsert organizationInsert = new FinansedOperationInsert();
                    organizationInsert.Show();
                }
                else if (metroTabControlCF2.SelectedTab.Text == "Паспорт")
                {
                    PassportInsert passIns = new PassportInsert();
                    passIns.Show();
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
                if (metroTabControlCF2.SelectedTab.Text == "Организация")
                {
                    if (metroGridOrganization.SelectedCells.Count != 0)
                    {
                        string ID_Org = manipulationDB.generationID("SELECT ИД FROM Организация " +
                            "WHERE Наименование='"+ metroGridOrganization.CurrentRow.Cells[1].Value + "'" +
                            " AND [Дата регистрации]='"+metroGridOrganization.CurrentRow.Cells[2].Value+"' AND" +
                            " [Юридический адрес]='"+ metroGridOrganization.CurrentRow.Cells[3].Value + "' AND" +
                            " [Фактический адрес]='"+ metroGridOrganization.CurrentRow.Cells[4].Value + "'");
                        manipulationProgramm.ZapisIndex(ID_Org);

                        UpdateOrganization updateOrganization = new UpdateOrganization();
                        updateOrganization.Show();
                        updateOrganization.metroTextBoxNamOrg.Text = Convert.ToString(metroGridOrganization.CurrentRow.Cells[1].Value);
                        updateOrganization.metroTextBoxDateReg.Text = Convert.ToString(metroGridOrganization.CurrentRow.Cells[2].Value);
                        updateOrganization.metroTextBoxUrAddress.Text = Convert.ToString(metroGridOrganization.CurrentRow.Cells[3].Value);
                        updateOrganization.metroTextBoxFactAdress.Text = Convert.ToString(metroGridOrganization.CurrentRow.Cells[4].Value);
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                    }
                }
                else if (metroTabControlCF2.SelectedTab.Text == "Валюты")
                {
                    if (metroGridMoney.SelectedCells.Count != 0)
                    {
                        string ID_Val = manipulationDB.generationID("SELECT ИД FROM Валюта" +
                            " WHERE Наименование='" + metroGridMoney.CurrentRow.Cells[1].Value + "' " +
                            "AND [Сокращенное наименование]='" + metroGridMoney.CurrentRow.Cells[2].Value + "'");

                        manipulationProgramm.ZapisIndex(ID_Val);

                        UpdateMoney updateMoney = new UpdateMoney();
                        updateMoney.Show();
                        updateMoney.metroTextBoxFullName.Text = Convert.ToString(metroGridMoney.CurrentRow.Cells[1].Value);
                        updateMoney.metroTextBoxMiniName.Text = Convert.ToString(metroGridMoney.CurrentRow.Cells[2].Value);
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                    }
                }
                else if (metroTabControlCF2.SelectedTab.Text == "Курсы валют")
                {
                    if (metroGridMoneySize.SelectedCells.Count != 0)
                    {
                        string ID_Val1 = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='"+metroGridMoneySize.CurrentRow.Cells[2].Value +"'");
                        string ID_Val12 = manipulationDB.generationID("SELECT ИД FROM Валюта WHERE [Сокращенное наименование]='" + metroGridMoneySize.CurrentRow.Cells[4].Value + "'");

                        string query_Curs = "SELECT ИД FROM [Курс валют] WHERE Единица1=@ed1 AND Валюта1=@val1 AND Единица2=@ed2 AND Валюта2=@val2";

                        string ID_Curs = "";
                        try
                        {
                            SqlCommand comm = new SqlCommand(query_Curs, connect);
                            connect.Open();
                            comm.Parameters.AddWithValue("@ed1", metroGridMoneySize.CurrentRow.Cells[1].Value);
                            comm.Parameters.AddWithValue("@val1", ID_Val1);
                            comm.Parameters.AddWithValue("@ed2", metroGridMoneySize.CurrentRow.Cells[3].Value);
                            comm.Parameters.AddWithValue("@val2", ID_Val12);

                            if (comm.ExecuteScalar() != null)
                            {
                                ID_Curs = comm.ExecuteScalar().ToString();
                            }
                            else
                            {
                                ID_Curs = "";
                            }
                            connect.Close();

                            manipulationProgramm.ZapisIndex(ID_Curs);

                            UpdateMoneySize updateMoneySize = new UpdateMoneySize();
                            updateMoneySize.Show();

                            manipulationDB.SelectComboBox("SELECT * FROM Валюта", updateMoneySize.metroComboBoxVal1, "Сокращенное наименование", "ИД");
                            manipulationDB.SelectComboBox("SELECT * FROM Валюта", updateMoneySize.metroComboBoxVal2, "Сокращенное наименование", "ИД");

                            updateMoneySize.metroTextBoxSizeMoney1.Text = Convert.ToString(metroGridMoneySize.CurrentRow.Cells[1].Value);
                            updateMoneySize.metroComboBoxVal1.Text = Convert.ToString(metroGridMoneySize.CurrentRow.Cells[2].Value);
                            updateMoneySize.metroTextBoxSizeMoney2.Text = Convert.ToString(metroGridMoneySize.CurrentRow.Cells[3].Value);
                            updateMoneySize.metroComboBoxVal2.Text = Convert.ToString(metroGridMoneySize.CurrentRow.Cells[4].Value);


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
                else if (metroTabControlCF2.SelectedTab.Text == "Финансовые операции")
                {
                    if (metroGridFinansedOperation.SelectedCells.Count != 0)
                    {
                        string ID_Oper = manipulationDB.generationID("SELECT * FROM Операция " +
                            "WHERE Наименование='" + metroGridFinansedOperation.CurrentRow.Cells[1].Value + "'");
                        manipulationProgramm.ZapisIndex(ID_Oper);

                        UpdateFinansedOperation updateFinansedOperation = new UpdateFinansedOperation();
                        updateFinansedOperation.Show();
                        updateFinansedOperation.metroTextBoxNamFinOperation.Text = Convert.ToString(metroGridFinansedOperation.CurrentRow.Cells[1].Value);
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку, которую хотите изменить!!!", "Ошибка");
                    }
                }
                else if(metroTabControlCF2.SelectedTab.Text == "Паспорт")
                {
                    if (metroGridPassport.SelectedCells.Count != 0)
                    {
                        string ID_Pass = manipulationDB.generationID("SELECT * FROM Паспорт " +
                            "WHERE ФИО='" + metroGridPassport.CurrentRow.Cells[1].Value + "' AND СиН='" + metroGridPassport.CurrentRow.Cells[2].Value + "'");
                        manipulationProgramm.ZapisIndex(ID_Pass);

                        UpdatePassport updatePass = new UpdatePassport();
                        updatePass.Show();
                        updatePass.metroTextBoxFio.Text = Convert.ToString(metroGridPassport.CurrentRow.Cells[1].Value);
                        updatePass.metroTextBoxSin.Text = Convert.ToString(metroGridPassport.CurrentRow.Cells[2].Value);
                        updatePass.metroTextBoxIdentifity.Text = Convert.ToString(metroGridPassport.CurrentRow.Cells[3].Value);
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

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void Delete8_Click(object sender, EventArgs e)
        {
            string ID_Pass = manipulationDB.generationID("SELECT ИД FROM Паспорт" +
                " WHERE СиН='" + Convert.ToString(metroGridPassport.CurrentRow.Cells[1].Value) + "' AND " +
                "Идентификатор='" + Convert.ToString(metroGridPassport.CurrentRow.Cells[2].Value)  + "'");
            string queryViborPass = "SELECT * FROM Банк WHERE Паспорт=";
            manipulationDB.DeleteWithVibor(metroGridPassport, queryViborPass, manipulationDB.queryPassportDel, ID_Pass);
        }

        private void metroButtonMenuOpen_Click(object sender, EventArgs e)
        {
            if (menuControl.Visible == true)
            {
                menuControl.Visible = false;
                metroButtonMenuOpen.Text = "<";
            }
            else if (menuControl.Visible == false)
            {
                menuControl.Visible = true;
                metroButtonMenuOpen.Text = ">";
            }
        }
    }
}
