using Decrypt_Library.EntityFrameworkCode;
using Decrypt_Library.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Decrypt_Library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            //ProductList.ItemsSource = EntityframeworkProducts.ShowAllProducts();
            this.BindingContext = this;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductList.ItemsSource = EntityframeworkProducts.ShowSearchedProduct(e.NewTextValue);
        }

        private async void ProductList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItemFromList = (CategoryName_Product)e.Item;
            await Navigation.PushAsync(new SelectedProductView(selectedItemFromList.Id));
            ((ListView)sender).SelectedItem = null;
        }
    }
}