namespace UI.Controls
{
    partial class InvoiceControl
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
            txtCustomer = new TextBox();
            txtVehicle = new TextBox();
            btnChooseCustomer = new Button();
            btnChooseVehicle = new Button();
            btnChooseService = new Button();
            dgvServices = new DataGridView();
            lblTotalAmount = new Label();
            btnSave = new Button();
            btnNew = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            SuspendLayout();
            // 
            // txtCustomer
            // 
            txtCustomer.Location = new Point(20, 20);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(300, 23);
            txtCustomer.TabIndex = 0;
            txtCustomer.ReadOnly = true;
            // 
            // txtVehicle
            // 
            txtVehicle.Location = new Point(20, 60);
            txtVehicle.Name = "txtVehicle";
            txtVehicle.Size = new Size(300, 23);
            txtVehicle.TabIndex = 1;
            // 
            // btnChooseCustomer
            // 
            btnChooseCustomer.Location = new Point(330, 20);
            btnChooseCustomer.Name = "btnChooseCustomer";
            btnChooseCustomer.Size = new Size(100, 23);
            btnChooseCustomer.TabIndex = 2;
            btnChooseCustomer.Text = "Müşteri Seç";
            btnChooseCustomer.UseVisualStyleBackColor = true;
            btnChooseCustomer.Click += new EventHandler(btnChooseCustomer_Click);
            // 
            // btnChooseVehicle
            // 
            btnChooseVehicle.Location = new Point(330, 60);
            btnChooseVehicle.Name = "btnChooseVehicle";
            btnChooseVehicle.Size = new Size(100, 23);
            btnChooseVehicle.TabIndex = 3;
            btnChooseVehicle.Text = "Araç Seç";
            btnChooseVehicle.UseVisualStyleBackColor = true;
            btnChooseVehicle.Click += new EventHandler(btnChooseVehicle_Click);
            // 
            // btnChooseService
            // 
            btnChooseService.Location = new Point(20, 100);
            btnChooseService.Name = "btnChooseService";
            btnChooseService.Size = new Size(150, 30);
            btnChooseService.TabIndex = 4;
            btnChooseService.Text = "Hizmet Ekle";
            btnChooseService.UseVisualStyleBackColor = true;
            btnChooseService.Click += new EventHandler(btnChooseService_Click);
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Location = new System.Drawing.Point(20, 150);
            this.dgvServices.Name = "dgvHizmetler";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.RowTemplate.Height = 25;
            this.dgvServices.Size = new System.Drawing.Size(600, 200);
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(20, 370);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(200, 23);
            lblTotalAmount.TabIndex = 6;
            lblTotalAmount.Text = "Toplam: 0";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(400, 370);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 7;
            btnSave.Text = "Faturayı Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += new EventHandler(btnSave_Click);
            // 
            // btnNew
            // 
            btnNew.Location = new Point(520, 370);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(100, 30);
            btnNew.TabIndex = 8;
            btnNew.Text = "Yeni Fatura";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += new EventHandler(btnNew_Click);
            // 
            // InvoiceControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnNew);
            Controls.Add(btnSave);
            Controls.Add(lblTotalAmount);
            Controls.Add(dgvServices);
            Controls.Add(btnChooseService);
            Controls.Add(btnChooseVehicle);
            Controls.Add(btnChooseCustomer);
            Controls.Add(txtVehicle);
            Controls.Add(txtCustomer);
            Name = "InvoiceControl";
            Size = new Size(1090, 435);
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCustomer;
        private TextBox txtVehicle;
        private Button btnChooseCustomer;
        private Button btnChooseVehicle;
        private Button btnChooseService;
        private DataGridView dgvServices;
        private Label lblTotalAmount;
        private Button btnSave;
        private Button btnNew;
    }
}
