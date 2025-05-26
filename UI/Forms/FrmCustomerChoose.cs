
using Business.Abstract;
using DataAccess.Abstract;
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

namespace UI.Forms
{
    public partial class FrmCustomerChoose : Form
    {
        private readonly ICustomerService _customerService;
        public CustomerDto ChosenCustomer { get; private set; }
        public FrmCustomerChoose(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            InitializeComponent();
        }
        private void FrmCustomerChoose_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }
        private void LoadCustomers(string filter ="")
        {
            var list = _customerService.CustomerList();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                list = list.
                    Where(m=> m.Name.Contains(filter,StringComparison.OrdinalIgnoreCase) ||
                m.PhoneNumber.Contains(filter,StringComparison.OrdinalIgnoreCase)).ToList();
            }
            dgvCustomers.DataSource = list;
            dgvCustomers.Columns["Id"].Visible = false;
            //dgvCustomers.Columns["Vehicle"].Visible = false;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCustomers(txtSearch.Text.Trim());
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            if(dgvCustomers.CurrentRow != null)
            {
                ChosenCustomer = (CustomerDto)dgvCustomers.CurrentRow.DataBoundItem;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
