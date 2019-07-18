using System;
using ProjektXamarin.Models;
using ProjektXamarin.Services;

namespace ProjektXamarin.ViewModels
{
    public class ProfilePageModel : ViewModelBase
    {
        public ProfilePageModel()
        {
            var service = new CustomerServices();
            Customer = service.GetCustomer();
        }

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set { SetProperty(ref _customer, value); }
        }
        public string DisplayMessage
        {
            get { return $"Last Name: {Customer.LastName}"; }
        }
    }
}
