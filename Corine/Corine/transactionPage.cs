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
    public partial class transactionPage : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Corine;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public transactionPage()
        {
            InitializeComponent();
        }
        private void transactionPage_Load(object sender, EventArgs e)
        {
            txtPetID.Text = Class1.Id;
            txtOwnerName.Text = Class1.Firstname;
            txtPetName.Text = Class2.Firstname;
            textBox2.Text = "00:00";
            textBox4.Text = "0";

            autoBookNumber();
        }

        private void autoBookNumber()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) + 1 from transactions");
            cmd.Connection = con;
            textBox3.Text = "TR00000" + cmd.ExecuteScalar().ToString();
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertTransaction");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Id", textBox3.Text);
                cmd.Parameters.AddWithValue("@petID", txtPetID.Text);
                cmd.Parameters.AddWithValue("@PetName", txtPetName.Text);
                cmd.Parameters.AddWithValue("@ownerName", txtOwnerName.Text);
                cmd.Parameters.AddWithValue("@timein", textBox1.Text);
                cmd.Parameters.AddWithValue("@timeout", textBox2.Text);
                cmd.Parameters.AddWithValue("@totalhrs", Convert.ToInt32(textBox4.Text));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                Class3.Id = textBox3.Text;
                Class1.Firstname = txtOwnerName.Text;
                Class2.Username = txtPetName.Text;
                Class3.Timein = textBox1.Text;
                Class3.Timeout = textBox2.Text;
                Class3.Totalhours = textBox4.Text;
                new inputTransaction().Show();
                this.Hide();
                //   new inputTransaction().Show();
                //    this.Hide();

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }

        }

     
        private void totalhours_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
         
        }
    }
}
