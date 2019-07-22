using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektXamarin.Models;

namespace ProjektXamarin.Services
{
    public class InsuranceServices : IDataStore<Insurance>
    {
        List<Insurance> items;
        public InsuranceServices()
        {
            items = new List<Insurance>();
            var mockItems = new List<Insurance>
            {
                new Insurance { Id = Guid.NewGuid().ToString(), Prize =  0, Type = "DEMO", Duration = 999 },
            };
            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Insurance item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Insurance item)
        {
            var oldItem = items.Where((Insurance arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Insurance arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Insurance> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Insurance>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
