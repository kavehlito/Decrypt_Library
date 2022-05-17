using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkBookHistory
    {

        public static List<MyPagesProductList> ShowUserReservations()
        {
           
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
                                      Title = product.Title,
                                      Author = product.AuthorName,
                                      ISBN = product.Isbn,
                                      StartDate = bookHistory.StartDate,
                                      EndDate = bookHistory.EndDate,

                                  };
                return loanHistory.ToList();
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
        public int Sum { get; set; }

    }
}
