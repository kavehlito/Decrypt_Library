using Decrypt_Library.Models;
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
    public partial class Admin : ContentPage
    {
        public Admin()
        {
            InitializeComponent();
        }

        User user = new User();

        #region CorrectInputBools
        bool MediaIdCorrect { get; set; }    
        bool StatusCorrect { get; set; } 
        bool IsbnCorrect { get; set; } 
        bool BookTitleCorrect { get; set; } 
        bool DescriptionCorrect { get; set; } 
        bool PagesCorrect { get; set; } 
        bool PlaytimeCorrect { get; set; } 
        bool PublisherCorrect { get; set; } 
        bool LanguageIdCorrect { get; set; } 
        bool AuthorNameCorrect { get; set; } 
        bool PublishDateCorrect { get; set; } 
        bool CategoryIdCorrect { get; set; } 
        bool ShelfIdCorrect { get; set; } 
        bool NarratorCorrect { get; set; } 
        bool NewProductCorrect { get; set; } 
        bool AudienceIdCorrect { get; set; } 
        bool HiddenProductCorrect { get; set; }

        bool CorrectProductInput = false;
        #endregion

        private void CompleteProductInput()
        {
            CorrectProductInput = true;
        }

        private void ShowNoWindows()
        {
            AddProduct.IsVisible = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ShowNoWindows();
            ProductList.ItemsSource = EntityFrameworkCode.EntityframeworkProducts.ShowAllProducts();
        }

        private void Button_AddProductClicked(object sender, EventArgs e)
        {
            AddProduct.IsVisible = true;
        }

        private void ProductList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void Button_ShowAllCategories(object sender, EventArgs e)
        {
            ShowNoWindows();
            ProductList.ItemsSource = EntityFrameworkCode.EntityframeworkCategories.ShowAllCategories();
        }

        private void Button_ShowAllUsers(object sender, EventArgs e)
        {
            ShowNoWindows();
            ProductList.ItemsSource = EntityFrameworkCode.EntityframeworkUsers.ShowAllUsers();
        }

        private void Button_ShowAllLanguages(object sender, EventArgs e)
        {
            ShowNoWindows();
            ProductList.ItemsSource = EntityFrameworkCode.EntityframeworkLanguages.ShowAllLanguages();
        }

        private void Button_ShowAllEvents(object sender, EventArgs e)
        {
            ShowNoWindows();
            ProductList.ItemsSource = EntityFrameworkCode.EntityframeworkEvents.ShowAllEvents();
        }

        private void Button_InsertProduct(object sender, EventArgs e)
        {

        }

        private void Entry_ProductInputCompleted(object sender, EventArgs e)
        {
            BookTitleCorrect = Readers.Readers.StringReader(entryTitle.Text);
            DescriptionCorrect = Readers.Readers.StringReader(entryDescription.Text);
            AuthorNameCorrect = Readers.Readers.StringReader(entryAuthor.Text);
            PublisherCorrect = Readers.Readers.StringReader(entryPublisher.Text);

            PagesCorrect = Readers.Readers.IntReaderSpecifyIntRange(entryPages.Text, 1, 2000, out int pagesinput);
            LanguageIdCorrect = Readers.Readers.LegalIDRangeLanguage(entryLanguage.Text, out int convertedUserIdInput);

            

            CorrectProductInput = MediaIdCorrect
                                  && StatusCorrect
                                  && IsbnCorrect
                                  && BookTitleCorrect
                                  && DescriptionCorrect
                                  && PagesCorrect
                                  && PlaytimeCorrect
                                  && PublisherCorrect
                                  && LanguageIdCorrect
                                  && AuthorNameCorrect
                                  && PublishDateCorrect
                                  && CategoryIdCorrect
                                  && ShelfIdCorrect
                                  && NarratorCorrect
                                  && NewProductCorrect
                                  && AudienceIdCorrect
                                  && HiddenProductCorrect;

        }
    }
}