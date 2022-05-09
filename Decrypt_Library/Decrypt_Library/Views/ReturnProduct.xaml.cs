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
    public partial class ReturnProduct : ContentPage
    {
        public ReturnProduct()
        {
            InitializeComponent();
        }

        private void ReturnProduct_Clicked(object sender, EventArgs e)
        {
            int.TryParse(Product.Text.ToString(), out int productId);
            var success = Decrypt_Library.ReturnProduct.UpdateProductHistory(productId);
            if (!success) { Product.Text = null; Error.IsVisible = true; }
            else
            {
                Error.IsVisible = false;
                Product.Text = null;
                Product.IsVisible = false;
                ReturnProductId.IsVisible = false;
                ReturnNewProduct.IsVisible = true;
                CheckOut.IsVisible = true;
            }
        }

        private void ReturnNewProduct_Clicked(object sender, EventArgs e)
        {
            Product.IsVisible = true;
            ReturnProductId.IsVisible = true;
            ReturnNewProduct.IsVisible = false;
            CheckOut.IsVisible = false;
        }

        private void CheckOut_Clicked(object sender, EventArgs e)
        {

        }
    }
}