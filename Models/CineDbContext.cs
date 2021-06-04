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
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
    }


}