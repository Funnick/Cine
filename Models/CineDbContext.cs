using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Cine.Models;

namespace Cine.Models {
    public class CineDbContext: DbContext {
        public CineDbContext(DbContextOptions<CineDbContext> opts): base(opts) {}

        public DbSet<Movie> Movies { get; set; }
    }


}