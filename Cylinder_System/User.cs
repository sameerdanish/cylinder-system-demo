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
    public partial class User : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samee\source\repos\Cylinder_System\Cylinder_System\CylinderDataBase.mdf;Integrated Security=True;Connect Timeout=30");
        public User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = false;
                //if (Addcheck.Checked)
                //{
                //    check = true;

                //}
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("Insert into [Users](Name,Email,Password,CreatedDate,IsActive)values(@name,@email,@password,@createddate,@isActive)", sqlcon);
                //SqlCommand cmd = new SqlCommand();
                //cmd = sqlcon.CreateCommand();
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "INSERT INTO [User]([Name],[Email],[Password],[Created_Date],[Updated_Date],[Isactive])VALUES('" + textName.Text + "','" + textEmail.Text + "','" + textPassword.Text + "','" + DateTime.Now + "', '"+DateTime.Now+"','"+check+"')";
                cmd.Parameters.AddWithValue("@name", textName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", textEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@password", textPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@createddate", DateTime.Now);
                //cmd.Parameters.AddWithValue("@updateddate", null);
                if (Addcheck.Checked)
                {
                    check = true;
                    cmd.Parameters.AddWithValue("@isActive", check);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@isActive", check);
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully Added", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sqlcon.Close();
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Users]", sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                //cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                textName.Text = "";
                textEmail.Text = "";
                textPassword.Text = "";
                Addcheck.Checked = false;

            }
            
        }

        private void User_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cylinderDataBaseDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.cylinderDataBaseDataSet.Users);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textName.Text = "";
            textEmail.Text = "";
            textPassword.Text = "";
            Addcheck.Checked = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = false;
                if (UcheckBox.Checked)
                {
                    check = true;

                }
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DateTime? nullableDateTime = null;
                cmd.CommandText = "UPDATE [Users] SET [Name] = '" + textUName.Text.Trim() + "',[Email] = '" + textUEmail.Text.Trim() + "',[Password]='" + textUPassword.Text.Trim() + "',[CreatedDate]='"+ nullableDateTime +"',[UpdatedDate] ='" + DateTime.Now + "',[IsActive]='" + check + "' WHERE [Id] ='" + textUId.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully updated", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Connection.Close();
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Users]", sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                textUId.Text = "";
                textUName.Text = "";
                textUEmail.Text = "";
                textUPassword.Text = "";
                UcheckBox.Checked = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                //delete query  
                SqlCommand cmd = new SqlCommand();
                cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [Users]";
                DialogResult result = MessageBox.Show("Do You Really Want TO Delete This Record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    textDId.Focus();
                }
                else
                {
                    cmd.CommandText = "DELETE FROM [Users] WHERE [Id]= '" + textDId.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Selected Record is deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cmd.Connection.Close();

                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Users]", sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [Users] WHERE [Name] = '" + textsname.Text + "' ";
                SqlDataAdapter adptr = new SqlDataAdapter(cmd.CommandText, sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                if (dt.Rows.Count == 0 )
                {
                    MessageBox.Show("Record Not Found", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
                sqlcon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Users]", sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
