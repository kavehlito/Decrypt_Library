using System;
using System.Collections.Generic;


namespace Decrypt_Library.Models
{
    public partial class BookHistory
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public DateTime? StartDate { get; set; }
        public int? EventId { get; set; }
        public int? UserId { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual TypeOfBookEvent Event { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
