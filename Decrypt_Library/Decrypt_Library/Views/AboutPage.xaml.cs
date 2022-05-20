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
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Frame_SizeChanged(object sender, EventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            contantInfo.IsVisible = false;
            openTimes.IsVisible = false;
            aboutUs.IsVisible = true;
            conplaints.IsVisible = false;

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            contantInfo.IsVisible = false;
            openTimes.IsVisible = true;
            conplaints.IsVisible = false;
            aboutUs.IsVisible = false;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            contantInfo.IsVisible = true;
            openTimes.IsVisible = false;
            aboutUs.IsVisible = false;
            conplaints.IsVisible = false;

        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            contantInfo.IsVisible = false;
            openTimes.IsVisible = false;
            aboutUs.IsVisible = false;
            conplaints.IsVisible = true;
        }
    }
}