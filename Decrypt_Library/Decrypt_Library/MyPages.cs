using Decrypt_Library.EntityFrameworkCode;
using System;
using System.Collections.Generic;
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

        public static List<MyPagesProductList> MyLoanHistory()
        {
            if (UserLogin.thisUser == null) return null;

            var loanHistory = EntityframeworkBookHistory.ShowUserLoanHistory();

            return loanHistory;

            //StringBuilder myLoanHistoryList = new StringBuilder();
            //myLoanHistoryList.AppendLine($"{"TITEL",-70}{"FÖRFATTARE",-25}{"ISBN",-35}{"UTLÅNINGSDATUM", -40}{"ÅTERLÄMNAD"}");
            /*foreach (var item in loanHistory)
                {
                    if (item.EndDate != null)
                        myLoanHistoryList.AppendLine($"{item.Title,-60}{item.Author,-25}{item.ISBN,-35}{item.StartDate.Value.ToShortDateString(),-40}{item.EndDate.Value.ToShortDateString()}");
                }
            */

        }
        public static List<MyPagesProductList> LoanList()
        {

            if (UserLogin.thisUser == null) return null;

            var books = EntityframeworkBookHistory.ShowUserLoanHistory();
            var loanList = new List<MyPagesProductList>();

            foreach (var book in books)
            {
                if (book.EndDate == null)
                {
                    var endDateTime = EntityframeworkBookHistory.SetEndDate((int)book.ID);

                    if (endDateTime != null) book.EndDate = endDateTime;
                    else
                        book.EndDate = book.StartDate.Value.AddDays(30);

                    loanList.Add(book);
                }

            }

            return loanList;


            //($"{item.Title,-60}{item.Author,-25}{item.ISBN,-35}{item.StartDate.Value.ToShortDateString(),-40}{item.EndDate.Value.ToShortDateString()}"

            /* if (item.EndDate == null)
             {
                 item.Add(new MyPagesProductList());

                 //DateTime startdate = Convert.ToDateTime(item.StartDate);
                 //DateTime TodayDate = DateTime.Now;
                 //var numberOfDays = (TodayDate - startdate).TotalDays;
                 //LateBooksList.Append($"{item.Title,-60}{item.Author,-25}{item.ISBN,-35}{item.StartDate.Value.ToShortDateString()}");
                 //if (numberOfDays > 30) LateBooksList.Append(" - Boken är försenad!");
             } */

        }
        public static List<MyPagesProductList> LateReturnList()
        {
          
            var books = EntityframeworkBookHistory.ShowUserLoanHistoryForAll();
            var loanList = new List<MyPagesProductList>();

            foreach (var book in books)
            {
                if (book.EndDate == null)
                {
                    var endDateTime = EntityframeworkBookHistory.SetEndDateForDelayes(book.ID);

                    if (endDateTime != null) book.EndDate = endDateTime;
                    else
                        book.EndDate = book.StartDate.Value.AddDays(30);

                    loanList.Add(book);
                }
            }
            return loanList;
        }
        public static List<MyPagesProductList> LateReturnListPopUpForUser()
        {         
            var books = EntityframeworkBookHistory.ShowUserLoanHistory();
            var loanList = new List<MyPagesProductList>();

            foreach (var book in books)
            {
                if (book.EndDate == null)
                {
                    var endDateTime = EntityframeworkBookHistory.SetEndDate(book.ID);

                    if (endDateTime != null) book.EndDate = endDateTime;
                    else
                        book.EndDate = book.StartDate.Value.AddDays(30);

                    loanList.Add(book);
                }
            }
            return loanList;
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
