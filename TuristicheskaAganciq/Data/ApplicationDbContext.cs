﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TuristicheskaAganciq.Data
{
    public class ApplicationDbContext : IdentityDbContext<Client>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Excursion> Excursions { get; set; }
        public DbSet<Rezervation> Rezurations { get; set;}
        public DbSet<Country>Countries { get; set; }
        public DbSet<Destination> Destinations { get; set; }
    }
}
