namespace UI.Forms
{
    partial class FrmVehicleChoose
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
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnChoose = new Button();
            btnCancel = new Button();
            dgvVehicles = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 

            //txtSearch

            txtSearch.Location = new Point(12, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 23);
            txtSearch.TabIndex = 0;
            // btnSearch

            btnSearch.Location = new Point(270, 11);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 25);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Ara";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += new EventHandler(btnSearch_Click);

            //dgvCustomers
            dgvVehicles.AllowUserToAddRows = false;
            dgvVehicles.AllowUserToDeleteRows = false;
            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehicles.Location = new Point(12, 45);
            dgvVehicles.Name = "dgvCustomers";
            dgvVehicles.ReadOnly = true;
            dgvVehicles.RowTemplate.Height = 25;
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.Size = new Size(460, 250);
            dgvVehicles.TabIndex = 2;

            //btnChoose

            btnChoose.Location = new Point(316, 305);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new Size(75, 30);
            btnChoose.TabIndex = 3;
            btnChoose.Text = "Seç";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += new EventHandler(btnChoose_Click);

            //btnCancel

            btnCancel.Location = new Point(397, 305);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 30);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "İptal";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += new EventHandler(btnCancel_Click);
            // 
            // FrmVehicleChoose
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(   dgvVehicles);
            Controls.Add(btnCancel);
            Controls.Add(btnChoose);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Name = "FrmVehicleChoose";
            Text = "Araç Seç";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmVehicleChoose_Load);
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnChoose;
        private Button btnCancel;
        private DataGridView dgvVehicles;
    }
}