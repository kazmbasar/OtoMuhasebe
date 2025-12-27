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
    public class EfInvoiceDal : EfEntityRepositoryBase<Invoice, OtoMuhasebeContext>, InvoiceDal
    {
        public Invoice GetById(int id)
        {
            using (OtoMuhasebeContext context = new OtoMuhasebeContext())
            {
                var res = context.Invoices
                    .Include(i => i.Customer)
                    .Include(i => i.Vehicle)
                    .Include(i => i.InvoiceDetails!)
                    .ThenInclude(id => id.Service)
                    .FirstOrDefault(i => i.Id == id);

                return res;
            }

        }



        public List<InvoiceListDto> GetInvoiceList()
        {
            using (OtoMuhasebeContext context = new OtoMuhasebeContext())
            {
                var res = context.Invoices.
                    Include(i => i.Customer)
                    .Include(i => i.Vehicle)
                    .Select(i => new InvoiceListDto
                    {
                        Id = i.Id,
                        CustomerName = i.Customer.Name,
                        Plate = i.Vehicle.Plate,
                        Date = i.Date,
                        TotalAmount = i.TotalAmount,
                    }).ToList();
                return res;
            }

        }

        public List<InvoiceDto> InvoiceLists()
        {
            using (OtoMuhasebeContext context = new OtoMuhasebeContext())
            {
                var res = context.Invoices
                    .Include(i => i.Customer)
                    .Include(i => i.Vehicle)
                    .Select(i => new InvoiceDto
                    {
                        Id = i.Id,
                        Musteri_Adi = i.Customer.Name,
                        Arac_Plaka = i.Vehicle.Plate,
                        Tarih = i.Date,
                        Toplam_Tutar = i.InvoiceDetails.Sum(fd => fd.Amount * fd.Service.Price)
                    }).ToList();
                return res;
            }
        }

        public List<InvoiceListDto> GetByCustomerId(int customerId)
        {
            using (OtoMuhasebeContext context = new OtoMuhasebeContext())
            {
                var res = context.Invoices.
                    Include(i => i.Customer)
                    .Include(i => i.Vehicle)
                    .Where(i => i.CustomerId == customerId)
                    .Select(i => new InvoiceListDto
                    {
                        Id = i.Id,
                        CustomerName = i.Customer.Name,
                        Plate = i.Vehicle.Plate,
                        Date = i.Date,
                        TotalAmount = i.TotalAmount,
                    }).OrderByDescending(i => i.Date).ToList();
                return res;
            }
        }
    }
}
