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
    public partial class Vendor : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samee\source\repos\Cylinder_System\Cylinder_System\CylinderDataBase.mdf;Integrated Security=True;Connect Timeout=30");
        public Vendor()
        {
            InitializeComponent();
        }

        private void textaPrice_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textaPrice.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textaPrice.Text = textaPrice.Text.Remove(textaPrice.Text.Length - 1);
            }
        }

        private void textaquantity_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textaquantity.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textaquantity.Text = textaquantity.Text.Remove(textaquantity.Text.Length - 1);
            }
        }

        private void textanumber_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textanumber.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textanumber.Text = textanumber.Text.Remove(textanumber.Text.Length - 1);
            }
        }

        private void textuprice_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textuprice.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textuprice.Text = textuprice.Text.Remove(textuprice.Text.Length - 1);
            }
        }

        private void textuquantity_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textuquantity.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textuquantity.Text = textuquantity.Text.Remove(textuquantity.Text.Length - 1);
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

        private void textdid_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textdid.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textdid.Text = textdid.Text.Remove(textdid.Text.Length - 1);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                bool check = false;
                SqlCommand cmd = new SqlCommand("Insert into [Vendor](CompanyName,Date,Price,Quantity,FullCylinder,EmptyCylinder,ContactNumber,Createddate,IsActive)values(@CompanyName,@Date,@Price,@Quantity,@FullCylinder,@EmptyCylinder,@Number,@CreatedDate,@IsActive)", sqlcon);
                cmd.Parameters.AddWithValue("@CompanyName", textaName.Text.Trim());
                cmd.Parameters.AddWithValue("@Date", AdddateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Price", textaPrice.Text.Trim());
                cmd.Parameters.AddWithValue("@Quantity", textaquantity.Text.Trim());
                cmd.Parameters.AddWithValue("@FullCylinder", textafulc.Text.Trim());
                cmd.Parameters.AddWithValue("@EmptyCylinder", textaec.Text.Trim());
                cmd.Parameters.AddWithValue("@Number", textanumber.Text.Trim());
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
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Vendor]", sqlcon);
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
                textaPrice.Text = "";
                textaquantity.Text = "";
                textafulc.Text = "";
                textaec.Text = "";
                textanumber.Text = "";
                Addcheck.Checked = false;
            }
        }

        private void Vendor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cylinderDataBaseDataSet3.Vendor' table. You can move, or remove it, as needed.
            this.vendorTableAdapter.Fill(this.cylinderDataBaseDataSet3.Vendor);


        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textaName.Text = "";
            textaPrice.Text = "";
            textaquantity.Text = "";
            textafulc.Text = "";
            textaec.Text = "";
            textanumber.Text = "";
            Addcheck.Checked = false;
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = false;
                if (ucheckBox1.Checked)
                {
                    check = true;

                }
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DateTime? nullableDateTime = null;
                cmd.CommandText = "UPDATE [Vendor] SET [CompanyName] = '" + textuname.Text + "',[Date] = '" + udateTimePicker1.Text + "',[Price]='" + textuprice.Text + "',[Quantity]='" + textuquantity.Text + "',[FullCylinder]='" + textufc.Text + "',[EmptyCylinder]='" +textuec.Text + "',[ContactNumber]='" +textunumber + "',[Createddate]='" + nullableDateTime + "',[UpdatedDate] ='" + DateTime.Now + "',[IsActive]='" + check + "' WHERE [Id] ='" + textuid.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully updated", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Connection.Close();
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Vendor]", sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                textuid.Text = "";
                textuname.Text = "";
                textuprice.Text = "";
                textuquantity.Text = "";
                textufc.Text = "";
                textuec.Text = "";
                textunumber.Text = "";
                ucheckBox1.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = false;
                if (ucheckBox1.Checked)
                {
                    check = true;

                }
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DateTime? nullableDateTime = null;
                cmd.CommandText = "UPDATE [Vendor] SET [CompanyName] = '" + textuname.Text + "',[Date] = '" + udateTimePicker1.Text + "',[Price]='" + textuprice.Text + "',[Quantity]='" + textuquantity.Text + "',[FullCylinder]='" + textufc.Text + "',[EmptyCylinder]='" + textuec.Text + "',[ContactNumber]='" + textunumber.Text + "',[Createddate]='" + nullableDateTime + "',[UpdatedDate] ='" + DateTime.Now + "',[IsActive]='" + check + "' WHERE [Id] ='" + textuid.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully updated", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Connection.Close();
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Vendor]", sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                textuid.Text = "";
                textuname.Text = "";
                textuprice.Text = "";
                textuquantity.Text = "";
                textufc.Text = "";
                textuec.Text = "";
                textunumber.Text = "";
                ucheckBox1.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                //delete query  
                SqlCommand cmd = new SqlCommand();
                cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [Vendor]";
                DialogResult result = MessageBox.Show("Do You Really Want TO Delete This Record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    textdid.Focus();
                }
                else
                {
                    cmd.CommandText = "DELETE FROM [Vendor] WHERE [Id]= '" + textdid.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Selected Record is deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cmd.Connection.Close();

                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Vendor]", sqlcon);
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

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [Vendor] WHERE [CompanyName] = '" + textsname.Text + "' ";
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

        private void Showall_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Vendor]", sqlcon);
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
    }
}
