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
            dtgInventory = new DataGridView();
            btnSearch = new Button();
            btnNext = new Button();
            cbPartNumber = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            cbShape = new ComboBox();
            cbBase = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            cbBaseValue = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            btnClear = new Button();
            label10 = new Label();
            cbPRange = new ComboBox();
            cbDiameter = new ComboBox();
            cbLength = new ComboBox();
            btnUpdate = new Button();
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
            label2.Size = new Size(116, 22);
            label2.TabIndex = 2;
            label2.Text = "Part Number:";
            // 
            // cbType
            // 
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(236, 118);
            cbType.Name = "cbType";
            cbType.Size = new Size(107, 30);
            cbType.TabIndex = 3;
            // 
            // dtgInventory
            // 
            dtgInventory.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtgInventory.BackgroundColor = Color.White;
            dtgInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgInventory.Location = new Point(22, 193);
            dtgInventory.Name = "dtgInventory";
            dtgInventory.RowHeadersWidth = 51;
            dtgInventory.Size = new Size(1335, 537);
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
            btnSearch.Location = new Point(1081, 97);
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
            btnNext.Location = new Point(1171, 785);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(165, 53);
            btnNext.TabIndex = 8;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // cbPartNumber
            // 
            cbPartNumber.BackColor = Color.White;
            cbPartNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPartNumber.FormattingEnabled = true;
            cbPartNumber.Location = new Point(33, 118);
            cbPartNumber.Name = "cbPartNumber";
            cbPartNumber.Size = new Size(197, 30);
            cbPartNumber.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(236, 84);
            label4.Name = "label4";
            label4.Size = new Size(55, 22);
            label4.TabIndex = 11;
            label4.Text = "Type:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(349, 84);
            label5.Name = "label5";
            label5.Size = new Size(64, 22);
            label5.TabIndex = 12;
            label5.Text = "Shape:";
            // 
            // cbShape
            // 
            cbShape.DropDownStyle = ComboBoxStyle.DropDownList;
            cbShape.FormattingEnabled = true;
            cbShape.Location = new Point(349, 118);
            cbShape.Name = "cbShape";
            cbShape.Size = new Size(107, 30);
            cbShape.TabIndex = 13;
            // 
            // cbBase
            // 
            cbBase.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBase.FormattingEnabled = true;
            cbBase.Location = new Point(462, 118);
            cbBase.Name = "cbBase";
            cbBase.Size = new Size(107, 30);
            cbBase.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(462, 84);
            label6.Name = "label6";
            label6.Size = new Size(99, 22);
            label6.TabIndex = 14;
            label6.Text = "Base Type:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(575, 84);
            label7.Name = "label7";
            label7.Size = new Size(104, 22);
            label7.TabIndex = 16;
            label7.Text = "Base Value:";
            // 
            // cbBaseValue
            // 
            cbBaseValue.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBaseValue.FormattingEnabled = true;
            cbBaseValue.Location = new Point(575, 118);
            cbBaseValue.Name = "cbBaseValue";
            cbBaseValue.Size = new Size(107, 30);
            cbBaseValue.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(688, 84);
            label8.Name = "label8";
            label8.Size = new Size(89, 22);
            label8.TabIndex = 18;
            label8.Text = "Diameter:";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(801, 84);
            label9.Name = "label9";
            label9.Size = new Size(68, 22);
            label9.TabIndex = 20;
            label9.Text = "Length:";
            label9.Click += label9_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = SystemColors.GrayText;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(1205, 97);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(118, 38);
            btnClear.TabIndex = 22;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += button1_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(916, 84);
            label10.Name = "label10";
            label10.Size = new Size(27, 22);
            label10.TabIndex = 23;
            label10.Text = "P:";
            // 
            // cbPRange
            // 
            cbPRange.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPRange.FormattingEnabled = true;
            cbPRange.Location = new Point(914, 118);
            cbPRange.Name = "cbPRange";
            cbPRange.Size = new Size(107, 30);
            cbPRange.TabIndex = 24;
            cbPRange.SelectedIndexChanged += cbPRange_SelectedIndexChanged;
            // 
            // cbDiameter
            // 
            cbDiameter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDiameter.FormattingEnabled = true;
            cbDiameter.Location = new Point(688, 118);
            cbDiameter.Name = "cbDiameter";
            cbDiameter.Size = new Size(107, 30);
            cbDiameter.TabIndex = 25;
            cbDiameter.SelectedIndexChanged += cbDiameter_SelectedIndexChanged;
            // 
            // cbLength
            // 
            cbLength.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLength.FormattingEnabled = true;
            cbLength.Location = new Point(801, 118);
            cbLength.Name = "cbLength";
            cbLength.Size = new Size(107, 30);
            cbLength.TabIndex = 26;
            cbLength.SelectedIndexChanged += cbLength_SelectedIndexChanged;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdate.Location = new Point(954, 785);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(165, 53);
            btnUpdate.TabIndex = 27;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // ucViewInventory
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(btnUpdate);
            Controls.Add(cbLength);
            Controls.Add(cbDiameter);
            Controls.Add(cbPRange);
            Controls.Add(label10);
            Controls.Add(btnClear);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(cbBaseValue);
            Controls.Add(label7);
            Controls.Add(cbBase);
            Controls.Add(label6);
            Controls.Add(cbShape);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(cbPartNumber);
            Controls.Add(btnNext);
            Controls.Add(btnSearch);
            Controls.Add(dtgInventory);
            Controls.Add(cbType);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucViewInventory";
            Size = new Size(1391, 861);
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
        private ComboBox cbPartNumber;
        private Label label4;
        private Label label5;
        private ComboBox cbShape;
        private ComboBox cbBase;
        private Label label6;
        private Label label7;
        private ComboBox cbBaseValue;
        private Label label8;
        private Label label9;
        private Button btnClear;
        private Label label10;
        private ComboBox cbPRange;
        private ComboBox cbDiameter;
        private ComboBox cbLength;
        private Button btnUpdate;
    }
}
