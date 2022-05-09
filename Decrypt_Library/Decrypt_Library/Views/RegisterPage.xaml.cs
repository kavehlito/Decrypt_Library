using Decrypt_Library.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Decrypt_Library.EntityFrameworkCode;

namespace Decrypt_Library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        bool correctUserName = false;
        bool correctPassword = false;
        bool correctEmail = false;
        bool correctPhone = false;
        bool correctSSN = false;
        private void Entry_Completed(object sender, EventArgs e)
        {
            var user = new User();

            try
            {
                correctUserName = Readers.Readers.StringReaderSpecifyStringRange(Username.Text, 3, 15);
                if (!correctUserName)
                    wrongUsernameInput.IsVisible = true;
                else
                    wrongUsernameInput.IsVisible = false;

                correctPassword = Readers.Readers.StringPasswordCorrect(Password.Text, 8, true);
                if (!correctPassword)
                    wrongPasswordInput.IsVisible = true;
                else
                    wrongPasswordInput.IsVisible = false;

                correctEmail = Readers.Readers.EmailReader(Email.Text);
                if (!correctEmail)
                    wrongEmailInput.IsVisible = true;
                else
                    wrongEmailInput.IsVisible = false;

                correctPhone = Readers.Readers.IntEqualsToSelectedNumber(Phone.Text, 10, out int convertedPhoneNr);
                if (!correctPhone)
                    wrongPhoneInput.IsVisible = true;
                else
                    wrongPhoneInput.IsVisible = false;

                correctSSN = Readers.Readers.IntEqualsToSelectedNumber(SSN.Text, 10, out int convertedSSN);
                if (!correctSSN)
                {
                    foreach (var item in EntityframeworkUsers.ShowAllUsers())
                    {
                        if (item.Ssn == user.Ssn)
                        {
                            DisplayAlert("Error!", "Det finns redan en användare med samma personnummer", "Gå vidare");
                            
                        }
                    }
                }
                if (!correctSSN)
                {
                    wrongSSNInput.IsVisible = true;
                    return;
                }
                else
                    wrongSSNInput.IsVisible = false;

            }
            catch (Exception exception)
            {
                DisplayAlert("Error", $"{exception.Message}", "Try again!");
            }


            bool completeRegistration = correctUserName && correctPassword && correctEmail && correctPhone && correctSSN;

            if (completeRegistration && Terms.IsChecked)
            {
                user.UserName = Username.Text;
                user.Password = Password.Text;
                user.Email = Email.Text;
                user.Phonenumber = long.Parse(Phone.Text);
                user.Ssn = long.Parse(SSN.Text);
                user.UserTypeId = 3;

               
                EntityframeworkUsers.CreateUser(user);
                DisplayAlert("YAY!", "Nu är din registrering klar - logga in för att komma till boksidan", "Gå vidare");
            }
            else
            {
                DisplayAlert("Ooops", "Dubbelkolla alla fält och klicka i användarvillkor", "OK");
            }

        }

        private void Terms_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Terms.IsChecked = true;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Entry_Completed(sender, e);
           
        }
    }
}