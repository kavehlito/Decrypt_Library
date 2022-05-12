using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkAudience
    {
        public static List<Audience> ShowAllAudiences()
        {
            var carts = new List<Models.Audience>();

            using (var db = new Models.Decrypt_LibraryContext())
            {
                carts = db.Audiences.ToList();
                return carts;
            }
        }
        public static List<Product> SpecificAudience(List<int> audienceList)
        {
            var products = new List<Product>();
            using (var db = new Decrypt_LibraryContext())
            {
                foreach (var audience in audienceList)
                {
                    products.AddRange(db.Products.Where(x => x.AudienceId == audience).ToList());
                }
                return products;
            }
        }

        public static List<string> ShowAllAudienceGroups()
        {

            using (var db = new Decrypt_LibraryContext())
            {
                var ageGroup = db.Audiences.Select(x => x.AgeGroup).ToList();
                return ageGroup;
            }
        }
    }
}
