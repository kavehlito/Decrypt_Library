using System;
using System.Collections.Generic;

#nullable disable

namespace Decrypt_Library.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime? Time { get; set; }
        public string Description { get; set; }
    }
}
