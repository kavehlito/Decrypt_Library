using System.Linq;
namespace Decrypt_Library
{
    public class UserLogin
    {
        public static Models.User thisUser = null;

        public static bool CheckUserNameAndPassword(long SSN, string password)
        {
            using (var db = new Models.Decrypt_LibraryContext())
            {
                var userList = db.Users;
                var user = userList.SingleOrDefault(u => u.Ssn == SSN && u.Password == password);

                if (user == null) return false;
                thisUser = user;
                return true;
            }
        }

        public static void LogOutUsers()
        {
            thisUser = null;
        }


        
    }
}
