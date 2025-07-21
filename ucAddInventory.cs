using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_Inventory_for_Juntec
{
    public partial class ucAddInventory : UserControl
    {
        public ucAddInventory()
        {
            InitializeComponent();
        }

        private void ucAddInventory_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtPressureMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPressureMin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRadius_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {

        }
        private void ClearInventoryFields()
        {
            txtPrecision.Text = "";
            txtMaterial.Text = "";
            txtType.Text = "";
            txtShape.Text = "";
            txtBaseType.Text = "";
            txtBaseValue.Text = "";
            txtDiameter.Text = "";
            txtLength.Text = "";
            txtPressureRange.Text = "";
            txtPressureMax.Text = "";
            txtPressureMin.Text = "";
            txtRadius.Text = "";
            txtHeight.Text = "";
            txtQuantity.Text = "";
            txtCost.Text = "";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPrecision.Text) ||
                    string.IsNullOrWhiteSpace(txtMaterial.Text) ||
                    string.IsNullOrWhiteSpace(txtType.Text) ||
                    string.IsNullOrWhiteSpace(txtShape.Text) ||
                    string.IsNullOrWhiteSpace(txtBaseType.Text) ||
                    string.IsNullOrWhiteSpace(txtBaseValue.Text) ||
                    string.IsNullOrWhiteSpace(txtDiameter.Text) ||
                    string.IsNullOrWhiteSpace(txtLength.Text) ||
                    string.IsNullOrWhiteSpace(txtPressureRange.Text) ||
                    string.IsNullOrWhiteSpace(txtPressureMax.Text) ||
                    string.IsNullOrWhiteSpace(txtPressureMin.Text) ||
                    string.IsNullOrWhiteSpace(txtRadius.Text) ||
                    string.IsNullOrWhiteSpace(txtHeight.Text) ||
                    string.IsNullOrWhiteSpace(txtQuantity.Text))
                {
                    MessageBox.Show("Please complete all required fields before registering.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal.TryParse(txtBaseValue.Text, out var bv);
                decimal.TryParse(txtDiameter.Text, out var d);
                decimal.TryParse(txtLength.Text, out var l);
                decimal.TryParse(txtPressureMax.Text, out var pMax);
                decimal.TryParse(txtPressureMin.Text, out var pMin);
                decimal.TryParse(txtRadius.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out var r);
                decimal.TryParse(txtHeight.Text, out var h);
                int.TryParse(txtQuantity.Text, out var qty);
                decimal.TryParse(txtCost.Text, NumberStyles.Currency, new CultureInfo("en-PH"), out var c);

                if (c > 99999999.99m)
                {
                    MessageBox.Show("Cost exceeds allowed limit. Please enter a smaller amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (r > 99999999.99m)
                {
                    MessageBox.Show("Radius tolerance exceeds allowed limit (max 99,999,999.99).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (qty < 0 || c < 0 || l < 0 || pMax < 0 || pMin < 0 || h < 0 || bv < 0)
                {
                    MessageBox.Show("Numeric fields cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection("Data Source=RCALUBAYAN\\SQLEXPRESS;Initial Catalog=PersonalDB;Integrated Security=True;Trust Server Certificate=True"))
                {
                    conn.Open();

                    string query = @"
                INSERT INTO inventory (
                precisionLevel, material, type, shapeCode, baseCode,
                baseValue, diameter, length,
                pressureRange, pressureMax, pressureMin,
                radiusTolerance, height, quantity, cost, notes)
                VALUES (
                @precisionLevel, @material, @type, @shapeCode, @baseCode,
                @baseValue, @diameter, @length,
                @pressureRange, @pressureMax, @pressureMin,
                @radiusTolerance, @height, @quantity, @cost, @notes)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@precisionLevel", txtPrecision.Text.Trim());
                        cmd.Parameters.AddWithValue("@material", txtMaterial.Text.Trim());
                        cmd.Parameters.AddWithValue("@type", txtType.Text.Trim());
                        cmd.Parameters.AddWithValue("@shapeCode", txtShape.Text.Trim());
                        cmd.Parameters.AddWithValue("@baseCode", txtBaseType.Text.Trim());
                        cmd.Parameters.AddWithValue("@baseValue", bv);
                        cmd.Parameters.AddWithValue("@diameter", d);
                        cmd.Parameters.AddWithValue("@length", l);
                        cmd.Parameters.AddWithValue("@pressureRange", txtPressureRange.Text.Trim());
                        cmd.Parameters.AddWithValue("@pressureMax", pMax);
                        cmd.Parameters.AddWithValue("@pressureMin", pMin);
                        cmd.Parameters.AddWithValue("@radiusTolerance", r);
                        cmd.Parameters.AddWithValue("@height", h);
                        cmd.Parameters.AddWithValue("@quantity", qty);
                        cmd.Parameters.AddWithValue("@cost", c);
                        cmd.Parameters.AddWithValue("@notes", txtNote.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Inventory successfully registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInventoryFields();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Error: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInventoryFields();
        }
    }
}
