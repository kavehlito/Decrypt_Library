using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Decrypt_Library.Views.Admin
{
    internal class AdminProductViewModel : BindableObject
    {
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

        public AdminProductViewModel()
        {
            CollectionList = new ObservableCollection<Product>(EntityFrameworkCode.EntityframeworkProducts.ShowAllProducts());
            DeleteCommand = new Command(OnDeleteTapped);
        }

        public void OnDeleteTapped(object obj)
        {
            var content = obj as Product;
            CollectionList.Remove(content);
            EntityFrameworkCode.EntityframeworkProducts.RemoveProduct(content);
            CollectionList = new ObservableCollection<Product>(EntityFrameworkCode.EntityframeworkProducts.ShowAllProducts());
        }
    }
}
