using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Cine.Models;

namespace Cine.Models {
    public class CineDbContext: DbContext {
        public CineDbContext(DbContextOptions<CineDbContext> opts): base(opts) {}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<TheaterMember> TheaterMembers { get; set; }
        public DbSet<TheaterUser> TheaterUsers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
    }


}