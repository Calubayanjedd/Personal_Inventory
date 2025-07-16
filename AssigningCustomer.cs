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
            lblItemID.Text = item.ItemId;
            lblItemName.Text = item.ItemName;
            lblItemType.Text = item.ItemType;
            lblItemSize.Text = item.ItemSize;
            lblItemCost.Text = item.ItemCost;
        }

        private void AssigningCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadCustomers()
        {
            comboBox1.Items.Clear(); // Clear existing items

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

        }
    }
}
