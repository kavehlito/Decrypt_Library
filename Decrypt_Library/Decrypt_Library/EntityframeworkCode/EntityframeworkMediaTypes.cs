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
        public static List<string> ShowAllMediaNames()
        {

            using (var db = new Decrypt_LibraryContext())
            {
                var mediaNames = db.MediaTypes.Select(x => x.FormatName).ToList();
                return mediaNames;
            }
        }
    }
}
