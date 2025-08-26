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
using System.Runtime.InteropServices;

namespace Personal_Inventory_for_Juntec
{
    public partial class AssigningCustomer : Form
    {
        private InventoryItem item;
        private readonly Action onDone;
        public AssigningCustomer(InventoryItem item, Action onDone)
        {
            InitializeComponent();

            this.item = item;

            LoadItemData();
            this.onDone = onDone;

            EnableFormDrag(this);
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        private void EnableFormDrag(Control control)
        {
            control.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            };
        }

        private void LoadItemData()
        {
            lblpartNumber.Text = item.PartNumber.ToString();
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

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PersonalDB;Integrated Security=True;"))
            {
                string query = "SELECT customerName FROM customer";

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string fullName = $"{reader["customerName"]}";
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

            decimal costValue;

            if (!string.IsNullOrWhiteSpace(txtNewCost.Text) &&
                decimal.TryParse(txtNewCost.Text.Replace("₱", "").Replace(",", "").Trim(), out decimal txtnewCost))
            {
                costValue = txtnewCost;
            }
            else if (decimal.TryParse(lblCost.Text.Replace("₱", "").Replace(",", "").Trim(), out decimal originalCost))
            {
                costValue = originalCost;
            }
            else
            {
                MessageBox.Show("Invalid cost format.");
                return;
            }

            string name = comboBox1.SelectedItem.ToString().Trim();
            int inventoryId = item.MaterialID;

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PersonalDB;Integrated Security=True;"))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    SqlCommand getCustomerIdCmd = new SqlCommand("SELECT customerTypeID FROM customer WHERE customerName = @customerName", conn, transaction);
                    getCustomerIdCmd.Parameters.AddWithValue("@customerName", name);
                    object result = getCustomerIdCmd.ExecuteScalar();

                    if (result == null)
                        throw new Exception("Customer not found.");

                    int customerId = Convert.ToInt32(result);

                    SqlCommand getStockCmd = new SqlCommand("SELECT quantity FROM inventory WHERE inventoryID = @id", conn, transaction);
                    getStockCmd.Parameters.AddWithValue("@id", inventoryId);
                    int currentStock = Convert.ToInt32(getStockCmd.ExecuteScalar());

                    if (requestedQty > currentStock)
                        throw new Exception("Not enough stock available.");

                    SqlCommand updateStockCmd = new SqlCommand("UPDATE inventory SET quantity = quantity - @qty WHERE inventoryID = @id", conn, transaction);
                    updateStockCmd.Parameters.AddWithValue("@qty", requestedQty);
                    updateStockCmd.Parameters.AddWithValue("@id", inventoryId);
                    updateStockCmd.ExecuteNonQuery();

                    SqlCommand historyCmd = new SqlCommand("INSERT INTO InventoryHistory (inventoryID, adminID, partNumber, type, shapeCode, baseCode, baseValue, diameter, length, pressureRange, pressureMax, pressureMin, radiusTolerance, height, ActionType, QuantityChanged, PreviousQuantity, NewQuantity, CostEach, PerformedBy, MachineName, Remarks) VALUES ( @inventoryID, @adminID, @partNumber, @type, @shapeCode, @baseCode, @baseValue, @diameter, @length, @pressureRange, @pressureMax, @pressureMin, @radiusTolerance, @height, @ActionType, @QuantityChanged, @PreviousQuantity, @NewQuantity, @CostEach, @PerformedBy, @MachineName, @Remarks)", conn, transaction);

                    historyCmd.Parameters.AddWithValue("@inventoryID", item.MaterialID);
                    historyCmd.Parameters.AddWithValue("@adminID", Session.AdminID);
                    historyCmd.Parameters.AddWithValue("@partNumber", item.PartNumber);
                    historyCmd.Parameters.AddWithValue("@type", item.Type);
                    historyCmd.Parameters.AddWithValue("@shapeCode", item.ShapeCode);
                    historyCmd.Parameters.AddWithValue("@baseCode", item.BaseCode);
                    historyCmd.Parameters.AddWithValue("@baseValue", item.BaseValue);
                    historyCmd.Parameters.AddWithValue("@diameter", item.Diameter);
                    historyCmd.Parameters.AddWithValue("@length", item.Length);
                    historyCmd.Parameters.AddWithValue("@pressureRange", item.PressureRange);
                    historyCmd.Parameters.AddWithValue("@pressureMax", item.PressureMax);
                    historyCmd.Parameters.AddWithValue("@pressureMin", item.PressureMin);
                    historyCmd.Parameters.AddWithValue("@radiusTolerance", item.RadiusTolerance);
                    historyCmd.Parameters.AddWithValue("@height", item.Height);
                    historyCmd.Parameters.AddWithValue("@ActionType", "Assigned to Customer - " + comboBox1.SelectedItem.ToString());
                    historyCmd.Parameters.AddWithValue("@QuantityChanged", -requestedQty);
                    historyCmd.Parameters.AddWithValue("@PreviousQuantity", item.Quantity);
                    historyCmd.Parameters.AddWithValue("@NewQuantity", item.Quantity - requestedQty);
                    historyCmd.Parameters.AddWithValue("@CostEach", item.Cost);
                    historyCmd.Parameters.AddWithValue("@performedBy", Environment.UserName);
                    historyCmd.Parameters.AddWithValue("@MachineName", Environment.MachineName);
                    historyCmd.Parameters.AddWithValue("@Remarks", "Assigned from AssigningCustomer form.");
                    historyCmd.Parameters.AddWithValue("@actionDate", DateTime.Now);

                    historyCmd.ExecuteNonQuery(); // Log to InventoryHistory

                    SqlCommand insertCmd = new SqlCommand("INSERT INTO customer_inventory_detailed ( inventoryID, customerTypeID, customerName, partNumber, type, shapeCode, baseCode, baseValue, diameter, length, pressureRange, pressureMax, pressureMin, radiusTolerance, height, quantity, cost) VALUES ( @inventoryID, @customerTypeID, @customerName, @partNumber, @type, @shapeCode, @baseCode, @baseValue, @diameter, @length, @pressureRange, @pressureMax, @pressureMin, @radiusTolerance, @height, @quantity, @cost)", conn, transaction);

                    insertCmd.Parameters.AddWithValue("@inventoryID", inventoryId);
                    insertCmd.Parameters.AddWithValue("@customerTypeID", customerId);
                    insertCmd.Parameters.AddWithValue("@customerName", comboBox1.SelectedItem.ToString());
                    insertCmd.Parameters.AddWithValue("@partNumber", item.PartNumber);
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
                    insertCmd.Parameters.AddWithValue("@quantity", requestedQty);
                    insertCmd.Parameters.AddWithValue("@cost", costValue * requestedQty);

                    insertCmd.ExecuteNonQuery();
                    transaction.Commit();
                    

                    MessageBox.Show("Item successfully set in Customer's Inventory.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    onDone?.Invoke();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
