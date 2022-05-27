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
        public AccountPage()
        {
            InitializeComponent();
           
        }

        User user = new User();
        

        private void MyProfile_Clicked(object sender, EventArgs e)
        {

            if (UserLogin.thisUser == null)
            {
                profileBar.IsVisible = false;
                profileText.IsVisible = true;
                profile.IsVisible = true;
                return;
            }

            MakeAllBarsInvisible();
            profile.IsVisible = true;
            profileBar.IsVisible = true;
            profileText.IsVisible = true;
            profileText.Text = MyPages.UserProfile();
        }
        private void MyLoan_Clicked(object sender, EventArgs e)
        {
            
            if (UserLogin.thisUser == null)
            {
                profile.IsVisible = true;
                return;
            }

            MakeAllBarsInvisible();
            loanList.IsVisible = true;
            loanList.ItemsSource = MyPages.LoanList();
        }

        private void MyReservations_Clicked(object sender, EventArgs e)
        {
            if (UserLogin.thisUser == null)
            {
                profile.IsVisible = true;
                return;
            }

            MakeAllBarsInvisible();
            reservations.IsVisible = true;
            reservations.ItemsSource = EntityframeworkBookHistory.ShowUserReservations();
        }

        private void MyLoanHistory_Clicked(object sender, EventArgs e)
        {
            if (UserLogin.thisUser == null)
            {
                profile.IsVisible = true;
                return;
            }

            MakeAllBarsInvisible();

            loanHistoryList.IsVisible = true;
            loanHistoryList.ItemsSource = MyPages.MyLoanHistory();
        }

        private void RemoveButton_Clicked(object sender, EventArgs e)
        {
            MakeAllBarsInvisible();
            reservations.IsVisible = true;

            Button btn = sender as Button;
            MyPagesProductList reserveList = btn.BindingContext as MyPagesProductList;
            EntityframeworkProducts.DeleteReservation(reserveList.ID);

            reservations.ItemsSource = null;
            reservations.ItemsSource = EntityframeworkBookHistory.ShowUserReservations();
        }

        private async void Postpone_Clicked(object sender, EventArgs e)
        {
            MakeAllBarsInvisible();
            loanList.IsVisible = true;

            Button btn = sender as Button;
            MyPagesProductList loanAgain = btn.BindingContext as MyPagesProductList;

            using (var db = new Decrypt_LibraryContext())
            {
                var bookhistory = db.BookHistories;
                bookhistory.Add(new BookHistory { EventId = 4, EndDate = null, ProductId = loanAgain.ID, StartDate = DateTime.Now, UserId = UserLogin.thisUser.Id });
                db.SaveChanges();
            }

            loanList.ItemsSource = MyPages.LoanList();

            await DisplayAlert($"{loanAgain.Title} förlängd", "Återlämnas om senast 30 dagar", "OK");

        }

        private void ProfileButton_Clicked(object sender, EventArgs e)
        {
            MakeAllBarsInvisible();
            profile.IsVisible = true;
            profileBar.IsVisible = true;
            profileText.IsVisible = true;
            profileText.Text = MyPages.UserProfile();
        }

        private void LoanCardButton_Clicked(object sender, EventArgs e)
        {
            currentUserID.Text = UserLogin.thisUser.Id.ToString();
            currentUserSSN.Text = UserLogin.thisUser.Ssn.ToString();
            currentUserName.Text = UserLogin.thisUser.UserName;
            MakeAllBarsInvisible();
            profileBar.IsVisible = true;
            profile.IsVisible = true;
            loanCard.IsVisible = true;
        }

        private void FavoriteButton_Pressed(object sender, EventArgs e)
        {
            favoriteList.ItemsSource = EntityframeworkUsers.ShowUserFavoriteList();

            MakeAllBarsInvisible();
            profile.IsVisible = true;
            profileBar.IsVisible = true;
            FavoriteTab.IsVisible = true;
        }
        private void RemoveButton_ClickedFavorite(object sender, EventArgs e)
        {
          //  MakeAllBarsInvisible();
            reservations.IsVisible = true;

            Button btn = sender as Button;
            MyPagesProductList favoriteList = btn.BindingContext as MyPagesProductList;
            EntityframeworkUsers.DeleteFavorite(favoriteList.ID);

            reservations.ItemsSource = null;
            reservations.ItemsSource = EntityframeworkUsers.ShowUserFavoriteList();
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            password.Text = "";
            confirmPassword.Text = "";
            updatePasswordButton.Text = "Bekräfta ditt val";
            MakeAllBarsInvisible();
            profile.IsVisible = true;
            profileBar.IsVisible = true;
            changePassword.IsVisible = true;
        }

        private void MakeAllBarsInvisible()
        {
            profileBar.IsVisible = false;
            loanCard.IsVisible = false;
            loanList.IsVisible = false;
            profile.IsVisible = false;
            profileText.IsVisible = false;
            changePassword.IsVisible = false;
            FavoriteTab.IsVisible = false;
            reservations.IsVisible = false;
            loanHistoryList.IsVisible = false;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            password.Text = e.NewTextValue;
        }

        private void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            confirmPassword.Text = e.NewTextValue;
        }

        private async void NewPasswordConfirmed(object sender, EventArgs e)
        {
            try
            {
                bool passwordCorrect = Readers.Readers.IsStringAndIsInt(password.Text);
                bool confirmPasswordCorrect = Readers.Readers.IsStringAndIsInt(password.Text);

                bool correctInput = passwordCorrect && confirmPasswordCorrect;

                if (correctInput)
                {
                    foreach (var item in EntityframeworkUsers.ShowAllUsers())
                    {
                        if (UserLogin.thisUser.Id == item.Id)
                        {
                            user = UserLogin.thisUser;
                            user.Password = password.Text;
                            EntityframeworkUsers.UpdateUser(user);
                            user = new User();
                            updatePasswordButton.Text = "Ditt lösenord har uppdaterats!";
                            return;
                        }
                    }
                }
                else
                    await DisplayAlert("Error", "något gick fel", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "något gick fel", "OK");
            }

        }


    }
}