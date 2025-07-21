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

        }

        private void ucViewInventory_Load(object sender, EventArgs e)
        {
            LoadInventory();
            LoadFilterValues("precisionLevel", cbPrecision);
            LoadFilterValues("material", cbMaterial);
            LoadFilterValues("type", cbType);
            LoadFilterValues("shapeCode", cbShape);
            LoadFilterValues("baseCode", cbBase);
            LoadFilterValues("baseValue", cbBaseValue);
        }

        private void LoadInventory()
        {
            lblLoading.Visible = true;

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=RCALUBAYAN\\SQLEXPRESS;Initial Catalog=PersonalDB;Integrated Security=True;Trust Server Certificate=True"))
                {
                    conn.Open();

                    string query = "SELECT materialID, precisionLevel, material, type, shapeCode, baseCode, baseValue, diameter, length, pressureMax, pressureMin, radiusTolerance, height, quantity, cost FROM inventory";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        inventoryTable = dt;

                        dtgInventory.DataSource = inventoryTable;
                        dtgInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        /*dtgInventory.Columns["pressureRange"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dtgInventory.Columns["pressureRange"].MinimumWidth = 100;*/

                        dtgInventory.Columns["materialID"].HeaderText = "ID";
                        dtgInventory.Columns["precisionLevel"].HeaderText = "Precision";
                        dtgInventory.Columns["material"].HeaderText = "Material";
                        dtgInventory.Columns["type"].HeaderText = "Type";
                        dtgInventory.Columns["shapeCode"].HeaderText = "Shape";
                        dtgInventory.Columns["baseCode"].HeaderText = "B";
                        dtgInventory.Columns["baseValue"].HeaderText = "Bvalue";
                        dtgInventory.Columns["diameter"].HeaderText = "D (mm)";
                        dtgInventory.Columns["length"].HeaderText = "L (mm)";
                        // dtgInventory.Columns["pressureRange"].HeaderText = "P Range";
                        dtgInventory.Columns["pressureMax"].HeaderText = "P·Max";
                        dtgInventory.Columns["pressureMin"].HeaderText = "P·Min";
                        dtgInventory.Columns["radiusTolerance"].HeaderText = "R";
                        dtgInventory.Columns["height"].HeaderText = "H";
                        dtgInventory.Columns["quantity"].HeaderText = "Qty";
                        dtgInventory.Columns["cost"].HeaderText = "Cost";
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

        private void LoadFilterValues(string columnName, ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("");

            string query = $"SELECT DISTINCT {columnName} FROM inventory WHERE {columnName} IS NOT NULL";

            using (SqlConnection conn = new SqlConnection("Data Source=RCALUBAYAN\\SQLEXPRESS;Initial Catalog=PersonalDB;Integrated Security=True;Trust Server Certificate=True"))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load values for {columnName}: " + ex.Message);
                }
            }
        }

        private void ApplyUniversalFilter()
        {
            var view = (dtgInventory.DataSource as DataTable)?.DefaultView;
            if (view == null) return;

            List<string> conditions = new List<string>();

            if (!string.IsNullOrWhiteSpace(cbPrecision.Text) && cbPrecision.Text != "All")
                conditions.Add($"precisionLevel LIKE '%{cbPrecision.Text.Replace("'", "''")}%'");

            if (!string.IsNullOrWhiteSpace(cbMaterial.Text) && cbMaterial.Text != "All")
                conditions.Add($"material LIKE '%{cbMaterial.Text.Replace("'", "''")}%'");

            if (!string.IsNullOrWhiteSpace(cbType.Text) && cbType.Text != "All")
                conditions.Add($"type LIKE '%{cbType.Text.Replace("'", "''")}%'");

            if (!string.IsNullOrWhiteSpace(cbShape.Text) && cbShape.Text != "All")
                conditions.Add($"shapeCode LIKE '%{cbShape.Text.Replace("'", "''")}%'");

            if (!string.IsNullOrWhiteSpace(cbBase.Text) && cbBase.Text != "All")
                conditions.Add($"baseCode LIKE '%{cbBase.Text.Replace("'", "''")}%'");

            if (!string.IsNullOrWhiteSpace(cbBaseValue.Text) && cbBaseValue.Text != "All")
                conditions.Add($"CONVERT(baseValue, 'System.String') LIKE '%{cbBaseValue.Text.Replace("'", "''")}%'");

            if (decimal.TryParse(txtDiameter.Text.Trim(), out decimal diameterValue))
                conditions.Add($"diameter = {diameterValue}");


            if (decimal.TryParse(txtLength.Text.Trim(), out decimal lengthValue))
                conditions.Add($"length = {lengthValue}");


            string filter = string.Join(" AND ", conditions);
            view.RowFilter = filter;

            var filteredTable = view.ToTable();
        }




        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNext.Enabled = dtgInventory.CurrentRow != null && !dtgInventory.CurrentRow.IsNewRow;
        }

        private decimal GetDecimalValue(object value)
        {
            return value != null ? Convert.ToDecimal(value) : 0.00M;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dtgInventory.CurrentRow != null && !dtgInventory.CurrentRow.IsNewRow)
            {
                try
                {
                    var item = new InventoryItem
                    {
                        MaterialID = Convert.ToInt32(dtgInventory.CurrentRow.Cells["materialID"].Value),
                        PrecisionLevel = dtgInventory.CurrentRow.Cells["precisionLevel"].Value?.ToString(),
                        Material = dtgInventory.CurrentRow.Cells["material"].Value?.ToString(),
                        Type = dtgInventory.CurrentRow.Cells["type"].Value?.ToString(),
                        ShapeCode = Convert.ToChar(dtgInventory.CurrentRow.Cells["shapeCode"].Value),
                        BaseCode = Convert.ToChar(dtgInventory.CurrentRow.Cells["baseCode"].Value),
                        BaseValue = GetDecimalValue(dtgInventory.CurrentRow.Cells["baseValue"].Value),
                        Diameter = GetDecimalValue(dtgInventory.CurrentRow.Cells["diameter"].Value),
                        Length = GetDecimalValue(dtgInventory.CurrentRow.Cells["length"].Value),
                        PressureRange = dtgInventory.CurrentRow.Cells["pressureRange"].Value?.ToString() ?? "—",
                        PressureMax = GetDecimalValue(dtgInventory.CurrentRow.Cells["pressureMax"].Value),
                        PressureMin = GetDecimalValue(dtgInventory.CurrentRow.Cells["pressureMin"].Value),
                        RadiusTolerance = GetDecimalValue(dtgInventory.CurrentRow.Cells["radiusTolerance"].Value),
                        Height = GetDecimalValue(dtgInventory.CurrentRow.Cells["height"].Value),
                        Quantity = Convert.ToInt32(dtgInventory.CurrentRow.Cells["quantity"].Value),
                        Cost = GetDecimalValue(dtgInventory.CurrentRow.Cells["cost"].Value)
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
            ApplyUniversalFilter();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbPrecision.SelectedIndex = -1;
            cbMaterial.SelectedIndex = -1;
            cbType.SelectedIndex = -1;
            cbShape.SelectedIndex = -1;
            cbBase.SelectedIndex = -1;
            cbBaseValue.SelectedIndex = -1;

            txtDiameter.Text = "";
            txtLength.Text = "";

            // 🗑 Clear DataGridView filter and show all rows
            var view = (inventoryTable as DataTable)?.DefaultView;
            if (view != null)
            {
                view.RowFilter = ""; // ✅ removes filtering
                dtgInventory.DataSource = view.ToTable(); // refresh the grid
            }
        }
    }
}
