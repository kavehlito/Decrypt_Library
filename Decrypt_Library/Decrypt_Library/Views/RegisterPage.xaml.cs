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

            bool completeRegistration = correctInput 
                                        && correctPassword 
                                        && correctEmail 
                                        && correctPhone 
                                        && correctSSN;

            if (completeRegistration)
            {
                user.UserName = Username.Text;
            }
            else
                wrongUsernameInput.IsVisible = true;
        }
    }
}