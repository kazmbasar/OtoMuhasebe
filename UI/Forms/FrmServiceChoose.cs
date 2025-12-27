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
    public partial class FrmServiceChoose : Form
    {
        private readonly ITreatmentService _tServiceDal;
        public List<Service> ChoosenServices { get;  set; }
        public FrmServiceChoose(ITreatmentService tServiceDal)
        {
            _tServiceDal = tServiceDal;
            InitializeComponent();
            ChoosenServices = new List<Service>();
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
            ;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadServices(txtSearch.Text.Trim());
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvServices.SelectedRows)
            {
                if (row.DataBoundItem is ServiceDto dto)
                {
                    if (!ChoosenServices.Any(s => s.Id == dto.Id))
                    {
                        var service = new Service
                        {
                            Id = dto.Id,
                            Name = dto.Isim,
                            Price = dto.Fiyat,
                        };
                        ChoosenServices.Add(service);
                    }
                }
            }

            MessageBox.Show($"Toplam eklenen hizmet: {ChoosenServices.Count}");
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
