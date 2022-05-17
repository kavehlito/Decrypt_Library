using Decrypt_Library.EntityFrameworkCode;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Decrypt_Library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
        }

        private void MyProfile_Clicked(object sender, EventArgs e)
        {
            profile.IsVisible = true;
            loanHistoryList.IsVisible = false;
            reservations.IsVisible = false;


            profileText.Text = MyPages.UserProfile();
        }

        private async void MyLoan_Clicked(object sender, EventArgs e)
        {
            if (UserLogin.thisUser == null)
                await DisplayAlert("Oops", "Du är inte inloggad", "OK");

            loanList.IsVisible = true;
            profile.IsVisible = false;
            reservations.IsVisible = false;
            loanList.ItemsSource = MyPages.LoanList();
        }

        private async void MyReservations_Clicked(object sender, EventArgs e)
        {
            if (UserLogin.thisUser == null)
                await DisplayAlert("Oops", "Du är inte inloggad", "OK");

            loanList.IsVisible = false;
            profile.IsVisible = false;
            reservations.IsVisible = true;

            reservations.ItemsSource = EntityframeworkBookHistory.ShowUserReservations();
        }

        private async void MyLoanHistory_Clicked(object sender, EventArgs e)
        {
            if (UserLogin.thisUser == null)
                await DisplayAlert("Oops", "Du är inte inloggad", "OK");

            loanList.IsVisible = false;
            profile.IsVisible = false;
            reservations.IsVisible = false;
            loanHistoryList.IsVisible = true;
            loanHistoryList.ItemsSource = MyPages.MyLoanHistory();
        }

        private void RemoveButton_Clicked(object sender, EventArgs e)
        {

            loanList.IsVisible = false;
            profile.IsVisible = false;
            loanHistoryList.IsVisible = false;
            reservations.IsVisible = true;

            Button btn = sender as Button;
            MyPagesProductList reserveList = btn.BindingContext as MyPagesProductList;
            EntityframeworkProducts.DeleteReservation(reserveList.ID);

            reservations.ItemsSource = null;
            reservations.ItemsSource = EntityframeworkBookHistory.ShowUserReservations();
        }
    }
}