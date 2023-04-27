using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace DAL.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int RoomNo { get; set; }
        public string RoomType { get; set; }
        public double? RoomPrice { get; set; }
        public int? HotelId { get; set; }
        public string RoomStatus { get; set; }

        [JsonIgnore]
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
