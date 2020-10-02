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
    public partial class UserLogin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Corine;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public UserLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(*) from Admin where Username='" + txtUserEmail.Text + "' and Userpassword='" + txtUserPassword.Text+"'");
            cmd.Connection = con;
            // cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                new CustomerLandingPage().Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Invalid Credentials!!!");
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new WelcomePage().Show();
            this.Hide();
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
