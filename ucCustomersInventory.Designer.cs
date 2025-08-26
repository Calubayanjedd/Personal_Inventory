namespace Personal_Inventory_for_Juntec
{
    partial class ucCustomersInventory
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
            dgvCustomersInventory = new DataGridView();
            label2 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnClear = new Button();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomersInventory).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 6);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(390, 45);
            label1.TabIndex = 1;
            label1.Text = "Customer's Inventory";
            // 
            // dgvCustomersInventory
            // 
            dgvCustomersInventory.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomersInventory.BackgroundColor = Color.White;
            dgvCustomersInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomersInventory.Location = new Point(16, 168);
            dgvCustomersInventory.Margin = new Padding(4, 3, 4, 3);
            dgvCustomersInventory.Name = "dgvCustomersInventory";
            dgvCustomersInventory.RowHeadersWidth = 51;
            dgvCustomersInventory.Size = new Size(1362, 575);
            dgvCustomersInventory.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 93);
            label2.Name = "label2";
            label2.Size = new Size(142, 22);
            label2.TabIndex = 3;
            label2.Text = "Customer Name:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(202, 90);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(324, 30);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DimGray;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(681, 84);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(119, 40);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.DimGray;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(546, 84);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(119, 40);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.DimGray;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(1178, 84);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(119, 40);
            btnExport.TabIndex = 7;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // ucCustomersInventory
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(btnExport);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(dgvCustomersInventory);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucCustomersInventory";
            Size = new Size(1391, 861);
            Load += ucCustomersInventory_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomersInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvCustomersInventory;
        private Label label2;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClear;
        private Button btnExport;
    }
}
