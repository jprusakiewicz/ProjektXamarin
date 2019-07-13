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
                FirstName = "Empty",
                LastName = "Empty"

            };
            return cus;
        }
    }
}
