using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotel19760575.Data;
using Hotel19760575.Models;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Authorization;

namespace Hotel19760575.Pages.Rooms
{
    [Authorize(Roles = "Customer")]
    public class SearchRoomsModel : PageModel
    {      
        //creates objects
        public IList<Room> Room { get; set; }

        [BindProperty]
        public Room room { get; set; }

        [BindProperty]
        public Booking booking { get; set; }


        //creates context
        private readonly Hotel19760575.Data.ApplicationDbContext _context;
        public SearchRoomsModel(Hotel19760575.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        //when form is submitted
        public async Task<IActionResult> OnPostAsync()
        {
            //query from alynn, creates a search query and parameter
            String query = "SELECT DISTINCT * From Room WHERE Room.BedCount = @BedCount and Room.ID NOT IN (SELECT Booking.RoomID FROM Booking INNER JOIN Room ON Booking.RoomID = Room.ID" +
                " WHERE @CheckIn < Booking.CheckOut AND Booking.CheckIn < @CheckOut)";

            var bedCount = new SqliteParameter("BedCount", room.BedCount);
            var CheckIn = new SqliteParameter("CheckIn", booking.CheckIn);
            var CheckOut = new SqliteParameter("CheckOut", booking.CheckOut);

            //submits the query and returns results as an Ilist, this list contains only the bed reqierment 
            Room = (IList<Room>)await _context.Room.FromSqlRaw(query, bedCount, CheckIn, CheckOut).ToListAsync();


            ViewData["posted"] = "true";

            //returns page
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Page();

        }



    }
}
