using Decrypt_Library.EntityFrameworkCode;
using Decrypt_Library.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            var selectedItemFromList = (Product)e.Item;
            await Navigation.PushAsync(new SelectedProductView(selectedItemFromList.Id));
            ((ListView)sender).SelectedItem = null;
        }
         private void OnCheckBoxCheckedChangedA(object sender, CheckedChangedEventArgs e)
        {
            List<int> audiences = new List<int>();

            if (checkbox8.IsChecked)
                audiences.Add(3);
            if (checkbox9.IsChecked)
                audiences.Add(4);
            if (checkbox10.IsChecked)
                audiences.Add(5);
            if (checkbox11.IsChecked)
                audiences.Add(2);
            if (checkbox12.IsChecked)
                audiences.Add(1);
           
            ProductList.ItemsSource = EntityframeworkAudience.SpecificAudience(audiences);
        }
        private void OnCheckBoxCheckedChangedC(object sender, CheckedChangedEventArgs e)
        {
            List<int> categorys = new List<int>();

            if (checkbox1.IsChecked)
                categorys.Add(1);
            if (checkbox2.IsChecked)
                categorys.Add(2);
            if (checkbox3.IsChecked)
                categorys.Add(3);
            if (checkbox4.IsChecked)
                categorys.Add(4);
            if (checkbox5.IsChecked)
                categorys.Add(5);
            if (checkbox6.IsChecked)
                categorys.Add(6);
            if (checkbox7.IsChecked)
                categorys.Add(7);

            ProductList.ItemsSource = EntityframeworkCategories.SpecificCategory(categorys);
        }
        private void OnCheckBoxCheckedChangedT(object sender, CheckedChangedEventArgs e)
        {
            List<int> MediaType = new List<int>();

            if (checkbox13.IsChecked)
                MediaType.Add(1);
            if (checkbox14.IsChecked)
                MediaType.Add(2);
            if (checkbox15.IsChecked)
                MediaType.Add(3);
     
            ProductList.ItemsSource = EntityframeworkMediaTypes.SpecificType(MediaType);
        }

    }
}