namespace Personal_Inventory_for_Juntec
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            topPanel = new Panel();
            btnExit = new Button();
            navPanel = new Panel();
            btnLogout = new Button();
            fillerPanel = new Panel();
            btnReports = new Button();
            customerSubpanel = new Panel();
            btnAddCustomer = new Button();
            btnViewCustomer = new Button();
            btnCustomer = new Button();
            inventorySubpanel = new Panel();
            btnAddInventory = new Button();
            btnViewInventory = new Button();
            btnInventory = new Button();
            btnDashboard = new Button();
            profilePanel = new Panel();
            lblName = new Label();
            pictureBox1 = new PictureBox();
            menuPanel = new Panel();
            label1 = new Label();
            btnMenu = new Button();
            mainPanel = new Panel();
            topPanel.SuspendLayout();
            navPanel.SuspendLayout();
            customerSubpanel.SuspendLayout();
            inventorySubpanel.SuspendLayout();
            profilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.LightGray;
            topPanel.Controls.Add(btnExit);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1569, 55);
            topPanel.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.BackColor = Color.Red;
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(1484, 9);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(73, 37);
            btnExit.TabIndex = 3;
            btnExit.Text = "✖";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // navPanel
            // 
            navPanel.BackColor = Color.LightGray;
            navPanel.Controls.Add(btnLogout);
            navPanel.Controls.Add(fillerPanel);
            navPanel.Controls.Add(btnReports);
            navPanel.Controls.Add(customerSubpanel);
            navPanel.Controls.Add(btnCustomer);
            navPanel.Controls.Add(inventorySubpanel);
            navPanel.Controls.Add(btnInventory);
            navPanel.Controls.Add(btnDashboard);
            navPanel.Controls.Add(profilePanel);
            navPanel.Controls.Add(menuPanel);
            navPanel.Dock = DockStyle.Left;
            navPanel.Location = new Point(0, 55);
            navPanel.Name = "navPanel";
            navPanel.Size = new Size(250, 837);
            navPanel.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.White;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(0, 772);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(20, 0, 0, 0);
            btnLogout.Size = new Size(250, 65);
            btnLogout.TabIndex = 9;
            btnLogout.Text = "✖ Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // fillerPanel
            // 
            fillerPanel.Dock = DockStyle.Fill;
            fillerPanel.Location = new Point(0, 771);
            fillerPanel.Name = "fillerPanel";
            fillerPanel.Size = new Size(250, 66);
            fillerPanel.TabIndex = 8;
            // 
            // btnReports
            // 
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatAppearance.MouseOverBackColor = Color.White;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Location = new Point(0, 706);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(20, 0, 0, 0);
            btnReports.Size = new Size(250, 65);
            btnReports.TabIndex = 7;
            btnReports.Text = "📢 Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // customerSubpanel
            // 
            customerSubpanel.Controls.Add(btnAddCustomer);
            customerSubpanel.Controls.Add(btnViewCustomer);
            customerSubpanel.Dock = DockStyle.Top;
            customerSubpanel.Location = new Point(0, 577);
            customerSubpanel.Name = "customerSubpanel";
            customerSubpanel.Size = new Size(250, 129);
            customerSubpanel.TabIndex = 6;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Dock = DockStyle.Top;
            btnAddCustomer.FlatAppearance.BorderSize = 0;
            btnAddCustomer.FlatAppearance.MouseOverBackColor = Color.White;
            btnAddCustomer.FlatStyle = FlatStyle.Flat;
            btnAddCustomer.Location = new Point(0, 65);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Padding = new Padding(20, 0, 0, 0);
            btnAddCustomer.Size = new Size(250, 65);
            btnAddCustomer.TabIndex = 1;
            btnAddCustomer.Text = "➕👤 Add Customers";
            btnAddCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += button2_Click;
            // 
            // btnViewCustomer
            // 
            btnViewCustomer.Dock = DockStyle.Top;
            btnViewCustomer.FlatAppearance.BorderSize = 0;
            btnViewCustomer.FlatAppearance.MouseOverBackColor = Color.White;
            btnViewCustomer.FlatStyle = FlatStyle.Flat;
            btnViewCustomer.Location = new Point(0, 0);
            btnViewCustomer.Name = "btnViewCustomer";
            btnViewCustomer.Padding = new Padding(20, 0, 0, 0);
            btnViewCustomer.Size = new Size(250, 65);
            btnViewCustomer.TabIndex = 0;
            btnViewCustomer.Text = "🔍︎👤 View Customers";
            btnViewCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnViewCustomer.UseVisualStyleBackColor = true;
            btnViewCustomer.Click += button1_Click_1;
            // 
            // btnCustomer
            // 
            btnCustomer.Dock = DockStyle.Top;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatAppearance.MouseOverBackColor = Color.White;
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.Location = new Point(0, 512);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Padding = new Padding(20, 0, 0, 0);
            btnCustomer.Size = new Size(250, 65);
            btnCustomer.TabIndex = 5;
            btnCustomer.Text = "👤 Customers";
            btnCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // inventorySubpanel
            // 
            inventorySubpanel.Controls.Add(btnAddInventory);
            inventorySubpanel.Controls.Add(btnViewInventory);
            inventorySubpanel.Dock = DockStyle.Top;
            inventorySubpanel.Location = new Point(0, 381);
            inventorySubpanel.Name = "inventorySubpanel";
            inventorySubpanel.Size = new Size(250, 131);
            inventorySubpanel.TabIndex = 4;
            // 
            // btnAddInventory
            // 
            btnAddInventory.Dock = DockStyle.Top;
            btnAddInventory.FlatAppearance.BorderSize = 0;
            btnAddInventory.FlatAppearance.MouseOverBackColor = Color.White;
            btnAddInventory.FlatStyle = FlatStyle.Flat;
            btnAddInventory.Location = new Point(0, 65);
            btnAddInventory.Name = "btnAddInventory";
            btnAddInventory.Padding = new Padding(20, 0, 0, 0);
            btnAddInventory.Size = new Size(250, 65);
            btnAddInventory.TabIndex = 1;
            btnAddInventory.Text = "➕📦 Add Inventory";
            btnAddInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnAddInventory.UseVisualStyleBackColor = true;
            btnAddInventory.Click += btnAddInventory_Click;
            // 
            // btnViewInventory
            // 
            btnViewInventory.Dock = DockStyle.Top;
            btnViewInventory.FlatAppearance.BorderSize = 0;
            btnViewInventory.FlatAppearance.MouseOverBackColor = Color.White;
            btnViewInventory.FlatStyle = FlatStyle.Flat;
            btnViewInventory.Location = new Point(0, 0);
            btnViewInventory.Name = "btnViewInventory";
            btnViewInventory.Padding = new Padding(20, 0, 0, 0);
            btnViewInventory.Size = new Size(250, 65);
            btnViewInventory.TabIndex = 0;
            btnViewInventory.Text = "🔍︎📋 View Inventory";
            btnViewInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnViewInventory.UseVisualStyleBackColor = true;
            btnViewInventory.Click += btnViewInventory_Click;
            // 
            // btnInventory
            // 
            btnInventory.Dock = DockStyle.Top;
            btnInventory.FlatAppearance.BorderSize = 0;
            btnInventory.FlatAppearance.MouseOverBackColor = Color.White;
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.Location = new Point(0, 316);
            btnInventory.Name = "btnInventory";
            btnInventory.Padding = new Padding(20, 0, 0, 0);
            btnInventory.Size = new Size(250, 65);
            btnInventory.TabIndex = 3;
            btnInventory.Text = "📦 Inventory";
            btnInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += btnInventory_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.LightGray;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.White;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(0, 251);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(20, 0, 0, 0);
            btnDashboard.Size = new Size(250, 65);
            btnDashboard.TabIndex = 2;
            btnDashboard.Text = "🏠︎ Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // profilePanel
            // 
            profilePanel.Controls.Add(lblName);
            profilePanel.Controls.Add(pictureBox1);
            profilePanel.Dock = DockStyle.Top;
            profilePanel.Location = new Point(0, 60);
            profilePanel.Name = "profilePanel";
            profilePanel.Size = new Size(250, 191);
            profilePanel.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(91, 145);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 19);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(58, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // menuPanel
            // 
            menuPanel.Controls.Add(label1);
            menuPanel.Controls.Add(btnMenu);
            menuPanel.Dock = DockStyle.Top;
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(250, 60);
            menuPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(82, 17);
            label1.Name = "label1";
            label1.Size = new Size(58, 23);
            label1.TabIndex = 1;
            label1.Text = "Menu";
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.LightGray;
            btnMenu.BackgroundImage = (Image)resources.GetObject("btnMenu.BackgroundImage");
            btnMenu.BackgroundImageLayout = ImageLayout.Stretch;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatAppearance.MouseOverBackColor = Color.White;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.ForeColor = SystemColors.ControlLight;
            btnMenu.Location = new Point(12, 6);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(50, 47);
            btnMenu.TabIndex = 0;
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += button1_Click;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(250, 55);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1319, 837);
            mainPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1569, 892);
            Controls.Add(mainPanel);
            Controls.Add(navPanel);
            Controls.Add(topPanel);
            Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            topPanel.ResumeLayout(false);
            navPanel.ResumeLayout(false);
            customerSubpanel.ResumeLayout(false);
            inventorySubpanel.ResumeLayout(false);
            profilePanel.ResumeLayout(false);
            profilePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuPanel.ResumeLayout(false);
            menuPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private Button btnExit;
        private Panel navPanel;
        private Panel mainPanel;
        private Panel menuPanel;
        private Button btnMenu;
        private Panel profilePanel;
        private Label lblName;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel inventorySubpanel;
        private Button btnInventory;
        private Button btnDashboard;
        private Button btnViewInventory;
        private Button btnAddInventory;
        private Panel customerSubpanel;
        private Button btnAddCustomer;
        private Button btnViewCustomer;
        private Button btnCustomer;
        private Button btnReports;
        private Button btnLogout;
        private Panel fillerPanel;
    }
}