using System;
using System.Collections.Generic;

namespace WebProject.WebModels
{
    public partial class User
    {
        public User()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int UserId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? PatronomycName { get; set; }
        public long? PhoneNumber { get; set; }
        public string? Mail { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int? PostId { get; set; }

        public virtual Post? Post { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
