using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Corine
{
    public partial class bill : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Corine;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public bill()
        {
            InitializeComponent();
        }

        private void bill_Load(object sender, EventArgs e)
        {
            textBox6.Text = Class3.Id;
            txtOwnerName.Text = Class3.Ownername;
            txtPetName.Text = Class3.Petname;
  
            textBox1.Text= Class3.Timein;
            textBox2.Text = Class3.Timeout;
            textBox4.Text = Class3.Totalhours;
        }


        private void autoBookNumber()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) + 1 from Books");
            cmd.Connection = con;
            textBox5.Text = "B0001" + cmd.ExecuteScalar().ToString();
            con.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            new CustomerLandingPage().Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
       

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double hrs = double.Parse(textBox4.Text);
            double rate = double.Parse(textBox3.Text);


            double result = hrs * rate;

            label6.Text = "P" + result.ToString();

        }
    }
}
