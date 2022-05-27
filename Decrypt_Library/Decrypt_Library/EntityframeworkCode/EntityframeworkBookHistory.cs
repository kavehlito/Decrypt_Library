using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkBookHistory
    {

        public static List<MyPagesProductList> ShowUserReservations()
        {
            if (UserLogin.thisUser == null) return null;

            using (var db = new Decrypt_LibraryContext())
            {
                var reservation = from
                                  bookHistory in db.BookHistories
                                  join
                                  product in db.Products on bookHistory.ProductId equals product.Id
                                  where bookHistory.UserId == UserLogin.thisUser.Id && bookHistory.EventId == 3
                                  select new MyPagesProductList
                                  {
                                      ID = bookHistory.Id,
                                      Title = product.Title,
                                      Author = product.AuthorName,
                                      ISBN = product.Isbn,
                                      StartDate = bookHistory.StartDate,
                                      EndDate = bookHistory.EndDate,
                                      ReservationNumber = EntityframeworkBookHistory.Reservationnumber(product.Id, UserLogin.thisUser.Id) + 1
                                  };
                return reservation.ToList();

            }
        }

        public static List<MyPagesProductList> ShowUserLoanHistory()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var loanHistory = from
                                  bookHistory in db.BookHistories
                                  join
                                  product in db.Products on bookHistory.ProductId equals product.Id
                                  where bookHistory.UserId == UserLogin.thisUser.Id && bookHistory.EventId == 2
                                  select new MyPagesProductList
                                  {
                                      ID = product.Id,
                                      Title = product.Title,
                                      Author = product.AuthorName,
                                      ISBN = product.Isbn,
                                      StartDate = bookHistory.StartDate,
                                      EndDate = bookHistory.EndDate,

                                  };
                return loanHistory.ToList();
            }
        }
        public static List<MyPagesProductList> ShowUserLoanHistoryForAll()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var loanHistory = from
                                  bookHistory in db.BookHistories
                                  join
                                  product in db.Products on bookHistory.ProductId equals product.Id
                                  where bookHistory.EventId == 2
                                  select new MyPagesProductList
                                  {
                                      ID = product.Id,
                                      Title = product.Title,
                                      Author = product.AuthorName,
                                      ISBN = product.Isbn,
                                      StartDate = bookHistory.StartDate,
                                      EndDate = bookHistory.EndDate,

                                  };
                return loanHistory.ToList();
            }
        }
        public static DateTime? SetEndDate(int productId)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var loanHistory = db.BookHistories;
                var specificProduct = loanHistory.Where(x => x.EventId == 4 && x.ProductId == productId && x.UserId == UserLogin.thisUser.Id).OrderByDescending(x => x.StartDate);
                if (specificProduct.Count() < 1) return null;
                return specificProduct.First().StartDate.Value.AddDays(30);
            }
        }
        public static DateTime? SetEndDateForDelayes(int productId)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var loanHistory = db.BookHistories;
                var specificProduct = loanHistory.Where(x => x.EventId == 4 && x.ProductId == productId).OrderByDescending(x => x.StartDate);
                if (specificProduct.Count() < 1) return null;
                return specificProduct.First().StartDate.Value.AddDays(30);
            }
        }
        public static bool ReserveProduct(string productTitle)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                Product choosenProduct = db.Products.Where(ch => ch.Title == productTitle).FirstOrDefault();
                BookHistory bookHistory = new BookHistory();

                var reservationExists = db.BookHistories;

                foreach (var reserv in reservationExists)
                {
                    if (reserv.ProductId == choosenProduct.Id && reserv.UserId == UserLogin.thisUser.Id)
                    {
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
                bookHistory.ProductId = choosenProduct.Id;
                bookHistory.EventId = 3;
                bookHistory.UserId = UserLogin.thisUser.Id;
                bookHistory.StartDate = DateTime.UtcNow;
                db.BookHistories.Update(bookHistory);
                db.SaveChanges();
                return true;
            }
        }

        public static int Reservationnumber(int productId, int userId)
        {
            using (var db = new Models.Decrypt_LibraryContext())
            {
                var reservations = db.BookHistories;
                var specificProductReservation = reservations.Where(x => x.ProductId == productId && x.EventId == 3).OrderBy(x => x.StartDate).ToList();
                var specificProductHistory = specificProductReservation.FirstOrDefault(x => x.ProductId == productId && x.UserId == userId);

                return specificProductReservation.IndexOf(specificProductHistory);
            }
        }

    }

    public class MyPagesProductList
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Int64? ISBN { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CategoriesName { get; set; }
        public int Count { get; set; }

        public int? MediaType { get; set; }
        public string FormatName { get; set; }
        public int? AgeGroupId { get; set; }
        public int? CategoryId { get; set; }
        public int? UsersID { get; set; }
        public int? ReservationNumber { get; set; }

    }
}
