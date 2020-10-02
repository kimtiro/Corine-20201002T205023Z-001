using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corine
{
    public partial class EmployeeLandingPage : Form
    {
        public EmployeeLandingPage()
        {
            InitializeComponent();
        }

        private void UserRegistration_Click(object sender, EventArgs e)
        {
            new UserRegistration().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ListOfCustomer().Show();
            this.Hide();
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            new inputTransaction().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new inputTransaction().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new WelcomePage().Show();
            this.Hide();
        }
    }
}
