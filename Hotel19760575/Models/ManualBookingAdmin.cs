using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel19760575.Models
{
    public class ManualBookingAdmin
    {

        // primary key
        [Key]
        public int BookingID { get; set; }

        // foreign key
        public int RoomID { get; set; }

        // foreign key
        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        public decimal Cost { get; set; }

        public Room TheRoom { get; set; }
        public Customer TheCustomer { get; set; }


    }
}
