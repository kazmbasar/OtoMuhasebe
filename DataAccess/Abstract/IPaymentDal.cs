using Domain.Entities;
using System.Collections.Generic;
using DataAccess.Repositories;

namespace DataAccess.Abstract
{
    public interface IPaymentDal : IEntityRepository<Payment>
    {
        List<Payment> GetByCustomer(int customerId);
    }
}
