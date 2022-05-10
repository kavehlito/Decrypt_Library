using Decrypt_Library.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Decrypt_Library.Readers
{
    internal class ShelfIdValidationBehavior : Behavior<Entry>
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
            int legalMediaLength = 0;
            var IdPattern = $"^[1-{EntityFrameworkCode.EntityframeworkLanguages.ShowAllLanguages().Count}]";
            var userEntry = sender as Entry;

            if (Regex.IsMatch(e.NewTextValue, IdPattern) && int.TryParse(e.NewTextValue, out legalMediaLength) && legalMediaLength <= EntityFrameworkCode.EntityframeworkLanguages.ShowAllLanguages().Count)
            {
                userEntry.BackgroundColor = Color.YellowGreen;
                AdminPage.ProductShelfIdCorrect = true;
            }
            else
            {
                userEntry.BackgroundColor = Color.MediumVioletRed;
                AdminPage.ProductShelfIdCorrect = false;
            }
        }
    }
}
