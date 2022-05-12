using Decrypt_Library.Models;
using System.Collections.Generic;
using System.Linq;

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

        public static int ShowSpecificMediaTypeIdByFormatName(string formatName)
        {

            using (var db = new Decrypt_LibraryContext())
            {
                var languageId = db.MediaTypes.SingleOrDefault(x => x.FormatName.ToLower().Contains(formatName.ToLower())).Id;
                return languageId;
            }
        }
    }
}
