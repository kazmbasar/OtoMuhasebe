using Business.Abstract;
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

namespace UI
{
    public partial class FrmVehicleSearch : Form
    {
        private readonly IVehicleService _vehicleService;
        public Vehicle ChosenVehicle { get; private set; }
        public FrmVehicleSearch(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string plate = txtPlate.Text.ToLower();
            string brand = txtBrand.Text.ToLower();
            string model = txtModel.Text.ToLower();

            var result = _vehicleService.GetAll().Where(a =>
            a.Plate.ToLower().Contains(plate) &&
            a.Brand.ToLower().Contains(brand) &&
            a.Model.ToLower().Contains(model))
                .ToList() ;
            dgvVehicle.DataSource = result ;
        }
        private void dgvVehicle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var row = dgvVehicle.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                ChosenVehicle = _vehicleService.GetById(id);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
