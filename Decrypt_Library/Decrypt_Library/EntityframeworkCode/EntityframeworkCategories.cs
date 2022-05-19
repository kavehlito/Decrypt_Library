using Decrypt_Library.Models;
using System.Collections.Generic;
using System.Linq;

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

        public static List<string> ShowAllCategoryNames()
        {

            using (var db = new Decrypt_LibraryContext())
            {
                var categoryNames = db.Categories.Select(x => x.CategoriesName).ToList();
                return categoryNames;
            }
        }

        public static List<Category> ShowAllProdutsInCateogry()
        {
            return null;
        }

        public static int ShowSpecificCategoryIdByCategoriesName(string categoryName)
        {

            using (var db = new Decrypt_LibraryContext())
            {
                var languageId = db.Categories.SingleOrDefault(x => x.CategoriesName.ToLower().Contains(categoryName.ToLower())).Id;
                return languageId;
            }
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

        public static List<Product> Checkboxes(List<int> category, List<int> age, List<int> media)
        {
            var products = new List<Product>();
            using (var db = new Decrypt_LibraryContext())
            {
                if (category.Count() > 0 && age.Count() == 0 && media.Count() == 0)
                {
                    products = db.Products.Where(c => category.Contains((int)c.CategoryId)).ToList();
                }
                else if (category.Count() == 0 && age.Count() > 0 && media.Count() == 0)
                {
                    products = db.Products.Where(a => age.Contains((int)a.AudienceId)).ToList();
                }
                else if (category.Count() == 0 && age.Count() == 0 && media.Count() > 0)
                {
                    products = db.Products.Where(m => media.Contains((int)m.MediaId)).ToList();
                }
                else if (category.Count() > 0 && age.Count() > 0 && media.Count() == 0)
                {
                    products = db.Products
                    .Where(c => category.Contains((int)c.CategoryId))
                    .Where(a => age.Contains((int)a.AudienceId))
                    .ToList();
                }
                else if (category.Count() == 0 && age.Count() > 0 && media.Count() > 0)
                {
                    products = db.Products
                    .Where(a => age.Contains((int)a.AudienceId))
                    .Where(m => media.Contains((int)m.MediaId))
                    .ToList();
                }
                else if (category.Count() > 0 && age.Count() == 0 && media.Count() > 0)
                {
                    products = db.Products
                    .Where(c => category.Contains((int)c.CategoryId))
                    .Where(m => media.Contains((int)m.MediaId))
                    .ToList();
                }
                else if (category.Count() > 0 && age.Count() > 0 && media.Count() > 0)
                {
                    products = db.Products
                    .Where(c => category.Contains((int)c.CategoryId))
                    .Where(a => age.Contains((int)a.AudienceId))
                    .Where(m => media.Contains((int)m.MediaId))
                    .ToList();
                }
                return products;
            }
        }
    }
}

