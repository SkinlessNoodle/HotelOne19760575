using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hotel19760575.Models
{
    public class Room
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Room Level")]
        [RegularExpression("^([G]|[1]|[2]|[3])$", ErrorMessage = "Level can only be: G, 1, 2 or 3")]
        public string Level { get; set; }

        [Display(Name = "Number of Beds")]
        [RegularExpression("^([1]|[2]|[3])$", ErrorMessage = "Bed Count can only be: 1, 2 or 3")]
        public int BedCount { get; set; }

        [Display(Name = "Price (Per Night)")]
        [Range(50, 300, ErrorMessage = "Price must be between $50 and $300")]
        public decimal Price { get; set; }
        public ICollection<Booking> TheBookings { get; set; }
    }
}
