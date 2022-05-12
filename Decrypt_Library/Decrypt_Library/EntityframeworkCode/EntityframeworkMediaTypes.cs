using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkMediaTypes
    {
        public static List<Models.MediaType> ShowAllMediaTypes()
        {
            var mediatypes = new List<Models.MediaType>();

            using (var db = new Models.Decrypt_LibraryContext())
            {
                mediatypes = db.MediaTypes.ToList();
                return mediatypes;
            }
        }
        public static List<Product> SpecificType(List<int> TypeList)
        {
            var products = new List<Product>();
            using (var db = new Decrypt_LibraryContext())
            {
                foreach (var audience in TypeList)
                {
                    products.AddRange(db.Products.Where(x => x.MediaId == audience).ToList());
                }
                return products;
            }
        }
    }
}
