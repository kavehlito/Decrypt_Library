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

        public static List<CategoryName_Product> Checkboxes(List<string> checkboxList)
        {
            var products = new List<CategoryName_Product>();
            using (var db = new Decrypt_LibraryContext())
            {
                var product = (from prod in db.Products
                                join cate in db.Categories on prod.CategoryId equals cate.Id
                                join aud in db.Audiences on prod.AudienceId equals aud.Id
                                join med in db.MediaTypes on prod.MediaId equals med.Id
                                select new CategoryName_Product
                                {
                                    Id = prod.Id,
                                    Title = prod.Title,
                                    AuthorName = prod.AuthorName,
                                    Audience = aud.AgeGroup,
                                    Media = med.FormatName,
                                    Category = cate.CategoriesName
                                    
                                }).ToList();

               
                    foreach (var prod in checkboxList)
                    {
                        products.AddRange(product.Where(x => x.Category == prod || x.Audience == prod || x.Media == prod).ToList());
                    }
                    return products;
                              
            }
        }
    }
}

