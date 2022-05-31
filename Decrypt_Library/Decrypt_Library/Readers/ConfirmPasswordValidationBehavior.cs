using Decrypt_Library.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Decrypt_Library.Readers
{
    internal class ConfirmPasswordValidationBehavior : Behavior<Entry>
    {
        public static string _oldpassword { get; set; }
        public static Match match { get; set; }

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
            var userEntry = sender as Entry;

            if (Regex.Equals(e.NewTextValue, ConfirmPasswordValidationBehavior._oldpassword))
            {
                userEntry.Text = e.NewTextValue;
                userEntry.BackgroundColor = Color.White;
                AdminPage.correctConfirmationPassword = true;
                RegisterPage._correctConfirmPassword = true;
            }
            else
            {
                
                userEntry.BackgroundColor = Color.IndianRed;
                AdminPage.correctConfirmationPassword = false;
                RegisterPage._correctConfirmPassword = false;
            }
        }
    }
}
