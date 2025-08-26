namespace Personal_Inventory_for_Juntec
{
    partial class ucReports
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            btnClearBackups = new Button();
            label2 = new Label();
            cmbBackupFiles = new ComboBox();
            lblLastBackupInfo = new Label();
            btnRestoreData = new Button();
            btnBackupData = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 5);
            label1.Name = "label1";
            label1.Size = new Size(151, 45);
            label1.TabIndex = 0;
            label1.Text = "Backup";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnClearBackups);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbBackupFiles);
            panel1.Controls.Add(lblLastBackupInfo);
            panel1.Controls.Add(btnRestoreData);
            panel1.Controls.Add(btnBackupData);
            panel1.Location = new Point(269, 143);
            panel1.Name = "panel1";
            panel1.Size = new Size(887, 552);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // btnClearBackups
            // 
            btnClearBackups.Anchor = AnchorStyles.Right;
            btnClearBackups.Location = new Point(644, 346);
            btnClearBackups.Name = "btnClearBackups";
            btnClearBackups.Size = new Size(156, 42);
            btnClearBackups.TabIndex = 6;
            btnClearBackups.Text = "Delete Backups";
            btnClearBackups.UseVisualStyleBackColor = true;
            btnClearBackups.Click += btnClearBackups_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(201, 316);
            label2.Name = "label2";
            label2.Size = new Size(163, 22);
            label2.TabIndex = 5;
            label2.Text = "Available backups:";
            // 
            // cmbBackupFiles
            // 
            cmbBackupFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbBackupFiles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBackupFiles.FormattingEnabled = true;
            cmbBackupFiles.Location = new Point(201, 341);
            cmbBackupFiles.Name = "cmbBackupFiles";
            cmbBackupFiles.Size = new Size(401, 30);
            cmbBackupFiles.TabIndex = 4;
            // 
            // lblLastBackupInfo
            // 
            lblLastBackupInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblLastBackupInfo.AutoSize = true;
            lblLastBackupInfo.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLastBackupInfo.Location = new Point(173, 24);
            lblLastBackupInfo.Name = "lblLastBackupInfo";
            lblLastBackupInfo.Size = new Size(0, 32);
            lblLastBackupInfo.TabIndex = 3;
            // 
            // btnRestoreData
            // 
            btnRestoreData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnRestoreData.Location = new Point(219, 393);
            btnRestoreData.Name = "btnRestoreData";
            btnRestoreData.Size = new Size(368, 84);
            btnRestoreData.TabIndex = 1;
            btnRestoreData.Text = "Restore data";
            btnRestoreData.UseVisualStyleBackColor = true;
            btnRestoreData.Click += btnRestoreData_Click;
            // 
            // btnBackupData
            // 
            btnBackupData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnBackupData.Location = new Point(219, 150);
            btnBackupData.Name = "btnBackupData";
            btnBackupData.Size = new Size(368, 84);
            btnBackupData.TabIndex = 0;
            btnBackupData.Text = "Backup data";
            btnBackupData.UseVisualStyleBackColor = true;
            btnBackupData.Click += btnBackupData_Click;
            // 
            // ucReports
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(panel1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucReports";
            Size = new Size(1391, 861);
            Load += ucReports_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button btnBackupData;
        private Button btnRestoreData;
        private Label lblLastBackupInfo;
        private Label label2;
        private ComboBox cmbBackupFiles;
        private Button btnClearBackups;
    }
}
