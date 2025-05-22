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
    }
}
