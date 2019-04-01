using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Domain;
using FinalProject.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

namespace FinalProject.WebApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class TitlesController : ControllerBase
	{
		private readonly TitleLogic _logic;
		public TitlesController()
		{
			_logic = new TitleLogic();
		}

		// GET: api/Title
		//[HttpGet]
		//public async Task<IList<Title>> GetMovies() {
		//	return await _logic.GetTitlesAsync();
		//}

        // GET: api/Title
        [HttpGet]
        public IEnumerable<Title> GetMovies() {
            return _logic.GetTitles().Take(1000).ToList();
        }

        // GET: api/Title/5
        [HttpGet("{id}")]
		public async Task<IActionResult> GetMovie([FromRoute] string id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Title movies = await _logic.GetTitleByIdAsync(id);

			if (movies == null)
			{
				return NotFound();
			}

			return Ok(movies);
		}

		// GET: api/Title/{string:title}
		[HttpGet("search/{title}")]
		public async Task<IActionResult> SearchMovie([FromRoute] string title)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

            IEnumerable<Title> movies = await _logic.GetTitlesByTitleAsync(title);

			if (movies == null)
			{
				return NotFound();
			}
			return Ok(movies);
		}

		// PUT: api/Title/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMovies([FromRoute] string id, [FromBody] Title title)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != title.TitleId)
			{
				return BadRequest();
			}

			//_context.Entry(movies).State = EntityState.Modified;

			try
			{
				await _logic.UpdateTitleAsync(title);
			}
			//catch (DbUpdateConcurrencyException)
			catch (Exception)
			{
				if (!_logic.TitleExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return Ok(title);
		}

		// POST: api/Title
		[HttpPost]
		public async Task<IActionResult> PostMovies([FromBody] Title title)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			//_context.Movies.Add(title);
			try
			{
				//await _context.SaveChangesAsync();
				Title newTitle = await _logic.InsertTitleAsync(title);
                return Ok(newTitle);
            }
			//catch (DbUpdateException) 
			catch (Exception)
			{
				if (_logic.TitleExists(title.TitleId))
				{
					return new StatusCodeResult(StatusCodes.Status409Conflict);
				}
				else
				{
					throw;
				}
			}
		}

		// DELETE: api/Title/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMovies([FromRoute] string id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			//var movies = await _context.Movies.FindAsync(id);
			//if (movies == null) {
			//    return NotFound();
			//}

			//_context.Movies.Remove(movies);
			//await _context.SaveChangesAsync();

			if (!_logic.TitleExists(id))
			{
				return NotFound();
			}

			await _logic.DeleteTitleAsync(id);

			return Ok(id);
			//return Ok(movies);
		}
	}
}
