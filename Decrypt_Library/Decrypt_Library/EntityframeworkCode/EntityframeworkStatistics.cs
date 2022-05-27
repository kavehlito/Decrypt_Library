using Decrypt_Library.EntityFrameworkCode;
using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decrypt_Library.EntityframeworkCode
{
    public class EntityframeworkStatistics
    {
        // Skapa metod för att hämta in info från databas och returnera en lista som sedan ska visas DESC, 
        // senast utlånad högst upp - till användare i Admin

        public static List<MyPagesProductList> ShowLoansByDescOrder()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var loanedByOrder = from
                                    loaned in db.BookHistories
                                    join
                                    product in db.Products on loaned.ProductId equals product.Id
                                    orderby loaned.StartDate descending
                                    where loaned.EventId == 2 && loaned.EndDate == null
                                    select new MyPagesProductList
                                    {
                                        ID = loaned.Id,
                                        Title = product.Title,
                                        Author = product.AuthorName,
                                        ISBN = product.Isbn,
                                        StartDate = loaned.StartDate,
                                        EndDate = loaned.StartDate.Value.AddDays(30),

                                    };
                return loanedByOrder.ToList();

            }
        }
        // Shows all the loaned books
        public static List<MyPagesProductList> ShowLoansByDescOrderGeneral()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var loanedByOrder = from
                                    loaned in db.BookHistories
                                    join
                                    product in db.Products on loaned.ProductId equals product.Id
                                    orderby loaned.StartDate descending
                                    where loaned.EventId == 2
                                    select new MyPagesProductList
                                    {
                                        ID = loaned.Id,
                                        Title = product.Title,
                                        Author = product.AuthorName,
                                        ISBN = product.Isbn,
                                        StartDate = loaned.StartDate,
                                        EndDate = loaned.EndDate,

                                    };
                return loanedByOrder.ToList();

            }
        }
        // top 5 most read books
        public static List<MyPagesProductList> ShowTopFiveMostRead()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var mostRead = (from
                               mostPop in db.BookHistories
                                join product in db.Products on mostPop.ProductId equals product.Id
                                where mostPop.EventId == 2
                                select product).ToList().GroupBy(c => c.Id)
                                    .Select(c => new MyPagesProductList
                                    {
                                        Title = c.FirstOrDefault().Title,
                                        Count = c.Count(),
                                    }).OrderByDescending(c => c.Count).ToList().Take(5);
                return mostRead.ToList();
            }

        }
        // Amount of books loaned at the moment
        public static int LoanedBooksATM()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var loanedBooks = db.Products.Where(s => s.Status == false).ToList().Count();

                return loanedBooks;
            }
        }

        // Most read category
        public static List<MyPagesProductList> MostReadCategory()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var mostRead = (from
                               mostPop in db.BookHistories
                                join product in db.Products on mostPop.ProductId equals product.Id
                                join category in db.Categories on product.CategoryId equals category.Id
                                where mostPop.EventId == 2
                                select category).ToList().GroupBy(c => c.Id)
                                    .Select(c => new MyPagesProductList
                                    {
                                        CategoriesName = c.FirstOrDefault().CategoriesName,
                                        Count = c.Count(),
                                    }).OrderByDescending(c => c.Count).ToList();
                return mostRead;
            }
        }
        // Total amount of books in the library
        public static int AmountOfBooks()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var amountOfBooks = db.Products;

                return amountOfBooks.Count();
            }
        }

        //Total amount of loaned products
        public static int TotalAmountOfBooksLoaned()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var amountOfBooks = db.BookHistories.Where(e => e.EventId == 2);

                return amountOfBooks.Count();
            }
        }


        // Most loaned Mediatype

        public static List<MyPagesProductList> ShowMostPopMediaType()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var mostPop = (from
                                pop in db.BookHistories
                               join product in db.Products on pop.ProductId equals product.Id
                               join mediatype in db.MediaTypes on product.MediaId equals mediatype.Id
                               where pop.EventId == 2
                               select mediatype).ToList().GroupBy(c => c.Id)
                                    .Select(c => new MyPagesProductList
                                    {
                                        //MediaType = c.FirstOrDefault().,
                                        FormatName = c.FirstOrDefault().FormatName,
                                        Count = c.Count(),
                                    }).OrderByDescending(c => c.Count).ToList();
                return mostPop;
            }
        }
        public static List<string> StatsValues()
        {
            var starList = new List<string>();
            starList.Add("Product: Populäraste Kategorin");
            starList.Add("Utlåning: Utlånade produkter just nu");
            // starList.Add();
            //starList.Add(4);
            //starList.Add(5);

            return starList;
        }

        public static int Reminder()
        {
            using (var db = new Decrypt_LibraryContext())
            {            
                var lateBooks = MyPages.LateReturnList();
                var reminder = new List<MyPagesProductList>();

                foreach (var book in lateBooks)
                {
                    if (book.EndDate < DateTime.Now)
                    {
                        reminder.Add(book);
                    }                  
                }
                return reminder.Count();
            }
        }

        public static List<MyPagesProductList> Delayes()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var lateBooks = MyPages.LateReturnList();
                var reminder = new List<MyPagesProductList>();

                foreach (var book in lateBooks)
                {
                    if (book.EndDate < DateTime.Now)
                    {
                        reminder.Add(book);
                    }
                }
                return reminder.ToList();
            }
        }

        // Hur många förseningar
        // Funktion för mest populära event - går ej att testa än
        // Statistik på hur långa reservationer för resp bok ** 
        // Kommer joina Kategorier och Users (skulle vi tro)
        // TIPS PÅ NY FUNKTION: I statistik ska en knapp finnas "Skicka varning" där när användare loggar in nästa
        // gång så dyker en DisplayAlert upp med "Du har fått en varning, lämna genast tillbaka din bok"
    }
}
