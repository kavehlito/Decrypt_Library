using System;
using Decrypt_Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkBookHistory
    {

        //public static List<MyPagesProductList> ShowUserReservations()
        //{
        //    using (var db = new Decrypt_LibraryContext())
        //    {
        //        var reservation = from
        //                          bookHistory in db.BookHistories
        //                          join
        //                          product in db.Products on bookHistory.ProductId equals product.Id
        //                          where bookHistory.UserId == UserLogin.thisUser.Id && bookHistory.EventId == 3
        //                          select new MyPagesProductList
        //                          {
        //                              Title = product.Title,
        //                              Author = product.AuthorName,
        //                              ISBN = product.Isbn,
        //                              StartDate = bookHistory.StartDate,
        //                              EndDate = bookHistory.EndDate,

        //                          };
        //        return reservation.ToList();
        //    }
        //}

        //public static List<MyPagesProductList> ShowUserLoanHistory()
        //{

        //    using (var db = new Decrypt_LibraryContext())
        //    {
        //        var loanHistory = from
        //                          bookHistory in db.BookHistories
        //                          join
        //                          product in db.Products on bookHistory.ProductId equals product.Id
        //                          where bookHistory.UserId == UserLogin.thisUser.Id && bookHistory.EventId == 2
        //                          select new MyPagesProductList
        //                          {
        //                              Title = product.Title,
        //                              Author = product.AuthorName,
        //                              ISBN = product.Isbn,
        //                              StartDate = bookHistory.StartDate,
        //                              EndDate = bookHistory.EndDate,

        //                          };
        //        return loanHistory.ToList();
        //    }
        //}
    }

    internal class MyPagesProductList
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Int64? ISBN { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
