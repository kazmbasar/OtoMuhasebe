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

        public List<CustomerBalanceListDto> GetListWithBalance()
        {
            using (OtoMuhasebeContext context = new OtoMuhasebeContext())
            {
                var list = context.Customers.Select(c => new CustomerBalanceListDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    IsActive = c.IsActive,
                    TotalDebt = context.Invoices.Where(i => i.CustomerId == c.Id).Sum(i => (decimal?)i.TotalAmount) ?? 0,
                    TotalPaid = context.Payments.Where(p => p.CustomerId == c.Id).Sum(p => (decimal?)p.Amount) ?? 0
                }).ToList();

                // Calculate balance in memory
                list.ForEach(x => x.Balance = x.TotalDebt - x.TotalPaid);
                return list;
            }
        }
    }
}
