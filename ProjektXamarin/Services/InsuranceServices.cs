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

            //var mockItems = new List<Insurance>
            //{
            //    new Insurance { Id = Guid.NewGuid().ToString(), Prize =  0, Type = "DEMO", Duration = 999 },
            //};
            //foreach (var item in mockItems)
            //{
            //    items.Add(item);
            //}
        }
      
        public async Task<bool> AddItemAsync(Insurance item)
        {
            await client.CreateDocumentAsync(collectionLink, item);
            //items.Add(item); //refresh insted
            await SynthAsync();

            return await Task.FromResult(true);
        }
        public async Task SynthAsync()
        {
            try
            {
                items.Clear();
                // The query excludes completed TodoItems
                var query = client.CreateDocumentQuery<Insurance>(collectionLink, new FeedOptions { MaxItemCount = -1 })
                 //     .Where(todoItem => todoItem.Complete == false)
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

        //public async Task<bool> UpdateItemAsync(Insurance item)
        //{
        //    var oldItem = items.Where((Insurance arg) => arg.Id == item.Id).FirstOrDefault();
        //    items.Remove(oldItem);
        //    items.Add(item);

        //    return await Task.FromResult(true);
        //}

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
