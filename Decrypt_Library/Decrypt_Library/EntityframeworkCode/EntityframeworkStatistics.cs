using Decrypt_Library.Models;
using System.Collections.Generic;

namespace Decrypt_Library.EntityframeworkCode
{
    internal class EntityframeworkStatistics
    {
        // Skapa metod för att hämta in info från databas och returnera en lista som sedan ska visas DESC, 
        // senast utlånad högst upp

        public static List<BookHistory> ShowReservationsByDescOrder()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var reservationByOrder = from
                                         reservations in db.BookHistory
                                         join
                                         product in db.Products on bookHistory.ProductId equals product.Id
                                       //  where bookHistory.UserId == UserLogin.thisUser.Id && bookHistory.EventId == 3
                                         select new MyPagesProductList
                                         {
                                             ID = bookHistory.Id,
                                             Title = product.Title,
                                             Author = product.AuthorName,
                                             ISBN = product.Isbn,
                                             StartDate = bookHistory.StartDate,
                                             EndDate = bookHistory.EndDate,

                                         };
                return reservationByOrder.ToList().OrderBy;

            }
        }

        // Mest frekvent läst kategori - lånehistorik
        // Mest utlånat inom respektive Medietyp
        // Antal böcker i sortimentet just nu
        // Hur många förseningar
        // Hur många utlånade just nu
        // Statistik på hur långa reservationer för resp bok ** 
        // Kommer joina Kategorier och Users (skulle vi tro)
        // Funktion för mest populära event - går ej att testa än
        // TIPS PÅ NY FUNKTION: I statistik ska en knapp finnas "Skicka varning" där när användare loggar in nästa
        // gång så dyker en DisplayAlert upp med "Du har fått en varning, lämna genast tillbaka din bok"
    }
}
