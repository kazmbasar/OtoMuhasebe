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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer,OtoMuhasebeContext>,ICustomerDal
    {
        public List<CustomerDto> CustomerList()
        {
            using (OtoMuhasebeContext context = new OtoMuhasebeContext())
            {
                return context.Customers.Select(c=> new CustomerDto
                {
                    Id = c.Id ,
                    Name = c.Name ,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address
                }).ToList();
            }
        }
    }
}
