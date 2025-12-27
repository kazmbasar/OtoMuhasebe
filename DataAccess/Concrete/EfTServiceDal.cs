using DataAccess.Abstract;
using DataAccess.Contexts;
using DataAccess.DTOs;
using DataAccess.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfTServiceDal : EfEntityRepositoryBase<Service, OtoMuhasebeContext>, ITServiceDal
    {
        public List<ServiceDto> ListServices()
        {
            using (OtoMuhasebeContext context = new OtoMuhasebeContext())
            {
                var result = context.Services.Select(s=> new ServiceDto
                {
                    Id = s.Id,
                    Aciklama = s.Description,
                    Fiyat = s.Price,
                    Isim = s.Name,
                });
                return result.ToList();
            }
        }

        public List<PerformedServiceDto> GetPerformedServices()
        {
            using (OtoMuhasebeContext context = new OtoMuhasebeContext())
            {
                var result = from s in context.Services
                             join v in context.Vehicles on s.VehicleId equals v.Id
                             join c in context.Customers on v.CustomerId equals c.Id
                             select new PerformedServiceDto
                             {
                                 Id = s.Id,
                                 ServiceName = s.Name,
                                 Description = s.Description,
                                 Price = s.Price,
                                 Date = s.Date,
                                 Plate = v.Plate,
                                 CustomerName = c.Name
                             };
                return result.ToList();
            }
        }

        public List<PerformedServiceDto> GetPerformedServicesByCustomer(int customerId)
        {
            using (OtoMuhasebeContext context = new OtoMuhasebeContext())
            {
                var result = from s in context.Services
                             join v in context.Vehicles on s.VehicleId equals v.Id
                             join c in context.Customers on v.CustomerId equals c.Id
                             where c.Id == customerId
                             select new PerformedServiceDto
                             {
                                 Id = s.Id,
                                 ServiceName = s.Name,
                                 Description = s.Description,
                                 Price = s.Price,
                                 Date = s.Date,
                                 Plate = v.Plate,
                                 CustomerName = c.Name
                             };
                return result.ToList();
            }
        }
    }
}
