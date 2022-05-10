using Decrypt_Library.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Decrypt_Library.Readers
{
    internal class DateValidationBehavior : Behavior<Entry>
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
            var IdPattern = "^[0-2]{1}[0-9]{3}/[0-1]{1}[0-9]{1}/[0-3]{1}[0-9]{1}$";
            var userEntry = sender as Entry;

            if (Regex.IsMatch(e.NewTextValue, IdPattern))
            {
                userEntry.Text = e.NewTextValue;
                userEntry.BackgroundColor = Color.YellowGreen;
                AdminPage.ProductPublishDateCorrect = true;
            }
            else
            {
                userEntry.BackgroundColor = Color.MediumVioletRed;
                AdminPage.ProductPublishDateCorrect = false;
            }
        }
    }
}
