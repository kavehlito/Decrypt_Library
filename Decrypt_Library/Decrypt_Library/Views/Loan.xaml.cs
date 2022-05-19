using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decrypt_Library.EntityFrameworkCode;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Decrypt_Library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loan : ContentPage
    {
        protected override void OnDisappearing()
        {
            if (CheckUserId.Text == null) CheckUserId.Text = "0";
            int.TryParse(CheckUserId.Text.ToString(), out int userId);
            base.OnDisappearing();
            Cart.DeleteCart(userId);
            CheckUserId.IsVisible = true;
            checkUserButton.IsVisible = true;
            StartAgain.IsVisible = false;
            User.Text = null;
            User.IsVisible = true;
            CheckUserId.Text = null;
            Headline.IsVisible = false;
            Cart.cartList.Clear();
            AddNewProduct.IsVisible = false;
            CheckOut.IsVisible = false;
            Product.IsVisible = false;
            Add.IsVisible = false;
            ProductList.ItemsSource = null;
            NumberOfItem.IsVisible = false;
            Headline.IsVisible = false;
        }

        public Loan()
        {
            InitializeComponent();
        }

        private void checkUserButton_Clicked(object sender, EventArgs e)
        {
            if (CheckUserId.Text == null) CheckUserId.Text = "0";
            int.TryParse(CheckUserId.Text.ToString(), out int userId);
            var sucess = Cart.CheckUserId(userId, out string UserName);
            if (!sucess) {DisplayAlert("Felmeddelande", "Användaren finns inte i systemet.", "OK"); CheckUserId.Text = null; }
            else
            {
                CheckUserId.IsVisible = false;
                checkUserButton.IsVisible = false;
                Product.IsVisible = true;
                Add.IsVisible = true;
                User.Text = $"Lånekortsnummer: {CheckUserId.Text}, Namn: {UserName}";
            }

        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            if (Product.Text == null) Product.Text = "0";
            int.TryParse(CheckUserId.Text.ToString(), out int userId);
            int.TryParse(Product.Text.ToString(), out int produktId);
            var productSuccess = Cart.CheckProductId(produktId);
            if (!productSuccess) { DisplayAlert("Felmeddelande", "Produkten går inte att låna just nu.", "OK"); Product.Text = null; }
            else
            {


                Cart.AddABookToCart(userId, produktId);

                //Receipt.Text = receipt.ToString();
                ProductList.ItemsSource = Cart.cartList;
                ProductList.ItemsSource = null;
                ProductList.ItemsSource = Cart.cartList;
                Product.Text = null;
                Product.IsVisible = false;
                Add.IsVisible = false;
                AddNewProduct.IsVisible = true;
                CheckOut.IsVisible = true;
                Headline.IsVisible = true;
                NumberOfItem.IsVisible = true;
                NumberOfItem.Text = $"Antal lånade produkter: {Cart.cartList.Count()}";
            }
        }

        private void AddNewProduct_Clicked(object sender, EventArgs e)
        {
            Product.IsVisible = true;
            Add.IsVisible = true;
            AddNewProduct.IsVisible = false;
            CheckOut.IsVisible = false;
            
        }

        private void CheckOut_Clicked(object sender, EventArgs e)
        {
            int.TryParse(CheckUserId.Text.ToString(), out int userId);
            var sucess = Cart.CheckoutCart(userId);
            AddNewProduct.IsVisible = false;
            CheckOut.IsVisible = false;
            StartAgain.IsVisible = true;
            Cart.cartList.Clear();
        }

        private void StartAgain_Clicked(object sender, EventArgs e)
        {
            CheckUserId.IsVisible = true;
            checkUserButton.IsVisible = true;
            StartAgain.IsVisible=false;
            User.Text = null;
            User.IsVisible = true;
            CheckUserId.Text = null;
            Headline.IsVisible = false;
            Cart.cartList.Clear();
            ProductList.ItemsSource = null;
            ProductList.ItemsSource = Cart.cartList;
            NumberOfItem.IsVisible = false;
        }

        private void ProductList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CartList loanList = btn.BindingContext as CartList;
            Cart.DeleteItemInCart(loanList.Id);
            
            ProductList.ItemsSource = null;

            ProductList.ItemsSource = Cart.cartList;
            NumberOfItem.Text = $"Antal lånade produkter: {Cart.cartList.Count()}";
        }
    }
}