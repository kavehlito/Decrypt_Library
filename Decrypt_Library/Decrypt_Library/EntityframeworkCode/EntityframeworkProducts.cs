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
        public static List<CategoryName_Product> ShowSpecificProductTitle(string selectedTitle)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var products = (from prod in db.Products
                                join cate in db.Categories on prod.CategoryId equals cate.Id
                                select new CategoryName_Product
                                {
                                    Id = prod.Id,
                                    Title = prod.Title,
                                    AuthorName = prod.AuthorName,
                                    Category = cate.CategoriesName
                                }).ToList();

                var findProduct = products.Where(p => p.Title.ToLower().Contains(selectedTitle.ToLower()) || p.Category.ToLower().Contains(selectedTitle.ToLower())).ToList();

                return findProduct;
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
        public static void FindProduct(string productSearch)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var products = (from prod in db.Products
                                join cate in db.Categories on prod.CategoryId equals cate.Id
                                select new
                                {
                                    Id = prod.Id,
                                    Title = prod.Title,
                                    AuthorName = prod.AuthorName,
                                    Category = cate.CategoriesName
                                }).ToList();
                var findProduct = products.Where(p => p.Title.ToLower().Contains(productSearch.ToLower()) || p.Category.ToLower().Contains(productSearch.ToLower()));

            }
        }
    }
}
