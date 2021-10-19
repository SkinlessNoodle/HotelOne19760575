using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hotel19760575.Data;
using Hotel19760575.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Hotel19760575.Pages.Bookings
{

    public class IndexModel : PageModel
    {
        private readonly Hotel19760575.Data.ApplicationDbContext _context;

        public IndexModel(Hotel19760575.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "date_asc";
            }

            var bookings = (IQueryable<Booking>)_context.Booking;

            switch (sortOrder)
            {
                case "date_asc":
                    bookings = bookings.OrderBy(s => s.CheckIn);
                    break;
                case "date_desc":
                    bookings = bookings.OrderByDescending(s => s.CheckIn);
                    break;
                case "price_asc":
                    bookings = bookings.OrderBy(s => (double)s.Cost);
                    break;
                case "price_desc":
                    bookings = bookings.OrderByDescending(s => (double)s.Cost);
                    break;
            }

            ViewData["NextDateOrder"] = sortOrder != "date_asc" ? "date_asc" : "date_desc";
            ViewData["NextPriceOrder"] = sortOrder != "price_asc" ? "price_asc" : "price_desc";

            string _email = User.FindFirst(ClaimTypes.Name).Value;

            Booking = await _context.Booking
                .Include(b => b.TheCustomer)
                .Where(s => s.CustomerEmail == _email)
                .Include(b => b.TheRoom)
                .AsNoTracking.ToListAsync();
        }
    }
}
