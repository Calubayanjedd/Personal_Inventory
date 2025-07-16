namespace Personal_Inventory_for_Juntec
{
    partial class ucViewInventory
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            txtSearch = new TextBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            cbType = new ComboBox();
            label3 = new Label();
            dtgInventory = new DataGridView();
            btnSearch = new Button();
            btnNext = new Button();
            lblLoading = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgInventory).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 5);
            label1.Name = "label1";
            label1.Size = new Size(281, 45);
            label1.TabIndex = 0;
            label1.Text = "View Inventory";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(88, 109);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(438, 30);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 75);
            label2.Name = "label2";
            label2.Size = new Size(122, 22);
            label2.TabIndex = 2;
            label2.Text = "Name of item:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(977, 109);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(232, 30);
            comboBox1.TabIndex = 3;
            // 
            // cbType
            // 
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(712, 109);
            cbType.Name = "cbType";
            cbType.Size = new Size(232, 30);
            cbType.TabIndex = 4;
            cbType.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(712, 75);
            label3.Name = "label3";
            label3.Size = new Size(55, 22);
            label3.TabIndex = 5;
            label3.Text = "Type:";
            // 
            // dtgInventory
            // 
            dtgInventory.BackgroundColor = SystemColors.ActiveCaption;
            dtgInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgInventory.Location = new Point(88, 177);
            dtgInventory.Name = "dtgInventory";
            dtgInventory.RowHeadersWidth = 51;
            dtgInventory.Size = new Size(1121, 551);
            dtgInventory.TabIndex = 6;
            dtgInventory.CellContentClick += dtgInventory_CellContentClick;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.GrayText;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(543, 108);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 30);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(1074, 769);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(135, 38);
            btnNext.TabIndex = 8;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblLoading
            // 
            lblLoading.AutoSize = true;
            lblLoading.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLoading.Location = new Point(1319, 837);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(102, 28);
            lblLoading.TabIndex = 9;
            lblLoading.Text = "Loading...";
            lblLoading.Visible = false;
            // 
            // ucViewInventory
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblLoading);
            Controls.Add(btnNext);
            Controls.Add(btnSearch);
            Controls.Add(dtgInventory);
            Controls.Add(label3);
            Controls.Add(cbType);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucViewInventory";
            Size = new Size(1319, 837);
            Load += ucViewInventory_Load;
            ((System.ComponentModel.ISupportInitialize)dtgInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private Label label2;
        private ComboBox comboBox1;
        private ComboBox cbType;
        private Label label3;
        private DataGridView dtgInventory;
        private Button btnSearch;
        private Button btnNext;
        private Label lblLoading; // ← Added here
    }
}
