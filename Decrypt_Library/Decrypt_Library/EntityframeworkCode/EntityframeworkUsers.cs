using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkUsers
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
