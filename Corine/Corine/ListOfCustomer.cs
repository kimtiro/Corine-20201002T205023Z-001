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
    public partial class ListOfCustomer : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Corine;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public ListOfCustomer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ListOfCustomer_Load(object sender, EventArgs e)
        {
            DisplayCustomerList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
        }

        private void DisplayCustomerList()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DisplayCustomerList"); //stored
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "PetDetails");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new CustomerLandingPage().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new UserRegistration().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdatePetDetails");
                cmd.Connection = con;
                //   cmd.Parameters.AddWithValue("@PetID", int.Parse(txtPetID.Text));
                cmd.Parameters.AddWithValue("@PetID", txtPetID.Text);
                cmd.Parameters.AddWithValue("@OwnerID", txtOwnerID.Text);
                cmd.Parameters.AddWithValue("@PetName", txtPetName.Text);
                cmd.Parameters.AddWithValue("@PetColor", txtPetColor.Text);
                cmd.Parameters.AddWithValue("@PetGender", txtPetGender.Text);
                cmd.Parameters.AddWithValue("@PetType", txtPetType.Text);
                cmd.Parameters.AddWithValue("@PetMedicine", txtPetMeds.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                ClearInput();
                DisplayCustomerList();
            }
            catch (Exception f)
            {
                con.Close();
                MessageBox.Show(f.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtPetID.Text = dataGridView1.Rows[e.RowIndex].Cells["PetID"].FormattedValue.ToString();
                txtOwnerID.Text = dataGridView1.Rows[e.RowIndex].Cells["OwnerID"].FormattedValue.ToString();
                txtPetName.Text = dataGridView1.Rows[e.RowIndex].Cells["PetName"].FormattedValue.ToString();
                txtPetColor.Text = dataGridView1.Rows[e.RowIndex].Cells["PetColor"].FormattedValue.ToString();
                txtPetGender.Text = dataGridView1.Rows[e.RowIndex].Cells["PetGender"].FormattedValue.ToString();
                txtPetType.Text = dataGridView1.Rows[e.RowIndex].Cells["PetType"].FormattedValue.ToString();
                txtPetMeds.Text = dataGridView1.Rows[e.RowIndex].Cells["PetMedicine"].FormattedValue.ToString();

            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            txtPetID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            txtOwnerID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            txtPetName.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            txtPetColor.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            txtPetGender.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            txtPetType.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            txtPetMeds.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();



        }



        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteCustomerListPhysically");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@PetID", txtPetID.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                ClearInput();
                DisplayCustomerList();
           

            }
            catch (Exception f)
            {
                con.Close();
                MessageBox.Show(f.Message);
            }
        }
        private void ClearInput()
        {
            txtPetID.Clear();
            txtOwnerID.Clear();
            txtPetName.Clear();
            txtPetColor.Clear();
            txtPetGender.Clear();
            txtPetType.Clear();
            txtPetMeds.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SearchPetType");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@PetType", textBox1.Text );
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "PetDetails");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new transactionPage().Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
