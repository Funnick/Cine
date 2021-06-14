using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Cine.Models;
using Cine.ModelsRepository;
//using Humanizer;

namespace Cine.SQLiteRepository
{
    public class DbMovieRepository : IGetRepository<Movie>
    {
        private readonly CineDbContext _context;
        
        public DbMovieRepository(CineDbContext context)
        {
            _context = context;
        }
        
        public void Add(Movie obj)
        {
            _context.Movies.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Movie obj)
        {
            Movie movie = _context.Movies.FirstOrDefault(m => m.MovieId == obj.MovieId);
            if (movie != null)
            {
                movie.Category = obj.Category;
                movie.Country = obj.Country;
                movie.Duration = obj.Duration;
                movie.Genre = obj.Genre;
                movie.Photo = obj.Photo;
                movie.Synopsis = obj.Synopsis;
                movie.Title = obj.Title;
                movie.Year = obj.Year;
            }

            _context.SaveChanges();
        }

        public Movie GetObj(int id)
        {
            return _context.Movies.Find(id);
        }

        public IEnumerable<Movie> GetAllObj()
        {
            return _context.Movies;
        }
    }
}