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
    public partial class ucReports : UserControl
    {
        public ucReports()
        {
            InitializeComponent();
        }

        private void ucReports_Load(object sender, EventArgs e)
        {
            UpdateLastBackupInfo();
            LoadBackupFilesToComboBox();
        }

        private void LoadBackupFilesToComboBox()
        {
            string backupFolder = Path.Combine(Application.StartupPath, "Backups");

            if (!Directory.Exists(backupFolder))
                Directory.CreateDirectory(backupFolder);

            string[] backupFiles = Directory.GetFiles(backupFolder, "*.bak");

            cmbBackupFiles.Items.Clear();
            cmbBackupFiles.Items.Add(""); // 👈 Add blank first

            foreach (string file in backupFiles)
            {
                cmbBackupFiles.Items.Add(Path.GetFileName(file));
            }

            cmbBackupFiles.SelectedIndex = 0; // 👈 Select the blank item by default
        }
        private void UpdateLastBackupInfo()
        {
            string backupFolder = Path.Combine(Application.StartupPath, "Backups");

            if (!Directory.Exists(backupFolder))
            {
                lblLastBackupInfo.Text = "📁 No backups found.";
                return;
            }

            string[] backupFiles = Directory.GetFiles(backupFolder, "*.bak");

            if (backupFiles.Length == 0)
            {
                lblLastBackupInfo.Text = "📁 No backup files found.";
                return;
            }

            // Get the latest backup file by creation time
            var latestBackup = backupFiles
                .Select(f => new FileInfo(f))
                .OrderByDescending(f => f.CreationTime)
                .FirstOrDefault();

            if (latestBackup != null)
            {
                lblLastBackupInfo.Text = $"🕒 Last backup: {latestBackup.CreationTime:G}\n📄 File: {latestBackup.Name}";
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBackupData_Click(object sender, EventArgs e)
        {
            try
            {
                string backupFolder = Path.Combine(Application.StartupPath, "Backups");
                Directory.CreateDirectory(backupFolder);

                string dbName = "PersonalDB";
                string backupFile = Path.Combine(backupFolder, $"{dbName}_{DateTime.Now:yyyyMMdd_HHmmss}.bak");

                // Use master database for backup command
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PersonalDB;Integrated Security=True;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = $@"
                BACKUP DATABASE [{dbName}] 
                TO DISK = N'{backupFile}' 
                WITH FORMAT, INIT, 
                NAME = N'Full Backup of {dbName}';";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("✅ Database backup successful!", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateLastBackupInfo();
                LoadBackupFilesToComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Backup failed:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestoreData_Click(object sender, EventArgs e)
        {
            try
            {
                string dbName = "PersonalDB";
                string backupFolder = Path.Combine(Application.StartupPath, "Backups");
                string backupPath = string.Empty;

                if (cmbBackupFiles.SelectedItem != null && cmbBackupFiles.SelectedItem.ToString().EndsWith(".bak") && File.Exists(Path.Combine(backupFolder, cmbBackupFiles.SelectedItem.ToString())))
                {
                    backupPath = Path.Combine(backupFolder, cmbBackupFiles.SelectedItem.ToString());
                }
                else
                {
                    var bakFiles = Directory.GetFiles(backupFolder, "*.bak");
                    if (bakFiles.Length == 0)
                    {
                        MessageBox.Show("⚠️ No backup file found to restore.", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    backupPath = bakFiles.OrderByDescending(File.GetCreationTime).First();
                }

                // ✅ Connect to master instead of the database being restored
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = $@"
                ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                RESTORE DATABASE [{dbName}] FROM DISK = N'{backupPath}' WITH REPLACE;
                ALTER DATABASE [{dbName}] SET MULTI_USER;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"✅ Database restored successfully from:\n\n{Path.GetFileName(backupPath)}", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Restore failed:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearBackups_Click(object sender, EventArgs e)
        {
            try
            {
                string backupFolder = Path.Combine(Application.StartupPath, "Backups");


                if (Directory.Exists(backupFolder))
                {
                    string[] backupFiles = Directory.GetFiles(backupFolder, "*.bak");

                    if (backupFiles.Length == 0)
                    {
                        MessageBox.Show("⚠️ No backup files to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to delete all backup files?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        foreach (string file in backupFiles)
                        {
                            File.Delete(file);
                        }

                        MessageBox.Show("🗑️ All backup files deleted successfully.", "Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh label and combobox
                        UpdateLastBackupInfo();
                        LoadBackupFilesToComboBox();
                    }
                }
                else
                {
                    MessageBox.Show("❌ Backup folder not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Failed to delete backups:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
