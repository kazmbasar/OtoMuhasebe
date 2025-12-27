using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly InvoiceDal _invoiceDal;
        private readonly IPaymentDal _paymentDal;

        public CustomerManager(ICustomerDal customerDal, InvoiceDal invoiceDal, IPaymentDal paymentDal)
        {
            _customerDal = customerDal;
            _invoiceDal = invoiceDal;
            _paymentDal = paymentDal;
        }

        public void Add(Customer customer)
        {
            _customerDal.Add(customer);
        }

        public void Delete(Customer customer)
        {
           if (_invoiceDal.GetAll(x => x.CustomerId == customer.Id).Count > 0)
               throw new InvalidOperationException("Müşteriye ait fatura kayıtları olduğu için silinemez.");
           
           if (_paymentDal.GetAll(x => x.CustomerId == customer.Id).Count > 0)
               throw new InvalidOperationException("Müşteriye ait ödeme kayıtları olduğu için silinemez.");

           _customerDal.Delete(customer);
        }

        public List<Customer> GetAllCustomers()
        {
           return _customerDal.GetAll();
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }
        public Customer GetCustomerById(int id)
        {
            return _customerDal.Get(c=>c.Id==id);
        }

        public List<Customer> GetCustomerByName(string name)
        {
            List<Customer> list = new List<Customer>();
            list = _customerDal.GetAll();
            foreach (Customer customer in list)
            {
                list.Where(c=> c.Name.Contains(name)).ToList().Add(customer);
            }
            return list;
        }

        public List<CustomerDto> CustomerList()
        {
            return _customerDal.CustomerList();
        }

        public List<CustomerBalanceListDto> GetListWithBalance()
        {
            return _customerDal.GetListWithBalance();
        }
    }
}
