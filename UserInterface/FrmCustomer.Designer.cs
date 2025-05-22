namespace UserInterface
{
    partial class FrmCustomer
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblAdress = new System.Windows.Forms.Label();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(468, 74);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Ad Soyad";
            this.lblName.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(446, 90);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(468, 130);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(43, 13);
            this.lblPhoneNumber.TabIndex = 2;
            this.lblPhoneNumber.Text = "Telefon";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(446, 162);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(100, 20);
            this.txtPhoneNumber.TabIndex = 3;
            // 
            // lblAdress
            // 
            this.lblAdress.AutoSize = true;
            this.lblAdress.Location = new System.Drawing.Point(468, 208);
            this.lblAdress.Name = "lblAdress";
            this.lblAdress.Size = new System.Drawing.Size(34, 13);
            this.lblAdress.TabIndex = 4;
            this.lblAdress.Text = "Adres";
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(446, 235);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(100, 20);
            this.txtAdress.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(380, 313);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(481, 313);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            this.btnDelete.Location = new System.Drawing.Point(585, 313);
            this.btnDelete.Name = "btnSil";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(54, 130);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.Size = new System.Drawing.Size(240, 150);
            this.dgvCustomers.TabIndex = 9;
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.lblAdress);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "FrmCustomer";
            this.Text = "Müşteri";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblAdress;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvCustomers;

        //private void InitializeComponent()
        //{
        //    this.txtName = new System.Windows.Forms.TextBox();
        //    this.txtPhoneNumber = new System.Windows.Forms.TextBox();
        //    this.txtAdress = new System.Windows.Forms.TextBox();
        //    this.btnAdd = new System.Windows.Forms.Button();
        //    this.btnUpdate = new System.Windows.Forms.Button();
        //    this.btnDelete = new System.Windows.Forms.Button();
        //    this.dgvCustomers = new System.Windows.Forms.DataGridView();
        //    this.lblName = new System.Windows.Forms.Label();
        //    this.lblPhoneNumber = new System.Windows.Forms.Label();
        //    this.lblAdress = new System.Windows.Forms.Label();
        //    ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
        //    this.SuspendLayout();

        //    // lblAdSoyad
        //    this.lblName.AutoSize = true;
        //    this.lblName.Location = new System.Drawing.Point(20, 20);
        //    this.lblName.Text = "Ad Soyad:";

        //    // txtAdSoyad
        //    this.txtName.Location = new System.Drawing.Point(100, 17);
        //    this.txtName.Size = new System.Drawing.Size(200, 22);

        //    // lblTelefon
        //    this.lblPhoneNumber.AutoSize = true;
        //    this.lblPhoneNumber.Location = new System.Drawing.Point(20, 55);
        //    this.lblPhoneNumber.Text = "Telefon:";

        //    // txtTelefon
        //    this.txtPhoneNumber.Location = new System.Drawing.Point(100, 52);
        //    this.txtPhoneNumber.Size = new System.Drawing.Size(200, 22);

        //    // lblAdres
        //    this.lblAdress.AutoSize = true;
        //    this.lblAdress.Location = new System.Drawing.Point(20, 90);
        //    this.lblAdress.Text = "Adres:";

        //    // txtAdres
        //    this.txtAdress.Location = new System.Drawing.Point(100, 87);
        //    this.txtAdress.Size = new System.Drawing.Size(200, 60);
        //    this.txtAdress.Multiline = true;

        //    // btnEkle
        //    this.btnAdd.Location = new System.Drawing.Point(320, 17);
        //    this.btnAdd.Size = new System.Drawing.Size(100, 30);
        //    this.btnAdd.Text = "Ekle";
        //    this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

        //    // btnGuncelle
        //    this.btnUpdate.Location = new System.Drawing.Point(320, 52);
        //    this.btnUpdate.Size = new System.Drawing.Size(100, 30);
        //    this.btnUpdate.Text = "Güncelle";
        //    this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

        //    // btnSil
        //    this.btnDelete.Location = new System.Drawing.Point(320, 87);
        //    this.btnDelete.Size = new System.Drawing.Size(100, 30);
        //    this.btnDelete.Text = "Sil";
        //    this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

        //    // dgvMusteriler
        //    this.dgvCustomers.Location = new System.Drawing.Point(20, 160);
        //    this.dgvCustomers.Size = new System.Drawing.Size(600, 250);
        //    this.dgvCustomers.ReadOnly = true;
        //    this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        //    this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        //    this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);

        //    // FrmMusteri
        //    this.ClientSize = new System.Drawing.Size(650, 430);
        //    this.Controls.Add(this.txtName);
        //    this.Controls.Add(this.txtPhoneNumber);
        //    this.Controls.Add(this.txtAdress);
        //    this.Controls.Add(this.btnAdd);
        //    this.Controls.Add(this.btnUpdate);
        //    this.Controls.Add(this.btnDelete);
        //    this.Controls.Add(this.dgvCustomers);
        //    this.Controls.Add(this.lblName);
        //    this.Controls.Add(this.lblPhoneNumber);
        //    this.Controls.Add(this.lblAdress);
        //    this.Text = "Müşteri Yönetimi";
        //    ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
        //    this.ResumeLayout(false);
        //    this.PerformLayout();
        //}
    }
}
   


        

 