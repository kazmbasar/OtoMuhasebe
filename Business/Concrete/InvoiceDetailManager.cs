using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InvoiceDetailManager : InvoiceDetailService
    {
        InvoiceDetailDal _invoiceDetailDal;
        public InvoiceDetailManager(InvoiceDetailDal invoiceDetailDal)
        {
            _invoiceDetailDal = invoiceDetailDal;
        }
        public void Add(InvoiceDetail invoiceDetail)
        {
           _invoiceDetailDal.Add(invoiceDetail);
        }

        public void Delete(InvoiceDetail invoiceDetail)
        {
            _invoiceDetailDal.Delete(invoiceDetail);
        }

        public List<InvoiceDetail> GetById(int id)
        { 
            return _invoiceDetailDal.GetById(id);
        }

        public List<InvoiceDetailDto> InvoiceDetailList(int id)
        {
            return _invoiceDetailDal.InvoiceDetailList(id);
        }

        public void Update(InvoiceDetail invoiceDetail)
        {
            _invoiceDetailDal.Update(invoiceDetail);
        }
    }
}
