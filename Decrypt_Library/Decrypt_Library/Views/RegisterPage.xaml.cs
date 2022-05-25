using Decrypt_Library.EntityFrameworkCode;
using Decrypt_Library.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Decrypt_Library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        public static bool _correctUserName = false;
        public static bool _correctPassword = false;
        public static bool _correctConfirmPassword = false;
        public static bool _correctEmail = false;
        public static bool _correctPhone = false;
        public static bool _correctSSN = false;
        private async void Entry_Completed(object sender, EventArgs e)
        {
            var user = new User();

            long convertedPhoneNumber = 0;
            long convertedSSN = 0;

            try
            {
                bool completeRegistration = _correctUserName
                                            && _correctPassword
                                            && _correctEmail
                                            && _correctPhone
                                            && _correctSSN;

                if (completeRegistration && Terms.IsChecked)
                {
                    user.UserName = char.ToUpper(Username.Text[0]) + Username.Text.Substring(1);
                    user.Password = Password.Text;

                    Readers.Readers.LongReaderOutLong(Phone.Text, out convertedPhoneNumber);
                    Readers.Readers.LongReaderOutLong(SSN.Text, out convertedSSN);


                    foreach (var item in EntityframeworkUsers.ShowAllUsers())
                    {
                        if (item.Ssn == convertedSSN)
                        {
                            await DisplayAlert("Error!", "Det finns redan en användare med samma personnummer", "Gå vidare");
                            return;
                        }
                    }

                    foreach (var item in EntityframeworkUsers.ShowAllUsers())
                    {
                        if (item.Phonenumber == convertedPhoneNumber)
                        {
                            await DisplayAlert("Error!", "Det finns redan en användare med samma telefonummer", "Gå vidare");
                            return;
                        }
                    }

                    user.Phonenumber = convertedPhoneNumber;
                    user.Email = Email.Text;
                    user.Ssn = convertedSSN;
                    user.UserTypeId = 1;

                    EntityframeworkUsers.CreateUser(user);
                    registerFrame.IsVisible = false;
                    registrationDoneFrame.IsVisible = true;

                    refreshProgress.Progress = 0;
                    refreshProgress.IsVisible = true;
                    await refreshProgress.ProgressTo(1, 2500, Easing.Linear);

                    var tab = new MainPage();
                    tab.CurrentPage = tab.Children[2];

                    await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(tab));

                }
                else
                {
                    await DisplayAlert("Ooops", "Dubbelkolla alla fält och klicka i användarvillkor", "OK");
                }
            }
            catch (Exception exception)
            {
                await DisplayAlert("Error", $"{exception.Message}", "Try again!");
            }

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var tab = new MainPage();
            tab.CurrentPage = tab.Children[2];

            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(tab));
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            Username.Text = e.NewTextValue;
        }

        private void SSN_TextChanged(object sender, TextChangedEventArgs e)
        {
            SSN.Text = e.NewTextValue;
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            Email.Text = e.NewTextValue;
        }

        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            Phone.Text = e.NewTextValue;
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password.Text = e.NewTextValue;
        }
    }
}