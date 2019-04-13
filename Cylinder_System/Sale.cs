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
    public partial class Sale : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samee\source\repos\Cylinder_System\Cylinder_System\CylinderDataBase.mdf;Integrated Security=True;Connect Timeout=30");
        public Sale()
        {
            InitializeComponent();
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cylinderDataBaseDataSet5.Sale' table. You can move, or remove it, as needed.
            this.saleTableAdapter.Fill(this.cylinderDataBaseDataSet5.Sale);
            // TODO: This line of code loads data into the 'cylinderDataBaseDataSet4.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter1.Fill(this.cylinderDataBaseDataSet4.Products);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                bool check = false;
                SqlCommand cmd = new SqlCommand("Insert into [Sale](ProductId,PurchasePrice,SalePrice,SaleDate,CreatedDate,IsActive)values(@ProductId,@PurchasePrice,@SalePrice,@SaleDate,@CreatedDate,@IsActive)", sqlcon);
                cmd.Parameters.AddWithValue("@ProductId", addcomboBox.SelectedValue);
                cmd.Parameters.AddWithValue("@PurchasePrice", textapprice.Text.Trim());
                cmd.Parameters.AddWithValue("@SalePrice", textasprice.Text.Trim());
                cmd.Parameters.AddWithValue("@SaleDate", adddateTimePicker.Text);
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
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Products]", sqlcon);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                //dataGridView1.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                textapprice.Text = "";
                textasprice.Text = "";
                Addcheck.Checked = false;
            }
        }

        private void addcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Price FROM Products WHERE Name = '" + addcomboBox.Text + "'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlcon;
                    sqlcon.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        textapprice.Text = sdr["Price"].ToString();
                        //txtName.Text = sdr["Name"].ToString();
                        //txtCountry.Text = sdr["Country"].ToString();
                    }
                    sqlcon.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
