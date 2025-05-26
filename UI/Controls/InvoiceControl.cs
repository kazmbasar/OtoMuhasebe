﻿using Business.Abstract;
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
        private readonly ICustomerService _customerService;
        private readonly IVehicleService _vehicleService;
        private readonly ITreatmentService _treatmentService;
        private CustomerDto _choosenCustomer;
        private VehicleDto _choosenVehicle;
        private List<SelectedServiceDto> _choosenServices ;
        private decimal _totalAmount = 0;
        public InvoiceControl(InvoiceService invoiceService, ICustomerService customerService, IVehicleService vehicleService, ITreatmentService treatmentService)
        {   
           _customerService = customerService;
            _vehicleService = vehicleService;
            _treatmentService = treatmentService;
            _invoiceService = invoiceService;
            InitializeComponent();
        }
        private void btnChooseCustomer_Click(object sender, EventArgs e)
        {
            var form = new FrmCustomerChoose(_customerService);
            if(form.ShowDialog() == DialogResult.OK)
            {
                _choosenCustomer = form.ChosenCustomer;
                txtCustomer.Text = _choosenCustomer.Name;
            }
        }
        private void btnChooseVehicle_Click(object sender, EventArgs e)
        {
            //if (_choosenCustomer == null)
            //{

            //    var form = new FrmVehicleChoose(_vehicleService, _choosenCustomer);
            //    if (form.ShowDialog() == DialogResult.OK)
            //    {
            //        _choosenVehicle = form.ChoosenVehicle;
            //        txtVehicle.Text = _choosenVehicle.Plaka;
            //    }
            //}
            if (_choosenCustomer != null)
            {
                var form1 = new FrmVehicleChoose(_vehicleService, _choosenCustomer);
                if (form1.ShowDialog() == DialogResult.OK)
                {
                    _choosenVehicle = form1.ChoosenVehicle;
                    txtVehicle.Text = _choosenVehicle.Plaka;
                }
            }
        }
        private void btnChooseService_Click(object sender, EventArgs e)
        {
            using (var form = new FrmServiceChoose(_treatmentService))
            {
                if(form.ShowDialog() == DialogResult.OK)
                {
                    foreach (var service in form.ChoosenServices)
                    {
                        if(!_choosenServices.Any(s=>s.Id == service.Id))
                        {
                            _choosenServices.Add(new SelectedServiceDto
                            {
                                Id = service.Id,
                                Servis_Adi = service.Name,
                                Fiyat = service.Price,
                            });
                        }
                    }

                }
                dgvServices.DataSource = null;
                dgvServices.DataSource = _choosenServices;
                //dgvServices.Columns["Id"].Visible = false;
                //dgvServices.Columns["Name"].HeaderText = "Hizmet Adı";
                dgvServices.Columns["Fiyat"].DefaultCellStyle.Format = "C2";
                
                
            }
          
        }
        //private void CalculateTotalAmount()
        //{
        //    _totalAmount = _choosenServices.Sum(x => x.Price);
        //    lblTotalAmount.Text = $"Toplam: {_totalAmount}";
        //}
        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if(_choosenCustomer ==null  || _choosenVehicle == null || !_choosenServices.Any())
        //    {
        //        MessageBox.Show("Lütfen müşteri, araç ve en az bir hizmet seçiniz");
        //        return;
        //    } 
        //    var invoice = new Invoice
        //    {
        //        CustomerId = _choosenCustomer.Id,
        //        VehicleId = _choosenVehicle.Id,
        //        Date = DateTime.Now,
        //        TotalAmount = _totalAmount,
        //        InvoiceDetails = _choosenServices.Select(h=> new InvoiceDetail
        //        {
        //            Id = h.Id,
        //            Price = h.Price,

        //        }).ToList()
        //    };
        //     _invoiceService.Add(invoice);
        //    MessageBox.Show("Fatura başarıyla kaydedildi");
            
        //}
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
