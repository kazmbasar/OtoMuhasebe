using Business.Concrete;
using DataAccess.Concrete;
using Domain.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        Customer customer = new Customer()
        {
            Name = "Test",
            PhoneNumber = "12345678",
            Address = "TESSSTTTT"

        };
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

        customerManager.Add(customer);
        foreach( var a in customerManager.GetAllCustomers())

        {
            Console.WriteLine(a.Name);
        };
    }
}