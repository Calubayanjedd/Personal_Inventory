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

        public void RefreshInventory()
        {
            LoadInventory();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ucViewInventory_Load(object sender, EventArgs e)
        {
            LoadInventory();
            LoadFilterValues("partNumber", cbPartNumber);
            LoadFilterValues("type", cbType);
            LoadFilterValues("shapeCode", cbShape);
            LoadFilterValues("baseCode", cbBase);
            LoadFilterValues("baseValue", cbBaseValue);
            LoadFilterValues("diameter", cbDiameter);
            LoadFilterValues("length", cbLength);
            LoadFilterValues("pressureRange", cbPRange);
        }

        private void LoadInventory()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PersonalDB;Integrated Security=True;"))
                {
                    conn.Open();

                    string query = "SELECT inventoryID, partNumber, type, shapeCode, baseCode, baseValue, diameter, length, pressureRange ,pressureMax, pressureMin, radiusTolerance, height, quantity, cost FROM inventory;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        inventoryTable = dt;

                        dtgInventory.DataSource = inventoryTable;
                        dtgInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dtgInventory.Columns["inventoryID"].Visible = false;
                        dtgInventory.Columns["partNumber"].MinimumWidth = 150;
                        //dtgInventory.Columns["dimension"].MinimumWidth = 200;

                        dtgInventory.Columns["partNumber"].HeaderText = "Part Number";
                        dtgInventory.Columns["inventoryID"].HeaderText = "ID";
                        dtgInventory.Columns["type"].HeaderText = "Type";
                        dtgInventory.Columns["shapeCode"].HeaderText = "Shape";
                        dtgInventory.Columns["baseCode"].HeaderText = "B";
                        dtgInventory.Columns["baseValue"].HeaderText = "B";
                        dtgInventory.Columns["diameter"].HeaderText = "D";
                        dtgInventory.Columns["length"].HeaderText = "L";
                        dtgInventory.Columns["pressureRange"].HeaderText = "P";
                        //dtgInventory.Columns["dimension"].HeaderText = "Dimension";
                        dtgInventory.Columns["pressureMax"].HeaderText = "P·Kmax";
                        dtgInventory.Columns["pressureMin"].HeaderText = "W";
                        dtgInventory.Columns["radiusTolerance"].HeaderText = "R";
                        dtgInventory.Columns["height"].HeaderText = "H";
                        dtgInventory.Columns["quantity"].HeaderText = "Qty";
                        dtgInventory.Columns["cost"].HeaderText = "Cost";

                        string[] hiddenColumns = { "inventoryID", "height", "pressureMax", "baseCode" };
                        foreach (string col in hiddenColumns)
                        {
                            if (dtgInventory.Columns.Contains(col))
                                dtgInventory.Columns[col].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load inventory: " + ex.Message);
            }
        }

        private void LoadFilterValues(string columnName, ComboBox comboBox)
        {
            try
            {
                comboBox.Items.Clear();
                comboBox.Items.Add("");

                string query = $"SELECT DISTINCT {columnName} FROM inventory WHERE {columnName} IS NOT NULL";

                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PersonalDB;Integrated Security=True;"))
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
            catch (Exception ex)
            {
                MessageBox.Show("Error loading filter values: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyUniversalFilter()
        {
            try
            {
                var view = (dtgInventory.DataSource as DataTable)?.DefaultView;
                if (view == null) return;

                List<string> conditions = new();

                if (!string.IsNullOrWhiteSpace(cbPartNumber.Text) && cbPartNumber.Text != "All")
                    conditions.Add($"partNumber LIKE '%{cbPartNumber.Text.Replace("'", "''")}%'");

                if (!string.IsNullOrWhiteSpace(cbType.Text) && cbType.Text != "All")
                    conditions.Add($"type LIKE '%{cbType.Text.Replace("'", "''")}%'");

                if (!string.IsNullOrWhiteSpace(cbShape.Text) && cbShape.Text != "All")
                    conditions.Add($"shapeCode LIKE '%{cbShape.Text.Replace("'", "''")}%'");

                if (!string.IsNullOrWhiteSpace(cbBase.Text) && cbBase.Text != "All")
                    conditions.Add($"baseCode LIKE '%{cbBase.Text.Replace("'", "''")}%'");

                if (!string.IsNullOrWhiteSpace(cbBaseValue.Text) && cbBaseValue.Text != "All")
                    conditions.Add($"CONVERT(baseValue, 'System.String') LIKE '%{cbBaseValue.Text.Replace("'", "''")}%'");

                if (!string.IsNullOrWhiteSpace(cbDiameter.Text) && cbDiameter.Text != "All")
                    conditions.Add($"CONVERT(diameter, 'System.String') LIKE '%{cbDiameter.Text.Replace("'", "''")}%'");

                if (!string.IsNullOrWhiteSpace(cbLength.Text) && cbLength.Text != "All")
                    conditions.Add($"CONVERT(length, 'System.String') LIKE '%{cbLength.Text.Replace("'", "''")}%'");

                if (!string.IsNullOrWhiteSpace(cbPRange.Text) && cbPRange.Text != "All")
                    conditions.Add($"pressureRange LIKE '%{cbPRange.Text.Replace("'", "''")}%'");

                string filter = string.Join(" AND ", conditions);
                view.RowFilter = filter;

                var filteredTable = view.ToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying filter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        MaterialID = Convert.ToInt32(dtgInventory.CurrentRow.Cells["inventoryID"].Value),
                        PartNumber = dtgInventory.CurrentRow.Cells["partNumber"].Value?.ToString() ?? "—",
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

                    AssigningCustomer assignForm = new AssigningCustomer(item, RefreshInventory);
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
            try
            {
                cbPartNumber.SelectedIndex = -1;
                cbType.SelectedIndex = -1;
                cbShape.SelectedIndex = -1;
                cbBase.SelectedIndex = -1;
                cbBaseValue.SelectedIndex = -1;
                cbDiameter.SelectedIndex = -1;
                cbLength.SelectedIndex = -1;
                cbPRange.SelectedIndex = -1;

                var view = (inventoryTable as DataTable)?.DefaultView;
                if (view != null)
                {
                    view.RowFilter = "";
                    dtgInventory.DataSource = view.ToTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing filters: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbDiameter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbLength_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbPRange_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dtgInventory.CurrentRow != null && !dtgInventory.CurrentRow.IsNewRow)
            {
                try
                {
                    var item = new InventoryItem
                    {
                        MaterialID = Convert.ToInt32(dtgInventory.CurrentRow.Cells["inventoryID"].Value),
                        PartNumber = dtgInventory.CurrentRow.Cells["partNumber"].Value?.ToString() ?? "—",
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

                    UpdateForm uf = new UpdateForm(item, RefreshInventory);
                    uf.ShowDialog();

                    // Option 2: Create a separate UpdateInventoryItem form if needed
                    // UpdateInventoryItem updateForm = new UpdateInventoryItem(item, RefreshInventory);
                    // updateForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load selected item for update: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
