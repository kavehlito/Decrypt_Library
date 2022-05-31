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
            if (UserLogin.thisUser.UserTypeId == 1 || UserLogin.thisUser.UserTypeId == 2)
            {
                var mainPage = new MainPage();
                Page adminPage = new AdminPage();
                Page loanPage = new Loan();
                Page returnProductPage = new ReturnProduct();
                var homePage = new NavigationPage(mainPage);

                returnProductPage.Title = "Lämna tillbaka";
                returnProductPage.TabIndex = 8;
                adminPage.Title = "Bibliotekarie";
                adminPage.TabIndex = 5;
                loanPage.Title = "Låna";
                loanPage.TabIndex = 7;
                mainPage.Children.Add(adminPage);
                mainPage.Children.Add(loanPage);
                mainPage.Children.Add(returnProductPage);

                await Navigation.PushModalAsync(homePage);
            }

        }
    }
}