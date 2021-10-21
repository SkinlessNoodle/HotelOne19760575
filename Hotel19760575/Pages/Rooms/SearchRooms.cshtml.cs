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

namespace Hotel19760575.Pages.Rooms
{
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
            //query from alynn
            //String query = "SELECT DISTINCT ID From Room WHERE Room.BedCount = 2 and Room.ID NOT IN (SELECT Booking.RoomID FROM Booking INNER JOIN Room ON Booking.RoomID = Room.ID" + 
            //    "WHERE  "2021-10-20 00:00:00" < Booking.CheckOut AND Booking.CheckIn < "2021-10-22 00:00:00")"


            //creates a search query and parameter
            String query = "SELECT * From Room Where BedCount = @BedCount";
            var param = new SqliteParameter("@BedCount", room.BedCount);

            var CheckIn = new SqliteParameter("CheckIn", booking.CheckIn);
            var CheckOut = new SqliteParameter("CheckOut", booking.CheckOut);

            //submits the query and returns results as an Ilist, this list contains only the bed reqierment 
            Room = (IList<Room>)await _context.Room.FromSqlRaw(query, param).ToListAsync();

            //next filter out the check in/ check out dates 
            //Room = (IList<Room>)await _context.Booking.FromSqlRaw("SELECT * FROM Booking INNER JOIN Room ON Booking.RoomID = Room.ID "
            //   + "WHERE @CheckIn < Booking.CheckOut AND Booking.CheckIn < @CheckOut", CheckIn , CheckOut)";



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
