using Decrypt_Library.Models;
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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        private void Entry_Completed(object sender, EventArgs e)
        {
            var user = new User();

            bool correctInput = Readers.Readers.StringReaderSpecifyStringRange(Username.Text, 5,15);
            bool correctPassword = false;
            bool correctEmail = false;
            bool correctPhone = false;
            bool correctSSN = false;

            if (!correctInput)
                wrongUsernameInput.IsVisible = true;
            else
                wrongUsernameInput.IsVisible = false;


            if (!correctPassword)
                wrongUsernameInput.IsVisible = true;
            else
                wrongUsernameInput.IsVisible = false;

            if (!correctEmail)
                wrongUsernameInput.IsVisible = true;
            else
                wrongUsernameInput.IsVisible = false;

            if (!correctPhone)
                wrongUsernameInput.IsVisible = true;
            else
                wrongUsernameInput.IsVisible = false;


            if (!correctSSN)
                wrongUsernameInput.IsVisible = true;
            else
                wrongUsernameInput.IsVisible = false;


            bool completeRegistration = correctInput 
                                        && correctPassword 
                                        && correctEmail 
                                        && correctPhone 
                                        && correctSSN;


        }
    }
}