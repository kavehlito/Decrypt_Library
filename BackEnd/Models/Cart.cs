using System;
using System.Collections.Generic;

#nullable disable

namespace Decrypt_Library.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
    }
}
