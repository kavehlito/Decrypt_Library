using Decrypt_Library.EntityFrameworkCode;
using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Decrypt_Library.Views.Admin
{
    internal class AdminProductViewModel : BindableObject
    {
        private ObservableCollection<Event> _EventCollectionList;
        public ObservableCollection<Event> EventCollectionList
        {
            get { return _EventCollectionList; }
            set
            {
                _EventCollectionList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Category> _CategoryCollectionList;
        public ObservableCollection<Category> CategoryCollectionList
        {
            get { return _CategoryCollectionList; }
            set
            {
                _CategoryCollectionList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Product> _CollectionList;
        public ObservableCollection<Product> CollectionList 
        { 
            get { return _CollectionList; }
            set
            {
                _CollectionList = value;
                OnPropertyChanged();
            }
        }
        public ICommand DeleteCommand { get; }
        public ICommand CategoryDeleteCommand { get; }
        public ICommand EventDeleteCommand { get; }

        public AdminProductViewModel()
        {
            CollectionList = new ObservableCollection<Product>(EntityframeworkProducts.ShowAllProducts());
            CategoryCollectionList = new ObservableCollection<Category>(EntityframeworkCategories.ShowAllCategories());
            EventCollectionList = new ObservableCollection<Event>(EntityframeworkEvents.ShowAllEvents());

            DeleteCommand = new Command(OnDeleteTapped);
            CategoryDeleteCommand = new Command(OnCategoryDeleteTapped);
            EventDeleteCommand = new Command(OnEventDeleteTapped);
        }


        public void OnEventDeleteTapped(object obj)
        {
            var admin = new AdminPage();
            var content = obj as Models.Event;

            EventCollectionList.Remove(content);
            EntityframeworkEvents.RemoveEvent(content);
            EventCollectionList = new ObservableCollection<Event>(EntityframeworkEvents.ShowAllEvents());
            admin.UpdateNewProductList();
            admin.RefreshPage();
        }

        public void OnCategoryDeleteTapped(object obj)
        {
            var admin = new AdminPage();
            var content = obj as Category;

            foreach (var item in EntityframeworkProducts.ShowAllProducts())
            {
                if (content.Id == item.CategoryId)
                {
                    return;
                }
            }
            CategoryCollectionList.Remove(content);
            EntityframeworkCategories.RemoveCategory(content);
            CategoryCollectionList = new ObservableCollection<Category>(EntityframeworkCategories.ShowAllCategories());
            admin.UpdateNewProductList();
            admin.RefreshPage();
        }

        public void OnDeleteTapped(object obj)
        {
            var admin = new AdminPage();
            var content = obj as Product;

            foreach (var item in EntityframeworkProducts.ShowAllProducts())
            {
                if (content.LanguageId == item.LanguageId)
                {
                    return;
                }
            }
            CollectionList.Remove(content);
            EntityFrameworkCode.EntityframeworkProducts.RemoveProduct(content);
            CollectionList = new ObservableCollection<Product>(EntityframeworkProducts.ShowAllProducts());
            admin.UpdateNewProductList();
            admin.RefreshPage();
        }

 
    }
}
