using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCore;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase {
        private readonly IMDBContext _context;

        public MoviesController(IMDBContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<Movies> GetMovies() {
            return _context.Movies;
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie([FromRoute] string id) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var movies = await _context.Movies.FindAsync(id);

            if (movies == null) {
                return NotFound();
            }

            return Ok(movies);
        }

        // GET: api/Movies/{string:genre}
        [HttpGet("search/{_genre}")]
        //[Route("search/{_genre}")]
        public async Task<IActionResult> SearchMovie([FromRoute] string _genre) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var movies = await _context.Movies.Where(
                                                    s => s.Genres.Contains(_genre))
                                                    .ToListAsync();


            if(movies == null) {
                return NotFound();
            }
            return Ok(movies);
             
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovies([FromRoute] string id, [FromBody] Movies movies) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != movies.Tconst) {
                return BadRequest();
            }

            _context.Entry(movies).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<IActionResult> PostMovies([FromBody] Movies movies) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _context.Movies.Add(movies);
            try  {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) {
                if (MoviesExists(movies.Tconst)) {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else {
                    throw;
                }
            }
            return CreatedAtAction("GetMovies", new { id = movies.Tconst }, movies);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovies([FromRoute] string id) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var movies = await _context.Movies.FindAsync(id);
            if (movies == null) {
                return NotFound();
            }

            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();

            return Ok(movies);
        }

        private bool MoviesExists(string id) {
            return _context.Movies.Any(e => e.Tconst == id);
        }
    }
}