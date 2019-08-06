using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Plugin.Media.Abstractions;
using ProjektXamarin.Models;
using Xamarin.Forms;

namespace ProjektXamarin.Services
{
    public class CustomerServices
    {
        const string accountURL = @"https://kozaczinioo.documents.azure.com:443/";
        const string accountKey = @"TmkFweVQfbDyNBAVWkJz4GE01QFgfoqyQagEqxD5tyb9hs4zPzBpNTJiMdvaqlgWtYH02XOSAQrBFSn6p0eyEQ==";
        const string databaseId = @"ToDoList";
        const string collectionId = @"Profile";

        private Uri collectionLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
        private DocumentClient client;

        Customer Cus;

        public CustomerServices()
        {
            client = new DocumentClient(new System.Uri(accountURL), accountKey);
            SynthAsync();
        }

        public async Task<bool> AddCustomerAsync(Customer _customer)
        {
            
            try
            {
                await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri("ToDoList", collectionId, _customer.Id), _customer);
                return true;
            }
            catch
            {
                await client.CreateDocumentAsync(collectionLink, _customer); //jeśli z jakiegoś powodu db jest pusta
                //throw;
            }

            await SynthAsync();

            return await Task.FromResult(true);
        }
        public async Task SynthAsync()
        {
            try
            {
                Cus = client.CreateDocumentQuery<Customer>(UriFactory.CreateDocumentCollectionUri(databaseId, collectionId))
                    .Where(x => x.Id == "singleton").ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
            }
        }
        public Customer GetCustomer()
        {

            if (Cus == null)
            {
                Cus = new Customer
                {
                    Id = "singleton",
                    FirstName = null,
                    Age = 0,
                    LastName = null,
                    Education = null,
                    MarialStatus = null,
                    Adress = null,
                    ProfilePhoto = "DefaultPortrait.png"
                };
            }
            Cus.ProfilePhoto = "DefaultPortrait.png";
            return Cus;
        }
        public async void SetCustomer(Customer _cus)
        {
            Cus = _cus;
            await AddCustomerAsync(_cus);
            Console.WriteLine("wysylam do db");
        }
    }
}
