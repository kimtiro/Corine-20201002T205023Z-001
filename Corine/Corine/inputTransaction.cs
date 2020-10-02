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
    public partial class inputTransaction : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Corine;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public inputTransaction()
        {
            InitializeComponent();
        }

        private void inputTransaction_Load(object sender, EventArgs e)
        {

            textBox3.Text = Class3.Id;
            txtPetID.Text = Class1.Id;
            txtOwnerName.Text = Class1.Firstname;
            txtPetName.Text = Class2.Username;
            textBox1.Text = Class3.Timein;


            Class3.Id = textBox3.Text;
            Class1.Firstname = txtOwnerName.Text;
            Class2.Username = txtPetName.Text;
            Class3.Timein = textBox1.Text;
            Class3.Timeout = textBox2.Text;
            Class3.Totalhours = textBox4.Text;


            DisplayTransactionList();

        }
        private void DisplayTransactionList()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DisplayTransactionList");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "transactions");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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
                DisplayTransactionList();
                ClearInput();
                //   new inputTransaction().Show();
                //    this.Hide();

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
                txtPetID.Text = dataGridView1.Rows[e.RowIndex].Cells["petID"].FormattedValue.ToString();
                txtPetName.Text = dataGridView1.Rows[e.RowIndex].Cells["PetName"].FormattedValue.ToString();
                txtOwnerName.Text = dataGridView1.Rows[e.RowIndex].Cells["ownerName"].FormattedValue.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["timein"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["timeout"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["totalhrs"].FormattedValue.ToString();

            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime firsttime = DateTime.Parse(textBox1.Text).AddHours(-6);
            DateTime secondtime = DateTime.Parse(textBox2.Text).AddHours(-6);

            TimeSpan difference = firsttime.Subtract(secondtime);

            int times = difference.Hours * 60;
            int timess = times / 60;
            textBox4.Text = timess.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            txtPetID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            txtOwnerName.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            txtPetName.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateTransaction");
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
                Class3.Ownername = txtOwnerName.Text;
                Class3.Petname = txtPetName.Text;
                Class3.Timein = textBox1.Text;
                Class3.Timeout = textBox2.Text;
                Class3.Totalhours = textBox4.Text;
                DisplayTransactionList();
                ClearInput();
            }
            catch (Exception f)
            {
                con.Close();
                MessageBox.Show(f.Message);
            }
        }
        private void ClearInput()
        {
            textBox3.Clear();
            txtPetID.Clear();
            txtPetName.Clear();
            txtOwnerName.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteTransactionPhysically");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Id", textBox3.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                  ClearInput();
                DisplayTransactionList();


            }
            catch (Exception f)
            {
                con.Close();
                MessageBox.Show(f.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Class3.Id = textBox3.Text;
            Class3.Ownername = txtOwnerName.Text;
            Class3.Petname = txtPetName.Text;
            Class3.Timein = textBox1.Text;
            Class3.Timeout = textBox2.Text;
            Class3.Totalhours = textBox4.Text;
            new bill().Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new CustomerLandingPage().Show();
            this.Hide();
        }
    }
}
