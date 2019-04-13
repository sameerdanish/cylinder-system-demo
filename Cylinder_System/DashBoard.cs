using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cylinder_System
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void productsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();
            sale.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vendor vendor = new Vendor();
            vendor.Show();
        }
    }
}
