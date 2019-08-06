using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektXamarin.Models;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace ProjektXamarin.Services
{
    public class InsuranceServices : IDataStore<Insurance>
    {
        const string accountURL = @"https://kozaczinioo.documents.azure.com:443/";
        const string accountKey = @"TmkFweVQfbDyNBAVWkJz4GE01QFgfoqyQagEqxD5tyb9hs4zPzBpNTJiMdvaqlgWtYH02XOSAQrBFSn6p0eyEQ==";
        const string databaseId = @"ToDoList";
        const string collectionId = @"Project";


        private Uri collectionLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
        private DocumentClient client;

        List<Insurance> items { get; set; }
        public InsuranceServices()
        {
            client = new DocumentClient(new System.Uri(accountURL), accountKey);
            items = new List<Insurance>();

        }
      
        public async Task<bool> AddItemAsync(Insurance item)
        {
            await client.CreateDocumentAsync(collectionLink, item);
            await SynthAsync();

            return await Task.FromResult(true);
        }
        public async Task SynthAsync()
        {
            try
            {
                items.Clear();
                var query = client.CreateDocumentQuery<Insurance>(collectionLink, new FeedOptions { MaxItemCount = -1 })
                      .AsDocumentQuery();

                while (query.HasMoreResults)
                {
                    items.AddRange(await query.ExecuteNextAsync<Insurance>());
                }


            }
            catch (Exception e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
            }
        }


        public async Task<bool> DeleteItemAsync(string id)
        {
            await SynthAsync(); //just in case

            //await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionId, id)); tak jest w dokumentacji
            using (var client = new DocumentClient(new Uri(accountURL), accountKey))
            {
                var link = UriFactory.CreateDocumentUri(databaseId, collectionId, id);
                await client.DeleteDocumentAsync(link, new RequestOptions()
                { PartitionKey = new Microsoft.Azure.Documents.PartitionKey(id) }); //a tak w praktyce
            }
            Console.WriteLine(id);
            await SynthAsync();

            return await Task.FromResult(true);
        }

        public async Task<Insurance> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Insurance>> GetItemsAsync(bool forceRefresh = false)
        {
            await SynthAsync();
            return await Task.FromResult(items);
        }
    }
}
