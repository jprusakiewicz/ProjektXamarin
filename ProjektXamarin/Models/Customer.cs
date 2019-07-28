using System;
using Xamarin.Forms;

namespace ProjektXamarin.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public enum Education { none, a, b, c } {get; set;}
        public int Age { get; set; }
        public string Education { get; set; }
        public string MarialStatus { get; set; }
        public string Adress { get; set; }
        public ImageSource ProfilePhoto { get; set; }

    }
}
