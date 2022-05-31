using Decrypt_Library.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Decrypt_Library.Readers
{
    internal class PasswordValidationBehavior : Behavior<Entry>
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
            var IdPattern = "([åäöÅÄÖA-Za-z]+[0-9]|[0-9]+[åäöÅÄÖA-Za-z])[åäöÅÄÖA-Za-z0-9]*";
            var userEntry = sender as Entry;

            if (Regex.IsMatch(e.NewTextValue, IdPattern))
            {
                userEntry.Text = e.NewTextValue;
                ConfirmPasswordValidationBehavior._oldpassword = e.NewTextValue;
                userEntry.BackgroundColor = Color.White;
                AdminPage.correctPassword = true;
                RegisterPage._correctPassword = true;
            }
            else
            {
                userEntry.BackgroundColor = Color.IndianRed;
                AdminPage.correctPassword = false;
                RegisterPage._correctPassword = false;
            }
        }
    }
}
