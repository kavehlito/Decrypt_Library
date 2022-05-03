using Decrypt_Library.Models;
using System.Collections.Generic;

namespace Decrypt_Library.EntityFrameworkCode
{
    public class EntityframeworkUsers
    {
        public static List<Models.User> ShowAllUsers()
        {
            var users = new List<User>();

            using (var db = new Decrypt_LibraryContext())
            {
                var user = db.Users;
                return users;
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
    }
}
