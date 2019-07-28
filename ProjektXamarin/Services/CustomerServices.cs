using System;
using System.IO;
using Plugin.Media.Abstractions;
using ProjektXamarin.Models;
using Xamarin.Forms;

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
                Education = null,
                MarialStatus = null,
                Adress = null,
                ProfilePhoto = "DefaultPortrait.png"
            };
            return cus;
        }
    }
}
