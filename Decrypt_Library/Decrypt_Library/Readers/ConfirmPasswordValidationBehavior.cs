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
        string oldpassword;
        public string _oldpassword
        {
            get { return _oldpassword; }
            set { oldpassword = value; }
        }
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
