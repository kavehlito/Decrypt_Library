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
            reservations.IsVisible = false;
            loanList.ItemsSource = MyPages.LoanList();
        }

        private void MyReservations_Clicked(object sender, EventArgs e)
        {
            loanList.IsVisible = false;
            profile.IsVisible = false;
            reservations.IsVisible = true;

            reservations.ItemsSource = EntityFrameworkCode.EntityframeworkBookHistory.ShowUserReservations();



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

            //BindingContext = Convert.ToInt32(this.Id);

            var selectedId = Convert.ToInt32(this.BindingContext);

           EntityFrameworkCode.EntityframeworkProducts.DeleteReservation(selectedId);



            //BindingContext = reservations.Id;

            //reservations.ItemsSource = EntityFrameworkCode.EntityframeworkProducts.DeleteReservation();



            //reservations.ItemsSource = EntityFrameworkCode.EntityframeworkProducts.DeleteReservation();

        }
    }
}