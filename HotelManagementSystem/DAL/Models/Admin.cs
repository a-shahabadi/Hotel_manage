using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace DAL.Models
{
    public partial class Admin
    {
        [Required(ErrorMessage ="Name Required")]
        public string AdminName { get; set; }
       
        [Required(ErrorMessage = "Password Required")]

        public string Password { get; set; }

    
        public int AdminId { get; set; }

        [JsonIgnore]
        public string AdminType { get; set; }

    }
}
