using DataAccess.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface InvoiceDetailService 
    {
        void Add(InvoiceDetail invoiceDetail);
        void Update(InvoiceDetail invoiceDetail);
        void Delete(InvoiceDetail invoiceDetail);
        List<InvoiceDetail> GetById(int id);
        List<InvoiceDetailDto> InvoiceDetailList(int id);
    }
}
