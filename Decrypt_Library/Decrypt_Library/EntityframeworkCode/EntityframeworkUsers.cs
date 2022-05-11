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

        public static void CreateUser(User newCustomer)
        {
            try
            {
                using (var db = new Decrypt_LibraryContext())
                {
                    var userList = db.Users;

                    userList.Add(newCustomer);
                    db.SaveChanges();
                }

            }
            catch (System.Exception)
            {
                
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
    }
}
