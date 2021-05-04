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
    public partial class FinansedOperationInsert : MetroForm
    {
        public FinansedOperationInsert()
        {
            InitializeComponent();
        }

        private void FinansedOperationInsert_Load(object sender, EventArgs e)
        {

        }

        ManipulationDB manipulationDB = new ManipulationDB();

        private void InsFinOperation()
        {
            string query_FinOper = "INSERT INTO Операция VALUES('" + metroTextBoxNamFinOperation.Text + "')";
            manipulationDB.Insert(query_FinOper);
            metroTextBoxNamFinOperation.Text = null;
        }

        private void metroButIns_Click(object sender, EventArgs e)
        {
            InsFinOperation();
        }

        private void metroButInsAndClose_Click(object sender, EventArgs e)
        {
            InsFinOperation();
            Close();
        }
    }
}
