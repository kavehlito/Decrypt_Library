using Decrypt_Library.Models;
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

        public static Models.Event ShowSelectedEvents(int eventId)
        {

            using (var db = new Models.Decrypt_LibraryContext())
            {
                var events = db.Events.SingleOrDefault(x => x.Id == eventId);
                return events;
            }
        }

        public static void RemoveEvent(Event selectedEvent)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                selectedEvent = db.Events.Where(x => x.Id == selectedEvent.Id).SingleOrDefault();

                db.Remove(selectedEvent);
                db.SaveChanges();
            }
        }

        public static void CreateEvent(Event selectedEvent)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                db.Add(selectedEvent);
                db.SaveChanges();
            }
        }
    }
}
