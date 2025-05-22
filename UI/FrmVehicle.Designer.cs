namespace UI
{
    partial class FrmVehicle
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
            
            txtPlate = new TextBox();
            txtModel = new TextBox();
            txtBrand = new TextBox();
            lblPlate = new Label();
            lblBrand = new Label();
            lblCustomer = new Label();
            lblModel = new Label();
            cmbCustomer = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnSearch = new Button();
            dgvVehicle = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvVehicle).BeginInit();
            SuspendLayout();
            // 
            // txtPlate
            // 
            txtPlate.Location = new Point(120, 20);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(200, 23);
            txtPlate.TabIndex = 13;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(120, 60);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(200, 23);
            txtModel.TabIndex = 12;
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(120, 100);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(100, 23);
            txtBrand.TabIndex = 11;
            // 
            // lblPlate
            // 
            lblPlate.Location = new Point(20, 20);
            lblPlate.Name = "lblPlate";
            lblPlate.Size = new Size(100, 23);
            lblPlate.TabIndex = 10;
            lblPlate.Text = "Plaka:";
            // 
            // lblBrand
            // 
            lblBrand.Location = new Point(20, 60);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(100, 23);
            lblBrand.TabIndex = 9;
            lblBrand.Text = "Marka:";
            // 
            // lblCustomer
            // 
            lblCustomer.Location = new Point(20, 140);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(100, 23);
            lblCustomer.TabIndex = 8;
            lblCustomer.Text = "Müşteri:";
            // 
            // lblModel
            // 
            lblModel.Location = new Point(20, 100);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(100, 23);
            lblModel.TabIndex = 7;
            lblModel.Text = "Model:";
            // 
            // cmbCustomer
            // 
            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.Location = new Point(120, 180);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(250, 23);
            cmbCustomer.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(20, 230);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Ekle";
            btnAdd.Click += new EventHandler(btnAdd_Click);
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(130, 230);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Güncelle";
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(240, 230);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Sil";
            btnDelete.Click += new EventHandler(btnDelete_Click);
            // 
            // btnClear
            // 
            btnClear.Location = new Point(350, 230);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 35);
            btnClear.TabIndex = 2;
            btnClear.Text = "Temizle";
            btnClear.Click += new EventHandler(btnClear_Click);
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(460, 230);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 35);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Ara";
            btnSearch.Click += new EventHandler(btnSearch_Click);
            // 
            // dgvVehicle
            // 
            dgvVehicle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehicle.Location = new Point(20, 271);
            dgvVehicle.Name = "dgvVehicle";
            dgvVehicle.ReadOnly = true;
            dgvVehicle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicle.Size = new Size(760, 250);
            dgvVehicle.TabIndex = 0;
            dgvVehicle.CellClick += dgvVehicle_CellClick;
            // 
            // FrmVehicle
            // 
            ClientSize = new Size(800, 550);
            Controls.Add(dgvVehicle);
            Controls.Add(btnSearch);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(cmbCustomer);
            Controls.Add(lblModel);
            Controls.Add(lblCustomer);
            Controls.Add(lblBrand);
            Controls.Add(lblPlate);
            Controls.Add(txtBrand);
            Controls.Add(txtModel);
            Controls.Add(txtPlate);
            Name = "FrmVehicle";
            Text = "Araç Yönetimi";
            ((System.ComponentModel.ISupportInitialize)dgvVehicle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPlate;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtModel;
        private TextBox txtBrand;
        private Label lblPlate;
        private Label lblBrand;
        private Label lblCustomer;
        private Label lblModel;
        private ComboBox cmbCustomer;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnSearch;
        private DataGridView dgvVehicle;
    }
}