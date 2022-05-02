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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LogIn_Clicked(object sender, EventArgs e)
        {

            Int32.TryParse(SSN.Text.ToString(), out int ssn);
            var password = Password.Text.ToString(); 

            var sucess = UserLogin.CheckUserNameAndPassword(ssn, password);
            if (!sucess) Error.IsVisible = true;

            
            SSN.Text = null;
            Password.Text = null;

            if (sucess) 
            { 
                Test.Text = $"{UserLogin.thisUser.UserName} är nu inloggad";
                SSN.IsVisible = false;
                Password.IsVisible = false;
                LogIn.IsVisible = false;
                Error.IsVisible = false;
                LogOut.IsVisible = true;
                Headline.IsVisible = false;
            }

        }

        private void LogOut_Clicked(object sender, EventArgs e)
        {
            Test.IsVisible = false;
            UserLogin.LogOutUsers();
            SSN.IsVisible = true;
            Password.IsVisible = true;
            LogIn.IsVisible = true;
            Error.IsVisible = false;
            LogOut.IsVisible = false;
            Headline.IsVisible=true;
        }
    }
}