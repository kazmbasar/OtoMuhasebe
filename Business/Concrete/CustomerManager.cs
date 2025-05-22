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

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Add(Customer customer)
        {
            _customerDal.Add(customer);
        }

        public void Delete(Customer customer)
        {
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
    }
}
