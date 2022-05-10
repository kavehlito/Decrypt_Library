using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Decrypt_Library
{
    public class ReturnProduct
    {

        public static bool UpdateProductHistory(int productId, out string productName)
        {
            productName = null;
            using (var db = new Models.Decrypt_LibraryContext())
            {
                var produkcHistory = db.BookHistories;
                var history = produkcHistory.SingleOrDefault(h => h.ProductId == productId && h.EventId == 2 && h.EndDate == null);

                if (history == null) return false;

                
                history.EndDate = DateTime.Now;                
                db.SaveChanges();
                
            }
            UpdateProductStatus(productId, out productName);
            return true;
        }

        public static bool UpdateProductStatus(int productId, out string productName)
        {
            productName = null;
            using (var db = new Models.Decrypt_LibraryContext())
            {
                var productList = db.Products;
                var product = productList.SingleOrDefault(p => p.Id == productId);
               

                if (product == null) return false;
                productName = product.Title;
                product.Status = true;
                db.SaveChanges();
                return true;
            }

        }


    }


    

}
