namespace UI
{
    partial class FrmVehicleSearch
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
            btnSearch = new Button();
            dgvVehicle = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvVehicle).BeginInit();
            SuspendLayout();
            // 
            // txtPlate
            // 
            txtPlate.Location = new Point(20, 20);
            txtPlate.Name = "txtPlate";
            txtPlate.PlaceholderText = "Plaka";
            txtPlate.Size = new Size(150, 23);
            txtPlate.TabIndex = 0;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(360, 20);
            txtModel.Name = "txtModel";
            txtModel.PlaceholderText = "Model";
            txtModel.Size = new Size(150, 23);
            txtModel.TabIndex = 2;
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(1900, 20);
            txtBrand.Name = "txtBrand";
            txtBrand.PlaceholderText = "Marka";
            txtBrand.Size = new Size(150, 23);
            txtBrand.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(360, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Ara";
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvVehicle
            // 
            dgvVehicle.Location = new Point(20, 60);
            dgvVehicle.Name = "dgvVehicle";
            dgvVehicle.ReadOnly = true;
            dgvVehicle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicle.Size = new Size(660, 300);
            dgvVehicle.TabIndex = 4;
            dgvVehicle.CellDoubleClick += dgvVehicle_CellDoubleClick;
            // 
            // FrmVehicleSearch
            // 
            ClientSize = new Size(700, 400);
            Controls.Add(txtPlate);
            Controls.Add(txtBrand);
            Controls.Add(txtModel);
            Controls.Add(btnSearch);
            Controls.Add(dgvVehicle);
            Name = "FrmVehicleSearch";
            Text = "Araç Arama";
            ((System.ComponentModel.ISupportInitialize)dgvVehicle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtPlate, txtBrand, txtModel;
        private Button btnSearch;
        private DataGridView dgvVehicle;

        #endregion
    }
}