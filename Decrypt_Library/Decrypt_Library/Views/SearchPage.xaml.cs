using Decrypt_Library.EntityFrameworkCode;
using Decrypt_Library.Models;
using System.Collections.Generic;
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
        private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            List<string> category = new List<string>();

            if (checkbox1.IsChecked)
                category.Add("Deckare");
            if (checkbox2.IsChecked)
                category.Add("Drama");
            if (checkbox3.IsChecked)
                category.Add("Novell");
            if (checkbox4.IsChecked)
                category.Add("Roman");
            if (checkbox5.IsChecked)
                category.Add("Saga");
            if (checkbox6.IsChecked)
                category.Add("Självbiografier");
            if (checkbox7.IsChecked)
                category.Add("Äventyr");
           
           
              if (checkbox8.IsChecked)
                category.Add("För Barn 0-6 år");
              if (checkbox9.IsChecked)
                category.Add("För Barn 6-9 år");
              if (checkbox10.IsChecked)
                category.Add("För Barn 9-12 år");
              if (checkbox11.IsChecked)
                category.Add("För Ungdomar");
              if (checkbox12.IsChecked)
                category.Add("För Vuxna");
             
              if (checkbox13.IsChecked)
                category.Add("Bok");
              if (checkbox14.IsChecked)
                category.Add("E-bok");
              if (checkbox15.IsChecked)
                category.Add("Ljudbok");

            ProductList.ItemsSource = EntityframeworkCategories.Checkboxes(category);

        }
    }
}


