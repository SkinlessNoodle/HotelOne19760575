using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotel19760575.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hotel19760575.Pages.Bookings
{
    public class StatisticsModel : PageModel
    {
        private readonly Hotel19760575.Data.ApplicationDbContext _context;

        public StatisticsModel(Hotel19760575.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CustomerStats> CustomerStatistic  { get; set; }
        public IList<BookingStats> BookingStatistic { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            var customerGroups = _context.Customer.GroupBy(c => c.Postcode);
            var bookingGroups = _context.Booking.GroupBy(b => b.RoomID);

            CustomerStatistic = await customerGroups.Select(s=> new CustomerStats { Postcode = s.Key, NumOfCustomers = s.Count() }).ToListAsync();
            BookingStatistic = await bookingGroups.Select(g => new BookingStats { RoomID = g.Key, NumOfBookings = g.Count()}).ToListAsync();
            return Page();

        }
    }
}
