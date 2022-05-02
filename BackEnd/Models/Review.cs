using System;
using System.Collections.Generic;

#nullable disable

namespace Decrypt_Library.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public int? Stars { get; set; }
        public int? ProduktId { get; set; }
        public int? UserId { get; set; }

        public virtual Product Produkt { get; set; }
        public virtual User User { get; set; }
    }
}
