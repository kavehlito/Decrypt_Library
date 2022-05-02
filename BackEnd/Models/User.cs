using System;
using System.Collections.Generic;

#nullable disable

namespace Decrypt_Library.Models
{
    public partial class User
    {
        public User()
        {
            BookHistories = new HashSet<BookHistory>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public int? UserTypeId { get; set; }
        public long? Ssn { get; set; }
        public string Password { get; set; }
        public long? Phonenumber { get; set; }
        public string Email { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual ICollection<BookHistory> BookHistories { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
