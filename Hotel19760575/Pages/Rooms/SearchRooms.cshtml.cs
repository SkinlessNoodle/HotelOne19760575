using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotel19760575.Data;
using Hotel19760575.Models;

namespace Hotel19760575.Pages.Rooms
{
    public class SearchRoomsModel : PageModel
    {
        public IList<Room> Room { get; set; }

        public void OnGet(int numRooms, DateTime checkInDate, DateTime checkOutDate)
        {
            ViewData["message"] = ($"rooms = {numRooms}, check in = {checkInDate}, check out = {checkOutDate}");
        }
    }
}
