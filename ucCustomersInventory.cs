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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Personal_Inventory_for_Juntec
{
    public partial class ucCustomersInventory : UserControl
    {
        private DataTable customerInventory = new DataTable();
        public ucCustomersInventory()
        {
            InitializeComponent();
        }

        private void ucCustomersInventory_Load(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void LoadInventory()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PersonalDB;Integrated Security=True;"))
                {
                    conn.Open();

                    string query = "SELECT customerTypeID, customerName, partNumber, (CAST(type AS VARCHAR) + CAST(shapeCode AS VARCHAR) + CAST(baseCode AS VARCHAR) + CAST(baseValue AS VARCHAR) + '-' + CAST(diameter AS VARCHAR) + '-' + CAST(pressureRange AS VARCHAR)) AS B, quantity, cost FROM customer_inventory_detailed";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        customerInventory = dt;

                        dgvCustomersInventory.Invoke(() =>
                        {
                            dgvCustomersInventory.DataSource = customerInventory;
                            dgvCustomersInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            //dgvCustomersInventory.Columns["pressureRange"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            //dgvCustomersInventory.Columns["pressureRange"].MinimumWidth = 100;
                            //dgvCustomersInventory.Columns["material"].Visible = false;
                            //dgvCustomersInventory.Columns["type"].Visible = false;
                            //dgvCustomersInventory.Columns["baseCode"].Visible = false;
                            //dgvCustomersInventory.Columns["shapeCode"].Visible = false;
                            //dgvCustomersInventory.Columns["pressureRange"].Visible = false;
                            //dgvCustomersInventory.Columns["inventoryID"].Visible = false;
                            //dgvCustomersInventory.Columns["customerInventoryID"].Visible = false;


                            dgvCustomersInventory.Columns["B"].HeaderText = "Dimension";
                            dgvCustomersInventory.Columns["B"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            dgvCustomersInventory.Columns["B"].MinimumWidth = 150;
                            dgvCustomersInventory.Columns["customerName"].MinimumWidth = 150;
                            //dgvCustomersInventory.Columns["precisionLevel"].Visible = false;
                            dgvCustomersInventory.Columns["customerTypeID"].Visible = false;
                            dgvCustomersInventory.Columns["customerTypeID"].HeaderText = "ID";
                            dgvCustomersInventory.Columns["customerName"].HeaderText = "Customer Name";
                            dgvCustomersInventory.Columns["partNumber"].HeaderText = "Part Number";
                            dgvCustomersInventory.Columns["quantity"].HeaderText = "Qty";
                            //dgvCustomersInventory.Columns["precisionLevel"].HeaderText = "Precision";
                            //dgvCustomersInventory.Columns["material"].HeaderText = "Material";
                            //dgvCustomersInventory.Columns["type"].HeaderText = "Type";
                            //dgvCustomersInventory.Columns["shapeCode"].HeaderText = "Shape";
                            //dgvCustomersInventory.Columns["baseCode"].HeaderText = "B";
                            //dgvCustomersInventory.Columns["baseValue"].HeaderText = "BValue";
                            //dgvCustomersInventory.Columns["diameter"].HeaderText = "Diameter (mm)";
                            //dgvCustomersInventory.Columns["length"].HeaderText = "Length (mm)";
                            //dgvCustomersInventory.Columns["pressureRange"].HeaderText = "P";
                            //dgvCustomersInventory.Columns["pressureMax"].HeaderText = "P·Kmax";
                            //dgvCustomersInventory.Columns["pressureMin"].HeaderText = "P·Wmin";
                            //dgvCustomersInventory.Columns["radiusTolerance"].HeaderText = "R";
                            //dgvCustomersInventory.Columns["height"].HeaderText = "H";
                            //dgvCustomersInventory.Columns["inventoryID"].HeaderText = "InventoryID";
                            dgvCustomersInventory.Columns["cost"].HeaderText = "Cost";
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load Customer inventory: " + ex.Message);
            }
        }

        private void ApplyFilter()
        {
            try
            {
                string filterText = txtSearch.Text.Trim();

                using (SqlConnection conn = new SqlConnection("Data Source=RCALUBAYAN\\SQLEXPRESS;Initial Catalog=PersonalDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"))
                {
                    conn.Open();

                    string query = @"SELECT customerTypeID, customerName, partNumber, (CAST(type AS VARCHAR) + CAST(shapeCode AS VARCHAR) + CAST(baseCode AS VARCHAR) + CAST(baseValue AS VARCHAR) + '-' + CAST(diameter AS VARCHAR) + '-' + CAST(pressureRange AS VARCHAR)) AS B, quantity, cost FROM customer_inventory_detailed WHERE customerName LIKE @filter";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@filter", "%" + filterText + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvCustomersInventory.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying filter: " + ex.Message);
            }
        }

        private void LoadAllCustomers()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=RCALUBAYAN\\SQLEXPRESS;Initial Catalog=PersonalDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"))
            {
                conn.Open();
                string query = @"SELECT customerTypeID, customerName, partNumber, (CAST(type AS VARCHAR) + CAST(shapeCode AS VARCHAR) + CAST(baseCode AS VARCHAR) + CAST(baseValue AS VARCHAR) + '-' + CAST(diameter AS VARCHAR) + '-' + CAST(pressureRange AS VARCHAR)) AS B, quantity, cost FROM customer_inventory_detailed";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCustomersInventory.DataSource = dt;
                }
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadAllCustomers();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvCustomersInventory.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Save Excel File"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Customer Data");

                        int colIndex = 1;
                        for (int i = 0; i < dgvCustomersInventory.Columns.Count; i++)
                        {
                            if (dgvCustomersInventory.Columns[i].HeaderText.ToLower() == "id") continue;

                            worksheet.Cell(1, colIndex).Value = dgvCustomersInventory.Columns[i].HeaderText;
                            colIndex++;
                        }

                        for (int i = 0; i < dgvCustomersInventory.Rows.Count; i++)
                        {
                            if (dgvCustomersInventory.Rows[i].IsNewRow) continue;

                            int dataColIndex = 1;
                            for (int j = 0; j < dgvCustomersInventory.Columns.Count; j++)
                            {
                                if (dgvCustomersInventory.Columns[j].HeaderText.ToLower() == "id") continue;

                                worksheet.Cell(i + 2, dataColIndex).Value = dgvCustomersInventory.Rows[i].Cells[j].Value?.ToString();
                                dataColIndex++;
                            }
                        }

                        worksheet.Columns().AdjustToContents();
                        MessageBox.Show("Export successful!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        workbook.SaveAs(sfd.FileName);
                    }
                }
            }
        }
    }
}
