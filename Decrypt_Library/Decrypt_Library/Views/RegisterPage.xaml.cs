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
            bool correctInput = Readers.Readers.StringReaderSpecifyStringRange(Username.Text, 5,15);

            if (!correctInput)
            {
                wrongUsernameInput.IsVisible = true;
            }
            else
                wrongUsernameInput.IsVisible = false;
        }
    }
}