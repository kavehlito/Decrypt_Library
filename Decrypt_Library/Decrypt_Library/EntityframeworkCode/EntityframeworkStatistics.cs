using Decrypt_Library.EntityFrameworkCode;
using Decrypt_Library.Models;
using System.Collections.Generic;
using System.Linq;

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
        // Most loaned Mediatype


        // Hur många förseningar
        // Funktion för mest populära event - går ej att testa än
        // Statistik på hur långa reservationer för resp bok ** 
        // Kommer joina Kategorier och Users (skulle vi tro)
        // TIPS PÅ NY FUNKTION: I statistik ska en knapp finnas "Skicka varning" där när användare loggar in nästa
        // gång så dyker en DisplayAlert upp med "Du har fått en varning, lämna genast tillbaka din bok"
    }
}
