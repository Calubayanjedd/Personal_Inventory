using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Personal_Inventory_for_Juntec
{
    public partial class ucViewInventory : UserControl
    {
        private DataTable inventoryTable = new DataTable();

        public ucViewInventory()
        {
            InitializeComponent();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ApplyFilter();
        }

        private async void ucViewInventory_Load(object sender, EventArgs e)
        {
            await LoadInventoryAsync();
            LoadItemTypes();
        }

        private async Task LoadInventoryAsync()
        {
            lblLoading.Visible = true;

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=RCALUBAYAN\\SQLEXPRESS;Initial Catalog=PersonalDB;Integrated Security=True;Trust Server Certificate=True"))
                {
                    await conn.OpenAsync(); // Open connection asynchronously

                    string query = "SELECT * FROM inventory";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader); // Load data into DataTable
                        inventoryTable = dt;

                        dtgInventory.Invoke(() =>
                        {
                            dtgInventory.DataSource = inventoryTable;
                            dtgInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load inventory: " + ex.Message);
            }
            finally
            {
                lblLoading.Visible = false;
            }
        }

        private void LoadItemTypes()
        {
            cbType.Items.Clear();
            cbType.Items.Add(""); // Optional: empty item for "All"


            using (SqlConnection conn = new SqlConnection("Data Source=RCALUBAYAN\\SQLEXPRESS;Initial Catalog=PersonalDB;Integrated Security=True;Trust Server Certificate=True"))
            {
                string query = "SELECT DISTINCT item_type FROM inventory WHERE item_type IS NOT NULL";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cbType.Items.Add(reader["item_type"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load types: " + ex.Message);
                }
            }
        }

        private void ApplyFilter()
        {
            string search = txtSearch.Text.Trim().ToLower().Replace("'", "''");
            string type = cbType.Text.Trim().ToLower().Replace("'", "''");

            // Start filter with search
            string filter = $"item_name LIKE '%{search}%'";

            // Add type filter if selected
            if (!string.IsNullOrWhiteSpace(type))
            {
                filter += $" AND item_type = '{type}'";
            }

            (dtgInventory.DataSource as DataTable).DefaultView.RowFilter = filter;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //ApplyFilter();
        }

        private void dtgInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNext.Enabled = dtgInventory.CurrentRow != null && !dtgInventory.CurrentRow.IsNewRow;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dtgInventory.CurrentRow != null && !dtgInventory.CurrentRow.IsNewRow)
            {
                try
                {
                    var item = new InventoryItem
                    {
                        ItemId = dtgInventory.CurrentRow.Cells["id"].Value?.ToString(),
                        ItemName = dtgInventory.CurrentRow.Cells["item_name"].Value?.ToString(),
                        ItemType = dtgInventory.CurrentRow.Cells["item_type"].Value?.ToString(),
                        ItemSize = dtgInventory.CurrentRow.Cells["item_size"].Value?.ToString(),
                        ItemCost = dtgInventory.CurrentRow.Cells["item_cost"].Value?.ToString()
                    };

                    AssigningCustomer assignForm = new AssigningCustomer(item);
                    assignForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid row from the table.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }
    }
}
