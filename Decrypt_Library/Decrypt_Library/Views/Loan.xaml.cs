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
    public partial class Loan : ContentPage
    {
        StringBuilder receipt = new StringBuilder($"{"STRECKKOD",-20}{"TITEL", -70}{"ÅTERLÄMNINGSDATUM",-40}");
        

        public Loan()
        {
            InitializeComponent();
        }

        private void checkUserButton_Clicked(object sender, EventArgs e)
        {
            if (CheckUserId.Text == null) CheckUserId.Text = "0";
            int.TryParse(CheckUserId.Text.ToString(), out int userId);
            var sucess = Cart.CheckUserId(userId, out string UserName);
            if (!sucess) {UserIdError.IsVisible = true; CheckUserId.Text = null; }
            else
            {
                CheckUserId.IsVisible = false;
                checkUserButton.IsVisible = false;
                UserIdError.IsVisible = false;
                Product.IsVisible = true;
                Add.IsVisible = true;
                User.Text = $"Lånekortsnummer: {CheckUserId.Text}, Namn: {UserName}";
            }

        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            if (Product.Text == null) Product.Text = "0";
            int.TryParse(CheckUserId.Text.ToString(), out int userId);
            int.TryParse(Product.Text.ToString(), out int produktId);
            var productSuccess = Cart.CheckProductId(produktId, out string ProduktName);
            if (!productSuccess) { ProductIdError.IsVisible = true; Product.Text = null; }
            else
            {


                Cart.AddABookToCart(userId, produktId);

                receipt.AppendLine($"\n{produktId, -27}{ProduktName, -64}{DateTime.Now.AddDays(30).ToShortDateString(), -40}");
                Receipt.Text = receipt.ToString();
                Product.Text = null;
                Product.IsVisible = false;
                Add.IsVisible = false;
                AddNewProduct.IsVisible = true;
                CheckOut.IsVisible = true;
                ProductIdError.IsVisible = false;
            }
        }

        private void AddNewProduct_Clicked(object sender, EventArgs e)
        {
            Product.IsVisible = true;
            Add.IsVisible = true;
            AddNewProduct.IsVisible = false;
            CheckOut.IsVisible = false;
        }

        private void CheckOut_Clicked(object sender, EventArgs e)
        {
            int.TryParse(CheckUserId.Text.ToString(), out int userId);
            var sucess = Cart.CheckoutCart(userId);
            AddNewProduct.IsVisible = false;
            CheckOut.IsVisible = false;
            Headline.IsVisible = true;
            Receipt.IsVisible = true;
            StartAgain.IsVisible = true;
        }

        private void StartAgain_Clicked(object sender, EventArgs e)
        {
            CheckUserId.IsVisible = true;
            checkUserButton.IsVisible = true;
            Receipt.Text = null;
            Receipt.IsVisible = false;
            StartAgain.IsVisible=false;
            User.Text = null;
            User.IsVisible = true;
            CheckUserId.Text = null;
            Headline.IsVisible = false;
        }
    }
}