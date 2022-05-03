using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decrypt_Library.Models;
using Decrypt_Library.Readers;

namespace Decrypt_Library
{
    public class Cart
    {
        public static bool CheckUserId(int userId, out string UserName)
        {
            UserName = null;
            using (var db = new Models.Decrypt_LibraryContext())
            {
                var userList = db.Users;
                var user = userList.SingleOrDefault(u => u.Id == userId);
            
                if (user == null) return false;
                
                UserName = user.UserName;
                
                return true;
            }
        }

        public static bool CheckProductId(int productId, out string ProductName)
        {
            ProductName = null;
            using (var db = new Models.Decrypt_LibraryContext())
            {
                var productList = db.Products;
                var product = productList.SingleOrDefault(p => p.Id == productId);

                if (product == null) return false;

                ProductName = product.Title;

                return true;
            }
        }



        public static bool AddABookToCart(int userId, int productId)
        {
            using (var db = new Models.Decrypt_LibraryContext())
            {
                var cart = db.Carts;
                cart.Add(new Models.Cart() { ProductId = productId, UserId = userId });
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        } 

        public static bool CheckoutCart(int userId)
        {
            using (var db = new Models.Decrypt_LibraryContext())
            {

                var cart = db.Carts;
                var bookHistory = db.BookHistories;

               
                foreach (var item in cart)
                {
                    if (item.UserId == userId)
                    {
                    bookHistory.Add(new Models.BookHistory() { StartDate = DateTime.Now, ProductId = item.ProductId, EventId = 2, UserId = userId });
                    cart.Remove(item);
                    }
                }
                
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
        }

        //public static void TestLoanABook()
        //{
        //    var userId =  0;
       
        //    while (true)
        //    {
        //    Console.WriteLine("Ange UserId:");
        //    userId = Convert.ToInt32(Console.ReadLine());
        //    var sucess = CheckUserId(userId);
        //        if (sucess == true) break;
        //        Console.WriteLine("Användare finns inte!!");
        //    }


        //    Console.WriteLine("Hur många böcker vill du låna?");
        //    var numberOfBooks = Convert.ToInt32(Console.ReadLine());

        //    for (int i = 0; i < numberOfBooks; i++)
        //    {
        //        Console.WriteLine("Ange produktId på bok:");
        //        var produktId = Convert.ToInt32(Console.ReadLine());
        //        var sucess = AddABookToCart(userId, produktId);
        //        if (!sucess) { Console.WriteLine("Boken finns inte eller går inte att låna"); i--; }
            
        //    }

        //    CheckoutCart(userId);
        //}

    }
}
