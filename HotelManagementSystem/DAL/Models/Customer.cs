using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? CustomerDob { get; set; }
        public string CustomerAddress { get; set; }
        public int? CustomerContact { get; set; }
        public string CustomerEmail { get; set; }
        public int? Age { get; set; }
        public string Custpass { get; set; }

        [JsonIgnore]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
