using Microsoft.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Personal_Inventory_for_Juntec
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PersonalDB.mdf;Integrated Security=True;"))
                {
                    conn.Open();

                    string query = "SELECT adminID FROM admin WHERE username = @username AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();
                        bool loginSuccess = result != null;
                        int adminId = loginSuccess ? Convert.ToInt32(result) : 0;

                        // Get environment info
                        string machineName = Environment.MachineName;
                        string ipAddress = GetLocalIPAddress();

                        string logQuery = @"INSERT INTO LoginHistory (adminID, Username, LoginTime, MachineName, IPAddress, Status)VALUES (@adminID, @username, GETDATE(), @machineName, @ipAddress, @status)";
                        using (SqlCommand logCmd = new SqlCommand(logQuery, conn))
                        {
                            logCmd.Parameters.AddWithValue("@adminID", adminId);
                            logCmd.Parameters.AddWithValue("@username", username);
                            logCmd.Parameters.AddWithValue("@machineName", machineName);
                            logCmd.Parameters.AddWithValue("@ipAddress", ipAddress);
                            logCmd.Parameters.AddWithValue("@status", loginSuccess ? "Success" : "Failed");
                            logCmd.ExecuteNonQuery();
                        }

                        // Handle result
                        if (loginSuccess)
                        {
                            Session.AdminID = adminId;
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUsername.Focus();
                            txtUsername.Clear();
                            txtPassword.Clear();
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("A database error occurred:\n" + sqlEx.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Helper function to get local IP Address
            string GetLocalIPAddress()
            {
                try
                {
                    var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            return ip.ToString();
                        }
                    }
                    return "N/A";
                }
                catch
                {
                    return "Unknown";
                }
            }
        }
    }
}
