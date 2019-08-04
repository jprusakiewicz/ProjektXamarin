using System;
using ProjektXamarin.Models;
using ProjektXamarin.Services;
using Xamarin.Forms;

namespace ProjektXamarin.ViewModels
{
    public class ProfilePageModel : ViewModelBase
    {
        CustomerServices service;
        public ProfilePageModel()
        {
            service = new CustomerServices();
            Customer = service.GetCustomer();
            MessagingCenter.Send(this, "ProfileUpdated", Customer);
        }

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set
            {
                SetProperty(ref _customer, value);
                service.SetCustomer(Customer);
            }
        }


        public Command SaveCommand
        {
            get
            {
                return new Command(() => {
                    this.Customer = Customer;
                    OnPropertyChanged(nameof(Customer));
                    MessagingCenter.Send(this, "ProfileUpdated",Customer); //todo
                });
            }
        }

    }
}
