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

namespace Hotel19760575.Pages.MovieGoers
{
    public class PeopleDiffModel : PageModel
    {
        private readonly Hotel19760575.Data.ApplicationDbContext _context;

        public PeopleDiffModel(Hotel19760575.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking booking { get; set; }
       
        //public TwoMovieGoers MovieGoersInput { get; set; }

        // List of different movies; for passing to Content file to display
        public IList<Booking> SameDates { get; set; }

        // GET: MovieGoers/PeopleDiff
        public IActionResult OnGet()
        {
            // Get the options for the MovieGoer select list from the database
            // and save them in ViewData for passing to Content file
           //ViewData["CustomerEmail"] = new SelectList(_context.Set<Customer>(), "Email", "Email");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            string _email = User.FindFirst(ClaimTypes.Name).Value;

            //Needed to retrieve customer email.
            Customer customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);

            Booking booking = new Booking();

            // prepare the parameters to be inserted into the query
            var CustomerCheckIn = new SqliteParameter("CheckIn", booking.CheckIn);
            var CustomerCheckOut = new SqliteParameter("CheckOut", booking.CheckOut);
            var RoomCost = new SqliteParameter("Price", booking.TheRoom.Price);

            // Construct the query to get the movies watched by Moviegoer A but not Moviegoer B
            // Use placeholders as the parameters
            var sameDates = _context.Booking.FromSqlRaw("SELECT * FROM Booking INNER JOIN Room ON Booking.RoomID = Room.ID " 
                + "WHERE @CheckIn < Booking.CheckOut AND Booking.CheckIn < @CheckOut", CustomerCheckIn, CustomerCheckOut);

            var getCost = _context.Room.FromSqlRaw("SELECT price FROM Room INNER JOIN Booking ON Booking.RoomID = Room.ID", RoomCost);

            /* "select [Movie].* from [Movie] inner join [Order] on "
                              + "[Movie].ID = [Order].MovieID where [Order].MovieGoerEmail = @CheckIn and "
                              + "[Movie].ID not in (select [Movie].ID from [Movie] inner join [Order] on "
                              + "[Movie].ID = [Order].MovieID where [Order].MovieGoerEmail = @CheckOut)"
            */

            //.Select(mo => new Movie { ID = mo.ID, Genre = mo.Genre, Price = mo.Price, ReleaseDate = mo.ReleaseDate, Title = mo.Title });

            // Run the query and save the results in DiffMovies for passing to content file
            SameDates = await sameDates.ToListAsync();
            // Save the options for both dropdown lists in ViewData for passing to content file
            //ViewData["MovieGoerList"] = new SelectList(_context.MovieGoer, "Email", "FullName");
            // invoke the content file

            var dateDiff = booking.CheckOut.Date - booking.CheckIn.Date;

            ViewData["DateDiff"] = dateDiff;


           return Page();
        }
    }
}