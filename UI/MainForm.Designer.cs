namespace UI
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
            panelMain = new Panel();
            panelMenu = new Panel();
            btnCustomer = new Button();
            btnVehicle = new Button();
            panelTop = new Panel();
            lblHeader = new Label();
            btnService = new Button();
            btnInvoice = new Button();
            panelMenu.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(200, 60);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(961, 516);
            panelMain.TabIndex = 0;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(30, 30, 30);
            panelMenu.Controls.Add(btnCustomer);
            panelMenu.Controls.Add(btnVehicle);
            panelMenu.Controls.Add(btnService);
            panelMenu.Controls.Add(btnInvoice);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 60);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(200, 516);
            panelMenu.TabIndex = 1;
            // 
            // btnCustomer
            // 
            btnCustomer.BackColor = Color.FromArgb(50, 50, 50);
            btnCustomer.Dock = DockStyle.Top;
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.ForeColor = Color.White;
            btnCustomer.Location = new Point(0, 50);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(200, 50);
            btnCustomer.TabIndex = 0;
            btnCustomer.Text = "Müşteri kaydı yap";
            btnCustomer.UseVisualStyleBackColor = false;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnVehicle
            // 
            btnVehicle.BackColor = Color.FromArgb(50, 50, 50);
            btnVehicle.Dock = DockStyle.Top;
            btnVehicle.FlatStyle = FlatStyle.Flat;
            btnVehicle.ForeColor = Color.White;
            btnVehicle.Location = new Point(0, 0);
            btnVehicle.Name = "btnVehicle";
            btnVehicle.Size = new Size(200, 50);
            btnVehicle.TabIndex = 1;
            btnVehicle.Text = "Araç kaydı yap";
            btnVehicle.UseVisualStyleBackColor = false;
            btnVehicle.Click += btnVehicle_Click;
            //btnService

            btnService.Location = new Point(0, 100);
            btnService.Dock=DockStyle.Top;
            btnService.FlatStyle = FlatStyle.Flat;
            btnService.ForeColor = Color.White;
            btnService.Name = "btnService";
            btnService.Size = new Size(200, 50);
            btnService.Text = "Hizmet kaydı yap";
            btnService.UseVisualStyleBackColor = false;
            btnService.Click += btnService_Click;
            // 
            //btnInvoice
            btnInvoice.Location = new Point(0, 150);
            btnInvoice.Name = "btnInvoice";
            btnInvoice.Size = new Size(200, 50);
            btnInvoice.Text = "Fatura Oluştur";
            btnInvoice.UseVisualStyleBackColor = false;
            btnInvoice.FlatStyle = FlatStyle.Flat;
            btnInvoice.ForeColor = Color.White;
            btnInvoice.Click += btnInvoice_Click;
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(45, 45, 45);
            panelTop.Controls.Add(lblHeader);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1161, 60);
            panelTop.TabIndex = 2;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(1161, 60);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "OtoMuhasebe";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            ClientSize = new Size(1161, 576);
            Controls.Add(panelMain);
            Controls.Add(panelMenu);
            Controls.Add(panelTop);

            Name = "MainForm";
            panelMenu.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Panel panelMenu;
        private Panel panelMain;
        private Button btnCustomer;
        private Button btnVehicle;
        private Button btnService;
        private Label lblHeader;
        private Button btnInvoice;
    }
}