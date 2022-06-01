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
        public static int? userLogin = 0;
        public MainPage()
        {
            InitializeComponent();

            if(UserLogin.thisUser != null)
            {
                if (UserLogin.thisUser.UserTypeId == 6)
                {
                    this.Children.Remove(aboutpage);
                    this.Children.Remove(accountpage);
                    this.Children.Remove(loginPage);
                    this.Children.Remove(searchpage);
                    this.Children.Remove(eventpage);
                    this.Children.Remove(registerPage);
                }
            }


            if (UserLogin.thisUser != null)
            {
                loginPage.Title = "Logga ut";
            }
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
