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
        private void Entry_Completed(object sender, EventArgs e)
        {
            bool correctInput = Readers.Readers.StringReaderSpecifyStringRange(Username.Text, 5,15);
            bool correctPassword = false;
            bool correctEmail = false;
            bool correctPhone = false;
            bool correctSSN = false;

            if (!correctInput)
            {
                wrongUsernameInput.IsVisible = true;
            }
            else
                wrongUsernameInput.IsVisible = false;
        }
    }
}