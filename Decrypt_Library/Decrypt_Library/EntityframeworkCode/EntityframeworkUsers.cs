using Decrypt_Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Decrypt_Library.EntityFrameworkCode
{
    public class EntityframeworkUsers
    {
        public static List<User> ShowAllUsers()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var users = db.Users.ToList();
                return users;
            }
        }

        public static void UpdateUser(User user)
        {
            var users = ShowAllUsers();
            using (var db = new Decrypt_LibraryContext())
            {
                db.Users.Update(user);
                db.SaveChanges();
            }
        }

        public static List<string> ShowAllUserTypeNames()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var usertypes = db.UserTypes.Select(x => x.UserTypeName).ToList();
                return usertypes;
            }
        }

        public static List<UserType> ShowAllUserTypes()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var usertypes = db.UserTypes.ToList();
                return usertypes;
            }
        }

        public static void CreateUser(User newCustomer)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var userList = db.Users;

                userList.Add(newCustomer);
                db.SaveChanges();
            }
        }

        public static void RemoveUser(User user)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                db.Remove(user);
                db.SaveChanges();
            }
        }

        public static List<User> ShowSpecificUserLogIn(User userLogIn)
        {
            var user = ShowAllUsers();

            using (var db = new Decrypt_LibraryContext())
            {
                var specificUser = user.Where(u => u.Id == userLogIn.Id).ToList();

                return specificUser;
            }

        }

        public static User ShowSpecificUserByUserName(long? ssn)
        {
            var user = ShowAllUsers();
            using (var db = new Decrypt_LibraryContext())
            {
                var specificUser = user.SingleOrDefault(u => u.Ssn == ssn);

                return specificUser;
            }

        }

        // Recommendation list based on past loans of books and agegroup
        
        public static List<Product> ShowRecommendations()
        {
            var recoList = new List<Product>();
            using (var db = new Decrypt_LibraryContext())
            {
                var product = db.Products;
                var recommend = (from
                                reco in db.BookHistories
                                join prod in db.Products on reco.ProductId equals prod.Id
                                join aud in db.Audiences on prod.AudienceId equals aud.Id
                                join category in db.Categories on prod.CategoryId equals category.Id
                                where reco.EventId == 2 && reco.UserId == UserLogin.thisUser.Id
                                select new MyPagesProductList
                                {
                                    AgeGroupId = prod.AudienceId,
                                    CategoryId = prod.CategoryId,
                                    UsersID = reco.UserId,

                                }).ToList();

                foreach (var item in recommend)
                {
                    recoList = product.Where(p => p.CategoryId == item.CategoryId).ToList();
                }

            }
                return recoList.ToList();
        }
        public static List<Product> ShowTopFiveMostReadNoHistory()
        {
            var topfiveList = new List<Product>();
            using (var db = new Decrypt_LibraryContext())
            {
                var products = db.Products;

                var mostRead = (from
                               mostPop in db.BookHistories
                                join product in db.Products on mostPop.ProductId equals product.Id
                                where mostPop.EventId == 2
                                select product).ToList().GroupBy(c => c.Id)
                                    .Select(c => new MyPagesProductList
                                    {
                                        Title = c.FirstOrDefault().Title,
                                        Count = c.Count(),
                                    }).OrderByDescending(c => c.Count).ToList().Take(5);

                foreach (var item in mostRead)
                {
                    topfiveList = products.Where(p => p.Id == item.ID).ToList();
                }
                return topfiveList.ToList();
            }

        }
    }
}
