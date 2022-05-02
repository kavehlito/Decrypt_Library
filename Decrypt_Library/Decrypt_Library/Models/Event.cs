using System;
using System.Collections.Generic;


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
