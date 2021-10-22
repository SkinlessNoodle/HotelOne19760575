using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Hotel19760575.Models;
using System.Security.Claims;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Hotel19760575.Pages.Bookings

{
    [Authorize(Roles = "Customer")]
    public class DateDiffModel : PageModel
    {
        private readonly Hotel19760575.Data.ApplicationDbContext _context;

        public DateDiffModel (Hotel19760575.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookingViewModel BookingInput { get; set; }

        public IList<Booking> SameDates { get; set; }

        // GET: MovieGoers/PeopleDiff
        public IActionResult OnGet()
        {
            ViewData["CustomerEmail"] = new SelectList(_context.Customer, "Email", "FullName");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            string _email = User.FindFirst(ClaimTypes.Name).Value;

            //Needed to retrieve customer email.
            Customer customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);

            // prepare the parameters to be inserted into the query
            var CustomerCheckIn = new SqliteParameter("CheckIn", BookingInput.CheckIn);
            var CustomerCheckOut = new SqliteParameter("CheckOut", BookingInput.CheckOut);
            var RoomID = new SqliteParameter("RoomID", BookingInput.RoomID);

            // Construct the query to get the bookings for the chosen RoomID that already exist within the chosen dates
            var sameDates = _context.Booking.FromSqlRaw("SELECT * FROM Booking INNER JOIN Room ON Booking.RoomID = Room.ID WHERE Booking.RoomID = @RoomID AND" 
                + "@CheckIn < Booking.CheckOut AND Booking.CheckIn < @CheckOut", RoomID, CustomerCheckIn, CustomerCheckOut);

  
            SameDates = await sameDates.ToListAsync();
            
            //calculate the number of days between check in & check out to calculate total cost of booking
            var dateDiff = BookingInput.CheckOut.Date.Day - BookingInput.CheckIn.Date.Day;

         
            ViewData["DateDiff"] = dateDiff;

            // creating a booking object for inserting into database
            Booking booking = new Booking();
            booking.RoomID = BookingInput.RoomID;
            booking.CheckIn = BookingInput.CheckIn;
            booking.CheckOut = BookingInput.CheckOut;
            booking.CustomerEmail = customer.Email;
           
            // retrieve the booked room
            var theRoom = await _context.Room.FindAsync(BookingInput.RoomID);

            Room room = new Room();

            // calculate the total price of this order
            booking.Cost = dateDiff * theRoom.Price;
            
            //convert DateTime output to Date
            var cIn = booking.CheckIn.ToString("dd/MM/yyyy");
            var cOut = booking.CheckOut.ToString("dd/MM/yyyy");

            ViewData["ID"] = booking.RoomID;
            ViewData["Level"] = theRoom.Level;
            ViewData["CIN"] = cIn;
            ViewData["COUT"] = cOut;
            ViewData["TotalPrice"] = booking.Cost;
            ViewData["Name"] = customer.FullName;

            if (SameDates.Count == 0)
            {
                _context.Booking.Add(booking);
                await _context.SaveChangesAsync();
             
                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}
