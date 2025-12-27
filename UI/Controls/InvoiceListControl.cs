using Business.Abstract;
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

namespace UI.Controls
{
    public partial class InvoiceListControl : UserControl
    {
        private readonly InvoiceService _invoiceService;
        private readonly ICustomerService _customerService;
        private readonly IVehicleService _vehicleService;
        private readonly ITreatmentService _treatmentService;
        private InvoiceControl _invoiceControl;
        public Action<UserControl> OnOpenControl { get; set; }
        public InvoiceListControl(InvoiceService invoiceService, ICustomerService customerService, IVehicleService vehicleService,ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
            _invoiceService = invoiceService;
            
            _customerService = customerService;
            _vehicleService = vehicleService;
            InitializeComponent();
            LoadInvoices();
        }
        private void LoadInvoices()
        {
            var invoices = _invoiceService.GetAllInvoices();
            dgvInvoices.DataSource = invoices.Select(i => new
            {
                i.Id,
                Musteri = _customerService.GetCustomerById(i.CustomerId).Name,
                Araç = _vehicleService.GetById(i.VehicleId).Plate,
                Tarih = i.Date.ToShortDateString(),
                Toplam = i.TotalAmount,
            }).ToList();
            dgvInvoices.Columns["Id"].Visible = false;
        }

      
            
            
        //}
        private void dgvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvInvoices.Rows[e.RowIndex];
                var invoiceId = (int)selectedRow.Cells["Id"].Value;

                var invoice = _invoiceService.GetById(invoiceId);
                var invoiceControl = new InvoiceControl(_invoiceService, _customerService, _vehicleService, _treatmentService);
                invoiceControl.LoadInvoiceForEdit(invoice);

                // Dışarıya bildir — varsa panelde bu kontrolü göster
                OnOpenControl?.Invoke(invoiceControl);
            }
        }

    }
}
