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
    public partial class UserRegistration : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Corine;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public UserRegistration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("InsertUser");
                cmd.Connection = con;
                //  cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
                cmd.Parameters.AddWithValue("@UserId", txtUserId.Text);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Userpassword", txtPassword.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@ContactNum ", Convert.ToInt32(txtContactNum.Text));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                autoBookNumber();
                Class1.Id = txtUserId.Text;
                Class1.Firstname = txtUsername.Text;
                new PetRegistration().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        private void autoBookNumber()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) + 1 from UserProfile");
            cmd.Connection = con;
            txtUserId.Text = "C00000" + cmd.ExecuteScalar().ToString();
            con.Close();
        }

        private void UserRegistration_Load(object sender, EventArgs e)
        {
            autoBookNumber();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CustomerLandingPage().Show();
            this.Hide();
        }
    }
}
