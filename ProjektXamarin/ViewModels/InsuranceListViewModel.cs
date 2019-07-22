using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ProjektXamarin.Models;
using ProjektXamarin.Views;
using Xamarin.Forms;

namespace ProjektXamarin.ViewModels
{
    public class InsuranceListViewModel : ViewModelBase
    {
        public ObservableCollection<Insurance> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public InsuranceListViewModel()
        {
            // Title = "Browse";
            Items = new ObservableCollection<Insurance>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            MessagingCenter.Subscribe<NewInsurancePage, Insurance>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Insurance;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            Debug.WriteLine("stan: " + IsBusy);
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
