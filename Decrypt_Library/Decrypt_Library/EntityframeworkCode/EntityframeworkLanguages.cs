using Decrypt_Library.Models;
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

        public static List<string> ShowAllLanguageNames()
        {

            using (var db = new Decrypt_LibraryContext())
            {
                var languageNames = db.Languages.Select(x => x.Languages).ToList();
                return languageNames;
            }
        }
        public static int ShowSpecificCountryIdByLanguage(string language)
        {

            using (var db = new Decrypt_LibraryContext())
            {
                var languageId = db.Languages.SingleOrDefault(x => x.Languages.ToLower().Contains(language.ToLower())).Id;
                return languageId;
            }
        }

        public static void CreateLanguage(Language language)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var userList = db.Languages;

                userList.Add(language);
                db.SaveChanges();
            }
        }

        public static void RemoveLanguage(Language language)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                language = db.Languages.Where(x => x.Id == language.Id).SingleOrDefault();
                db.Remove(language);
                db.SaveChanges();
            }
        }

    }
}
