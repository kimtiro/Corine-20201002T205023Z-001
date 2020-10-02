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
    public partial class PetRegistration : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Corine;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public PetRegistration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PetRegistration_Load(object sender, EventArgs e)
        {
            txtOwnerID.Text = Class1.Id;
            autoBookNumber();
        }
       private void autoBookNumber()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) + 1 from PetDetails");
            cmd.Connection = con;
            txtPetID.Text = "P00000" + cmd.ExecuteScalar().ToString();
            con.Close();
        }

        private void UserRegisterPet_Click(object sender, EventArgs e)
        {
            try
            {
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertPet");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@PetID", txtPetID.Text);
            cmd.Parameters.AddWithValue("@OwnerID", txtOwnerID.Text);
            cmd.Parameters.AddWithValue("@PetName", txtPetName.Text);
            cmd.Parameters.AddWithValue("@PetColor", txtPetColor.Text);
            cmd.Parameters.AddWithValue("@PetGender", txtPetGender.Text);
            cmd.Parameters.AddWithValue("@PetType", txtPetType.Text);
            cmd.Parameters.AddWithValue("@PetMedicine", txtPetMedicine.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
                autoBookNumber();
            Class2.Id = txtPetID.Text;
            Class2.Firstname = txtPetName.Text;
            new transactionPage().Show();
            this.Hide();

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
}

        private void button1_Click(object sender, EventArgs e)
        {
            new UserLogin().Show();
            this.Hide();
        }

        private void txtPetID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
