using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkShelf
    {
        public static List<Shelf> ShowAllShelves()
        {
            var shelves = new List<Shelf>();

            using (var db = new Decrypt_LibraryContext())
            {
                shelves = db.Shelves.ToList();
                return shelves;
            }
        }

        public static Shelf FindSpecificShelf(string shelf)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                Shelf shelf2 = db.Shelves.SingleOrDefault(p => p.Shelfname.Contains(shelf));

                return shelf2;
            }
        }
    }
}
