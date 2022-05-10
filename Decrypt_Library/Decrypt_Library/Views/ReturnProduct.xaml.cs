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

        StringBuilder receipt = new StringBuilder($"{"STRECKKOD",-20}{"TITEL",-70}{"ÅTERLÄMNINGSDATUM",-40}");
        public ReturnProduct()
        {
            InitializeComponent();
        }

        private void ReturnProduct_Clicked(object sender, EventArgs e)
        {
            if (Product.Text == null) Product.Text = "0";
            int.TryParse(Product.Text.ToString(), out int productId);
            var success = Decrypt_Library.ReturnProduct.UpdateProductHistory(productId, out string title);
            if (!success) { Product.Text = null; Error.IsVisible = true; }
            else
            {
                Error.IsVisible = false;
                Product.Text = null;
                Product.IsVisible = false;
                ReturnProductId.IsVisible = false;
                ReturnNewProduct.IsVisible = true;
                CheckOut.IsVisible = true;
                receipt.AppendLine($"\n{productId,-27}{title,-64}");
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
            Product.IsVisible = false;
            ReturnProductId.IsVisible = false;
            ReturnNewProduct.IsVisible = false;
            CheckOut.IsVisible = false;
            Headline.IsVisible = true;
            Receipt.IsVisible = true;
        }
    }
}