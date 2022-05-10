using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decrypt_Library.Models;


namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityFrameworkCart
    {
        public static List<Models.Cart> ShowAllCarts()
        {
            var carts = new List<Models.Cart>();

            using (var db = new Models.Decrypt_LibraryContext())
            {
                carts = db.Carts.ToList();
                return carts;
            }
        }
    }
}
