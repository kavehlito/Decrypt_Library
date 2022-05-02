using System;
using System.Collections.Generic;

#nullable disable

namespace Decrypt_Library.Models
{
    public partial class Product
    {
        public Product()
        {
            BookHistories = new HashSet<BookHistory>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public int? MediaId { get; set; }
        public bool? Status { get; set; }
        public long? Isbn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Pages { get; set; }
        public double? Playtime { get; set; }
        public string Publisher { get; set; }
        public int? LanguageId { get; set; }
        public string AuthorName { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? CategoryId { get; set; }
        public int? ShelfId { get; set; }
        public string Narrator { get; set; }
        public bool? NewProduct { get; set; }
        public int? AudienceId { get; set; }
        public bool? HiddenProduct { get; set; }

        public virtual ICollection<BookHistory> BookHistories { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
