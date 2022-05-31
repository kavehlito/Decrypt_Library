using Decrypt_Library.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Decrypt_Library.Readers
{
    internal class EmailValidationBehavior : Behavior <Entry>
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
            var IdPattern = "^[0-9åäöÅÄÖa-zA-Z]+[.+-_]{0,1}[0-9åäöÅÄÖa-zA-Z]+[@][åäöÅÄÖa-zA-Z]+[.][åäöÅÄÖa-zA-Z]{2,3}([åäöÅÄÖa-zA-Z]{2,3}){0,1}$";
            var userEntry = sender as Entry;

            if (Regex.IsMatch(e.NewTextValue, IdPattern))
            {
                userEntry.BackgroundColor = Color.White;
                AdminPage.correctEmail = true;
                RegisterPage._correctEmail = true;
            }
            else
            {
                userEntry.BackgroundColor = Color.IndianRed;
                AdminPage.correctEmail = false;
                RegisterPage._correctEmail = false;
            }
        }
    }

}
