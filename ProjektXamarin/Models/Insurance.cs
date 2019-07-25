using System;
namespace ProjektXamarin.Models
{
    public class Insurance
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int Prize { get; set; }
        public int Duration { get; set; }

        //Car
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }

        //property
        public string Size { get; set; }
        public string PropertyType { get; set; }

        //Trip
        public string Destination { get; set; }

        public Customer owner { get; set; }
    }
}
