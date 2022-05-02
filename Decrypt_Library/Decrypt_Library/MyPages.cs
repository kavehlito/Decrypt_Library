using System;
using Decrypt_Library.Models;
using Decrypt_Library.EntityFrameworkCode;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt_Library
{
    public static class MyPages
    {
        public static string UserProfile()
        {
            if (UserLogin.thisUser == null) return "Du är inte inloggad!";

            StringBuilder myProfile = new StringBuilder();

            myProfile.AppendLine($"Namn: {UserLogin.thisUser.UserName}");
            myProfile.AppendLine($"Personnummer: {UserLogin.thisUser.Ssn}");
            myProfile.AppendLine($"Telefonnummer: {UserLogin.thisUser.Phonenumber}");
            myProfile.AppendLine($"E-post: {UserLogin.thisUser.Email}");
            myProfile.AppendLine($"Lösenord: {UserLogin.thisUser.Password}");

            return myProfile.ToString();
        }

        public static string MyReservationsList()
        {

            if (UserLogin.thisUser == null) return "Du är inte inloggad!";

            StringBuilder myReservationsList = new StringBuilder();

            var reservation = EntityframeworkBookHistory.ShowUserReservations();
            foreach (var item in reservation)
            {
                if (item.EndDate == null)
                    myReservationsList.AppendLine($"{item.Title,-70}{item.Author,-25}{item.ISBN,-35}{item.StartDate.}");
            }

            return myReservationsList.ToString();

        }

        public static string MyLoanHistory()
        {
            if (UserLogin.thisUser == null) return "Du är inte inloggad!";

            StringBuilder myLoanHistoryList = new StringBuilder();

            var loanHistory = EntityframeworkBookHistory.ShowUserLoanHistory();

                foreach (var item in loanHistory)
                {
                    if (item.EndDate != null)
                        myLoanHistoryList.AppendLine($"{item.Title,-50}{item.Author,-20}{item.ISBN,-15}{item.StartDate,15},{item.EndDate,-15}");
                }

                return myLoanHistoryList.ToString();
        }

        public static void TestMyPages()
        {
            Console.WriteLine("MIN PROFIL");
            Console.WriteLine(MyPages.UserProfile());
            Console.WriteLine();
            Console.WriteLine("MINA RESERVATIONER");
            Console.WriteLine(MyPages.MyReservationsList());
            Console.WriteLine();
            Console.WriteLine("MINA TIDIGARE LÅN");
            Console.WriteLine(MyPages.MyLoanHistory());
        }
    }
}
