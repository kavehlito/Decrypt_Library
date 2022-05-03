using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkLanguages
    {
        public static List<Models.Language> ShowAllLanguages()
        {
            using (var db = new Models.Decrypt_LibraryContext())
            {
                var languages = db.Languages.ToList();
                return languages;
            }
        }
    }
}
