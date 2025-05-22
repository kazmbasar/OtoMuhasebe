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
    public partial class ServiceControl : UserControl
    {
        private readonly ITreatmentService _service;
        private int _chosenServiceId = 0;
        public ServiceControl(ITreatmentService service)
        {
            _service = service;
            InitializeComponent();
            LoadServices();
        }
        private void LoadServices()
        {
            dgvService.DataSource = _service.ListServices();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var service = new Service
            {
                Name = txtName.Text,

                Description = txtTreatment.Text,
                Price = decimal.Parse(txtPrice.Text),

            };
            _service.Add(service);
            LoadServices();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_chosenServiceId == 0) return;
            var service = new Service
            {
                Id = _chosenServiceId,
                Name = txtName.Text,
                Description = txtTreatment.Text,
                Price = decimal.Parse(txtPrice.Text),
            };
            _service.Update(service);
            LoadServices();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_chosenServiceId == 0) return;
            _service.Delete(_service.GetById(_chosenServiceId));
            LoadServices();
        }
        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _chosenServiceId = Convert.ToInt32(dgvService.Rows[e.RowIndex].Cells["Id"].Value);
                txtName.Text = dgvService.Rows[e.RowIndex].Cells["Isim"].Value.ToString();
                txtTreatment.Text = dgvService.Rows[e.RowIndex].Cells["Aciklama"].Value.ToString();
                txtPrice.Text = dgvService.Rows[e.RowIndex].Cells["Fiyat"].Value.ToString();
            }
        }
    }
}
