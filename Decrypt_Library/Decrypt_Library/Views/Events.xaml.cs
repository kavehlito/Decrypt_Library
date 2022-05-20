using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Decrypt_Library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Events : ContentPage
    {
        public Events()
        {
            InitializeComponent();
            eventList.ItemsSource= EntityFrameworkCode.EntityframeworkEvents.ShowAllEvents();
        }

        private async void eventList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItemFromList = (Models.Event)e.Item;
            await Navigation.PushAsync(new SelectedEventView(selectedItemFromList.Id));
            ((ListView)sender).SelectedItem = null;

        }
    }
}