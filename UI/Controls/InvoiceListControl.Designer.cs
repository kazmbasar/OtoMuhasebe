namespace UI.Controls
{
    partial class InvoiceListControl
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
            dgvInvoices = new System.Windows.Forms.DataGridView();
            //this.grpInvoiceDetails = new System.Windows.Forms.GroupBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblVehicle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            //this.dgvInvoiceDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dgvInvoices)).BeginInit();
            this.SuspendLayout();

            //dgvInvoices
            this.dgvInvoices.AllowUserToAddRows = false;
            this.dgvInvoices.AllowUserToDeleteRows = false;
            this.dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoices.MultiSelect = false;
            this.dgvInvoices.Location = new System.Drawing.Point(10, 10);
            this.dgvInvoices.Size = new System.Drawing.Size(500, 400);
            //this.dgvInvoices.CellClick += new DataGridViewCellEventHandler(this.dgvInvoices_CellClick);
            dgvInvoices.CellDoubleClick += new DataGridViewCellEventHandler(dgvInvoices_CellDoubleClick);
            //// 
            //// grpInvoiceDetails
            //// 
            //this.grpInvoiceDetails.Controls.Add(this.lblCustomer);
            //this.grpInvoiceDetails.Controls.Add(this.lblVehicle);
            //this.grpInvoiceDetails.Controls.Add(this.lblDate);
            //this.grpInvoiceDetails.Controls.Add(this.lblTotal);
            ////this.grpInvoiceDetails.Controls.Add(this.dgvInvoiceDetails);
            //this.grpInvoiceDetails.Location = new System.Drawing.Point(520, 10);
            //this.grpInvoiceDetails.Size = new System.Drawing.Size(500, 400);
            //this.grpInvoiceDetails.Text = "Fatura Detayı";
            //// 
            //// lblCustomer
            //// 
            //this.lblCustomer.Location = new System.Drawing.Point(10, 20);
            //this.lblCustomer.Size = new System.Drawing.Size(400, 20);
            //this.lblCustomer.Text = "Müşteri: ";

            //// 
            //// lblVehicle
            //// 
            //this.lblVehicle.Location = new System.Drawing.Point(10, 45);
            //this.lblVehicle.Size = new System.Drawing.Size(400, 20);
            //this.lblVehicle.Text = "Araç: ";

            //// 
            //// lblDate
            //// 
            //this.lblDate.Location = new System.Drawing.Point(10, 70);
            //this.lblDate.Size = new System.Drawing.Size(400, 20);
            //this.lblDate.Text = "Tarih: ";

            //// 
            //// lblTotal
            //// 
            //this.lblTotal.Location = new System.Drawing.Point(10, 95);
            //this.lblTotal.Size = new System.Drawing.Size(400, 20);
            //this.lblTotal.Text = "Toplam: ";

            // 
            // dgvInvoiceDetails
            // 
            //this.dgvInvoiceDetails.AllowUserToAddRows = false;
            //this.dgvInvoiceDetails.AllowUserToDeleteRows = false;
            //this.dgvInvoiceDetails.Location = new System.Drawing.Point(10, 130);
            //this.dgvInvoiceDetails.Size = new System.Drawing.Size(470, 250);
            //this.dgvInvoiceDetails.ReadOnly = true;
            //this.dgvInvoiceDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //InvoiceListControl

            this.Controls.Add(this.dgvInvoices);
            //this.Controls.Add(this.grpInvoiceDetails);
            this.Size = new System.Drawing.Size(1040, 430);
            Name = "InvoiceListControl";


            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.ResumeLayout(false);

        }
        private DataGridView dgvInvoices;

        //private GroupBox grpInvoiceDetails;
        private Label lblCustomer;
        private Label lblVehicle;
        private Label lblDate;
        private Label lblTotal;
        

        #endregion
    }
}
