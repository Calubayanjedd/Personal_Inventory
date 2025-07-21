
namespace Personal_Inventory_for_Juntec
{
    partial class ucAddInventory
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            txtPrecision = new TextBox();
            txtMaterial = new TextBox();
            txtType = new TextBox();
            txtShape = new TextBox();
            txtBaseType = new TextBox();
            txtBaseValue = new TextBox();
            txtDiameter = new TextBox();
            txtLength = new TextBox();
            txtPressureRange = new TextBox();
            txtPressureMax = new TextBox();
            txtPressureMin = new TextBox();
            txtRadius = new TextBox();
            txtHeight = new TextBox();
            txtQuantity = new TextBox();
            txtCost = new TextBox();
            btnRegister = new Button();
            btnClear = new Button();
            Quantity = new Label();
            txtNote = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 5);
            label1.Name = "label1";
            label1.Size = new Size(268, 45);
            label1.TabIndex = 0;
            label1.Text = "Add Inventory";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(90, 121);
            label2.Name = "label2";
            label2.Size = new Size(91, 22);
            label2.TabIndex = 1;
            label2.Text = "Precision:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(97, 184);
            label3.Name = "label3";
            label3.Size = new Size(84, 22);
            label3.TabIndex = 2;
            label3.Text = "Material:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(126, 255);
            label4.Name = "label4";
            label4.Size = new Size(55, 22);
            label4.TabIndex = 3;
            label4.Text = "Type:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(117, 334);
            label5.Name = "label5";
            label5.Size = new Size(64, 22);
            label5.TabIndex = 4;
            label5.Text = "Shape:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(82, 409);
            label6.Name = "label6";
            label6.Size = new Size(99, 22);
            label6.TabIndex = 5;
            label6.Text = "Base Type:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(77, 483);
            label7.Name = "label7";
            label7.Size = new Size(104, 22);
            label7.TabIndex = 6;
            label7.Text = "Base Value:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(92, 558);
            label8.Name = "label8";
            label8.Size = new Size(89, 22);
            label8.TabIndex = 7;
            label8.Text = "Diameter:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(113, 632);
            label9.Name = "label9";
            label9.Size = new Size(68, 22);
            label9.TabIndex = 8;
            label9.Text = "Length:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(43, 717);
            label10.Name = "label10";
            label10.Size = new Size(138, 22);
            label10.TabIndex = 9;
            label10.Text = "Pressure Range:";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(594, 118);
            label11.Name = "label11";
            label11.Size = new Size(89, 22);
            label11.TabIndex = 10;
            label11.Text = "P · Kmax:";
            label11.Click += label11_Click;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(597, 184);
            label12.Name = "label12";
            label12.Size = new Size(86, 22);
            label12.TabIndex = 11;
            label12.Text = "P · Kmin:";
            label12.Click += label12_Click;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Location = new Point(612, 252);
            label13.Name = "label13";
            label13.Size = new Size(71, 22);
            label13.TabIndex = 12;
            label13.Text = "Radius:";
            label13.Click += label13_Click;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Location = new Point(615, 334);
            label14.Name = "label14";
            label14.Size = new Size(68, 22);
            label14.TabIndex = 13;
            label14.Text = "Height:";
            label14.Click += label14_Click;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Location = new Point(631, 483);
            label15.Name = "label15";
            label15.Size = new Size(52, 22);
            label15.TabIndex = 14;
            label15.Text = "Cost:";
            label15.Click += label15_Click;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Location = new Point(629, 554);
            label16.Name = "label16";
            label16.Size = new Size(54, 22);
            label16.TabIndex = 15;
            label16.Text = "Note:";
            label16.Click += label16_Click;
            // 
            // txtPrecision
            // 
            txtPrecision.Location = new Point(213, 118);
            txtPrecision.Name = "txtPrecision";
            txtPrecision.Size = new Size(296, 30);
            txtPrecision.TabIndex = 16;
            // 
            // txtMaterial
            // 
            txtMaterial.Location = new Point(213, 181);
            txtMaterial.Name = "txtMaterial";
            txtMaterial.Size = new Size(296, 30);
            txtMaterial.TabIndex = 17;
            // 
            // txtType
            // 
            txtType.Location = new Point(213, 252);
            txtType.Name = "txtType";
            txtType.Size = new Size(296, 30);
            txtType.TabIndex = 18;
            // 
            // txtShape
            // 
            txtShape.Location = new Point(213, 331);
            txtShape.Name = "txtShape";
            txtShape.Size = new Size(296, 30);
            txtShape.TabIndex = 19;
            // 
            // txtBaseType
            // 
            txtBaseType.Location = new Point(213, 406);
            txtBaseType.Name = "txtBaseType";
            txtBaseType.Size = new Size(296, 30);
            txtBaseType.TabIndex = 20;
            // 
            // txtBaseValue
            // 
            txtBaseValue.Location = new Point(213, 480);
            txtBaseValue.Name = "txtBaseValue";
            txtBaseValue.Size = new Size(296, 30);
            txtBaseValue.TabIndex = 21;
            // 
            // txtDiameter
            // 
            txtDiameter.Location = new Point(213, 555);
            txtDiameter.Name = "txtDiameter";
            txtDiameter.Size = new Size(296, 30);
            txtDiameter.TabIndex = 22;
            // 
            // txtLength
            // 
            txtLength.Location = new Point(213, 629);
            txtLength.Name = "txtLength";
            txtLength.Size = new Size(296, 30);
            txtLength.TabIndex = 23;
            // 
            // txtPressureRange
            // 
            txtPressureRange.Location = new Point(213, 714);
            txtPressureRange.Name = "txtPressureRange";
            txtPressureRange.Size = new Size(296, 30);
            txtPressureRange.TabIndex = 24;
            // 
            // txtPressureMax
            // 
            txtPressureMax.Anchor = AnchorStyles.Right;
            txtPressureMax.Location = new Point(730, 113);
            txtPressureMax.Name = "txtPressureMax";
            txtPressureMax.Size = new Size(296, 30);
            txtPressureMax.TabIndex = 25;
            txtPressureMax.TextChanged += txtPressureMax_TextChanged;
            // 
            // txtPressureMin
            // 
            txtPressureMin.Anchor = AnchorStyles.Right;
            txtPressureMin.Location = new Point(730, 181);
            txtPressureMin.Name = "txtPressureMin";
            txtPressureMin.Size = new Size(296, 30);
            txtPressureMin.TabIndex = 26;
            txtPressureMin.TextChanged += txtPressureMin_TextChanged;
            // 
            // txtRadius
            // 
            txtRadius.Anchor = AnchorStyles.Right;
            txtRadius.Location = new Point(730, 252);
            txtRadius.Name = "txtRadius";
            txtRadius.Size = new Size(296, 30);
            txtRadius.TabIndex = 27;
            txtRadius.TextChanged += txtRadius_TextChanged;
            // 
            // txtHeight
            // 
            txtHeight.Anchor = AnchorStyles.Right;
            txtHeight.Location = new Point(730, 331);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(296, 30);
            txtHeight.TabIndex = 28;
            txtHeight.TextChanged += txtHeight_TextChanged;
            // 
            // txtQuantity
            // 
            txtQuantity.Anchor = AnchorStyles.Right;
            txtQuantity.Location = new Point(730, 406);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(296, 30);
            txtQuantity.TabIndex = 29;
            txtQuantity.TextChanged += txtCost_TextChanged;
            // 
            // txtCost
            // 
            txtCost.Anchor = AnchorStyles.Right;
            txtCost.Location = new Point(730, 480);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(296, 30);
            txtCost.TabIndex = 30;
            txtCost.TextChanged += txtNote_TextChanged;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.Right;
            btnRegister.Location = new Point(1001, 724);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(233, 57);
            btnRegister.TabIndex = 31;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(740, 724);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(233, 57);
            btnClear.TabIndex = 32;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Quantity
            // 
            Quantity.Anchor = AnchorStyles.Right;
            Quantity.AutoSize = true;
            Quantity.Location = new Point(601, 409);
            Quantity.Name = "Quantity";
            Quantity.Size = new Size(82, 22);
            Quantity.TabIndex = 33;
            Quantity.Text = "Quantity:";
            // 
            // txtNote
            // 
            txtNote.Anchor = AnchorStyles.Right;
            txtNote.Location = new Point(730, 555);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(296, 30);
            txtNote.TabIndex = 34;
            // 
            // ucAddInventory
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtNote);
            Controls.Add(Quantity);
            Controls.Add(btnClear);
            Controls.Add(btnRegister);
            Controls.Add(txtCost);
            Controls.Add(txtQuantity);
            Controls.Add(txtHeight);
            Controls.Add(txtRadius);
            Controls.Add(txtPressureMin);
            Controls.Add(txtPressureMax);
            Controls.Add(txtPressureRange);
            Controls.Add(txtLength);
            Controls.Add(txtDiameter);
            Controls.Add(txtBaseValue);
            Controls.Add(txtBaseType);
            Controls.Add(txtShape);
            Controls.Add(txtType);
            Controls.Add(txtMaterial);
            Controls.Add(txtPrecision);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucAddInventory";
            Size = new Size(1319, 837);
            Load += ucAddInventory_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private TextBox txtPrecision;
        private TextBox txtMaterial;
        private TextBox txtType;
        private TextBox txtShape;
        private TextBox txtBaseType;
        private TextBox txtBaseValue;
        private TextBox txtDiameter;
        private TextBox txtLength;
        private TextBox txtPressureRange;
        private TextBox txtPressureMax;
        private TextBox txtPressureMin;
        private TextBox txtRadius;
        private TextBox txtHeight;
        private TextBox txtQuantity;
        private TextBox txtCost;
        private Button btnRegister;
        private Button btnClear;
        private Label Quantity;
        private TextBox txtNote;
    }
}
