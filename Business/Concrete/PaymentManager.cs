using Business.Abstract;
using DataAccess.Abstract;
using Domain.Entities;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public void Add(Payment payment)
        {
            _paymentDal.Add(payment);
        }

        public void Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
        }

        public List<Payment> GetAll()
        {
            return _paymentDal.GetAll();
        }

        public List<Payment> GetByCustomer(int customerId)
        {
            return _paymentDal.GetByCustomer(customerId);
        }

        public Payment GetById(int id)
        {
            return _paymentDal.Get(p => p.Id == id);
        }

        public void Update(Payment payment)
        {
            _paymentDal.Update(payment);
        }
    }
}
