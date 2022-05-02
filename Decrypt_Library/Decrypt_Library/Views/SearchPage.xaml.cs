using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Decrypt_Library.EntityFrameworkCode;
using Decrypt_Library.Models;
using System.Collections;

namespace Decrypt_Library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            ProductList.ItemsSource = EntityframeworkProducts.ShowAllProducts();
            this.BindingContext = this;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductList.ItemsSource = EntityframeworkProducts.ShowSpecificProductTitle(e.NewTextValue);
        }

        private void ProductList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}