using Decrypt_Library.EntityFrameworkCode;
using Decrypt_Library.Models;
using Decrypt_Library.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            var employees = EntityframeworkUsers.ShowAllUsers();
            var employeeList = employees.Where(el => el.UserTypeId == 2).ToList();

            userList.ItemsSource = employeeList;
            shelfPicker.ItemsSource = EntityframeworkShelf.ShowAllShelfNames();
            categoryPicker.ItemsSource = EntityframeworkCategories.ShowAllCategoryNames();
            audiencePicker.ItemsSource = EntityframeworkAudience.ShowAllAudienceGroups();
            mediaPicker.ItemsSource = EntityframeworkMediaTypes.ShowAllMediaNames();
            languagePicker.ItemsSource = EntityframeworkLanguages.ShowAllLanguageNames();
        }

        Product product = new Product();
        Category category = new Category();
        Event createdEvent = new Event();
        Language language = new Language(); 

        /// <summary>
        /// Product Bools
        /// </summary>
        #region Product bools

        bool ProductMediaIdCorrect = false;
        bool ProductLanguageIdCorrect = false;
        bool ProductAudienceIdCorrect = false;
        bool ProductCategoryIdCorrect = false;
        public static bool ProductStatusCorrect { get; set; } 
        public static bool ProductIsbnCorrect { get; set; } 
        public static bool ProductTitleCorrect { get; set; } 
        public static bool ProductDescriptionCorrect { get; set; } 
        public static bool ProductPagesCorrect { get; set; } 
        public static bool ProductPlaytimeCorrect { get; set; } 
        public static bool ProductPublisherCorrect { get; set; } 
        public static bool ProductAuthorNameCorrect { get; set; }
        public static bool ProductPublishDateCorrect { get; set; }
        public static bool ProductShelfIdCorrect { get; set; }
        public static bool ProductNarratorCorrect { get; set; }
        public static bool ProductNewProductCorrect { get; set; }
        public static bool ProductHiddenProductCorrect { get; set; }
        
        bool ProductCorrectProductInput = false;
        #endregion

        /// <summary>
        /// Category Bools
        /// </summary>
        #region Category bools
        bool CateogryCorrectCategoryName { get; set; }
        #endregion

        /// <summary>
        /// Event Bools
        /// </summary>
        #region Event bools
        bool EventEventNameCorrect { get; set; }
        bool EventEventTimeCorrect { get; set; }
        bool EventEventDescrptionCorrect { get; set; }

        bool EventEventInputsCorrect = false;

        #endregion

        /// <summary>
        /// Resets all bools
        /// </summary>
        #region Bool Reset

        private void BoolReset()
        {
            ProductMediaIdCorrect = false;
            ProductStatusCorrect = false;
            ProductIsbnCorrect = false;
            ProductTitleCorrect = false;
            ProductDescriptionCorrect = false;
            ProductPagesCorrect = false;
            ProductPlaytimeCorrect = false;
            ProductPublisherCorrect = false;

            ProductLanguageIdCorrect = false;
            ProductAuthorNameCorrect = false;
            ProductPublishDateCorrect = false;
            ProductCategoryIdCorrect = false;
            ProductShelfIdCorrect = false;
            ProductNarratorCorrect = false;
            ProductNewProductCorrect = false;
            ProductAudienceIdCorrect = false;
            ProductHiddenProductCorrect = false;
            ProductCorrectProductInput = false;

            EventEventNameCorrect = false;
            EventEventTimeCorrect = false;
            EventEventDescrptionCorrect = false;
            EventEventInputsCorrect = false;
        }

        #endregion

        /// <summary>
        /// Buttons for Products
        /// </summary>
        #region Buttons tab1 products
        private void ShowNoWindows()
        {
            createProductTab.IsVisible = false;

        }

        private void ShowProductsButton_Pressed(object sender, EventArgs e)
        {
            ProductList.IsVisible = true;
            ShowNoWindows();
            ProductList.ItemsSource = EntityFrameworkCode.EntityframeworkProducts.ShowAllProducts();
        }

        private void Button_AddProductClicked(object sender, EventArgs e)
        {
            createProductTab.IsVisible = true;
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

        private void entryAuthor_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryAuthor.Text = e.NewTextValue;
        }

        private void entryDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryDate.Text = e.NewTextValue;    
        }

        private void entryNarrator_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryNarrator.Text = e.NewTextValue;
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


        private void ProductListItem_Tapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
        }

        private void Colorize(bool Id, Picker userInput)
        {
            if(!Id)
                userInput.BackgroundColor = Color.IndianRed;
            else
                userInput.BackgroundColor = Color.White;
        }

        #endregion

        /// <summary>
        /// Completetion button of Products
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Complete product add
        private async void CompleteProduct_Pressed(object sender, EventArgs e)
        {
            ProductList.IsVisible = false;
            if (!createProductTab.IsVisible)
            {
                createProductTab.IsVisible = true;
                return;
            }

            int pagesInput = 0;
            double playTime = 0;
            long isbn = 0;
            DateTime date = DateTime.Now;

            try
            {
                ProductTitleCorrect = Readers.Readers.StringReader(entryTitle.Text);
                ProductIsbnCorrect = Readers.Readers.LongReaderOutLong(entryISBN.Text, out isbn);
                ProductPublisherCorrect = Readers.Readers.StringReader(entryPublisher.Text);
                ProductAuthorNameCorrect = Readers.Readers.StringReader(entryAuthor.Text);
                ProductPublishDateCorrect = Readers.Readers.ReadDateTime(entryDate.Text, out date);
                ProductNarratorCorrect = Readers.Readers.StringReader(entryNarrator.Text);
                ProductPlaytimeCorrect = Readers.Readers.DoubleReaderOutDouble(entryPlaytime.Text, out playTime);
                ProductPagesCorrect = Readers.Readers.IntReaderSpecifyIntRange(entryPages.Text, 1, 2000, out pagesInput);
                ProductDescriptionCorrect = Readers.Readers.StringReader(entryDescription.Text);

                ProductAudienceIdCorrect = !string.IsNullOrEmpty(audiencePicker.SelectedItem.ToString());
                ProductLanguageIdCorrect = !string.IsNullOrEmpty(languagePicker.SelectedItem.ToString());
                ProductShelfIdCorrect = !string.IsNullOrEmpty(shelfPicker.SelectedItem.ToString());
                ProductCategoryIdCorrect = !string.IsNullOrEmpty(categoryPicker.SelectedItem.ToString());
                ProductMediaIdCorrect = !string.IsNullOrEmpty(mediaPicker.SelectedItem.ToString());

                Colorize(ProductAudienceIdCorrect, audiencePicker);
                Colorize(ProductLanguageIdCorrect, languagePicker);
                Colorize(ProductShelfIdCorrect, shelfPicker);
                Colorize(ProductCategoryIdCorrect, categoryPicker);
                Colorize(ProductMediaIdCorrect, mediaPicker);

                ProductStatusCorrect = inStock.IsChecked;
                ProductNewProductCorrect = newProduct.IsChecked;
                ProductHiddenProductCorrect = hiddenProduct.IsChecked;

                ProductCorrectProductInput = ProductIsbnCorrect
                                      && ProductTitleCorrect
                                      && ProductDescriptionCorrect
                                      && ProductPagesCorrect
                                      && ProductPlaytimeCorrect
                                      && ProductPublisherCorrect
                                      && ProductAuthorNameCorrect
                                      && ProductPublishDateCorrect
                                      && ProductNarratorCorrect;

                if (ProductCorrectProductInput)
                {
                    product.Title = entryTitle.Text;
                    product.Description = entryDescription.Text;
                    product.AuthorName = entryAuthor.Text;
                    product.Publisher = entryPublisher.Text;
                    product.Narrator = entryNarrator.Text;

                    product.Pages = pagesInput;
                    product.LanguageId = EntityframeworkLanguages.ShowSpecificCountryIdByLanguage(languagePicker.SelectedItem.ToString());
                    product.ShelfId = EntityframeworkShelf.ShowSpecificShelfIdByLetter(shelfPicker.SelectedItem.ToString());
                    product.CategoryId = EntityframeworkCategories.ShowSpecificCategoryIdByCategoriesName(categoryPicker.SelectedItem.ToString());
                    product.AudienceId = EntityframeworkAudience.ShowSpecificAudienceIdByAgeGroup(audiencePicker.SelectedItem.ToString());
                    product.MediaId = EntityframeworkMediaTypes.ShowSpecificMediaTypeIdByFormatName(mediaPicker.SelectedItem.ToString());
                    product.Isbn = isbn;
                    product.Playtime = playTime;
                    product.PublishDate = date;
                    product.NewProduct = newProduct.IsChecked;
                    product.HiddenProduct = hiddenProduct.IsChecked;
                    product.Status = inStock.IsChecked;

                    EntityframeworkProducts.CreateProduct(product);
                    ProductList.ItemsSource = EntityframeworkProducts.ShowAllProducts();
                    createProductTab.IsVisible = false;
                    ProductList.IsVisible = true;
                    product = new Product();
                }
                else
                    await DisplayActionSheet($"Wrong input", "could not be inserted", "OK");

            }
            catch (Exception errormessage)
            {
                await DisplayActionSheet($"{errormessage.Message}", "Error", "OK");
            }
        }

        private void RemoveProduct_ButtonClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Product selectedProduct = btn.BindingContext as Product;
            EntityframeworkProducts.RemoveProduct(selectedProduct);

            ProductList.ItemsSource = EntityframeworkProducts.ShowAllProducts();
        }

        #endregion

        /// <summary>
        /// Buttons for Category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Buttons tab2 categories

        private void EntryCategoryNametab2_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryCategoryNametab2.Text = e.NewTextValue;
        }

        private void ShowCategories_Pressed(object sender, EventArgs e)
        {
            createCategoryBar.IsVisible = false;
            categoryTab.IsVisible= true;
            categoryList.IsVisible= true;
            categoryList.ItemsSource = EntityframeworkCategories.ShowAllCategories();
        }

        private void AddCategoryButton_Pressed(object sender, EventArgs e)
        {
            if (!createCategoryBar.IsVisible)
            {
                createCategoryBar.IsVisible = true;
                return;
            }

            try
            {
                if (Readers.Readers.StringReader(entryCategoryNametab2.Text))
                {
                    category.CategoriesName = entryCategoryNametab2.Text;
                    EntityframeworkCategories.CreateCategory(category);
                    createCategoryBar.IsVisible = false;
                    categoryList.ItemsSource = EntityframeworkCategories.ShowAllCategories();
                    category = new Category();
                }
            }

            catch (Exception exception)
            {
                DisplayAlert("Error", $"{exception}", "ok");
            }
        }

        private void RemoveCategory_ButtonClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Category selectedCategory = btn.BindingContext as Category;

            foreach (var item in EntityframeworkProducts.ShowAllProducts())
            {
                if (selectedCategory.Id == item.CategoryId)
                {
                    DisplayAlert("Error", "Can't remove a language with products associated to it", "OK");
                    return;
                }
            }
            EntityframeworkCategories.RemoveCategory(selectedCategory);
            categoryList.ItemsSource = EntityframeworkCategories.ShowAllCategories();
        }

        #endregion

        /// <summary>
        /// Buttons for Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Buttons tab3 events
        private void ShowAllEvents_Pressed(object sender, EventArgs e)
        {
            createEventBar.IsVisible = false;
            eventList.ItemsSource = EntityFrameworkCode.EntityframeworkEvents.ShowAllEvents();
        }

        private void entryEventNametab2_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryEventNametab2.Text = e.NewTextValue;
        }

        private void entryEventDescriptiontab2_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryEventDescriptiontab2.Text = e.NewTextValue;
        }

        private void entryEventTimetab2_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryEventTimetab2.Text = e.NewTextValue;
        }
        #endregion

        /// <summary>
        /// Buttons for Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Event buttons

        private void AddEventButton_Pressed(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;

            if (!createEventBar.IsVisible) 
            {
                createEventBar.IsVisible = true;
                return;
            }

            try
            {
                EventEventNameCorrect = Readers.Readers.StringReader(entryEventNametab2.Text);
                EventEventTimeCorrect = Readers.Readers.ReadDateTime(entryEventTimetab2.Text, out date);
                if (!string.IsNullOrEmpty(entryEventDescriptiontab2.Text))
                    EventEventDescrptionCorrect = true;
            }
            catch
            {
                DisplayAlert("Error wrong input", "one of tha values were wrong", "ok");
            }

            EventEventInputsCorrect = EventEventNameCorrect 
                                           && EventEventTimeCorrect 
                                           && EventEventDescrptionCorrect;

            if (EventEventInputsCorrect)
            {
                try
                {
                    createdEvent.EventName = entryEventNametab2.Text;
                    createdEvent.Description = entryEventDescriptiontab2.Text;
                    createdEvent.Time = date;
                    EntityframeworkEvents.CreateEvent(createdEvent);
                    eventList.ItemsSource = EntityframeworkEvents.ShowAllEvents();
                    createEventBar.IsVisible = false;
                    createdEvent = new Event();
                }
                catch (Exception exception)
                {
                    DisplayAlert("Error", $"{exception}", "OK");
                }
            }
        }
        private void RemoveEvent_ButtonClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Event selectedEvent = btn.BindingContext as Event;
            EntityframeworkEvents.RemoveEvent(selectedEvent);

            eventList.ItemsSource = EntityframeworkEvents.ShowAllEvents();
        }

        #endregion

        #region Language Buttons

        private void AddLanguageButton_Pressed(object sender, EventArgs e)
        {
            try
            {
                if (!createLanguageBar.IsVisible)
                {
                    createLanguageBar.IsVisible = true;
                    removeLanguageBar.IsVisible = false;
                    return;
                }

                if (Readers.Readers.StringReader(entryLanguageCreatetab3.Text))
                {
                    language.Languages = entryLanguageCreatetab3.Text;
                    EntityFrameworkCode.EntityframeworkLanguages.CreateLanguage(language);
                    languageList.ItemsSource = EntityFrameworkCode.EntityframeworkLanguages.ShowAllLanguages();
                    createLanguageBar.IsVisible = false;
                    language = new Language();
                }
            } catch (Exception exception)
            {
                DisplayAlert("Error", $"{exception.Message}", "OK");
            }
        }
        private void entryLanguageCreatetab3_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryLanguageCreatetab3.Text = e.NewTextValue;  
        }

        private void entryLanguageRemovetab3_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryLanguageRemovetab3.Text = e.NewTextValue;
        }

        private void ShowLanguagesButton_Pressed(object sender, EventArgs e)
        {
            createLanguageBar.IsVisible = false;
            languageList.ItemsSource = EntityframeworkLanguages.ShowAllLanguages();
        }


        private void Remove_LanguageButton(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Language selectedLanguage = btn.BindingContext as Language;


            foreach (var item in EntityframeworkProducts.ShowAllProducts())
            {
                if (selectedLanguage.Id == item.LanguageId)
                {
                    DisplayAlert("Error", "Can't remove a language with products associated to it", "OK");
                    return;
                }
            }

            EntityframeworkLanguages.RemoveLanguage(selectedLanguage);
            languageList.ItemsSource = EntityframeworkLanguages.ShowAllLanguages();
        }
        #endregion


        #region Employee Options

        private void Button_Clicked(object sender, EventArgs e)
        {
            userList.IsVisible = false;
            register.IsVisible = true;
            startLabel.IsVisible = false;
            endLabel.IsVisible = true;
            pressedButton.IsVisible = false;    

            //await Navigation.PushAsync(new RegisterPage());

        }

        bool correctUserName = false;
        bool correctPassword = false;
        bool correctEmail = false;
        bool correctPhone = false;
        bool correctSSN = false;

        private void Entry_Completed(object sender, EventArgs e)
        {
            var user = new User();
            long convertedPhoneNr = 0;
            long convertedSSN = 0;

            try
            {
                correctUserName = Readers.Readers.StringReaderSpecifyStringRange(Username.Text, 3, 15);
                correctPassword = Readers.Readers.StringPasswordCorrect(Password.Text, 8, true);
                correctEmail = Readers.Readers.EmailReader(Email.Text);
                correctPhone = Readers.Readers.LongReaderLengthEqualsTo(Phone.Text, 10, out convertedPhoneNr);
                correctSSN = Readers.Readers.LongReaderLengthEqualsTo(SSN.Text, 10, out convertedSSN);

                if (!correctUserName)
                    wrongUsernameInput.IsVisible = true;
                else
                    wrongUsernameInput.IsVisible = false;

                if (!correctPassword)
                    wrongPasswordInput.IsVisible = true;
                else
                    wrongPasswordInput.IsVisible = false;

                if (!correctEmail)
                    wrongEmailInput.IsVisible = true;
                else
                    wrongEmailInput.IsVisible = false;

                correctPhone = Readers.Readers.LongReaderLengthEqualsTo(Phone.Text, 10, out convertedPhoneNr);
                if (!correctPhone)
                    wrongPhoneInput.IsVisible = true;
                else
                    wrongPhoneInput.IsVisible = false;

                correctSSN = Readers.Readers.LongReaderLengthEqualsTo(SSN.Text, 10, out convertedSSN);
                if (!correctSSN)
                {
                    wrongSSNInput.IsVisible = true;

                    foreach (var item in EntityframeworkUsers.ShowAllUsers())
                    {
                        if (item.Ssn == user.Ssn)
                        {
                            DisplayAlert("Error!", "Det finns redan en användare med samma personnummer", "Gå vidare");

                        }
                    }
                }
                if (!correctSSN)
                {
                    wrongSSNInput.IsVisible = true;
                    //return;
                }
                else
                    wrongSSNInput.IsVisible = false;
            }
            catch (Exception exception)
            {
                DisplayAlert("Error", $"{exception.Message}", "Try again!");
            }

            bool completeRegistration = correctUserName && correctPassword && correctEmail && correctPhone && correctSSN;

            if (completeRegistration)
            {
                user.UserName = Username.Text;
                user.Password = Password.Text;
                user.Email = Email.Text;
                user.Phonenumber = convertedPhoneNr;
                user.Ssn = convertedSSN;
                user.UserTypeId = 2;


                EntityframeworkUsers.CreateUser(user);
                DisplayAlert("YAY!", "Nu är din registrering klar - logga in för att komma till boksidan", "Gå vidare");
            }
            else
            {
                DisplayAlert("Ooops", "Dubbelkolla alla fält och försök igen", "OK");
            }

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Entry_Completed(sender, e);
        }






        #endregion

        private void Button_Clicked_Product(object sender, EventArgs e)
        {
            loanedInfo.IsVisible = false;
            productInfo.ItemsSource = EntityframeworkCode.EntityframeworkStatistics.MostReadCategory();
            productInfo.IsVisible = true; 
        }

        private void Button_Clicked_Loaned(object sender, EventArgs e)
        {
            productInfo.IsVisible = false;
            loanedInfo.ItemsSource = EntityframeworkCode.EntityframeworkStatistics.ShowLoansByDescOrder();
            loanedInfo.IsVisible =true;
        }
    }
}