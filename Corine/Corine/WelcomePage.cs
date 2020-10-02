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
    public partial class WelcomePage : Form
    {
        public WelcomePage() => InitializeComponent();

        


        private void AdminLogin_Click(object sender, EventArgs e)
        {
            new UserLogin().Show();
            this.Hide();
        }

        private void AdminLogin_Click_1(object sender, EventArgs e)
        {
            new UserLogin().Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void WelcomePage_Load(object sender, EventArgs e)
        {

        }

        private void btnEmployeeLogin_Click(object sender, EventArgs e)
        {

            new EmployeeLogin().Show();
            this.Hide();
        }
    }
}
