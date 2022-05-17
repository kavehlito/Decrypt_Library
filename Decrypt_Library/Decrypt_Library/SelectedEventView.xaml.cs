using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Decrypt_Library
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedEventView : ContentPage
    {
        int SelectedId = 0;
        public SelectedEventView()
        {
            InitializeComponent();
        }

        public SelectedEventView(int selectedId)
        {
            InitializeComponent();
            SelectedId = selectedId;
            BindingContext = EntityFrameworkCode.EntityframeworkEvents.ShowSelectedEvents(SelectedId);
            if (UserLogin.thisUser == null) UserError.IsVisible = true;
            else SignUpButton.IsVisible = true;
        }

        private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            EventSignUp.EventSignUpMethod(SelectedId);
        }
    }
}