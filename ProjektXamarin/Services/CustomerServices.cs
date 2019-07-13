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
                FirstName = "Empty_F",
                LastName = "Empty_L"

            };
            return cus;
        }
    }
}
