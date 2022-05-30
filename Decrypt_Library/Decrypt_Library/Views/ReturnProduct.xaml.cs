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
    public partial class ReturnProduct : ContentPage
    {

        public ReturnProduct()
        {
            InitializeComponent();
        }

        private void ReturnProduct_Clicked(object sender, EventArgs e)
        {
            if (Product.Text == null) Product.Text = "0";
            int.TryParse(Product.Text.ToString(), out int productId);
            var success = Decrypt_Library.ReturnProduct.UpdateProductHistory(productId, out string title);
            if (!success) { Product.Text = null; DisplayAlert("Felmeddelande", "Boken går inte att lämna tillbaka eftersom den inte är utlånad.", "OK"); }
            else
            {
                Product.Text = null;
                Headline.IsVisible = true;
                CheckOut.IsVisible = true;
                ProductList.ItemsSource = Cart.cartList;
                ProductList.ItemsSource = null;
                ProductList.ItemsSource = Cart.cartList;
            }
        }


        private void CheckOut_Clicked(object sender, EventArgs e)
        {
            Product.IsVisible = false;
            ReturnProductId.IsVisible = false;
            CheckOut.IsVisible = false;
            Headline.IsVisible = true;
            StartAgain.IsVisible = true;
        }

        private async void StartAgain_Clicked(object sender, EventArgs e)
        {
            Cart.cartList.Clear();
            var tab = new MainPage();
            tab.CurrentPage = tab.Children[8];

            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(tab));

        }
    }
}