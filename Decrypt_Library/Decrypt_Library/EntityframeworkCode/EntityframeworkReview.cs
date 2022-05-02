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
        public static List<Review> ShowBookReview(User user)
        {
            var review = new List<Review>();

            using (var db = new Decrypt_LibraryContext())
            {
                review = db.Reviews.ToList();
                return review;
            }
        }
    }
}
