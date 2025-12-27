using DataAccess.DTOs;
using DataAccess.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface InvoiceDal : IEntityRepository<Invoice>
    {
        Invoice GetById(int id);
        List<InvoiceDto> InvoiceLists();
        List<InvoiceListDto> GetInvoiceList();
        List<InvoiceListDto> GetByCustomerId(int customerId);
        
    }
}
