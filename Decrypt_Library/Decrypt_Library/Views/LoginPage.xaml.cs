using Decrypt_Library.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Decrypt_Library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            if (UserLogin.thisUser != null)
                Title = "Logga ut";
            else
            {
                Title = "Logga in";
            }
        }
        protected override void OnAppearing()
        {
            if (UserLogin.thisUser != null)
            {
                Headline.IsVisible = false;
                loginFrame.IsVisible = false;
                LogIn.IsVisible = false;
                alternativeOptions.IsVisible = false;

                Test.IsVisible = true;
                Test.Text = $"{UserLogin.thisUser.UserName} är nu inloggad";
                LogOut.IsVisible = true;
                Error.IsVisible = false;
            }

        }

        public async void DelayedProduct()
        {
            if (UserLogin.thisUser != null)
            {
                using (var db = new Decrypt_LibraryContext())
                {
                    var lateBooks = MyPages.LateReturnListPopUpForUser();
                    foreach (var book in lateBooks)
                    {
                        if (book.EndDate < DateTime.Now)
                        {
                            await DisplayAlert($"{book.Title} är försenad", "Lämna genast tillbaka ditt lån!", "OK");
                        }
                    }
                }
            }
        }
        private async void LogIn_Clicked(object sender, EventArgs e)
        {

            if (Password.Text == null || SSN.Text == null) { Password.Text = "0"; SSN.Text = "0"; }
            Int64.TryParse(SSN.Text.ToString(), out long ssn);
            var password = Password.Text.ToString();

            var sucess = UserLogin.CheckUserNameAndPassword(ssn, password);
            if (!sucess) Error.IsVisible = true;

            SSN.Text = null;
            Password.Text = null;

            if (sucess)
            {
                Test.IsVisible = true;
                Test.Text = $"{UserLogin.thisUser.UserName} är nu inloggad";
                SSN.IsVisible = false;
                Password.IsVisible = false;
                LogIn.IsVisible = false;
                Error.IsVisible = false;
                LogOut.IsVisible = true;
                Headline.IsVisible = false;
                alternativeOptions.IsVisible = false;
                borderHide.IsVisible = false;

                DelayedProduct();

                if (UserLogin.thisUser.UserTypeId == 3)
                {
                    var mainPage = new MainPage();
                    var homePage = new NavigationPage(mainPage);
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
        private async void LogOut_Clicked(object sender, EventArgs e)
        {
            UserLogin.LogOutUsers();
            var tab = new MainPage();
            tab.CurrentPage = tab.Children[2];

            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(tab));
        }

        private void SSN_TextChanged(object sender, TextChangedEventArgs e)
        {
            SSN.Text = e.NewTextValue;
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password.Text = e.NewTextValue;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void ForgotPassword_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Återställning av lösenord", "Konatakta administratör eller prata med bibliotekarie", "OK");
        }
    }
}