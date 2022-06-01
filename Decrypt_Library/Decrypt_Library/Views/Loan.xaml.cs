using Decrypt_Library.EntityFrameworkCode;
using System;
using System.Linq;
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

        protected override void OnAppearing()
        {

        }

        public Loan()
        {
            InitializeComponent();
        }

        private void checkUserButton_Clicked(object sender, EventArgs e)
        {
            bool success = false;
            Models.User user = new Models.User();
            if (string.IsNullOrEmpty(CheckUserId.Text) || string.IsNullOrEmpty(Password.Text)) return;


            int.TryParse(CheckUserId.Text.ToString(), out int userId);

            var allUserList = EntityframeworkUsers.ShowAllUsers();

            foreach (var item in allUserList)
            {
                if (item.Id == userId && item.Password == Password.Text) { success = true; user = item; }
            }
            
    


            if (!success) { DisplayAlert("Felmeddelande", "Användaren finns inte i systemet.", "OK"); CheckUserId.Text = null; }
            else
            {
                userIdFrame.IsVisible = false;
                Password.IsVisible = false;
                userPasswordFrame.IsVisible = false;
                CheckUserId.IsVisible = false;
                checkUserButton.IsVisible = false;
                CancelButton.IsVisible = true;
                Password.IsVisible = false;
                Product.IsVisible = true;
                Add.IsVisible = true;
                User.Text = $"Lånekortsnummer: {user.Id}, Namn: {user.UserName}";
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
                adminPage.Title = "Bibliotekarie";
                loanPage.Title = "Låna";
                mainPage.Children.Add(adminPage);
                mainPage.Children.Add(loanPage);
                mainPage.Children.Add(returnProductPage);

                await Navigation.PushModalAsync(homePage);
            }

            if(UserLogin.thisUser.UserTypeId == 6)
            {
                var mainPage = new MainPage();
                Page loanPage = new Loan();
                Page returnProductPage = new ReturnProduct();
                var homePage = new NavigationPage(mainPage);

                returnProductPage.Title = "Lämna tillbaka";
                loanPage.Title = "Låna";
                mainPage.Children.Add(loanPage);
                mainPage.Children.Add(returnProductPage);

                await Navigation.PushModalAsync(homePage);
            }

        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            if (StartAgain.IsVisible) { DisplayAlert("Felmeddelande", "Utlåningsprocessen är redan klar, går ej att avbryta", "Ok"); return; }
            Button btn = sender as Button;
            CartList loanList = btn.BindingContext as CartList;
            Cart.DeleteItemInCart(loanList.Id);

            ProductList.ItemsSource = null;

            ProductList.ItemsSource = Cart.cartList;
            NumberOfItem.Text = $"Antal lånade produkter: {Cart.cartList.Count()}";
        }

        private void CheckUserId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(CheckUserId.Text))
                {
                    int.TryParse(CheckUserId.Text.ToString(), out int userId);
                    Cart.DeleteCart(userId);
                }
            }
            catch (Exception)
            {
                return;
            }
            Cart.cartList.Clear();


            if (UserLogin.thisUser.UserTypeId == 6)
            {
                var mainPage = new MainPage();
                Page loanPage = new Loan();
                Page returnProductPage = new ReturnProduct();
                var homePage = new NavigationPage(mainPage);

                returnProductPage.Title = "Lämna tillbaka";
                loanPage.Title = "Låna";
                mainPage.Children.Add(loanPage);
                mainPage.Children.Add(returnProductPage);

                await Navigation.PushModalAsync(homePage);
            }

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