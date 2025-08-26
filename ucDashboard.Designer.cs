namespace Personal_Inventory_for_Juntec
{
    partial class ucDashboard
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
            panel6 = new Panel();
            label9 = new Label();
            label5 = new Label();
            panel5 = new Panel();
            label8 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            label7 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 5);
            label1.Name = "label1";
            label1.Size = new Size(207, 45);
            label1.TabIndex = 0;
            label1.Text = "Dashboard";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(91, 155);
            panel1.Name = "panel1";
            panel1.Size = new Size(1213, 481);
            panel1.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top;
            panel6.Controls.Add(label9);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(651, 136);
            panel6.Name = "panel6";
            panel6.Size = new Size(225, 139);
            panel6.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(110, 72);
            label9.Name = "label9";
            label9.Size = new Size(15, 19);
            label9.TabIndex = 5;
            label9.Text = "-";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(28, 15);
            label5.Name = "label5";
            label5.Size = new Size(97, 23);
            label5.TabIndex = 3;
            label5.Text = "Total Cost";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(958, 136);
            panel5.Name = "panel5";
            panel5.Size = new Size(225, 139);
            panel5.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(109, 72);
            label8.Name = "label8";
            label8.Size = new Size(15, 19);
            label8.TabIndex = 4;
            label8.Text = "-";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(30, 15);
            label6.Name = "label6";
            label6.Size = new Size(94, 23);
            label6.TabIndex = 3;
            label6.Text = "Total Sold";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top;
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(361, 136);
            panel3.Name = "panel3";
            panel3.Size = new Size(225, 139);
            panel3.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(109, 72);
            label7.Name = "label7";
            label7.Size = new Size(15, 19);
            label7.TabIndex = 3;
            label7.Text = "-";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 15);
            label4.Name = "label4";
            label4.Size = new Size(92, 23);
            label4.TabIndex = 3;
            label4.Text = "Inventory";
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(35, 136);
            panel2.Name = "panel2";
            panel2.Size = new Size(225, 139);
            panel2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(89, 72);
            label3.Name = "label3";
            label3.Size = new Size(15, 19);
            label3.TabIndex = 2;
            label3.Text = "-";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(19, 15);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 2;
            label2.Text = "Customers";
            // 
            // ucDashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Silver;
            Controls.Add(panel1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ucDashboard";
            Size = new Size(1391, 861);
            Load += ucDashboard_Load;
            panel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panel6;
        private Panel panel5;
        private Panel panel3;
        private Panel panel2;
        private Label label3;
        private Label label2;
        private Label label9;
        private Label label5;
        private Label label8;
        private Label label6;
        private Label label7;
        private Label label4;
    }
}
