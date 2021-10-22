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

namespace Hotel19760575.Pages.Bookings

{
    //TO DO: Make sure bookign validation works , convert DateDiff to int
    public class PeopleDiffModel : PageModel
    {
        private readonly Hotel19760575.Data.ApplicationDbContext _context;

        public PeopleDiffModel (Hotel19760575.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookingViewModel BookingInput { get; set; }

        //public TwoMovieGoers MovieGoersInput { get; set; }

        // List of different movies; for passing to Content file to display
        public IList<Booking> SameDates { get; set; }

        // GET: MovieGoers/PeopleDiff
        public IActionResult OnGet()
        {
            // Get the options for the MovieGoer select list from the database
            // and save them in ViewData for passing to Content file
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




            // Construct the query to get the movies watched by Moviegoer A but not Moviegoer B
            // Use placeholders as the parameters
            var sameDates = _context.Booking.FromSqlRaw("SELECT * FROM Booking INNER JOIN Room ON Booking.RoomID = Room.ID WHERE Booking.RoomID = @RoomID AND" 
+ "@CheckIn < Booking.CheckOut AND Booking.CheckIn < @CheckOut", RoomID, CustomerCheckIn, CustomerCheckOut);

            

            // Run the query and save the results in DiffMovies for passing to content file
            SameDates = await sameDates.ToListAsync();
            // Save the options for both dropdown lists in ViewData for passing to content file
            //ViewData["MovieGoerList"] = new SelectList(_context.MovieGoer, "Email", "FullName");
            // invoke the content file

            var dateDiff = BookingInput.CheckOut.Date.Day - BookingInput.CheckIn.Date.Day;

         
            ViewData["DateDiff"] = dateDiff;

            // creating a subscription object for inserting into database
            Booking booking = new Booking();
            booking.RoomID = BookingInput.RoomID;
            booking.CheckIn = BookingInput.CheckIn;
            booking.CheckOut = BookingInput.CheckOut;
            booking.CustomerEmail = customer.Email;
            
            // retrieve the ordered magazine to get its price
            var theRoom = await _context.Room.FindAsync(BookingInput.RoomID);

            Room room = new Room();

            // calculate the total price of this order **MAKE CHANGES TO CONVERT THE DATEDIFF TO INTEGER**
            booking.Cost = dateDiff * theRoom.Price;
            //booking.Cost = 10;

            ViewData["ID"] = booking.RoomID;
            ViewData["Level"] = theRoom.Level;
            ViewData["CIN"] = booking.CheckIn;
            ViewData["COUT"] = booking.CheckOut;
            ViewData["TotalPrice"] = booking.Cost;
            //ViewData["Name"] = 

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
