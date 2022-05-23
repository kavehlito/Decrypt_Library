using Decrypt_Library.EntityFrameworkCode;
using Decrypt_Library.Models;
using System.Collections.Generic;
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
        private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            List<int> category = new List<int>();
            List<int> age = new List<int>();
            List<int> media = new List<int>();

            if (checkbox1.IsChecked)
                category.Add(1);
            if (checkbox2.IsChecked)
                category.Add(2);
            if (checkbox3.IsChecked)
                category.Add(3);
            if (checkbox4.IsChecked)
                category.Add(4);
            if (checkbox5.IsChecked)
                category.Add(5);           
            if (checkbox6.IsChecked)
                category.Add(6);
            if (checkbox7.IsChecked)
                category.Add(7);

            if (checkbox8.IsChecked)
                age.Add(3);
            if (checkbox9.IsChecked)
                age.Add(4);
            if (checkbox10.IsChecked)
                age.Add(5);
            if (checkbox11.IsChecked)
                age.Add(2);
            if (checkbox12.IsChecked)
                age.Add(1);

            if (checkbox13.IsChecked)
                media.Add(1);
            if (checkbox14.IsChecked)
                media.Add(2);
            if (checkbox15.IsChecked)
                media.Add(3);
            ProductList.ItemsSource = EntityframeworkCategories.Checkboxes(category, age, media);

            var alternative = EntityframeworkCategories.Checkboxes(category, age, media);
            
            /*   if (alternative.Count == 0 || )
                {   
                    mySearch.Text = "Din sökning gav inget resultat...";
                    mySearch.Opacity = 1;
                }
                else
                {
                    mySearch.Opacity = 0;
                    ProductList.ItemsSource = alternative;
                }  */    
        }
    }
}


