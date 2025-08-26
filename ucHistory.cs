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
    public partial class ucHistory : UserControl
    {
        public ucHistory()
        {
            InitializeComponent();
        }

        private void ucHistory_Load(object sender, EventArgs e)
        {
            LoadLoginHistory();
            LoadInventoryHistory();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLogin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadLoginHistory()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PersonalDB;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT LoginID, adminID, Username, LoginTime, MachineName, IPAddress, Status FROM LoginHistory ORDER BY LoginTime DESC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvLogin.DataSource = dt;

                        dgvLogin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading login history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadInventoryHistory()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PersonalDB;Integrated Security=True;";

            string query = "SELECT HistoryID, inventoryID, adminID, partNumber, type, shapeCode, baseCode, baseValue, diameter, length, pressureRange, pressureMax, pressureMin, radiusTolerance, height, ActionType, QuantityChanged, PreviousQuantity, NewQuantity, CostEach, PerformedBy, MachineName, Timestamp, Remarks FROM InventoryHistory ORDER BY Timestamp DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvInventory.DataSource = dt;
                    }
                }

                dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvInventory.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvInventory.AutoResizeRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory history:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
