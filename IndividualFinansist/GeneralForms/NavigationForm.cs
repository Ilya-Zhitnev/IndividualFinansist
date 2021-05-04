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

namespace IndividualFinansist.GeneralForms
{
    public partial class NavigationForm : MetroForm
    {
        public NavigationForm()
        {
            InitializeComponent();
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            ControlFormTwo controlFormTwo = new ControlFormTwo();
            controlFormTwo.Show();
            this.Hide();
        }

        private void btBack_Click_1(object sender, EventArgs e)
        {
            AvtorizationForm avtorizationForm = new AvtorizationForm();
            avtorizationForm.Show();
            this.Hide();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            ControlForm controlForm = new ControlForm();
            controlForm.Show();
            this.Hide();
        }
    }
}
