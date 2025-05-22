using System.ComponentModel;

namespace UI
{
    partial class FrmCustomerSearch
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
            lblSearch = new Label();
            dgvCustomer = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dgvCustomer)).BeginInit();
            SuspendLayout();
            //lblSearch

            lblSearch.AutoSize = true;
            lblSearch.Location = new System.Drawing.Point(20, 20);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(32, 16);
            lblSearch.Text = "Ara:";

            //txtSearch

            txtSearch.Location = new System.Drawing.Point(60, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 22);
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);

            //dgvCustomer

            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AllowUserToDeleteRows = false;
            dgvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomer.Location = new System.Drawing.Point(20, 60);
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.ReadOnly = true;
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomer.Size = new System.Drawing.Size(500, 300);
            dgvCustomer.CellDoubleClick += new DataGridViewCellEventHandler(dgvCustomer_CellDoubleClick);

            //FrmCustomerSearch

            AutoScaleDimensions = new SizeF(8f, 16f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(500, 300);
            Controls.Add(txtSearch);
            Controls.Add(dgvCustomer);
            Controls.Add(lblSearch);
            Name = "FrmCustomerSearch";
            Text = "Müşteri Ara";
            Load += new EventHandler(FrmCustomerSearch_Load);
            ((ISupportInitialize)dgvCustomer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private DataGridView dgvCustomer;

        private Label lblSearch;
        
       
    }
}