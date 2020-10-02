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
    public partial class RegisterEmployee : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Corine;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public RegisterEmployee()
        {
            InitializeComponent();
        }
        private void DisplayAllEmployee()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DisplayAllEmployee");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "employee");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void BookClearInput()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtContactNum.Clear();
            txtAddress.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            textBox1.Clear();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("InsertEmployee");
                cmd.Connection = con;
                //  cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
                cmd.Parameters.AddWithValue("@Id", txtUserId.Text);
                cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@lastname", txtLastName.Text);
                cmd.Parameters.AddWithValue("@contactnumber", txtContactNum.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@status  ",textBox1.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                autoBookNumber();
                DisplayAllEmployee();
                BookClearInput();
        
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
            SqlCommand cmd = new SqlCommand("select count(*) + 1 from employee");
            cmd.Connection = con;
            txtUserId.Text = "E00000" + cmd.ExecuteScalar().ToString();
            con.Close();
        }
        private void RegisterEmployee_Load(object sender, EventArgs e)
        {
            DisplayAllEmployee();
            autoBookNumber();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateEmployee");
                cmd.Connection = con;
                //   cmd.Parameters.AddWithValue("@PetID", int.Parse(txtPetID.Text));
                cmd.Parameters.AddWithValue("@Id", txtUserId.Text);
                cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@lastname", txtLastName.Text);
                cmd.Parameters.AddWithValue("@contactnumber", txtContactNum.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@status  ", textBox1.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                autoBookNumber();
                DisplayAllEmployee();
                BookClearInput();
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
                txtUserId.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
                txtFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells["firstname"].FormattedValue.ToString();
                txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells["lastname"].FormattedValue.ToString();
                txtContactNum.Text = dataGridView1.Rows[e.RowIndex].Cells["contactnumber"].FormattedValue.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].FormattedValue.ToString();
                txtUsername.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].FormattedValue.ToString();
                txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].FormattedValue.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["status"].FormattedValue.ToString();

            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtUserId.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            txtFirstName.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            txtLastName.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            txtContactNum.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            txtUsername.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            txtPassword.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new CustomerLandingPage().Show();
            this.Hide();
        }
    }
}
