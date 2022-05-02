using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkEvents
    {
        public static List<Models.Event> ShowAllEvents()
        {
            var events = new List<Models.Event>();

            using (var db = new Models.Decrypt_LibraryContext())
            {
                events = db.Events.ToList();
                return events;
            }
        }
    }
}
