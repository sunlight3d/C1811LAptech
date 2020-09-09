using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _09_09_2020
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyMovieService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyMovieService.svc or MyMovieService.svc.cs at the Solution Explorer and start debugging.
    public class MyMovieService : IMyMovieService
    {
        public void AddMovie(Movie newMovie)
        {
            using (MoviesDBEntities1 dbContext = new MoviesDBEntities1())
            {
                dbContext.Movies.Add(newMovie);
            }
        }

        public void Delete(int id)
        {
            using (MoviesDBEntities1 dbContext = new MoviesDBEntities1())
            {
                var foundMovie = dbContext.Movies.FirstOrDefault(m => m.MovieId == id);
                dbContext.Movies.Remove(foundMovie);
                dbContext.SaveChanges();
            }
        }

        public void Edit(Movie movie)
        {
            using (MoviesDBEntities1 dbContext = new MoviesDBEntities1())
            {
                var foundMovie = dbContext.Movies.FirstOrDefault(m => m.MovieId == movie.MovieId);
                if (foundMovie != null)
                {
                    foundMovie.Title = movie.Title;
                    foundMovie.ReleaseDate = movie.ReleaseDate;
                    foundMovie.RunningTime = movie.RunningTime;
                    foundMovie.GenreId = movie.GenreId;
                    foundMovie.BoxOffice = movie.BoxOffice;
                }

            }
        }

        public List<Movie> GetAll()
        {
            using (MoviesDBEntities1 dbContext = new MoviesDBEntities1())
            {
                return dbContext.Movies.ToList();

            }
        }
        public List<Movie> GetMovies(int pageNumber, int numberOfRecords)
        {
            using (MoviesDBEntities1 dbContext = new MoviesDBEntities1())
            {
                return dbContext
                    .Movies.Skip(numberOfRecords * pageNumber)
                    .Take(numberOfRecords)
                    .ToList();

            }
        }

        public Movie GetById(int id)
        {
            using (MoviesDBEntities1 dbContext = new MoviesDBEntities1())
            {
                return dbContext
                    .Movies.FirstOrDefault(m => m.MovieId == id);

            }
        }

        public List<Movie> Search(string searchString)
        {
            using (MoviesDBEntities1 dbContext = new MoviesDBEntities1())
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    return dbContext
                    .Movies.Where(movie => movie.Title.Contains(searchString))
                    .ToList();
                }
                else
                {
                    return dbContext.Movies
                    .Take(100)
                    .ToList();
                }
            }
        }
    }
}
