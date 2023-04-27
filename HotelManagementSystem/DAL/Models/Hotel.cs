using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace DAL.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Employee1s = new HashSet<Employee1>();
            Rooms = new HashSet<Room>();
        }

        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public int? Pincode { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employee1> Employee1s { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
