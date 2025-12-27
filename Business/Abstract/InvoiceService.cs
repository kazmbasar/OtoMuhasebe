using DataAccess.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface InvoiceService
    {
        void Add(Invoice invoice);
        List<Invoice> GetAllInvoices();
        void DeleteInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        Invoice? GetById(int id);
        List<InvoiceDto> InvoiceLists();
        List<InvoiceListDto> GetInvoiceList();
        List<InvoiceListDto> GetByCustomerId(int customerId);
        
    }
}
