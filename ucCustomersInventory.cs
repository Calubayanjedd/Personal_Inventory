using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_Inventory_for_Juntec
{
    public partial class ucCustomersInventory : UserControl
    {
        public ucCustomersInventory()
        {
            InitializeComponent();
        }

        private void ucCustomersInventory_Load(object sender, EventArgs e)
        {

        }

        private void ApplyFilter()
        {
            string search = txtSearch.Text.Trim().Replace("'", "''");
            //string type = cbType.Text.Trim().Replace("'", "''");

            // Start filter with search
            string filter = $"item_name LIKE '%{search}%'";

            // Add type filter if selected
            /*if (!string.IsNullOrWhiteSpace(type))
            {
                filter += $" AND item_type = '{type}'";
            }*/

            (dgvCustomersInventory.DataSource as DataTable).DefaultView.RowFilter = filter;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //ApplyFilter();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }
    }
}
