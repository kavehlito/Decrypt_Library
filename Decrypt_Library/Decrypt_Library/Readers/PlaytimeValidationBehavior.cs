using Decrypt_Library.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Decrypt_Library.Readers
{
    internal class PlaytimeValidationBehavior : Behavior<Entry>
    {

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += BindAbleOnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.TextChanged -= BindAbleOnTextChanged;
        }

        private void BindAbleOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var IdPattern = "^[1-9]{1}[0-9]{1,5000}$";
            var userEntry = sender as Entry;

     

            if (Regex.IsMatch(e.NewTextValue, IdPattern) && int.TryParse(e.NewTextValue, out _))
            {
                userEntry.BackgroundColor = Color.White;
                AdminPage.ProductPlaytimeCorrect = true;
            }
            else
            {
                userEntry.BackgroundColor = Color.IndianRed;
                AdminPage.ProductPlaytimeCorrect = false;
            }
        }
    }
}
