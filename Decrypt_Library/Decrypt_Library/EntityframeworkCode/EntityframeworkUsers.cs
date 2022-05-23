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
    }
}
