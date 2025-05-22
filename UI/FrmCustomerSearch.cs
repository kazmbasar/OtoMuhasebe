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
    public partial class FrmCustomerSearch : Form
    {
        private ICustomerService _customerService;
        public Customer ChoosenCustomer { get; private set; }
        public FrmCustomerSearch(ICustomerService customerService)
        {

            InitializeComponent();
            _customerService = customerService;
        }
        private void FrmCustomerSearch_Load(object sender, EventArgs e)
        {
            List();
        }
        private void List(string filter = "")
        {
           dgvCustomer.DataSource =  _customerService.GetCustomerByName(filter);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List(txtSearch.Text.Trim());
        }
        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                int id = Convert.ToInt32(dgvCustomer.Rows[e.RowIndex].Cells["Id"].Value);
                ChoosenCustomer = _customerService.GetCustomerById(id);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
