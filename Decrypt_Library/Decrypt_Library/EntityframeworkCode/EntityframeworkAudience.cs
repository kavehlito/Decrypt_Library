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
    }
}
