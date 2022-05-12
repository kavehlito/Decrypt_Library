using Decrypt_Library.EntityFrameworkCode;
using Decrypt_Library.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Decrypt_Library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        private User _user;
        Label idLabel = new Label();
        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public AccountPage()
        {
            InitializeComponent();
            // User = user;

        }

        private void MyProfile_Clicked(object sender, EventArgs e)
        {
            profile.IsVisible = true;
            loanHistoryList.IsVisible = false;
            reservations.IsVisible = false;

            //profileList.ItemsSource = EntityFrameworkCode.EntityframeworkUsers.ShowSpecificUserLogIn(_user);
            profileText.Text = MyPages.UserProfile();
        }

        private void MyLoan_Clicked(object sender, EventArgs e)
        {
            loanList.IsVisible = true;
            profile.IsVisible = false;
            loanList.ItemsSource = MyPages.LoanList();
        }

        private void MyReservations_Clicked(object sender, EventArgs e)
        {
            loanList.IsVisible = false;
            profile.IsVisible = false;
            reservations.IsVisible = true;
            reservations.ItemsSource = EntityframeworkBookHistory.ShowUserReservations();

            BindingContext = this;
            idLabel.SetBinding(Label.TextProperty, "ID");
        }

        private void MyLoanHistory_Clicked(object sender, EventArgs e)
        {
            loanList.IsVisible = false;
            profile.IsVisible = false;
            reservations.IsVisible = false;
            loanHistoryList.IsVisible = true;
            loanHistoryList.ItemsSource = MyPages.MyLoanHistory();
        }

        private void RemoveButton_Clicked(object sender, EventArgs e)
        {
            // function for removing from list not the product
            loanList.IsVisible = false;
            profile.IsVisible = false;
            loanHistoryList.IsVisible = false;
            reservations.IsVisible = true;

            int id = Convert.ToInt32(idLabel.Text);
            EntityframeworkProducts.DeleteReservation(id);


        }
    }
}