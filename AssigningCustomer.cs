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
using System.Globalization;

namespace Personal_Inventory_for_Juntec
{
    public partial class AssigningCustomer : Form
    {
        private InventoryItem item;
        public AssigningCustomer(InventoryItem item)
        {
            InitializeComponent();

            this.item = item;

            LoadItemData();
        }

        private void LoadItemData()
        {
            lblPrecision.Text = item.PrecisionLevel;
            lblMaterial.Text = item.Material;
            lblType.Text = item.Type;
            lblShape.Text = item.ShapeCode.ToString();
            lblBase.Text = item.BaseCode.ToString();
            lblBaseValue.Text = item.BaseValue.ToString("0.00");
            txtDiameter.Text = item.Diameter.ToString("0.00");
            txtLength.Text = item.Length.ToString("0.00");
            lblPressureRange.Text = string.IsNullOrEmpty(item.PressureRange) ? "—" : item.PressureRange;
            lblPressureMax.Text = item.PressureMax.ToString("0.00");
            lblPressureMin.Text = item.PressureMin.ToString("0.00");
            lblRadius.Text = item.RadiusTolerance.ToString("0.000");
            lblHeight.Text = item.Height.ToString("0.00");
            lblCost.Text = item.Cost.ToString("C2", new CultureInfo("en-PH"));
        }

        private void AssigningCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadItemData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadCustomers()
        {
            comboBox1.Items.Clear();

            using (SqlConnection conn = new SqlConnection("Data Source=RCALUBAYAN\\SQLEXPRESS;Initial Catalog=PersonalDB;Integrated Security=True;Trust Server Certificate=True"))
            {
                string query = "SELECT first_name, last_name FROM customer";

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string fullName = $"{reader["first_name"]} {reader["last_name"]}";
                        comboBox1.Items.Add(fullName);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load customers: " + ex.Message);
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantity.Text.Trim(), out int requestedQty) || requestedQty <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error");
                return;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.", "Validation Error");
                return;
            }

            if (!decimal.TryParse(txtDiameter.Text.Trim(), out decimal updatedDiameter) ||
                !decimal.TryParse(txtLength.Text.Trim(), out decimal updatedLength))
            {
                MessageBox.Show("Please enter valid numeric values for diameter and length.", "Validation Error");
                return;
            }

            string[] names = comboBox1.SelectedItem.ToString().Split(' ');
            if (names.Length < 2)
            {
                MessageBox.Show("Invalid customer name format.");
                return;
            }

            string firstName = names[0];
            string lastName = names[1];
            int inventoryId = item.MaterialID;

            using (SqlConnection conn = new SqlConnection("Data Source=RCALUBAYAN\\SQLEXPRESS;Initial Catalog=PersonalDB;Integrated Security=True;Trust Server Certificate=True"))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    SqlCommand getCustomerIdCmd = new SqlCommand("SELECT id FROM customer WHERE first_name = @first AND last_name = @last", conn, transaction);
                    getCustomerIdCmd.Parameters.AddWithValue("@first", firstName);
                    getCustomerIdCmd.Parameters.AddWithValue("@last", lastName);
                    object result = getCustomerIdCmd.ExecuteScalar();

                    if (result == null)
                        throw new Exception("Customer not found.");

                    int customerId = Convert.ToInt32(result);

                    SqlCommand getStockCmd = new SqlCommand("SELECT quantity FROM inventory WHERE materialID = @id", conn, transaction);
                    getStockCmd.Parameters.AddWithValue("@id", inventoryId);
                    int currentStock = Convert.ToInt32(getStockCmd.ExecuteScalar());

                    if (requestedQty > currentStock)
                        throw new Exception("Not enough stock available.");

                    SqlCommand updateStockCmd = new SqlCommand("UPDATE inventory SET quantity = quantity - @qty WHERE materialID = @id", conn, transaction);
                    updateStockCmd.Parameters.AddWithValue("@qty", requestedQty);
                    updateStockCmd.Parameters.AddWithValue("@id", inventoryId);
                    updateStockCmd.ExecuteNonQuery();

                    SqlCommand insertCmd = new SqlCommand(@"INSERT INTO customer_inventory_detailed ( customerName, assignedDate, assignedQuantity,
                     precisionLevel, material, type, shapeCode, baseCode, baseValue,
                     diameter, length, pressureRange, pressureMax, pressureMin,
                     radiusTolerance, height, notes, inventoryID, @cost)
                     VALUES (
                      @customerName, GETDATE(), @assignedQuantity,
                      @precisionLevel, @material, @type, @shapeCode, @baseCode, @baseValue,
                      @diameter, @length, @pressureRange, @pressureMax, @pressureMin,
                      @radiusTolerance, @height, @notes, @inventoryID, @cost)", conn, transaction);


                    insertCmd.Parameters.AddWithValue("@customerName", comboBox1.SelectedItem.ToString());
                    insertCmd.Parameters.AddWithValue("@assignedQuantity", requestedQty);
                    insertCmd.Parameters.AddWithValue("@precisionLevel", item.PrecisionLevel);
                    insertCmd.Parameters.AddWithValue("@material", item.Material);
                    insertCmd.Parameters.AddWithValue("@type", item.Type);
                    insertCmd.Parameters.AddWithValue("@shapeCode", item.ShapeCode);
                    insertCmd.Parameters.AddWithValue("@baseCode", item.BaseCode);
                    insertCmd.Parameters.AddWithValue("@baseValue", item.BaseValue);
                    insertCmd.Parameters.AddWithValue("@diameter", updatedDiameter);
                    insertCmd.Parameters.AddWithValue("@length", updatedLength);
                    insertCmd.Parameters.AddWithValue("@pressureRange", item.PressureRange);
                    insertCmd.Parameters.AddWithValue("@pressureMax", item.PressureMax);
                    insertCmd.Parameters.AddWithValue("@pressureMin", item.PressureMin);
                    insertCmd.Parameters.AddWithValue("@radiusTolerance", item.RadiusTolerance);
                    insertCmd.Parameters.AddWithValue("@height", item.Height);
                    insertCmd.Parameters.AddWithValue("@notes", txtNote.Text);
                    insertCmd.Parameters.AddWithValue("@inventoryID", inventoryId);
                    insertCmd.Parameters.AddWithValue("@cost", txtNewCost.Text);

                    insertCmd.ExecuteNonQuery();
                    transaction.Commit();

                    MessageBox.Show("Item successfully set in Customer's Inventory.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Failed to assign item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
