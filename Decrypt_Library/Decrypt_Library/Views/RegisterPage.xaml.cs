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
        private void Entry_Completed(object sender, EventArgs e)
        {
            var user = new User();

            bool correctUserName = Readers.Readers.StringReaderSpecifyStringRange(Username.Text, 3, 15);
            bool correctPassword = Readers.Readers.StringPasswordCorrect(Password.Text, 8, true);
            bool correctEmail = Readers.Readers.EmailReader(Email.Text);
            bool correctPhone = Readers.Readers.PhoneNrReader(Phone.Text, 10);
            bool correctSSN = Readers.Readers.SSNReader(SSN.Text, 10);

            if (!correctUserName)
                wrongUsernameInput.IsVisible = true;
            else
                wrongUsernameInput.IsVisible = false;

            if (!correctPassword)
                wrongPasswordInput.IsVisible = true;
            else
                wrongPasswordInput.IsVisible = false;

            if(!correctEmail)
                wrongEmailInput.IsVisible = true;
            else
                wrongEmailInput.IsVisible = false;

            if(!correctPhone)
                wrongPhoneInput.IsVisible = true;
            else
                wrongPhoneInput.IsVisible = false;

            if (!correctSSN)
                wrongSSNInput.IsVisible = true;
            else
                wrongSSNInput.IsVisible = false;


            bool completeRegistration = correctUserName && correctPassword && correctEmail && correctPhone && correctSSN;

            if (completeRegistration)
            {
                user.UserName = Username.Text;
                user.Password = Password.Text;
                user.Email = Email.Text;
                user.Phonenumber = long.Parse(Phone.Text);
                user.Ssn = long.Parse(SSN.Text);
                user.UserTypeId = 3;
                EntityframeworkUsers.CreateUser(user);
            }
        }
    }
}