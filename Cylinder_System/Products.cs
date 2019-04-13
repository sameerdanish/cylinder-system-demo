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
    public partial class Products : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samee\source\repos\Cylinder_System\Cylinder_System\CylinderDataBase.mdf;Integrated Security=True;Connect Timeout=30");
        public Products()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Products_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cylinderDataBaseDataSet1.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.cylinderDataBaseDataSet1.Products);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                bool check = false;
                SqlCommand cmd = new SqlCommand("Insert into [Products](Name,Size,Price,Weight,AvailableQuantity,CreatedDate,IsActive)values(@Name,@Size,@Price,@Weight,@AvailableQuantity,@CreatedDate,@IsActive)", sqlcon);
                cmd.Parameters.AddWithValue("@Name", textaName.Text.Trim());
                cmd.Parameters.AddWithValue("@Size", textasize.Text.Trim());
                cmd.Parameters.AddWithValue("@Price", textaprice.Text.Trim());
                cmd.Parameters.AddWithValue("@Weight", textaweight.Text.Trim());
                cmd.Parameters.AddWithValue("@AvailableQuantity", textaquantity.Text.Trim());
                cmd.Parameters.AddWithValue("@CreatedDate",DateTime.Now);
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
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Products]", sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                textaName.Text = "";
                textasize.Text = "";
                textaprice.Text = "";
                textaweight.Text = "";
                textaquantity.Text = "";
                Addcheck.Checked = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textaName.Text = "";
            textasize.Text = "";
            textaprice.Text = "";
            textaweight.Text = "";
            textaquantity.Text = "";
            Addcheck.Checked = false;
        }

        private void textasize_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textasize.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textasize.Text = textasize.Text.Remove(textasize.Text.Length - 1);
            }
        }

        private void textaprice_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textaprice.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textaprice.Text = textaprice.Text.Remove(textaprice.Text.Length - 1);
            }
        }

        private void textaweight_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textaweight.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textaweight.Text = textaweight.Text.Remove(textaweight.Text.Length - 1);
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
                cmd.CommandText = "UPDATE [Products] SET [Name] = '" + textuname.Text + "',[Size] = '" + textusize.Text + "',[Price]='" + textuprice.Text + "',[Weight]='"+ textuweight.Text +"',[AvailableQuantity]='"+ textuquantity.Text +"',[CreatedDate]='" + nullableDateTime + "',[UpdatedDate] ='" + DateTime.Now + "',[IsActive]='" + check + "' WHERE [Id] ='" + textuid.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully updated", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Connection.Close();
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Products]", sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                textuid.Text = "";
                textuname.Text = "";
                textusize.Text = "";
                textuprice.Text = "";
                textuweight.Text = "";
                textuquantity.Text = "";
                updatecheckBox.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void textuname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textusize_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textusize.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textusize.Text = textusize.Text.Remove(textusize.Text.Length - 1);
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

        private void textuweight_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textuweight.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textuweight.Text = textuweight.Text.Remove(textuweight.Text.Length - 1);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                //delete query  
                SqlCommand cmd = new SqlCommand();
                cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [Products]";
                DialogResult result = MessageBox.Show("Do You Really Want TO Delete This Record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    textdid.Focus();
                }
                else
                {
                    cmd.CommandText = "DELETE FROM [Products] WHERE [Id]= '" + textdid.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Selected Record is deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cmd.Connection.Close();

                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Products]", sqlcon);
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

        private void textdid_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textdid.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textdid.Text = textdid.Text.Remove(textdid.Text.Length - 1);
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
                cmd.CommandText = "SELECT * FROM [Products] WHERE [Name] = '" + textsname.Text + "' ";
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
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Products]", sqlcon);
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
