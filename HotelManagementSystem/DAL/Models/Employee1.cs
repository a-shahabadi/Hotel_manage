using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace DAL.Models
{
    public partial class Employee1
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        // public string EmpGrade { get; set; }
        public int? HotelId { get; set; }
        public string Emppass { get; set; }


        [JsonIgnore]
        public virtual Hotel Hotel { get; set; }
    }
}
