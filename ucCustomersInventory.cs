using Microsoft.Data.SqlClient;
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
        private DataTable customerInventory = new DataTable();
        public ucCustomersInventory()
        {
            InitializeComponent();
        }

        private async void ucCustomersInventory_Load(object sender, EventArgs e)
        {
            await LoadInventoryAsync();
        }

        private async Task LoadInventoryAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=RCALUBAYAN\\SQLEXPRESS;Initial Catalog=PersonalDB;Integrated Security=True;Trust Server Certificate=True"))
                {
                    await conn.OpenAsync(); // Open connection asynchronously

                    string query = "SELECT * FROM customer_inventory_detailed";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader); // Load data into DataTable
                        customerInventory = dt;

                        dgvCustomersInventory.Invoke(() =>
                        {
                            dgvCustomersInventory.DataSource = customerInventory;
                            dgvCustomersInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dgvCustomersInventory.Columns["pressureRange"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvCustomersInventory.Columns["pressureRange"].MinimumWidth = 100;

                            dgvCustomersInventory.Columns["customerInventoryID"].HeaderText = "CustomerID";
                            dgvCustomersInventory.Columns["customerName"].HeaderText = "Name";
                            dgvCustomersInventory.Columns["assignedDate"].HeaderText = "Date of Purchase";
                            dgvCustomersInventory.Columns["assignedQuantity"].HeaderText = "Qty";
                            dgvCustomersInventory.Columns["precisionLevel"].HeaderText = "Precision";
                            dgvCustomersInventory.Columns["material"].HeaderText = "Material";
                            dgvCustomersInventory.Columns["type"].HeaderText = "Type";
                            dgvCustomersInventory.Columns["shapeCode"].HeaderText = "Shape";
                            dgvCustomersInventory.Columns["baseCode"].HeaderText = "B";
                            dgvCustomersInventory.Columns["baseValue"].HeaderText = "BValue";
                            dgvCustomersInventory.Columns["diameter"].HeaderText = "Diameter (mm)";
                            dgvCustomersInventory.Columns["length"].HeaderText = "Length (mm)";
                            dgvCustomersInventory.Columns["pressureRange"].HeaderText = "P";
                            dgvCustomersInventory.Columns["pressureMax"].HeaderText = "P·Kmax";
                            dgvCustomersInventory.Columns["pressureMin"].HeaderText = "P·Kmin";
                            dgvCustomersInventory.Columns["radiusTolerance"].HeaderText = "R";
                            dgvCustomersInventory.Columns["height"].HeaderText = "H";
                            dgvCustomersInventory.Columns["notes"].HeaderText = "Notes";
                            dgvCustomersInventory.Columns["inventoryID"].HeaderText = "InventoryID";
                            dgvCustomersInventory.Columns["cost"].HeaderText = "Cost";
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load inventory: " + ex.Message);
            }
        }

       
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
