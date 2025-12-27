using DataAccess.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void Add(Customer customer);
        void Delete(Customer customer);
        void Update(Customer customer);
        List<Customer> GetCustomerByName(string name);
        List<CustomerDto> CustomerList();
        List<CustomerBalanceListDto> GetListWithBalance();
    }
}
