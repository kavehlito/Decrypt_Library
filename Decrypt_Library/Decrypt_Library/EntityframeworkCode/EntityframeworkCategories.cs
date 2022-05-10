using Decrypt_Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkCategories
    {
        public static List<Category> ShowAllCategories()
        {
            var categories = new List<Category>();

            using (var db = new Decrypt_LibraryContext())
            {
                categories = db.Categories.OrderBy(x => x.Id).ToList();
                return categories;
            }
        }

        public static List<Category> ShowAllProdutsInCateogry()
        {
            return null;
        }

        public static void CreateCategory(Category category)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var categoryList = db.Categories;

                categoryList.Add(category);
                db.SaveChanges();
            }
        }

        public static void RemoveCategory(Category category)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var categoryList = db.Categories;
                category = db.Categories.Where(x => x.Id == category.Id).SingleOrDefault();

                categoryList.Remove(category);
                db.SaveChanges();
            }
        }

        public static List<Product> SpecificCategory(List<int> categoryList)
        {
            var products = new List<Product>();
            using (var db = new Decrypt_LibraryContext())
            {
                foreach (var category in categoryList)
                {
                    products.AddRange(db.Products.Where(x => x.CategoryId == category).ToList());
                }
                return products;
            }
        }

    }
}

