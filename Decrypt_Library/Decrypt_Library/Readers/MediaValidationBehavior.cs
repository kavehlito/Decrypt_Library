using Decrypt_Library.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Decrypt_Library.Readers
{
    internal class MediaValidationBehavior : Behavior<Entry>
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
            var admin = new AdminPage();
            var userInput = e.NewTextValue;
            var emailPattern = "^[0-9]{1}";
            var userEntry = sender as Entry;

            if (Regex.IsMatch(userInput, emailPattern))
            {
                userEntry.BackgroundColor = Color.YellowGreen;
            }
            else
            {
                userEntry.TextColor = Color.MediumVioletRed;
            }
        }
    }
}
