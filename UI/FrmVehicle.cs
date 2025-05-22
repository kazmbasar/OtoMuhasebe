using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
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
    public partial class FrmVehicle : Form
    {
        private readonly IVehicleService _vehicleService;
        private readonly ICustomerService _customerService;

        private int _selectedVehicleId = 0;
        public FrmVehicle(IVehicleService vehicleService, ICustomerService customerService)
        {
            InitializeComponent();
            _vehicleService = vehicleService;
            _customerService = customerService;
            LoadCustomers();
            LoadVehicles();
        }
        private void FrmVehicleLoad(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadVehicles();
        }
        private void LoadCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            
            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.ValueMember = "Id";
            cmbCustomer.DataSource = customers;
        }
        private void LoadVehicles()
        {
            dgvVehicle.DataSource = _vehicleService.GetAll();
            dgvVehicle.ClearSelection();
        }
        private void Clear()
        {
            txtPlate.Clear();
            txtBrand.Clear();
            txtModel.Clear();
            cmbCustomer.SelectedIndex = 0;
            _selectedVehicleId = 0;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newVehicle = new Vehicle
            {
                Plate = txtPlate.Text.Trim(),
                Brand = txtBrand.Text.Trim(),
                Model = txtModel.Text.Trim(),
                CustomerId = (int)cmbCustomer.SelectedValue,
            };
            
            _vehicleService.Add(newVehicle);
            LoadVehicles();
            Clear();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedVehicleId == 0)
                return;
            var vehicle = _vehicleService.GetById(_selectedVehicleId);
            if (vehicle == null) return;
            vehicle.Plate = txtPlate.Text.Trim();
            vehicle.Brand = txtBrand.Text.Trim();
            vehicle.Model = txtModel.Text.Trim();
            vehicle.CustomerId = (int)cmbCustomer.SelectedValue;
            _vehicleService.Update(vehicle);
            LoadVehicles();
            Clear();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedVehicleId == 0) return;
            _vehicleService.Delete(_vehicleService.GetById(_selectedVehicleId));
            LoadVehicles();
            Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void dgvVehicle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvVehicle.Rows[e.RowIndex];
                _selectedVehicleId = Convert.ToInt32(row.Cells["Id"].Value);
                txtPlate.Text = row.Cells["Plate"].Value.ToString();
                txtBrand.Text = row.Cells["Brand"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                cmbCustomer.SelectedValue = row.Cells["CustomerId"].Value;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var frm = new FrmVehicleSearch(new VehicleManager(new EfVehicleDal()));
            if (frm.ShowDialog() == DialogResult.OK && frm.ChosenVehicle != null)
            {
                var vehicle = frm.ChosenVehicle;
                _selectedVehicleId = vehicle.Id;
                txtPlate.Text = vehicle.Plate;
                txtBrand.Text = vehicle.Brand;
                txtModel.Text = vehicle.Model;
                cmbCustomer.SelectedValue = vehicle.CustomerId;
            }
        }
    }
}
