using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace Personal_Inventory_for_Juntec
{
    public partial class UpdateForm : Form
    {
        private InventoryItem item;
        private readonly Action onDone;
        public UpdateForm(InventoryItem item, Action onDone)
        {
            InitializeComponent();
            this.item = item;
            this.onDone = onDone;
            EnableFormDrag(this);
            LoadItemData();
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Constants
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

        private void UpdateForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadItemData()
        {
            lblPartNumber.Text = item.PartNumber.ToString();
            lblType.Text = item.Type;
            lblShape.Text = item.ShapeCode.ToString();
            lblB.Text = item.BaseValue.ToString("0");
            lblD.Text = item.Diameter.ToString("0.00");
            lblL.Text = item.Length.ToString("0.00");
            lblP.Text = string.IsNullOrEmpty(item.PressureRange) ? "—" : item.PressureRange;
            lblW.Text = item.PressureMin.ToString("0.00");
            lblR.Text = item.RadiusTolerance.ToString("0.000");
            lblCost.Text = item.Cost.ToString("C2", new CultureInfo("en-PH"));
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantity.Text.Trim(), out int addedQty) || addedQty <= 0)
            {
                MessageBox.Show("Please enter a valid quantity to add.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int inventoryId = item.MaterialID;

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PersonalDB;Integrated Security=True;"))
            {
                try
                {
                    conn.Open();

                    // Step 1: Get current quantity
                    int previousQty = 0;
                    SqlCommand getQtyCmd = new SqlCommand("SELECT quantity FROM inventory WHERE inventoryID = @id", conn);
                    getQtyCmd.Parameters.AddWithValue("@id", inventoryId);
                    var result = getQtyCmd.ExecuteScalar();
                    if (result != null)
                    {
                        previousQty = Convert.ToInt32(result);
                    }

                    // Step 2: Update quantity
                    SqlCommand updateCmd = new SqlCommand("UPDATE inventory SET quantity = quantity + @qty WHERE inventoryID = @id", conn);
                    updateCmd.Parameters.AddWithValue("@qty", addedQty);
                    updateCmd.Parameters.AddWithValue("@id", inventoryId);
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        int newQty = previousQty + addedQty;

                        // Step 3: Insert into InventoryHistory (ONE-LINER)
                        SqlCommand historyCmd = new SqlCommand("INSERT INTO InventoryHistory (ItemID, adminID, partNumber, type, shapeCode, baseCode, baseValue, diameter, length, pressureRange, pressureMax, pressureMin, radiusTolerance, height, ActionType, QuantityChanged, PreviousQuantity, NewQuantity, CostEach, PerformedBy, MachineName, Remarks) VALUES (@ItemID, @AdminID, @PartNumber, @Type, @ShapeCode, @BaseCode, @BaseValue, @Diameter, @Length, @PressureRange, @PressureMax, @PressureMin, @RadiusTolerance, @Height, @ActionType, @QuantityChanged, @PreviousQuantity, @NewQuantity, @CostEach, @PerformedBy, @MachineName, @Remarks)", conn);

                        historyCmd.Parameters.AddWithValue("@ItemID", item.MaterialID);
                        historyCmd.Parameters.AddWithValue("@AdminID", Session.AdminID); // Make sure this variable is defined appropriately
                        historyCmd.Parameters.AddWithValue("@PartNumber", item.PartNumber ?? (object)DBNull.Value);
                        historyCmd.Parameters.AddWithValue("@Type", item.Type ?? (object)DBNull.Value);
                        historyCmd.Parameters.AddWithValue("@ShapeCode", item.ShapeCode);
                        historyCmd.Parameters.AddWithValue("@BaseCode", item.BaseCode);
                        historyCmd.Parameters.AddWithValue("@BaseValue", item.BaseValue);
                        historyCmd.Parameters.AddWithValue("@Diameter", item.Diameter);
                        historyCmd.Parameters.AddWithValue("@Length", item.Length);
                        historyCmd.Parameters.AddWithValue("@PressureRange", item.PressureRange ?? (object)DBNull.Value);
                        historyCmd.Parameters.AddWithValue("@PressureMax", item.PressureMax);
                        historyCmd.Parameters.AddWithValue("@PressureMin", item.PressureMin);
                        historyCmd.Parameters.AddWithValue("@RadiusTolerance", item.RadiusTolerance);
                        historyCmd.Parameters.AddWithValue("@Height", item.Height);
                        historyCmd.Parameters.AddWithValue("@ActionType", "Added");
                        historyCmd.Parameters.AddWithValue("@QuantityChanged", addedQty);
                        historyCmd.Parameters.AddWithValue("@PreviousQuantity", previousQty);
                        historyCmd.Parameters.AddWithValue("@NewQuantity", newQty);
                        historyCmd.Parameters.AddWithValue("@CostEach", item.Cost);
                        historyCmd.Parameters.AddWithValue("@PerformedBy", Environment.UserName);
                        historyCmd.Parameters.AddWithValue("@MachineName", Environment.MachineName); // Added missing param
                        historyCmd.Parameters.AddWithValue("@Remarks", "Added via UpdateForm");

                        historyCmd.ExecuteNonQuery();

                        // Show success
                        MessageBox.Show("Quantity successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        onDone?.Invoke();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Item not found or update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating quantity: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
