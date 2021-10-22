using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotel19760575.Data;
using Hotel19760575.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hotel19760575.Pages.Bookings
{
    public class AdminManualIndex : PageModel
    {       
        private readonly Hotel19760575.Data.ApplicationDbContext _context;

        public AdminManualIndex(Hotel19760575.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get; set; }

        public async Task OnGetAsync()
        {

            var bookings = (IQueryable<Booking>)_context.Booking;

            Booking = await _context.Booking.ToListAsync();
            Booking = await bookings
                .Include(s => s.TheCustomer)
                .Include(s => s.TheRoom)
                .AsNoTracking().ToListAsync();
        }
    }
}
