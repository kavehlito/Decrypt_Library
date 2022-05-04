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
    public partial class AdminPage : TabbedPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        Product product = new Product();
        Category category = new Category();

        //product bools

        #region CorrectInputBools
        bool ProductMediaIdCorrect { get; set; }    
        bool ProductStatusCorrect { get; set; } 
        bool ProductIsbnCorrect { get; set; } 
        bool ProductTitleCorrect { get; set; } 
        bool ProductDescriptionCorrect { get; set; } 
        bool ProductPagesCorrect { get; set; } 
        bool ProductPlaytimeCorrect { get; set; } 
        bool ProductPublisherCorrect { get; set; } 
        bool ProductLanguageIdCorrect { get; set; } 
        bool ProductAuthorNameCorrect { get; set; } 
        bool ProductPublishDateCorrect { get; set; } 
        bool ProductCategoryIdCorrect { get; set; } 
        bool ProductShelfIdCorrect { get; set; } 
        bool ProductNarratorCorrect { get; set; } 
        bool ProductNewProductCorrect { get; set; } 
        bool ProductAudienceIdCorrect { get; set; } 
        bool ProductHiddenProductCorrect { get; set; }

        bool ProductCorrectProductInput = false;

        //category bools

        bool CateogryCorrectCategoryName { get; set; }


        #endregion

        #region Buttons tab1 products
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

        #endregion

        #region Complete product add

        private void CompleteProduct_Pressed(object sender, EventArgs e)
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
                ProductTitleCorrect = Readers.Readers.StringReader(entryTitle.Text);
                ProductDescriptionCorrect = Readers.Readers.StringReader(entryDescription.Text);
                ProductAuthorNameCorrect = Readers.Readers.StringReader(entryAuthor.Text);
                ProductPublisherCorrect = Readers.Readers.StringReader(entryPublisher.Text);
                ProductNarratorCorrect = Readers.Readers.StringReader(entryNarrator.Text);

                ProductPagesCorrect = Readers.Readers.IntReaderSpecifyIntRange(entryPages.Text, 1, 2000, out pagesInput);
                ProductPlaytimeCorrect = Readers.Readers.DoubleReaderOutDouble(entryPlaytime.Text, out playTime);

                ProductLanguageIdCorrect = Readers.Readers.LegalIDRangeLanguage(entryLanguage.Text, out languageId);
                ProductShelfIdCorrect = Readers.Readers.LegalIDRangeShelfId(entryShelfId.Text, out shelfId);
                ProductCategoryIdCorrect = Readers.Readers.LegalIDRangeCategoryId(entryCategoryId.Text, out categoryId);
                ProductAudienceIdCorrect = Readers.Readers.LegalIDRangeAudienceId(entryAudienceId.Text, out audienceId);
                ProductMediaIdCorrect = Readers.Readers.LegalIDRangeMediaId(entryMediaId.Text, out mediaId);
                ProductIsbnCorrect = Readers.Readers.LongReaderOutLong(entryISBN.Text, out isbn);
                ProductPublishDateCorrect = Readers.Readers.ReadDateTime(entryDate.Text, out date);

                ProductStatusCorrect = inStock.IsToggled;
                ProductNewProductCorrect = newProduct.IsToggled;
                ProductHiddenProductCorrect = hiddenProduct.IsToggled;

            }
            catch (Exception errormessage)
            {
                DisplayActionSheet("Error", $"{errormessage.Message}", "OK");
            }


            if (!ProductTitleCorrect)
                entryTitle.BackgroundColor = Color.MediumVioletRed;
            else
                entryTitle.BackgroundColor = Color.White;

            if (!ProductDescriptionCorrect)
                entryDescription.BackgroundColor = Color.MediumVioletRed;
            else
                entryDescription.BackgroundColor = Color.White;

            if (!ProductAuthorNameCorrect)
                entryAuthor.BackgroundColor = Color.MediumVioletRed;
            else
                entryAuthor.BackgroundColor = Color.White;

            if (!ProductPublisherCorrect)
                entryPublisher.BackgroundColor = Color.MediumVioletRed;
            else
                entryPublisher.BackgroundColor = Color.White;

            if (!ProductNarratorCorrect)
                entryNarrator.BackgroundColor = Color.MediumVioletRed;
            else
                entryNarrator.BackgroundColor = Color.White;

            if (!ProductPagesCorrect)
                entryPages.BackgroundColor = Color.MediumVioletRed;
            else
                entryPages.BackgroundColor = Color.White;

            if (!ProductPlaytimeCorrect)
                entryPlaytime.BackgroundColor = Color.MediumVioletRed;
            else
                entryPlaytime.BackgroundColor = Color.White;

            if (!ProductLanguageIdCorrect)
                entryLanguage.BackgroundColor = Color.MediumVioletRed;
            else
                entryLanguage.BackgroundColor = Color.White;

            if (!ProductShelfIdCorrect)
                entryShelfId.BackgroundColor = Color.MediumVioletRed;
            else
                entryShelfId.BackgroundColor = Color.White;

            if (!ProductCategoryIdCorrect)
                entryCategoryId.BackgroundColor = Color.MediumVioletRed;
            else
                entryCategoryId.BackgroundColor = Color.White;

            if (!ProductAudienceIdCorrect)
                entryAudienceId.BackgroundColor = Color.MediumVioletRed;
            else
                entryAudienceId.BackgroundColor = Color.White;

            if (!ProductMediaIdCorrect)
                entryMediaId.BackgroundColor = Color.MediumVioletRed;
            else
                entryMediaId.BackgroundColor = Color.White;

            if (!ProductIsbnCorrect)
                entryISBN.BackgroundColor = Color.MediumVioletRed;
            else
                entryISBN.BackgroundColor = Color.White;

            ProductCorrectProductInput = ProductMediaIdCorrect
                                  && ProductStatusCorrect
                                  && ProductIsbnCorrect
                                  && ProductTitleCorrect
                                  && ProductDescriptionCorrect
                                  && ProductPagesCorrect
                                  && ProductPlaytimeCorrect
                                  && ProductPublisherCorrect
                                  && ProductLanguageIdCorrect
                                  && ProductAuthorNameCorrect
                                  && ProductPublishDateCorrect
                                  && ProductCategoryIdCorrect
                                  && ProductShelfIdCorrect
                                  && ProductNarratorCorrect
                                  && ProductNewProductCorrect
                                  && ProductAudienceIdCorrect
                                  && ProductHiddenProductCorrect;

            if (ProductCorrectProductInput)
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

        #endregion

        private void ShowCategories(object sender, EventArgs e)
        {
            categoryList.ItemsSource = EntityFrameworkCode.EntityframeworkCategories.ShowAllCategories();
        }

        private void AddCategoryButton_Pressed(object sender, EventArgs e)
        {
            var categoryList = EntityFrameworkCode.EntityframeworkCategories.ShowAllCategories();

            try
            {
                CateogryCorrectCategoryName = Readers.Readers.StringReader(entryCategorytab2.Text);
            }
            catch (Exception)
            {
                DisplayAlert("WRONG INPUT", "not allowed to have duplicate categories", "ok");
            }


            if (CateogryCorrectCategoryName)
            {

                foreach (var item in categoryList)
                {
                    if (item.CategoriesName == entryCategorytab2.Text)
                        DisplayAlert("WRONG INPUT", "not allowed to have duplicate categories", "ok");
                    return;
                }

                category.CategoriesName = entryCategorytab2.Text;
                EntityFrameworkCode.EntityframeworkCategories.CreateCategory(category);

            }
        }

        private void entryCategorytab2_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryCategorytab2.Text = e.NewTextValue;
        }
    }
}