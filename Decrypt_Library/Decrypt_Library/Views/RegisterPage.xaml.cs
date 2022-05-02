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
        private void Entry_Completed(object sender, EventArgs e)
        {
            var user = new Models.User();

            bool correctInput = Readers.Readers.StringReaderSpecifyStringRange(Username.Text, 5, 15);
            bool correctPassword = Readers.Readers.StringPasswordCorrect(Password.Text, 8, true);
            bool correctEmail = false;
            bool correctPhone = false;
            bool correctSSN = Readers.Readers.IntReader(SSN.Text, out Ssn);

            bool correctRegistration = correctInput && correctPassword && correctEmail && correctPhone && correctSSN;

            if (!correctRegistration)
            {

                user.UserName = Username.Text;
                // wrongUsernameInput.IsVisible = true;
                user.Ssn = Convert.ToInt64(SSN.Text);

                user.Password = Password.Text;
               // wrongPasswordInput.IsVisible = true;

                user.Email = Email.Text;

            }
            else

            wrongUsernameInput.IsVisible = false;
            wrongPasswordInput.IsVisible = false;
            wrongEmailInput.IsVisible = false;

        }
    }
}