using Decrypt_Library.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Decrypt_Library
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (UserLogin.thisUser != null)
                loginPage.Title = "Logga ut";
            else
            {
                loginPage.Title = "Logga in";
            }

            if(UserLogin.thisUser != null)
            {
                this.Children.Remove(registerPage);
            }
            else
                this.Children.Add(registerPage);

        }
    }
}
