using DataAccess.Abstract;
using DataAccess.Contexts;
using DataAccess.DTOs;
using DataAccess.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfInvoiceDetailDal : EfEntityRepositoryBase<InvoiceDetail, OtoMuhasebeContext>, InvoiceDetailDal
    {
        public List<InvoiceDetail> GetById(int id)
        {
            using (OtoMuhasebeContext context = new OtoMuhasebeContext())
            {
                var res = context.InvoiceDetails
                    .Include(i => i.Service)
                    .Where(i => i.InvoiceId == id).ToList();
                return res;
            }
        }
        public List<InvoiceDetailDto> InvoiceDetailList(int id)
        {
            using (OtoMuhasebeContext context = new OtoMuhasebeContext())
            {
                var res = context.InvoiceDetails
                    .Include(fd=> fd.Service)
                    .Where(fd=>  fd.InvoiceId == id)
                    .Select(fd=> new InvoiceDetailDto
                    {
                        Id = fd.Id,
                        Hizmet_Adi = fd.Service.Name,
                        Birim_Fiyat = fd.Service.Price,
                        Adet = fd.Amount,
                    }).ToList();
                return res;
            }
        }
    }
}
