namespace Personal_Inventory_for_Juntec
{
    partial class AssigningCustomer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblItemID = new Label();
            lblItemName = new Label();
            lblItemType = new Label();
            lblItemCost = new Label();
            label5 = new Label();
            lblItemSize = new Label();
            comboBox1 = new ComboBox();
            label6 = new Label();
            btnDone = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 65);
            label1.Name = "label1";
            label1.Size = new Size(75, 22);
            label1.TabIndex = 0;
            label1.Text = "Item ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 129);
            label2.Name = "label2";
            label2.Size = new Size(101, 22);
            label2.TabIndex = 1;
            label2.Text = "Item Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 196);
            label3.Name = "label3";
            label3.Size = new Size(94, 22);
            label3.TabIndex = 2;
            label3.Text = "Item Type:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 338);
            label4.Name = "label4";
            label4.Size = new Size(91, 22);
            label4.TabIndex = 3;
            label4.Text = "Item Cost:";
            // 
            // lblItemID
            // 
            lblItemID.AutoSize = true;
            lblItemID.Location = new Point(170, 65);
            lblItemID.Name = "lblItemID";
            lblItemID.Size = new Size(17, 22);
            lblItemID.TabIndex = 4;
            lblItemID.Text = "-";
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Location = new Point(170, 129);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(17, 22);
            lblItemName.TabIndex = 5;
            lblItemName.Text = "-";
            // 
            // lblItemType
            // 
            lblItemType.AutoSize = true;
            lblItemType.Location = new Point(170, 196);
            lblItemType.Name = "lblItemType";
            lblItemType.Size = new Size(17, 22);
            lblItemType.TabIndex = 6;
            lblItemType.Text = "-";
            // 
            // lblItemCost
            // 
            lblItemCost.AutoSize = true;
            lblItemCost.Location = new Point(170, 338);
            lblItemCost.Name = "lblItemCost";
            lblItemCost.Size = new Size(17, 22);
            lblItemCost.TabIndex = 7;
            lblItemCost.Text = "-";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 266);
            label5.Name = "label5";
            label5.Size = new Size(89, 22);
            label5.TabIndex = 8;
            label5.Text = "Item Size:";
            // 
            // lblItemSize
            // 
            lblItemSize.AutoSize = true;
            lblItemSize.Location = new Point(170, 266);
            lblItemSize.Name = "lblItemSize";
            lblItemSize.Size = new Size(17, 22);
            lblItemSize.TabIndex = 9;
            lblItemSize.Text = "-";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(170, 407);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(297, 30);
            comboBox1.TabIndex = 10;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(37, 410);
            label6.Name = "label6";
            label6.Size = new Size(91, 22);
            label6.TabIndex = 11;
            label6.Text = "Customer:";
            // 
            // btnDone
            // 
            btnDone.Location = new Point(197, 486);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(146, 43);
            btnDone.TabIndex = 12;
            btnDone.Text = "Done";
            btnDone.UseVisualStyleBackColor = true;
            btnDone.Click += btnDone_Click;
            // 
            // AssigningCustomer
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 583);
            Controls.Add(btnDone);
            Controls.Add(label6);
            Controls.Add(comboBox1);
            Controls.Add(lblItemSize);
            Controls.Add(label5);
            Controls.Add(lblItemCost);
            Controls.Add(lblItemType);
            Controls.Add(lblItemName);
            Controls.Add(lblItemID);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AssigningCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AssigningCustomer";
            Load += AssigningCustomer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblItemID;
        private Label lblItemName;
        private Label lblItemType;
        private Label lblItemCost;
        private Label label5;
        private Label lblItemSize;
        private ComboBox comboBox1;
        private Label label6;
        private Button btnDone;
    }
}