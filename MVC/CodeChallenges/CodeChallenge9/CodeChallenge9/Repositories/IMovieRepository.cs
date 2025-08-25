using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge9.Models;
using System.Data.Entity;

namespace CodeChallenge9.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        IEnumerable<Movie> GetMoviesByYear(int year);
        IEnumerable<Movie> GetMoviesByDirector(string director);
    }

    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesDbContext _context = new MoviesDbContext();

        public IEnumerable<Movie> GetAll() => _context.Movies.ToList();

        public Movie GetById(int id) => _context.Movies.Find(id);

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var m = _context.Movies.Find(id);
            if (m != null)
            {
                _context.Movies.Remove(m);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Movie> GetMoviesByYear(int year) =>
            _context.Movies.Where(m => m.DateOfRelease.Year == year).ToList();

        public IEnumerable<Movie> GetMoviesByDirector(string director) =>
            _context.Movies.Where(m => m.DirectorName == director).ToList();
    }
}







