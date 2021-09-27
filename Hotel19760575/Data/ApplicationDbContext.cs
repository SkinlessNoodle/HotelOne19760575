using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Hotel19760575.Models;

namespace Hotel19760575.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hotel19760575.Models.Room> Room { get; set; }
        public DbSet<Hotel19760575.Models.Booking> Booking { get; set; }
        public DbSet<Hotel19760575.Models.Customer> Customer { get; set; }
    }
}
