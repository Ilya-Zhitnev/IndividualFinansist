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
    public partial class OrganizationInsert : MetroForm
    {
        public OrganizationInsert()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();

        private void OrganizationInsert_Load(object sender, EventArgs e)
        {

        }

        private void InsOrganization()
        {
            string query_Organiz = "INSERT INTO Организация " +
                "VALUES('" + metroTextBoxNamOrg.Text + "', '" + metroTextBoxDateReg.Text + "', " +
                "'" + metroTextBoxUrAddress.Text + "', '" + metroTextBoxFactAddress.Text + "')";
            manipulationDB.Insert(query_Organiz);
            metroTextBoxNamOrg.Text = null;
            metroTextBoxDateReg.Text = null;
            metroTextBoxUrAddress.Text = null;
            metroTextBoxFactAddress.Text = null;
        }
        private void metroButIns_Click(object sender, EventArgs e)
        {
            InsOrganization();
        }

        private void metroButInsAndClose_Click(object sender, EventArgs e)
        {
            InsOrganization();
            Close();
        }
    }
}
