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
            label2 = new Label();
            cbType = new ComboBox();
            cbMaterial = new ComboBox();
            label3 = new Label();
            dtgInventory = new DataGridView();
            btnSearch = new Button();
            btnNext = new Button();
            lblLoading = new Label();
            cbPrecision = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            cbShape = new ComboBox();
            cbBase = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            cbBaseValue = new ComboBox();
            label8 = new Label();
            txtDiameter = new TextBox();
            txtLength = new TextBox();
            label9 = new Label();
            btnClear = new Button();
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 84);
            label2.Name = "label2";
            label2.Size = new Size(91, 22);
            label2.TabIndex = 2;
            label2.Text = "Precision:";
            // 
            // cbType
            // 
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(301, 118);
            cbType.Name = "cbType";
            cbType.Size = new Size(128, 30);
            cbType.TabIndex = 3;
            // 
            // cbMaterial
            // 
            cbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaterial.FormattingEnabled = true;
            cbMaterial.Location = new Point(167, 118);
            cbMaterial.Name = "cbMaterial";
            cbMaterial.Size = new Size(128, 30);
            cbMaterial.TabIndex = 4;
            cbMaterial.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(167, 84);
            label3.Name = "label3";
            label3.Size = new Size(84, 22);
            label3.TabIndex = 5;
            label3.Text = "Material:";
            // 
            // dtgInventory
            // 
            dtgInventory.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtgInventory.BackgroundColor = Color.White;
            dtgInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgInventory.Location = new Point(22, 181);
            dtgInventory.Name = "dtgInventory";
            dtgInventory.RowHeadersWidth = 51;
            dtgInventory.Size = new Size(1263, 547);
            dtgInventory.TabIndex = 6;
            dtgInventory.CellContentClick += dtgInventory_CellContentClick;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = SystemColors.GrayText;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(1048, 97);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(118, 38);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNext.Location = new Point(1099, 761);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(165, 53);
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
            // cbPrecision
            // 
            cbPrecision.BackColor = Color.White;
            cbPrecision.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPrecision.FormattingEnabled = true;
            cbPrecision.Location = new Point(33, 118);
            cbPrecision.Name = "cbPrecision";
            cbPrecision.Size = new Size(128, 30);
            cbPrecision.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(301, 84);
            label4.Name = "label4";
            label4.Size = new Size(55, 22);
            label4.TabIndex = 11;
            label4.Text = "Type:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(435, 84);
            label5.Name = "label5";
            label5.Size = new Size(64, 22);
            label5.TabIndex = 12;
            label5.Text = "Shape:";
            // 
            // cbShape
            // 
            cbShape.DropDownStyle = ComboBoxStyle.DropDownList;
            cbShape.FormattingEnabled = true;
            cbShape.Location = new Point(435, 118);
            cbShape.Name = "cbShape";
            cbShape.Size = new Size(128, 30);
            cbShape.TabIndex = 13;
            // 
            // cbBase
            // 
            cbBase.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBase.FormattingEnabled = true;
            cbBase.Location = new Point(569, 118);
            cbBase.Name = "cbBase";
            cbBase.Size = new Size(128, 30);
            cbBase.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(569, 81);
            label6.Name = "label6";
            label6.Size = new Size(99, 22);
            label6.TabIndex = 14;
            label6.Text = "Base Type:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(703, 84);
            label7.Name = "label7";
            label7.Size = new Size(104, 22);
            label7.TabIndex = 16;
            label7.Text = "Base Value:";
            // 
            // cbBaseValue
            // 
            cbBaseValue.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBaseValue.FormattingEnabled = true;
            cbBaseValue.Location = new Point(703, 118);
            cbBaseValue.Name = "cbBaseValue";
            cbBaseValue.Size = new Size(128, 30);
            cbBaseValue.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(847, 81);
            label8.Name = "label8";
            label8.Size = new Size(89, 22);
            label8.TabIndex = 18;
            label8.Text = "Diameter:";
            label8.Click += label8_Click;
            // 
            // txtDiameter
            // 
            txtDiameter.BackColor = Color.Gray;
            txtDiameter.ForeColor = Color.White;
            txtDiameter.Location = new Point(847, 118);
            txtDiameter.Name = "txtDiameter";
            txtDiameter.Size = new Size(79, 30);
            txtDiameter.TabIndex = 19;
            txtDiameter.TextChanged += textBox1_TextChanged;
            // 
            // txtLength
            // 
            txtLength.BackColor = Color.Gray;
            txtLength.ForeColor = Color.White;
            txtLength.Location = new Point(946, 118);
            txtLength.Name = "txtLength";
            txtLength.Size = new Size(79, 30);
            txtLength.TabIndex = 21;
            txtLength.TextChanged += textBox2_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(946, 81);
            label9.Name = "label9";
            label9.Size = new Size(68, 22);
            label9.TabIndex = 20;
            label9.Text = "Length:";
            label9.Click += label9_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Right;
            btnClear.BackColor = SystemColors.GrayText;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(1177, 97);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(118, 38);
            btnClear.TabIndex = 22;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += button1_Click;
            // 
            // ucViewInventory
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnClear);
            Controls.Add(txtLength);
            Controls.Add(label9);
            Controls.Add(txtDiameter);
            Controls.Add(label8);
            Controls.Add(cbBaseValue);
            Controls.Add(label7);
            Controls.Add(cbBase);
            Controls.Add(label6);
            Controls.Add(cbShape);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(cbPrecision);
            Controls.Add(lblLoading);
            Controls.Add(btnNext);
            Controls.Add(btnSearch);
            Controls.Add(dtgInventory);
            Controls.Add(label3);
            Controls.Add(cbMaterial);
            Controls.Add(cbType);
            Controls.Add(label2);
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
        private Label label2;
        private ComboBox cbType;
        private ComboBox cbMaterial;
        private Label label3;
        private DataGridView dtgInventory;
        private Button btnSearch;
        private Button btnNext;
        private Label lblLoading; // ← Added here
        private ComboBox cbPrecision;
        private Label label4;
        private Label label5;
        private ComboBox cbShape;
        private ComboBox cbBase;
        private Label label6;
        private Label label7;
        private ComboBox cbBaseValue;
        private Label label8;
        private TextBox txtDiameter;
        private TextBox txtLength;
        private Label label9;
        private Button btnClear;
    }
}
