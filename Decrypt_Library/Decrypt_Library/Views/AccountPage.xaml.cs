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

        private void Button_Clicked(object sender, EventArgs e)
        {
            Content.Text = MyPages.UserProfile();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Content.Text = MyPages.LateReturn();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Content.Text = MyPages.MyReservationsList();
        }

        private void MyLoanHistory_Clicked(object sender, EventArgs e)
        {
            Content.Text = MyPages.MyLoanHistory();
        }

    
    }
}