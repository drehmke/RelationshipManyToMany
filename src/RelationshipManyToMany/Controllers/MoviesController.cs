using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RelationshipManyToMany.Data;
using RelationshipManyToMany.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RelationshipManyToMany.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _db;
        public MoviesController(ApplicationDbContext db)
        {
            this._db = db;
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return this._db.Movies.ToList();
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            Movie movieToReturn = _db.Movies.FirstOrDefault(m => m.Id == id);
            if( movieToReturn == null )
            { return NotFound(); }
            else
            { return Ok(movieToReturn);  }
        }

        // Post to /api/movies
        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody]Actor actor)
        {
            // Create the actor in the database
            _db.Actors.Add(actor);
            _db.SaveChanges();

            _db.MovieActors.Add(new MovieActor
            {
                MovieId = id,
                ActorId = actor.Id
            });
            _db.SaveChanges();

            return Ok();
        }
    }
}
