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
    public partial class Customer : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samee\source\repos\Cylinder_System\Cylinder_System\CylinderDataBase.mdf;Integrated Security=True;Connect Timeout=30");
        public Customer()
        {
            InitializeComponent();
        }

        private void textanumber_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textanumber.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textanumber.Text = textanumber.Text.Remove(textanumber.Text.Length - 1);
            }
        }

        private void textunumber_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textunumber.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textunumber.Text = textunumber.Text.Remove(textunumber.Text.Length - 1);
            }
        }

        private void textuid_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textuid.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textuid.Text = textuid.Text.Remove(textuid.Text.Length - 1);
            }
        }

        private void textdid_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textdid.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textdid.Text = textdid.Text.Remove(textdid.Text.Length - 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                bool check = false;
                SqlCommand cmd = new SqlCommand("Insert into [Customers](ShopkeerName,Address,CNumber,CreatedDate,IsActive)values(@ShopkeerName,@Address,@CNumber,@CreatedDate,@IsActive)", sqlcon);
                cmd.Parameters.AddWithValue("@ShopkeerName", textaName.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", textaaddress.Text.Trim());
                cmd.Parameters.AddWithValue("@CNumber", textanumber.Text.Trim());
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                if (Addcheck.Checked)
                {
                    check = true;
                    cmd.Parameters.AddWithValue("@IsActive", check);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsActive", check);
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully Added", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sqlcon.Close();
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Customers]", sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                textaName.Text = "";
                textaaddress.Text = "";
                textanumber.Text = "";
                Addcheck.Checked = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textaName.Text = "";
            textaaddress.Text = "";
            textanumber.Text = "";
            Addcheck.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = false;
                if (updatecheckBox.Checked)
                {
                    check = true;

                }
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DateTime? nullableDateTime = null;
                cmd.CommandText = "UPDATE [Customers] SET [ShopkeerName] = '" + textuname.Text + "',[Address] = '" + textuaddress.Text + "',[CNumber]='" + textunumber.Text + "',[CreatedDate]='" + nullableDateTime + "',[UpdatedDate] ='" + DateTime.Now + "',[IsActive]='" + check + "' WHERE [Id] ='" + textuid.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully updated", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Connection.Close();
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Customers]", sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                textuid.Text = "";
                textuname.Text = "";
                textuaddress.Text = "";
                textunumber.Text = "";
                updatecheckBox.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                //delete query  
                SqlCommand cmd = new SqlCommand();
                cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [Customers]";
                DialogResult result = MessageBox.Show("Do You Really Want TO Delete This Record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    textdid.Focus();
                }
                else
                {
                    cmd.CommandText = "DELETE FROM [Customers] WHERE [Id]= '" + textdid.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Selected Record is deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cmd.Connection.Close();

                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Customers]", sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [Customers] WHERE [ShopkeerName] = '" + textsname.Text + "' ";
                SqlDataAdapter adptr = new SqlDataAdapter(cmd.CommandText, sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Record Not Found", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Customers]", sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cylinderDataBaseDataSet2.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.cylinderDataBaseDataSet2.Customers);


        }
    }
}
