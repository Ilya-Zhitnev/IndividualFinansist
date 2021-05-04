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
    public partial class MoneyInsert : MetroForm
    {
        public MoneyInsert()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();

        private void MoneyInsert_Load(object sender, EventArgs e)
        {

        }

        private void InsMoney()
        {
            string query_Money = "INSERT INTO Валюта VALUES('"+ metroTextBoxNamMoney.Text + "','" + metroTextBoxNamMoneyL.Text + "')";
            manipulationDB.Insert(query_Money);
            metroTextBoxNamMoney.Text = null;
            metroTextBoxNamMoneyL.Text = null;
        }
        private void metroButIns_Click(object sender, EventArgs e)
        {
            InsMoney();
        }

        private void metroButInsAndClose_Click(object sender, EventArgs e)
        {
            InsMoney();
            Close();
        }
    }
}
