using System;
using System.Collections.Generic;

#nullable disable

namespace Decrypt_Library.Models
{
    public partial class UserEvent
    {
        public int? UserId { get; set; }
        public int? EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
