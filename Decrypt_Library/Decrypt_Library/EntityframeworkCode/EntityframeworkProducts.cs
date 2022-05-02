using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkProducts
    {
        public static List<Product> ShowAllProducts()
        {
            var products = new List<Product>();

            using (var db = new Decrypt_LibraryContext())
            {
                products = db.Products.ToList();
                return products;
            }
        }
        public static Product ShowSpecificProductTitle(string selectedTitle)
        {
            var products = ShowAllProducts();

            using (var db = new Decrypt_LibraryContext())
            {
                var product = products.SingleOrDefault(p => p.Title.Contains(selectedTitle));

                return product;
            }
        }
        public static Product ShowSpecificProductID(int selectedID)
        {
            var products = ShowAllProducts();

            using (var db = new Decrypt_LibraryContext())
            {
                var product = products.SingleOrDefault(p => p.Id == selectedID);

                return product;
            }
        }
        public static List<Product> ShowSpecificProductAuthor(string selectedAuthor)
        {
            var products = ShowAllProducts();

            using (var db = new Decrypt_LibraryContext())
            {
                var product = products.Where(p => p.AuthorName.Contains(selectedAuthor));

                return products;
            }
        }
        public static List<Product> ShowAllProductsOnSpecificShelf(int shelfId)
        {
            var products = ShowAllProducts();

            using (var db = new Decrypt_LibraryContext())
            {
                var product = products.Where(p => p.Id == shelfId);

                return products;
            }
        }
    }
}
