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
    public class InvoiceManager : InvoiceService
    {

        InvoiceDal _invoiceDal;

        public InvoiceManager(InvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;

        }


        public void Add(Invoice invoice)
        {
            _invoiceDal.Add(invoice);
        }

        public void DeleteInvoice(Invoice invoice)
        {
            _invoiceDal.Delete(invoice);
        }

        public List<Invoice> GetAllInvoices()
        {
            return _invoiceDal.GetAll();
        }

        public Invoice GetById(int id)
        {
            return _invoiceDal.GetById(id);
        }

        public List<InvoiceListDto> GetInvoiceList()
        {
            return _invoiceDal.GetInvoiceList();
        }

        public List<InvoiceDto> InvoiceLists()
        { 
            return _invoiceDal.InvoiceLists();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _invoiceDal.Update(invoice);
        }

        public List<InvoiceListDto> GetByCustomerId(int customerId)
        {
            return _invoiceDal.GetByCustomerId(customerId);
        }
    }
}
