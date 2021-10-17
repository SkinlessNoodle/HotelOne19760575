using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Hotel19760575.Models
{
    public class CustomerViewModel
    {
        [Required, Display(Name = "Surname")]
        [RegularExpression(@"[A-Za-z'-]{2,20}")]
        public string Surname { get; set; }

        [Required, Display(Name = "Given Name")]
        [RegularExpression(@"[A-Za-z'-]{2,20}")]
        public string GivenName { get; set; }

        [Required, Display(Name = "Postcode")]
        [RegularExpression(@"[0-9]{4}")]
        public string Postcode { get; set; }

        // Navigation Properties

        public ICollection<Booking> TheBookings { get; set; }
    }
}
