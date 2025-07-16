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
            dgvCustomersInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomersInventory.Location = new Point(86, 159);
            dgvCustomersInventory.Margin = new Padding(4, 3, 4, 3);
            dgvCustomersInventory.Name = "dgvCustomersInventory";
            dgvCustomersInventory.RowHeadersWidth = 51;
            dgvCustomersInventory.Size = new Size(1132, 575);
            dgvCustomersInventory.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(86, 93);
            label2.Name = "label2";
            label2.Size = new Size(142, 22);
            label2.TabIndex = 3;
            label2.Text = "Customer Name:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(234, 90);
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
            btnSearch.Location = new Point(564, 84);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(119, 40);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // ucCustomersInventory
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(dgvCustomersInventory);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucCustomersInventory";
            Size = new Size(1319, 837);
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
    }
}
