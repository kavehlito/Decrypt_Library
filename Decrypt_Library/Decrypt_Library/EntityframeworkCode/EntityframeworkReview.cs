using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkReview
    {
        public static List<ReviewNames> ShowBookReview(string title)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var reviews = (from r in db.Reviews
                              join p in db.Products on r.ProduktId equals p.Id
                              join u in db.Users on r.UserId equals u.Id
                              where p.Title == title
                              select new ReviewNames
                              {
                                  UserName = u.UserName,
                                  ReviewText = r.ReviewText,
                                  Stars = r.Stars
                              }).ToList();
                return reviews;
            }
        }
    }
}
