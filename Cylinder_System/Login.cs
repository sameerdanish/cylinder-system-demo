using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cylinder_System
{
    public partial class Login : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samee\source\repos\Cylinder_System\Cylinder_System\CylinderDataBase.mdf;Integrated Security=True;Connect Timeout=30");
        public Login()
        {
            InitializeComponent();
            string query = "Select * from Users Where Id='1'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count != 1)
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("Insert into Users(Name,Email,Password,CreatedDate,IsActive)values(@Name,@Email,@Password,@CreatedDate,@IsActive)", sqlcon);

                cmd.Parameters.AddWithValue("@Name", "admin");
                cmd.Parameters.AddWithValue("@Email", "admin@mail.com");
                cmd.Parameters.AddWithValue("@Password", "admin123");
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsActive", "True");
                cmd.ExecuteNonQuery();
                sqlcon.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                sqlcon.Open();

                //Create object of SqlAdapter and pass the query and object of ConnectionString
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT Name,Password,IsActive FROM Users", sqlcon);

                //Create object of Dataset 
                DataSet ds = new DataSet();

                //dataset is fiiled with dataAdapter
                adptr.Fill(ds);

                //create object of DataTable and assign the table to it
                DataTable dt = ds.Tables[0];

                //loops start
                Boolean b = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Active = "True";
                    //comparision with the username and password entered
                    if ((textusername.Text).Equals((dt.Rows[i][0]).ToString()) && (textpassword.Text).Equals((dt.Rows[i][1]).ToString()) && (Active).Equals((dt.Rows[i][2]).ToString()))
                    {
                        MessageBox.Show("You Are Successfully Loged in...", "Wel-Come To Cylinder-Store-Management-System", MessageBoxButtons.OK, MessageBoxIcon.None);

                        //shows the mdi form and hide the login form
                        DashBoard dashBoard = new DashBoard();
                        dashBoard.Show();
                        this.Hide();
                        b = true;
                        break;
                    }
                }

                // if User name and password are not matched
                if (!b)
                {
                    MessageBox.Show("Invalid Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textusername.Text = "";
                    textpassword.Text = "";
                    textusername.Focus();
                }

                // Closing of database
                sqlcon.Close();
            }
            finally
            {
            }
        }
    }
}
