using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Decrypt_Library.EntityFrameworkCode;
using Decrypt_Library.Models;

namespace Decrypt_Library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedProductView : ContentPage
    {
        public SelectedProductView()
        {
            InitializeComponent();           
        }
        public SelectedProductView(int selectedId)
        {
            InitializeComponent();
            BindingContext = EntityframeworkProducts.ShowProductInformation(selectedId);
            if (UserLogin.thisUser == null)
            {
                LoanOrReserveButton.IsVisible = false;
                PlsLoginlbl.IsVisible = true;
            }
            else
            {
                LoanOrReserveButton.IsVisible = true;
                PlsLoginlbl.IsVisible = false;
            }
            if (LoanOrReserveButton.Text == "True")
            {
                LoanOrReserveButton.Text = "Låna";
            }
            else
            {
                LoanOrReserveButton.Text = "Reservera";
            }
        }

        private void LoanOrReserveButton_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}