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
    public class EfVehicleDal : EfEntityRepositoryBase<Vehicle, OtoMuhasebeContext>, IVehicleDal
    {
        public List<VehicleDto> GetByCustomerId(int customerId)
        {
            using (OtoMuhasebeContext context = new OtoMuhasebeContext())
            {
                var res = from c in context.Customers
                          join v in context.Vehicles
                          on c.Id equals v.CustomerId
                          select new VehicleDto
                          {
                              Id = v.Id,
                              Marka = v.Model,
                              Plaka = v.Plate,
                              Müsteri_Adı = c.Name,
                              Model = v.Brand,
                              Musteri_Id = v.CustomerId,
                          };
                return res.Where(x=>x.Musteri_Id == customerId).ToList();
                
            }
            
        }

        public List<VehicleDto> VehicleList()
        {
            using (OtoMuhasebeContext context = new OtoMuhasebeContext())
            {
                var res = from c in context.Customers
                          join v in context.Vehicles
                          on c.Id equals v.CustomerId
                          select new VehicleDto
                          {
                              Id = v.Id,
                              Marka = v.Model,
                              Plaka = v.Plate,
                              Müsteri_Adı = c.Name,
                              Model = v.Brand,
                          };
                return res.ToList();
            }
            
        }
    }
}
