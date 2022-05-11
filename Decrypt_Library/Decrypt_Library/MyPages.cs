using Decrypt_Library.EntityFrameworkCode;
using System;
using System.Text;

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
            myReservationsList.AppendLine($"{"TITEL",-70}{"FÖRFATTARE",-25}{"ISBN",-35}{"UTLÅNINGSDATUM"}");

            foreach (var item in reservation)
            {
                if (item.EndDate == null)
                    myReservationsList.AppendLine($"{item.Title,-70}{item.Author,-25}{item.ISBN,-35}{item.StartDate.Value.ToShortDateString()}");
            }

            return myReservationsList.ToString();

        }

        public static string MyLoanHistory()
        {
            if (UserLogin.thisUser == null) return "Du är inte inloggad!";

            StringBuilder myLoanHistoryList = new StringBuilder();

            var loanHistory = EntityframeworkBookHistory.ShowUserLoanHistory();
            myLoanHistoryList.AppendLine($"{"TITEL",-70}{"FÖRFATTARE",-25}{"ISBN",-35}{"UTLÅNINGSDATUM", -40}{"ÅTERLÄMNAD"}");
            foreach (var item in loanHistory)
                {
                    if (item.EndDate != null)
                        myLoanHistoryList.AppendLine($"{item.Title,-60}{item.Author,-25}{item.ISBN,-35}{item.StartDate.Value.ToShortDateString(),-40}{item.EndDate.Value.ToShortDateString()}");
                }

            return myLoanHistoryList.ToString();
        }
        public static string LateReturn()
        {
            if (UserLogin.thisUser == null) return "Du är inte inloggad!";

            StringBuilder LateBooksList = new StringBuilder();
            var lateBooks = EntityframeworkBookHistory.ShowUserLoanHistory();
            LateBooksList.AppendLine($"{"TITEL",-70}{"FÖRFATTARE",-25}{"ISBN",-35}{"UTLÅNINGSDATUM"}");

            foreach (var item in lateBooks)
            {
                if (item.EndDate == null)
                {
                    DateTime startdate = Convert.ToDateTime(item.StartDate);
                    DateTime TodayDate = DateTime.Now;
                    var numberOfDays = (TodayDate - startdate).TotalDays;
                    LateBooksList.AppendLine();
                    LateBooksList.Append($"{item.Title,-60}{item.Author,-25}{item.ISBN,-35}{item.StartDate.Value.ToShortDateString()}");
                    if (numberOfDays > 30) LateBooksList.Append(" - Boken är försenad!");
                }
            }
            return LateBooksList.ToString();
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
