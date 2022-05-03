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

        Product product = new Product();

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

        private void entryTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryTitle.Text = e.NewTextValue;
        }

        private void entryISBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryISBN.Text = e.NewTextValue;
        }

        private void entryPublisher_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryPublisher.Text = e.NewTextValue;   
        }

        private void entryLanguage_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryLanguage.Text = e.NewTextValue;
        }

        private void entryAuthor_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryAuthor.Text = e.NewTextValue;
        }

        private void entryDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryDate.Text = e.NewTextValue;    
        }

        private void entryCategoryId_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryCategoryId.Text = e.NewTextValue;
        }

        private void entryShelfId_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryShelfId.Text = e.NewTextValue;
        }

        private void entryNarrator_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryNarrator.Text = e.NewTextValue;
        }

        private void entryAudienceId_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryAudienceId.Text = e.NewTextValue;
        }

        private void entryMediaId_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryMediaId.Text = e.NewTextValue;
        }

        private void entryDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryDescription.Text = e.NewTextValue;
        }

        private void entryPages_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryPages.Text = e.NewTextValue;
        }

        private void entryPlaytime_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryPlaytime.Text = e.NewTextValue;
        }


        private void Button_Clicked_2(object sender, EventArgs e)
        {
            int pagesInput = 0;
            double playTime = 0;
            int languageId = 0;
            int shelfId = 0;
            int categoryId = 0;
            int audienceId = 0;
            int mediaId = 0;
            long isbn = 0;
            DateTime date = DateTime.Now;


            try
            {
                BookTitleCorrect = Readers.Readers.StringReader(entryTitle.Text);
                DescriptionCorrect = Readers.Readers.StringReader(entryDescription.Text);
                AuthorNameCorrect = Readers.Readers.StringReader(entryAuthor.Text);
                PublisherCorrect = Readers.Readers.StringReader(entryPublisher.Text);
                NarratorCorrect = Readers.Readers.StringReader(entryNarrator.Text);

                PagesCorrect = Readers.Readers.IntReaderSpecifyIntRange(entryPages.Text, 1, 2000, out pagesInput);
                PlaytimeCorrect = Readers.Readers.DoubleReaderOutDouble(entryPlaytime.Text, out playTime);

                LanguageIdCorrect = Readers.Readers.LegalIDRangeLanguage(entryLanguage.Text, out languageId);
                ShelfIdCorrect = Readers.Readers.LegalIDRangeShelfId(entryShelfId.Text, out shelfId);
                CategoryIdCorrect = Readers.Readers.LegalIDRangeCategoryId(entryCategoryId.Text, out categoryId);
                AudienceIdCorrect = Readers.Readers.LegalIDRangeAudienceId(entryAudienceId.Text, out audienceId);
                MediaIdCorrect = Readers.Readers.LegalIDRangeMediaId(entryMediaId.Text, out mediaId);
                IsbnCorrect = Readers.Readers.LongReaderOutLong(entryISBN.Text, out isbn);
                PublishDateCorrect = Readers.Readers.ReadDateTime(entryDate.Text, out date);

                StatusCorrect = inStock.IsToggled;
                NewProductCorrect = newProduct.IsToggled;
                HiddenProductCorrect = hiddenProduct.IsToggled;

            }
            catch (Exception errormessage)
            {
                DisplayActionSheet("Error", $"{errormessage.Message}", "OK");
            }


            if (!BookTitleCorrect)
                entryTitle.BackgroundColor = Color.MediumVioletRed;
            else
                entryTitle.BackgroundColor = Color.White;

            if (!DescriptionCorrect)
                entryDescription.BackgroundColor = Color.MediumVioletRed;
            else
                entryDescription.BackgroundColor = Color.White;

            if (!AuthorNameCorrect)
                entryAuthor.BackgroundColor = Color.MediumVioletRed;
            else
                entryAuthor.BackgroundColor = Color.White;

            if (!PublisherCorrect)
                entryPublisher.BackgroundColor = Color.MediumVioletRed;
            else
                entryPublisher.BackgroundColor = Color.White;

            if (!NarratorCorrect)
                entryNarrator.BackgroundColor = Color.MediumVioletRed;
            else
                entryNarrator.BackgroundColor = Color.White;

            if (!PagesCorrect)
                entryPages.BackgroundColor = Color.MediumVioletRed;
            else
                entryPages.BackgroundColor = Color.White;

            if (!PlaytimeCorrect)
                entryPlaytime.BackgroundColor = Color.MediumVioletRed;
            else
                entryPlaytime.BackgroundColor = Color.White;

            if (!LanguageIdCorrect)
                entryLanguage.BackgroundColor = Color.MediumVioletRed;
            else
                entryLanguage.BackgroundColor = Color.White;

            if (!ShelfIdCorrect)
                entryShelfId.BackgroundColor = Color.MediumVioletRed;
            else
                entryShelfId.BackgroundColor = Color.White;

            if (!CategoryIdCorrect)
                entryCategoryId.BackgroundColor = Color.MediumVioletRed;
            else
                entryCategoryId.BackgroundColor = Color.White;

            if (!AudienceIdCorrect)
                entryAudienceId.BackgroundColor = Color.MediumVioletRed;
            else
                entryAudienceId.BackgroundColor = Color.White;

            if (!MediaIdCorrect)
                entryMediaId.BackgroundColor = Color.MediumVioletRed;
            else
                entryMediaId.BackgroundColor = Color.White;

            if (!IsbnCorrect)
                entryISBN.BackgroundColor = Color.MediumVioletRed;
            else
                entryISBN.BackgroundColor = Color.White;

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

            if (CorrectProductInput)
            {
                product.Title = entryTitle.Text;
                product.Description = entryDescription.Text;
                product.AuthorName = entryAuthor.Text;
                product.Publisher = entryPublisher.Text;
                product.Narrator = entryNarrator.Text;

                product.Pages = pagesInput;
                product.LanguageId = languageId;
                product.ShelfId = shelfId;
                product.CategoryId = categoryId;
                product.AudienceId = audienceId;
                product.MediaId = mediaId;
                product.Isbn = isbn;
                product.PublishDate = date;
                product.NewProduct = newProduct.IsToggled;
                product.HiddenProduct = hiddenProduct.IsToggled;
                product.Status = inStock.IsToggled;

                EntityFrameworkCode.EntityframeworkProducts.CreateProduct(product);

                DisplayActionSheet("New product added", $"{product.Title}", "ok");

                product = null;
            }

        }
    }
}