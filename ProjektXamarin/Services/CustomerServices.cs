using System;
using ProjektXamarin.Models;
namespace ProjektXamarin.Services
{
    public class CustomerServices
    {
        public CustomerServices()
        {
        }

        public Customer GetCustomer()
        {
            var cus = new Customer
            {
                FirstName = null,
                Age = 0,
                LastName = null,
                Education = null
            };
            return cus;
        }
    }
}
