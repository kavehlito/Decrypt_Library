using Decrypt_Library.Models;
using System.Collections.Generic;
using System.Linq;

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
        public static void ReviewEntry(Review newReview)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var review = db.Reviews;

                review.Add(newReview);
                db.SaveChanges();
            }
        }
        public static List<int> StarValues()
        {
            var starList = new List<int>();
            starList.Add(1);
            starList.Add(2);
            starList.Add(3);
            starList.Add(4);
            starList.Add(5);

            return starList;
        }
    }
}
