using Business.Abstract;
using DataAccess.Abstract;
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
    public partial class FrmServiceChoose : Form
    {
        private readonly ITreatmentService _tServiceDal;
        public Service ChoosenService { get; private set; }
        public FrmServiceChoose(ITreatmentService tServiceDal)
        {
            _tServiceDal = tServiceDal;
            InitializeComponent();
        }

        private void FrmServiceChoose_Load(object sender, EventArgs e)
        {
            LoadServices();
        }
        private void LoadServices(string filter="")
        {
            var list = _tServiceDal.ListServices();
            if(!string.IsNullOrWhiteSpace(filter) )
            {
                list = list.Where(s=>  
                s.Isim.Contains(filter,StringComparison.OrdinalIgnoreCase) ||
                s.Aciklama.Contains(filter,StringComparison.OrdinalIgnoreCase)).ToList();
            }
            dgvServices.DataSource = list;
            dgvServices.Columns["Id"].Visible = false;
            dgvServices.Columns["Fiyat"].Visible = false;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadServices(txtSearch.Text.Trim());
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow != null)
            {
                ChoosenService = dgvServices.CurrentRow.DataBoundItem as Service;
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
