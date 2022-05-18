using Decrypt_Library.EntityFrameworkCode;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Decrypt_Library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedProductView : ContentPage
    {
        public SelectedProductView()
        {
            InitializeComponent();
        }
        public SelectedProductView(int selectedId)
        {
            InitializeComponent();
            BindingContext = EntityframeworkProducts.ShowProductInformation(selectedId);
            reviewList.ItemsSource = EntityframeworkReview.ShowBookReview(Title);

            if (UserLogin.thisUser == null)
            {
                LoanOrReserveButton.IsVisible = false;
                PlsLoginlbl.IsVisible = true;
            }
            else
            {
                LoanOrReserveButton.IsVisible = true;
                PlsLoginlbl.IsVisible = false;
            }

            if (LoanOrReserveButton.Text == "True")
            {
                LoanOrReserveButton.IsVisible = false;
                statuslbl.Text = "Produkten finns att låna";
            }
            else
            {
                LoanOrReserveButton.Text = "Reservera";
                statuslbl.Text = "Produkten är utlånad, försök igen senare eller reservera produkten!";
            }

            if (mediaTypelbl.Text == "Format: Bok" || mediaTypelbl.Text == "Format: E-Bok")
            {
                pageslbl.IsVisible = true;
                narratorlbl.IsVisible = false;
                playtimelbl.IsVisible = false;
            }
            else if (mediaTypelbl.Text == "Format: Ljudbok")
            {
                pageslbl.IsVisible = false;
                narratorlbl.IsVisible = true;
                playtimelbl.IsVisible = true;
            }
        }

        private async void LoanOrReserveButton_Clicked(object sender, EventArgs e)
        {
            if (LoanOrReserveButton.Text == "Reservera")
            {
                var reservationCheck = EntityframeworkBookHistory.ReserveProduct(Title);
                if (reservationCheck == false)
                {
                    await DisplayAlert("Error!", "Du har redan reserverat denna produkt!", "Alrighty Then..");
                }
                else
                {
                    await DisplayAlert("Hurra!", "Produkten är nu reserverad", "Fortsätt bläddra");
                }
            }
        }
    }
}