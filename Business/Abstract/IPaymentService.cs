using Domain.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        void Add(Payment payment);
        void Delete(Payment payment);
        void Update(Payment payment);
        List<Payment> GetAll();
        Payment GetById(int id);
        List<Payment> GetByCustomer(int customerId);
    }
}
