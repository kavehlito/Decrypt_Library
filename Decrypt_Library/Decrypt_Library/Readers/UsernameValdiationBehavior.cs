using Decrypt_Library.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Decrypt_Library.Readers
{
    internal class UsernameValdiationBehavior : Behavior <Entry>
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
            var IdPattern = "^[a-zA-Z]{2,20}$";
            var userEntry = sender as Entry;


            if (Regex.IsMatch(e.NewTextValue, IdPattern))
            {
                userEntry.BackgroundColor = Color.White;
                AdminPage.correctUserName = true;
                RegisterPage._correctUserName = true;
            }
            else
            {
                userEntry.BackgroundColor = Color.IndianRed;
                AdminPage.correctUserName = false;
                RegisterPage._correctUserName = false;
            }
        }
    }
}
