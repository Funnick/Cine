﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Cine.Models;
using Cine.ModelsRepository;

namespace Cine.SQLiteRepository
{
    public class DbShowRepository : IGetRepository<Show>
    {
        private readonly CineDbContext _context;
        
        public DbShowRepository(CineDbContext context)
        {
            _context = context;
        }
        
        public void Add(Show obj)
        {
            _context.Shows.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Show obj)
        {
            Show show = _context.Shows.FirstOrDefault(s => s.ShowId == obj.ShowId);
            if (show != null)
            {
                show.Cinema = obj.Cinema;
                show.Date = obj.Date;
                show.Discount = obj.Discount;
                show.Movie = obj.Movie;
                show.Price = obj.Price;
                show.PointsPrice = obj.PointsPrice;
                show.CinemaId = obj.Cinema.CinemaId;
                show.MovieId = obj.Movie.MovieId;
                show.StartTime = obj.StartTime;
                show.EndTime = obj.EndTime;
            }

            _context.SaveChanges();
        }

        public Show GetObj(int id)
        {
            return _context.Shows.Find(id);
        }

        public IEnumerable<Show> GetAllObj()
        {
            return _context.Shows;
        }
    }
}