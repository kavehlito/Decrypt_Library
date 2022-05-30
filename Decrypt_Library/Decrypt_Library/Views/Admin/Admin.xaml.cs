using Decrypt_Library.EntityframeworkCode;
using Decrypt_Library.EntityFrameworkCode;
using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

            shelfPicker.ItemsSource = EntityframeworkShelf.ShowAllShelfNames();
            categoryPicker.ItemsSource = EntityframeworkCategories.ShowAllCategoryNames();
            audiencePicker.ItemsSource = EntityframeworkAudience.ShowAllAudienceGroups();
            mediaPicker.ItemsSource = EntityframeworkMediaTypes.ShowAllMediaNames();
            languagePicker.ItemsSource = EntityframeworkLanguages.ShowAllLanguageNames();
            statsPicker.ItemsSource = EntityframeworkStatistics.StatsValues();
            userIDpicker.ItemsSource = EntityframeworkUsers.ShowAllUserTypeNames();
        }
        protected override void OnAppearing()
        {
            if (UserLogin.thisUser.UserTypeId == 1)
                userIDpicker.ItemsSource = EntityframeworkUsers.ShowAllUserTypeNames();

            if (UserLogin.thisUser.UserTypeId == 2)
            {
                List<string> stringList = new List<string>();
                stringList.Add("User");
                userIDpicker.ItemsSource = stringList;
            }
        }

        Product product = new Product();
        Product selectedProductToChange = new Product();
        Category category = new Category();
        Event createdEvent = new Event();
        Language language = new Language();

        int? selectedMediaId;

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
            shelfChangeTab.IsVisible = false;
        }

        private void ShowProductsButton_Pressed(object sender, EventArgs e)
        {
            ProductList.IsVisible = true;
            ShowNoWindows();
            ProductList.ItemsSource = EntityframeworkProducts.ShowAllProducts();
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
            ProductList.IsVisible = false;
            shelfChangeTab.IsVisible = true;
            changeShelf.ItemsSource = EntityframeworkShelf.ShowAllShelfNames();
            changeAudiencePicker.ItemsSource = EntityframeworkAudience.ShowAllAudienceGroups();
            changeCategoryPicker.ItemsSource = EntityframeworkCategories.ShowAllCategoryNames();
            selectedProductToChange = e.Item as Product;
            tappedBook.Text = selectedProductToChange.Title;
            ProductList.ItemsSource = EntityframeworkProducts.ShowAllProducts();


            if (!shelfChangeTab.IsVisible)
            {
                shelfChangeTab.IsVisible = true;
            }
        }

        private void MediaPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            selectedMediaId = picker.SelectedIndex + 1;

            if (selectedMediaId == 1 || selectedMediaId == 2)
            {
                pageLabel.IsVisible = true;
                pageFrame.IsVisible = true;
                entryPages.IsVisible = true;
                entryPages.IsEnabled = true;

                playTimeLabel.IsVisible = false;
                playTimeFrame.IsVisible = false;
                entryPlaytime.IsVisible = false;
                entryPlaytime.IsEnabled = false;

                narratorLabel.IsVisible = false;
                narratorFrame.IsVisible = false;
                entryNarrator.IsVisible = false;
                entryNarrator.IsEnabled = false;
            }
            if (selectedMediaId == 3)
            {
                playTimeLabel.IsVisible = true;
                playTimeFrame.IsVisible = true;
                entryPlaytime.IsVisible = true;
                entryPlaytime.IsEnabled = true;

                narratorLabel.IsVisible = true;
                narratorFrame.IsVisible = true;
                entryNarrator.IsVisible = true;
                entryNarrator.IsEnabled = true;

                pageLabel.IsVisible = false;
                entryPages.IsVisible = false;
                entryPages.IsEnabled = false;
                pageFrame.IsVisible = false;

            }
        }
        private void ShowCreateProdctTab_ButtonClicked(object sender, EventArgs e)
        {
            ProductList.IsVisible = false;
            shelfChangeTab.IsVisible = false;
            if (!createProductTab.IsVisible)
            {
                createProductTab.IsVisible = true;
                return;
            }
        }

        private void ChangeProduct_Clicked(object sender, EventArgs e)
        {
            try
            {
                selectedProductToChange.Title = changedTitleEntry.Text ?? selectedProductToChange.Title;
                selectedProductToChange.Description = changedDescriptionEntry.Text ?? selectedProductToChange.Description;

                if (changeCategoryPicker.SelectedIndex != -1)
                    selectedProductToChange.CategoryId = EntityframeworkCategories.ShowSpecificCategoryIdByCategoriesName(changeCategoryPicker.SelectedItem.ToString());

                if (changeAudiencePicker.SelectedIndex != -1)
                    selectedProductToChange.AudienceId = EntityframeworkAudience.ShowSpecificAudienceIdByAgeGroup(changeAudiencePicker.SelectedItem.ToString());

                shelfChangeTab.IsVisible = false;
                EntityframeworkProducts.UpdateProduct(selectedProductToChange);
                ProductList.ItemsSource = EntityframeworkProducts.ShowAllProducts();
                ProductList.IsVisible = true;
                selectedProductToChange = new Product();

                changedTitleEntry.Text = "";
                changedDescriptionEntry.Text = "";
                changeAudiencePicker.SelectedIndex = -1;
                changeAudiencePicker.SelectedIndex = -1;

                ProductList.ItemsSource = EntityframeworkProducts.ShowAllProducts();
                ProductList.IsVisible = true;
                selectedProductToChange = new Product();
            }
            catch (Exception exception)
            {
                DisplayAlert("Error", $"{exception.Message}", "OK");
            }
        }

        private void ChosenProduct_Clicked(object sender, EventArgs e)
        {
            if (changeShelf.SelectedIndex == -1)
            {
                return;
            }

            try
            {
                selectedProductToChange.ShelfId = EntityframeworkShelf.ShowSpecificShelfIdByLetter(changeShelf.SelectedItem.ToString());
                EntityframeworkProducts.UpdateProduct(selectedProductToChange);
                shelfChangeTab.IsVisible = false;
                ProductList.ItemsSource = EntityframeworkProducts.ShowAllProducts();
                ProductList.IsVisible = true;
                selectedProductToChange = new Product();
            }
            catch (Exception)
            {
                return;
            }
        }
        private async void CancelProductButton_Clicked(object sender, EventArgs e)
        {
            var tab = new MainPage();
            tab.CurrentPage = tab.Children[5];

            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(tab));
        }

        private async void CancelEditProductButton_Clicked(object sender, EventArgs e)
        {
            var tab = new MainPage();
            tab.CurrentPage = tab.Children[5];
            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(tab));
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

            int pagesInput = 0;
            double playTime = 0;
            long isbn = 0;
            DateTime date = DateTime.Now;

            if (shelfPicker.SelectedIndex != -1)
                shelfPicker.BackgroundColor = Color.YellowGreen;
            else
                shelfPicker.BackgroundColor = Color.IndianRed;

            if (categoryPicker.SelectedIndex != -1)
                categoryPicker.BackgroundColor = Color.YellowGreen;
            else
                categoryPicker.BackgroundColor = Color.IndianRed;

            if (languagePicker.SelectedIndex != -1)
                languagePicker.BackgroundColor = Color.YellowGreen;
            else
                languagePicker.BackgroundColor = Color.IndianRed;

            if (audiencePicker.SelectedIndex != -1)
                audiencePicker.BackgroundColor = Color.YellowGreen;
            else
                audiencePicker.BackgroundColor = Color.IndianRed;

            if (mediaPicker.SelectedIndex != -1)
                mediaPicker.BackgroundColor = Color.YellowGreen;
            else
                mediaPicker.BackgroundColor = Color.IndianRed;

            try
            {
                ProductTitleCorrect = Readers.Readers.StringReader(entryTitle.Text);
                ProductIsbnCorrect = Readers.Readers.LongReaderOutLong(entryISBN.Text, out isbn);
                ProductPublisherCorrect = Readers.Readers.StringReader(entryPublisher.Text);
                ProductAuthorNameCorrect = Readers.Readers.StringReader(entryAuthor.Text);
                ProductPublishDateCorrect = Readers.Readers.ReadDateTime(entryDate.Text, out date);
                ProductDescriptionCorrect = Readers.Readers.StringReader(entryDescription.Text);

                ProductAudienceIdCorrect = !string.IsNullOrEmpty(audiencePicker.SelectedItem.ToString());
                ProductLanguageIdCorrect = !string.IsNullOrEmpty(languagePicker.SelectedItem.ToString());
                ProductShelfIdCorrect = !string.IsNullOrEmpty(shelfPicker.SelectedItem.ToString());
                ProductCategoryIdCorrect = !string.IsNullOrEmpty(categoryPicker.SelectedItem.ToString());

                if (selectedMediaId == 1 || selectedMediaId == 2)
                {
                    ProductPagesCorrect = Readers.Readers.IntReaderSpecifyIntRange(entryPages.Text, 1, 2000, out pagesInput);
                    ProductPlaytimeCorrect = true;
                    ProductNarratorCorrect = true;
                    ProductMediaIdCorrect = true;
                }
                if (selectedMediaId == 3)
                {
                    ProductPlaytimeCorrect = Readers.Readers.DoubleReaderOutDouble(entryPlaytime.Text, out playTime);
                    ProductNarratorCorrect = Readers.Readers.StringReader(entryNarrator.Text);
                    ProductPagesCorrect = true;
                    ProductMediaIdCorrect = true;
                }

                ProductStatusCorrect = inStock.IsChecked;
                ProductNewProductCorrect = newProduct.IsChecked;
                ProductHiddenProductCorrect = hiddenProduct.IsChecked;

                ProductCorrectProductInput = ProductIsbnCorrect
                                      && ProductMediaIdCorrect
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
                    if (selectedMediaId == 1 || selectedMediaId == 2)
                    {
                        product.Pages = pagesInput;
                        product.Narrator = null;
                        product.Playtime = null;
                    }

                    if (selectedMediaId == 3)
                    {
                        product.Narrator = entryNarrator.Text;
                        product.Playtime = playTime;
                        product.Pages = null;
                    }

                    product.Title = entryTitle.Text;
                    product.Description = entryDescription.Text;
                    product.AuthorName = entryAuthor.Text;
                    product.Publisher = entryPublisher.Text;

                    product.LanguageId = EntityframeworkLanguages.ShowSpecificCountryIdByLanguage(languagePicker.SelectedItem.ToString());
                    product.ShelfId = EntityframeworkShelf.ShowSpecificShelfIdByLetter(shelfPicker.SelectedItem.ToString());
                    product.CategoryId = EntityframeworkCategories.ShowSpecificCategoryIdByCategoriesName(categoryPicker.SelectedItem.ToString());
                    product.AudienceId = EntityframeworkAudience.ShowSpecificAudienceIdByAgeGroup(audiencePicker.SelectedItem.ToString());
                    product.MediaId = selectedMediaId;
                    product.Isbn = isbn;
                    product.PublishDate = date;
                    product.NewProduct = newProduct.IsChecked;
                    product.HiddenProduct = hiddenProduct.IsChecked;
                    product.Status = inStock.IsChecked;

                    EntityframeworkProducts.CreateProduct(product);

                    product = new Product();
                    var tab = new MainPage();
                    tab.CurrentPage = tab.Children[5];

                    await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(tab));

                }
                else
                    return;
            }
            catch
            {
                return;
            }
        }

        private void RemoveProduct_ButtonClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Product selectedProduct = btn.BindingContext as Product;
            EntityframeworkProducts.HideProduct(selectedProduct);
            ProductList.ItemsSource = EntityframeworkProducts.ShowAllProducts();
        }



        #endregion

        /// <summary>
        /// Buttons for Category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Buttons tab2 categories

        private void CategoryList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
        }
        private void EntryCategoryNametab2_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryCategoryNametab2.Text = e.NewTextValue;
        }

        private void ShowCategories_Pressed(object sender, EventArgs e)
        {
            createCategoryBar.IsVisible = false;
            categoryTab.IsVisible = true;
            categoryList.IsVisible = true;
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
        private void EventList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
        }
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
                EventEventTimeCorrect = Readers.Readers.ReadDateTime2(entryEventTimetab2.Text, out date);
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

        private void LanguageList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
        }
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
            }
            catch (Exception exception)
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

        private void UserList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
        }

        private void AddUser_ButtonClicked(object sender, EventArgs e)
        {
            userList.IsVisible = false;
            register.IsVisible = true;
            startLabel.IsVisible = false;
            endLabel.IsVisible = true;

            //await Navigation.PushAsync(new RegisterPage());
        }

        public static bool correctUserName = false;
        public static bool correctPassword = false;
        public static bool correctConfirmationPassword = false;
        public static bool correctEmail = false;
        public static bool correctPhone = false;
        public static bool correctSSN = false;

        private void RegisterUser_AdminClicked(object sender, EventArgs e)
        {
            var user = new User();
            long convertedPhoneNr = 0;
            long convertedSSN = 0;
            int userType = 0;

            try
            {
                correctPhone = Readers.Readers.LongReaderLengthEqualsTo(Phone.Text, 10, out convertedPhoneNr);
                correctPhone = Readers.Readers.LongReaderLengthEqualsTo(Phone.Text, 10, out convertedPhoneNr);
                correctSSN = Readers.Readers.LongReaderLengthEqualsTo(SSN.Text, 10, out convertedSSN);

                foreach (var item in EntityframeworkUsers.ShowAllUserTypes())
                {
                    if (userIDpicker.SelectedIndex == -1)
                        return;

                    if (item.UserTypeName.Contains(userIDpicker.SelectedItem.ToString()))
                        userType = item.Id;
                }

                if (!correctSSN)
                {
                    foreach (var item in EntityframeworkUsers.ShowAllUsers())
                    {
                        if (item.Ssn == user.Ssn)
                        {
                            DisplayAlert("Error!", "Det finns redan en användare med samma personnummer", "Gå vidare");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                DisplayAlert("Error", $"{exception.Message}", "Try again!");
            }

            bool completeRegistration = correctUserName
                                        && correctPassword
                                        && correctEmail
                                        && correctPhone
                                        && correctSSN
                                        && correctConfirmationPassword;

            if (completeRegistration)
            {
                user.UserName = Username.Text;
                user.Password = Password.Text;
                user.Email = Email.Text;
                user.Phonenumber = convertedPhoneNr;
                user.Ssn = convertedSSN;
                user.UserTypeId = userType;

                Username.Text = "";
                Email.Text = "";
                SSN.Text = "";
                Phone.Text = "";
                Password.Text = "";
                passwordConfirmation.Text = "";
                register.IsVisible = false;
                userList.IsVisible = true;

                foreach (var item in EntityframeworkUsers.ShowAllUsers())
                {
                    if (item.UserName.Contains(user.UserName))
                    {
                        DisplayAlert("Error", $"Användarnamnet: {user.UserName} finns redan i databasen", "OK");
                        return;
                    }
                }

                foreach (var item in EntityframeworkUsers.ShowAllUsers())
                {
                    if (item.Ssn == user.Ssn)
                    {
                        DisplayAlert("Error", $"Användare med personummer: {user.Ssn} finns redan i databasen", "OK");
                        return;
                    }
                }

                foreach (var item in EntityframeworkUsers.ShowAllUsers())
                {
                    if (item.Phonenumber == user.Phonenumber)
                    {
                        DisplayAlert("Error", $"Användare med telefonnumret: {user.Phonenumber} finns redan i databasen", "OK");
                        return;
                    }
                }

                foreach (var item in EntityframeworkUsers.ShowAllUsers())
                {
                    if (item.Email == user.Email)
                    {
                        DisplayAlert("Error", $"Användare med Email: {user.Email} finns redan i databasen", "OK");
                        return;
                    }
                }

                EntityframeworkUsers.CreateUser(user);
                userList.ItemsSource = EntityframeworkUsers.ShowAllUsers().Where(x => x.UserTypeId == 1 || x.UserTypeId == 2);
            }
            else
            {
                DisplayAlert("Ooops", "Dubbelkolla alla fält och försök igen", "OK");
            }
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var tab = new MainPage();
            tab.CurrentPage = tab.Children[5];

            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(tab));
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            RegisterUser_AdminClicked(sender, e);
        }


        private void ShowAllUsers_Clicked(object sender, EventArgs e)
        {
            if (UserLogin.thisUser.UserTypeId == 2)
                userList.ItemsSource = EntityframeworkUsers.ShowAllUsers().Where(x => x.UserTypeId == 3);
            else userList.ItemsSource = EntityframeworkUsers.ShowAllUsers();
            register.IsVisible = false;
            endLabel.IsVisible = false;
            startLabel.IsVisible = true;
            userList.IsVisible = true;
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            Username.Text = e.NewTextValue;
        }
        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            Email.Text = e.NewTextValue;
        }
        private void SSN_TextChanged(object sender, TextChangedEventArgs e)
        {
            SSN.Text = e.NewTextValue;
        }
        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            Phone.Text = e.NewTextValue;
        }
        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password.Text = e.NewTextValue;
        }
        private void PasswordConfirmation_TextChanged(object sender, TextChangedEventArgs e)
        {
            passwordConfirmation.Text = e.NewTextValue;
        }

        private void Remove_UserClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            User user = btn.BindingContext as User;

            foreach (var users in EntityframeworkUsers.ShowAllUsers())
            {
                foreach (var bookhistory in users.BookHistories)
                {
                    if (bookhistory.UserId == user.Id)
                    {
                        DisplayAlert("Error", "Du kan inte ta bort en användare med historik", "OK");
                        return;
                    }
                }
            }
            EntityframeworkUsers.RemoveUser(user);
            userList.ItemsSource = EntityframeworkUsers.ShowAllUsers().Where(x => x.UserTypeId == 1 || x.UserTypeId == 2);
        }

        #endregion

        #region Statistics Page
        private void statsPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var showStatList = statsPicker.SelectedIndex;

            switch (showStatList)
            {
                case 0:
                    loanedTab.IsVisible = false;
                    userTab.IsVisible = false;
                    ProductTab.IsVisible = true;

                    mediaInfo.IsVisible = false;
                    FavouriteMediaType.IsVisible = false;
                    TopFive.IsVisible = false;
                    mostPopular.IsVisible = false;
                    AmountOfBooks.IsVisible = false;
                    AmountOfBooksLoanedATM.IsVisible = false;
                    loanedInfo.IsVisible = false;
                    AmountOfBooksLoaned.IsVisible = false;
                    loanedInfoStatistics.IsVisible = false;
                    userInfo.IsVisible = false;
                    totalNrUsers.IsVisible = false;
                    DelayedBooks.IsVisible = false;
                    reminders.IsVisible = false;

                    productInfo.ItemsSource = EntityframeworkStatistics.MostReadCategory();
                    productInfo.IsVisible = true;

                    FavoriteCategory.IsVisible = true;
                    FavoriteCategory.Text = "Mest populära kategorier i rangordning:";
                    break;

                case 1:
                    loanedTab.IsVisible = false;
                    userTab.IsVisible = false;
                    ProductTab.IsVisible = true;

                    productInfo.IsVisible = false;
                    FavoriteCategory.IsVisible = false;
                    TopFive.IsVisible = false;
                    mostPopular.IsVisible = false;
                    AmountOfBooks.IsVisible = false;
                    AmountOfBooksLoanedATM.IsVisible = false;
                    loanedInfo.IsVisible = false;
                    AmountOfBooksLoaned.IsVisible = false;
                    loanedInfoStatistics.IsVisible = false;
                    userInfo.IsVisible = false;
                    totalNrUsers.IsVisible = false;
                    DelayedBooks.IsVisible = false;
                    reminders.IsVisible = false;

                    mediaInfo.ItemsSource = EntityframeworkStatistics.ShowMostPopMediaType();
                    FavouriteMediaType.Text = "Populära mediatyper i rangordning: ";
                    mediaInfo.IsVisible = true;
                    FavouriteMediaType.IsVisible = true;

                    break;

                case 2:
                    loanedTab.IsVisible = false;
                    userTab.IsVisible = false;
                    ProductTab.IsVisible = true;

                    productInfo.IsVisible = false;
                    FavoriteCategory.IsVisible = false;
                    mediaInfo.IsVisible = false;
                    FavouriteMediaType.IsVisible = false;
                    AmountOfBooks.IsVisible = false;
                    AmountOfBooksLoanedATM.IsVisible = false;
                    loanedInfo.IsVisible = false;
                    AmountOfBooksLoaned.IsVisible = false;
                    loanedInfoStatistics.IsVisible = false;
                    userInfo.IsVisible = false;
                    totalNrUsers.IsVisible = false;
                    DelayedBooks.IsVisible = false;
                    reminders.IsVisible = false;

                    TopFive.Text = "TOP 5 mest populära produkter:";
                    mostPopular.ItemsSource = EntityframeworkStatistics.ShowTopFiveMostRead();

                    TopFive.IsVisible = true;
                    mostPopular.IsVisible = true;
                    break;

                case 3:
                    loanedTab.IsVisible = false;
                    userTab.IsVisible = false;
                    ProductTab.IsVisible = true;

                    productInfo.IsVisible = false;
                    FavoriteCategory.IsVisible = false;
                    mediaInfo.IsVisible = false;
                    FavouriteMediaType.IsVisible = false;
                    TopFive.IsVisible = false;
                    mostPopular.IsVisible = false;
                    AmountOfBooksLoanedATM.IsVisible = false;
                    loanedInfo.IsVisible = false;
                    AmountOfBooksLoaned.IsVisible = false;
                    loanedInfoStatistics.IsVisible = false;
                    userInfo.IsVisible = false;
                    totalNrUsers.IsVisible = false;
                    DelayedBooks.IsVisible = false;
                    reminders.IsVisible = false;

                    var bookNr = EntityframeworkStatistics.AmountOfBooks().ToString();
                    AmountOfBooks.Text = $"Totalt antal produkter i vårt sortiment: {bookNr}";
                    AmountOfBooks.IsVisible = true;
                    break;

                case 4:
                    ProductTab.IsVisible = false;
                    userTab.IsVisible = false;
                    loanedTab.IsVisible = true;

                    productInfo.IsVisible = false;
                    FavoriteCategory.IsVisible = false;
                    mediaInfo.IsVisible = false;
                    FavouriteMediaType.IsVisible = false;
                    TopFive.IsVisible = false;
                    mostPopular.IsVisible = false;
                    AmountOfBooks.IsVisible = false;
                    AmountOfBooksLoaned.IsVisible = false;
                    loanedInfoStatistics.IsVisible = false;
                    userInfo.IsVisible = false;
                    totalNrUsers.IsVisible = false;
                    DelayedBooks.IsVisible = false;
                    reminders.IsVisible = false;

                    var loanedBooks = EntityframeworkStatistics.LoanedBooksATM().ToString();
                    AmountOfBooksLoanedATM.Text = $"Antal utlånade produkter just nu: {loanedBooks}";
                    loanedInfo.ItemsSource = EntityframeworkStatistics.ShowLoansByDescOrder();
                    AmountOfBooksLoanedATM.IsVisible = true;
                    loanedInfo.IsVisible = true;
                    break;

                case 5:
                    ProductTab.IsVisible = false;
                    userTab.IsVisible = false;
                    loanedTab.IsVisible = true;

                    productInfo.IsVisible = false;
                    FavoriteCategory.IsVisible = false;
                    mediaInfo.IsVisible = false;
                    FavouriteMediaType.IsVisible = false;
                    TopFive.IsVisible = false;
                    mostPopular.IsVisible = false;
                    AmountOfBooks.IsVisible = false;
                    AmountOfBooksLoanedATM.IsVisible = false;
                    loanedInfo.IsVisible = false;
                    userInfo.IsVisible = false;
                    totalNrUsers.IsVisible = false;
                    DelayedBooks.IsVisible = false;
                    reminders.IsVisible = false;

                    var statistic = EntityframeworkStatistics.TotalAmountOfBooksLoaned().ToString();
                    AmountOfBooksLoaned.Text = $"Alla utlånade böcker över tid: {statistic}";
                    loanedInfoStatistics.ItemsSource = EntityframeworkStatistics.ShowLoansByDescOrderGeneral();

                    AmountOfBooksLoaned.IsVisible = true;
                    loanedInfoStatistics.IsVisible = true;
                    break;

                case 6:


                    ProductTab.IsVisible = false;
                    userTab.IsVisible = false;
                    loanedTab.IsVisible = true;

                    productInfo.IsVisible = false;
                    FavoriteCategory.IsVisible = false;
                    mediaInfo.IsVisible = false;
                    FavouriteMediaType.IsVisible = false;
                    TopFive.IsVisible = false;
                    mostPopular.IsVisible = false;
                    AmountOfBooks.IsVisible = false;
                    AmountOfBooksLoanedATM.IsVisible = false;
                    loanedInfo.IsVisible = false;
                    AmountOfBooksLoaned.IsVisible = false;
                    loanedInfoStatistics.IsVisible = false;
                    totalNrUsers.IsVisible = false;
                    totalNrUsers.IsVisible = false;
                    userInfo.IsVisible = false;

                    var reminder = EntityframeworkStatistics.Reminder();
                    DelayedBooks.Text = $"Antal försenade produkter just nu: {reminder}";
                    reminders.ItemsSource = EntityframeworkStatistics.Delayes(); ;

                    DelayedBooks.IsVisible = true;
                    reminders.IsVisible = true;


                    break;

                case 7:
                    loanedTab.IsVisible = false;
                    ProductTab.IsVisible = false;
                    userTab.IsVisible = true;

                    productInfo.IsVisible = false;
                    FavoriteCategory.IsVisible = false;
                    mediaInfo.IsVisible = false;
                    FavouriteMediaType.IsVisible = false;
                    TopFive.IsVisible = false;
                    mostPopular.IsVisible = false;
                    AmountOfBooks.IsVisible = false;
                    AmountOfBooksLoanedATM.IsVisible = false;
                    loanedInfo.IsVisible = false;
                    AmountOfBooksLoaned.IsVisible = false;
                    loanedInfoStatistics.IsVisible = false;
                    totalNrUsers.IsVisible = false;
                    DelayedBooks.IsVisible = false;
                    reminders.IsVisible = false;


                    userInfo.ItemsSource = EntityframeworkUsers.ShowAllUsers().Where(x => x.Id >= 2);
                    var totalUsers = EntityframeworkUsers.ShowAllUsers().Where(x => x.Id >= 2).Count().ToString();
                    totalNrUsers.Text = $"Totalt antal användare: {totalUsers}";
                    totalNrUsers.IsVisible = true;
                    userInfo.IsVisible = true;
                    break;
            }

        }
        #endregion
        private async void Button_Click_Reminder(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MyPagesProductList book = btn.BindingContext as MyPagesProductList;
            await DisplayAlert($"{book.Title} är försenad", "En påminnelse har skickats till kund", "OK");
        }
    }
}
