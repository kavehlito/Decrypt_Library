using System;
using System.Collections.Generic;

#nullable disable

namespace Decrypt_Library.Models
{
    public partial class TypeOfBookEvent
    {
        public TypeOfBookEvent()
        {
            BookHistories = new HashSet<BookHistory>();
        }

        public int Id { get; set; }
        public string TypeofEventName { get; set; }

        public virtual ICollection<BookHistory> BookHistories { get; set; }
    }
}
