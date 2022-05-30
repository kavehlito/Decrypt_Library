using System;

namespace Decrypt_Library.Models
{
    internal class SelectedProduct
    {
        public int Id { get; set; }
        public string Audience { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public string Shelf { get; set; }
        public string MediaType { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string Narrator { get; set; }
        public long? Isbn { get; set; }
        public string Publisher { get; set; }
        public int? Pages { get; set; }
        public double? Playtime { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool? Status { get; set; }
        public int? NumberInStock { get; set; }
        public int? NumberInAvailable { get; set; }
    }
}