using Business.Abstract;
using DataAccess.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmVehicleChoose : Form
    {
        private readonly IVehicleService _vehicleDal;
        public Vehicle ChoosenVehicle { get; private set; }
        public FrmVehicleChoose(IVehicleService vehicleDal)
        {
            _vehicleDal = vehicleDal;
            InitializeComponent();
        }
        private void FrmVehicleChoose_Load(object sender, EventArgs e)
        {
            LoadVehicles();
        }
        private void LoadVehicles(string filter = "")
        {
            var list = _vehicleDal.VehicleList();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                list = list.Where(v => v.Marka.Contains(filter, StringComparison.OrdinalIgnoreCase)
                || v.Plaka.Contains(filter, StringComparison.OrdinalIgnoreCase)
                || v.Marka.Contains(filter, StringComparison.OrdinalIgnoreCase)
                || v.Müsteri_Adı.Contains(filter, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }
            dgvVehicles.DataSource = list;
            dgvVehicles.Columns["Id"].Visible = false;

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadVehicles(txtSearch.Text.Trim());
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            if(dgvVehicles.CurrentRow != null)
            {
                ChoosenVehicle = dgvVehicles.CurrentRow.DataBoundItem as Vehicle;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; Close(); }
    }
}
