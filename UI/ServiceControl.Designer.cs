namespace UI
{
    partial class ServiceControl
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
            txtName = new TextBox();
            txtTreatment = new TextBox();
            txtPrice = new TextBox();
            dgvService = new DataGridView();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lblName = new Label();
            lblTreatment = new Label();
            lblPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvService).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(110, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 6;
            // 
            // txtTreatment
            // 
            txtTreatment.Location = new Point(110, 60);
            txtTreatment.Name = "txtTreatment";
            txtTreatment.Size = new Size(200, 23);
            txtTreatment.TabIndex = 5;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(110, 100);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 23);
            txtPrice.TabIndex = 4;
            // 
            // dgvService
            // 
            dgvService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvService.Location = new Point(20, 150);
            dgvService.Name = "dgvService";
            dgvService.ReadOnly = true;
            dgvService.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvService.Size = new Size(720, 300);
            dgvService.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(330, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 30);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Ekle";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(330, 60);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 30);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Güncelle";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(330, 100);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Sil";
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(800, 25);
            lblName.TabIndex =4;
            lblName.Text = "Hizmet:";
            // 
            // lblTreatment
            // 
            lblTreatment.Location = new Point(20, 60);
            lblTreatment.Name = "lblTreatment";
            lblTreatment.Size = new Size(80, 25);
            lblTreatment.TabIndex = 0;
            lblTreatment.Text = "Açıklama:";
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(20, 100);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(80, 25);
            lblPrice.TabIndex = 0;
            lblPrice.Text = "Fiyat:";

            //EventHandlers

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
            dgvService.CellClick += dgvService_CellClick;
            // 
            // ServiceControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(dgvService);
            Controls.Add(txtPrice);
            Controls.Add(txtTreatment);
            Controls.Add(txtName);
            Controls.Add(lblPrice);
            Controls.Add(lblName);
            Controls.Add(lblTreatment);
            Name = "ServiceControl";
            Size = new Size(1211, 641);
            ((System.ComponentModel.ISupportInitialize)dgvService).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtTreatment;
        private TextBox txtPrice;
        private DataGridView dgvService;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label lblPrice;
        private Label lblTreatment;
        private Label lblName;
    }
}
