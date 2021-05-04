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

namespace IndividualFinansist.FormsForControlFormTwo.InsertFormForControlFormTwo
{
    public partial class PassportInsert : MetroForm
    {
        public PassportInsert()
        {
            InitializeComponent();
        }

        ManipulationDB manipulationDB = new ManipulationDB();

        private void InsPass()
        {
            string insPass = "INSERT INTO Паспорт VALUES('" + metroTextBoxFio.Text + "', '" + metroTextBoxSin.Text + "'," +
                "'" + shifr_PBKDF2.Encrypt(Convert.ToString(metroTextBoxIdentifity.Text), "204503") + "')";
            manipulationDB.Insert(insPass);
            metroTextBoxFio.Text = null;
            metroTextBoxSin.Text = null;
            metroTextBoxIdentifity.Text = null;
        }
        private void metroButIns_Click(object sender, EventArgs e)
        {
            InsPass();
        }

        private void metroButInsAndClose_Click(object sender, EventArgs e)
        {
            InsPass();
            Close();
        }
    }
}
