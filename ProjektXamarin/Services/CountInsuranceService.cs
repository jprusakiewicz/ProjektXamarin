using ProjektXamarin.Models;

namespace ProjektXamarin.Services
{
    public class CountInsuranceService
    {
        public CountInsuranceService()
        {
            //var Customer get customer
        }
        public Insurance CountInsurance(Insurance insurance)
        {
            if(insurance.Type == "Car")
                insurance.Prize = 3 * insurance.Duration;
            if (insurance.Type == "Trip")
                insurance.Prize = 2 * insurance.Duration;
            if (insurance.Type == "Property")
                insurance.Prize =  insurance.Duration;
            return insurance;
        }
    }
}
