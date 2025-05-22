using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Domain.Entities;

namespace UI
{
    public partial class FrmCustomer : Form
    {
        private readonly ICustomerService _customerService;
        private int selectedId = -1;
        public FrmCustomer(ICustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;
            GetAll();
        }
        private void GetAll()
        {
            dgvCustomers.DataSource = _customerService.CustomerList();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                Name = txtName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Address = txtAdress.Text,
            };
            _customerService.Add(customer);
            GetAll();
            Clear();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId < 0) return;
            var customer = _customerService.GetCustomerById(selectedId);
            if (customer != null)
            {
                customer.Name = txtName.Text;
                customer.PhoneNumber = txtPhoneNumber.Text;
                customer.Address = txtAdress.Text;
                _customerService.Update(customer);
                GetAll();
                Clear();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId < 0) return;
            _customerService.Delete(_customerService.GetCustomerById(selectedId));
            GetAll();
            Clear();
        }



        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["Id"].Value);
                txtName.Text = dgvCustomers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtPhoneNumber.Text = dgvCustomers.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
                txtAdress.Text = dgvCustomers.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            }
        }
        private void Clear()
        {
            txtName.Clear();
            txtPhoneNumber.Clear();
            txtAdress.Clear();
            selectedId = -1;
        }
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            using (FrmCustomerSearch frmSearch = new FrmCustomerSearch(new CustomerManager(new EfCustomerDal())))
            {
                if (frmSearch.ShowDialog() == DialogResult.OK && frmSearch.ChoosenCustomer != null)
                {
                    var m = frmSearch.ChoosenCustomer;
                    selectedId = m.Id;
                    txtName.Text = m.Name;
                    txtPhoneNumber.Text = m.PhoneNumber;
                    txtAdress.Text = m.Address;
                }
            }
            
               

        }
    }
}


