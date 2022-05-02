using System;
using System.Collections.Generic;


namespace Decrypt_Library.Models
{
    public partial class UsersCart
    {
        public int? UserId { get; set; }
        public int? CartId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual User User { get; set; }
    }
}
