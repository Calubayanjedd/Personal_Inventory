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

namespace Personal_Inventory_for_Juntec
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            inventorySubpanel.Visible = false;
            customerSubpanel.Visible = false;
            EnableFormDrag(this);
            EnableFormDrag(mainPanel);
            EnableFormDrag(navPanel);
            EnableFormDrag(topPanel);
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

        private bool isCollapsed = false;

        private void button1_Click(object sender, EventArgs e)
        {
            CollapseAllSubpanels();
            if (isCollapsed)
            {
                navPanel.Width = 250;
                btnDashboard.Text = "🏠︎ Dashboard";
                btnInventory.Text = "📦 Inventory";
                btnViewInventory.Text = "🔍︎📋 View Inventory";
                btnAddInventory.Text = "➕📦 Add Inventory";
                btnCustomer.Text = "👤 Customer";
                btnViewCustomer.Text = "🔍︎👤 View Customer";
                btnAddCustomer.Text = "➕👤 Add Customer";
                btnReports.Text = "📢 Reports";
                btnLogout.Text = "✖ Logout";
                isCollapsed = false;
            }
            else
            {
                navPanel.Width = 75;
                btnDashboard.Text = "🏠︎";
                btnInventory.Text = "📦";
                btnViewInventory.Text = "🔍︎📋";
                btnAddInventory.Text = "➕📦";
                btnCustomer.Text = "👤";
                btnViewCustomer.Text = "🔍︎👤";
                btnAddCustomer.Text = "➕👤";
                btnReports.Text = "📢";
                btnLogout.Text = "✖";
                isCollapsed = true;
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            CollapseAllSubpanels();
            inventorySubpanel.Visible = !inventorySubpanel.Visible;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CollapseAllSubpanels();
            customerSubpanel.Visible = !customerSubpanel.Visible;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }
        }

        private void LoadUserControl(UserControl uc)
        {
            mainPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(uc);
        }

        private void CollapseAllSubpanels()
        {
            inventorySubpanel.Visible = false;
            customerSubpanel.Visible = false;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            CollapseAllSubpanels();
            LoadUserControl(new ucDashboard());
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucAddInventory());
        }

        private void btnViewInventory_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucViewInventory());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadUserControl(new ucViewCustomers());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucAddCustomers());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            CollapseAllSubpanels();
            LoadUserControl(new ucReports());
        }
    }
}
