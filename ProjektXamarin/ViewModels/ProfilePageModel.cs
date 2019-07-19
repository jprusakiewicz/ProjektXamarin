using System;
using ProjektXamarin.Models;
using ProjektXamarin.Services;
using Xamarin.Forms;

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
            get { return Message; }
        }
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                SetProperty(ref _message, value);
            }
        }
        public Command SaveCommand
        {
            get
            {
                return new Command(() => {
                     Message = "I am " + Customer.FirstName + ", My Name is " + Customer.LastName;
                    this.Customer = Customer;
                });
            }
        }
    }
}
