using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Controls;

namespace UI
{
    public partial class MainForm : Form
    {
        private readonly ICustomerService _customerService;
        private readonly IVehicleService _vehicleService;
        private readonly ITreatmentService _treatmentService;
        private readonly InvoiceService _invoiceService;
        public MainForm(ICustomerService customerService,IVehicleService vehicleService, ITreatmentService treatmentService, InvoiceService invoiceService)
        {
            _customerService = customerService;
            _vehicleService = vehicleService;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            _treatmentService = treatmentService;
            _invoiceService = invoiceService;
        }
        private void LoadUserControl(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            LoadUserControl(new CustomerControl(_customerService));
        }
        private void btnVehicle_Click(object sender, EventArgs e)
        {
            LoadUserControl(new VehicleControl(_customerService,_vehicleService));
        }
        private void btnService_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ServiceControl(_treatmentService));
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            LoadUserControl(new InvoiceControl(_invoiceService,_customerService,_vehicleService,_treatmentService));

        }
    }
}
