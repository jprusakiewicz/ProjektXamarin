using System;
using System.Collections.Generic;
using System.IO;
using Plugin.Media;
using Plugin.Media.Abstractions;
using ProjektXamarin.ViewModels;
using Xamarin.Forms;

namespace ProjektXamarin.Views
{
    public partial class ProfileEditPage : ContentPage
    {
        MediaFile file;
        public ProfileEditPage(ProfilePageModel profilePageModel)
        {
            InitializeComponent();
            this.BindingContext = profilePageModel;
        }

        async void Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Handle_Clicked (object sender, System.EventArgs e) 
        {
            try
            {
                file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (file == null) return;
                imgSelected.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }

            catch (Exception ex)
            {
                string text = ex.Message;
                Console.WriteLine("ex: " + text);
            }
        }
    }
    
}
