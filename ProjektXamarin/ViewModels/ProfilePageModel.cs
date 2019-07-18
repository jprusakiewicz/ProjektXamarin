using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProjektXamarin.Models;
using ProjektXamarin.Services;
using Xamarin.Forms;

namespace ProjektXamarin.ViewModels
{
    public class ProfilePageModel : INotifyPropertyChanged
    {
        public ProfilePageModel()
        {
            //var service = new CustomerServices();
            //Customer = service.GetCustomer();
            Customer = new Customer()
            {
                FirstName = "ABC",
                LastName = "DEF"
            };
        }

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            //set { SetProperty(ref _customer, value); }
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
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
                _message = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
