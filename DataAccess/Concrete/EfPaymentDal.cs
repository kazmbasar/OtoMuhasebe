using DataAccess.Abstract;
using DataAccess.Contexts;
using DataAccess.Repositories;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, OtoMuhasebeContext>, IPaymentDal
    {
        public List<Payment> GetByCustomer(int customerId)
        {
            using (var context = new OtoMuhasebeContext())
            {
                return context.Payments.Where(x => x.CustomerId == customerId).OrderByDescending(x => x.Date).ToList();
            }
        }
    }
}
