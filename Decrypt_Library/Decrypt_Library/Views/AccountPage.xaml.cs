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
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
            var numberOfReservation = MyPages.MyReservationsList();
        }

        private void MyProfile_Clicked(object sender, EventArgs e)
        {
            //  MyReservation.Text = MyPages.UserProfile();
            profileList.IsVisible = true;
            profileList.ItemsSource = UserLogin.thisUser.ToString();

        }

        private void MyLoan_Clicked(object sender, EventArgs e)
        {
           //Content.Text = MyPages.LateReturn();
        }

        private void MyReservations_Clicked(object sender, EventArgs e)
        {
          //  Text.= MyPages.MyReservationsList();
            
            reservations.ItemsSource = EntityFrameworkCode.EntityframeworkBookHistory.ShowUserReservations();

        }

        private void MyLoanHistory_Clicked(object sender, EventArgs e)
        {
         //   Content.Text = MyPages.MyLoanHistory();

            loanList.ItemsSource = EntityFrameworkCode.EntityframeworkBookHistory.ShowUserLoanHistory();
        }

        private void removeButton_Clicked(object sender, EventArgs e)
        {
            // function for removing from list not the product
        }
    }
}