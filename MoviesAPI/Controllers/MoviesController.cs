using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcMovie.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private static List<Movie> movies = new List<Movie>()
        {
            new Movie() { Id = Guid.NewGuid(), Title = "The Hunger Games", Genre = "Dystopian", Price = 15 },
            new Movie() { Id = Guid.NewGuid(), Title = "The Sound of Music", Genre = "Musical", Price = 20 },
            new Movie() { Id = Guid.NewGuid(), Title = "Lord of the Rings", Genre = "Adventure", Price = 24 },
            new Movie() { Id = Guid.NewGuid(), Title = "City of Angels", Genre = "Romance", Price = 8 },
            new Movie() { Id = Guid.NewGuid(), Title = "About Time", Genre = "Romance", Price = 19 }
        };

        [HttpGet]
        public Movie[] Get()
        {
            return movies.ToArray();
        }

        [HttpPost]
        public void Post([FromBody] Movie movie)
        {
            if (movie.Id == Guid.Empty)
                movie.Id = Guid.NewGuid();

            movies.Add(movie);
        }

        [HttpPut]
        public void Put([FromBody] Movie movie)
        {
            Movie currentMovie = movies.FirstOrDefault(m => m.Id == movie.Id);
            currentMovie.Title = movie.Title;
            currentMovie.Genre = movie.Genre;
            currentMovie.Price = movie.Price;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            movies.RemoveAll(movie => movie.Id == id);
        }
    }
}
