using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.DTOs;
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
using UI.Forms;

namespace UI.Controls
{
    public partial class InvoiceControl : UserControl
    {
        private readonly InvoiceService _invoiceService;
        private readonly ICustomerService _customerDal;
        private readonly IVehicleService _vehicleDal;
        private readonly ITreatmentService _tServiceDal;
        private Customer _choosenCustomer;
        private Vehicle _choosenVehicle;
        private List<Service> _choosenServices = new();
        private decimal _totalAmount = 0;
        public InvoiceControl(InvoiceService invoiceService, ICustomerService customerDal, IVehicleService vehicleDal, ITreatmentService tServiceDal)
        {   
            _customerDal= customerDal;
            _vehicleDal= vehicleDal;
            _tServiceDal= tServiceDal;
            _invoiceService = invoiceService;
            InitializeComponent();
        }
        private void btnChooseCustomer_Click(object sender, EventArgs e)
        {
            var form = new FrmCustomerChoose(_customerDal);
            if(form.ShowDialog() == DialogResult.OK)
            {
                _choosenCustomer = form.ChosenCustomer;
                txtCustomer.Text = _choosenCustomer.Name;
            }
        }
        private void btnChooseVehicle_Click(object sender, EventArgs e)
        {
            var form = new FrmVehicleChoose(_vehicleDal);
            if(form.ShowDialog() == DialogResult.OK)
            {
                _choosenVehicle = form.ChoosenVehicle;
                txtVehicle.Text = _choosenVehicle.Plate;
            }
        }
        private void btnChooseService_Click(object sender, EventArgs e)
        {
            var form = new FrmServiceChoose(_tServiceDal);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var service = form.ChoosenService;
                _choosenServices.Add(service);
                dgvServices.DataSource = null;
                dgvServices.DataSource = _choosenServices;
                dgvServices.Columns["Id"].Visible = false;
                CalculateTotalAmount();
            }
        }
        private void CalculateTotalAmount()
        {
            _totalAmount = _choosenServices.Sum(x => x.Price);
            lblTotalAmount.Text = $"Toplam: {_totalAmount}";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_choosenCustomer ==null  || _choosenVehicle == null || !_choosenServices.Any())
            {
                MessageBox.Show("Lütfen müşteri, araç ve en az bir hizmet seçiniz");
                return;
            } 
            var invoice = new Invoice
            {
                CustomerId = _choosenCustomer.Id,
                VehicleId = _choosenVehicle.Id,
                Date = DateTime.Now,
                TotalAmount = _totalAmount,
                InvoiceDetails = _choosenServices.Select(h=> new InvoiceDetail
                {
                    Id = h.Id,
                    Price = h.Price,

                }).ToList()
            };
             _invoiceService.Add(invoice);
            MessageBox.Show("Fatura başarıyla kaydedildi");
            
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            _choosenCustomer = null;
            _choosenServices.Clear();
            _choosenVehicle = null;
            txtCustomer.Clear();
            txtVehicle.Clear();
            dgvServices.DataSource = null;
            lblTotalAmount.Text = "Toplam: 0"; 
        }

    }
}
