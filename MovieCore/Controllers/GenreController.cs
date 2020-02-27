using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieCore.Data;
using MovieCore.Models;

namespace MovieCore.Controllers
{
    [Route("api/[Controller]/[action]")]
    public class GenreController : Controller
    {
        private Context _context;
        public GenreController(Context context)
        {
            _context = context;
        }

        //Get All Contributors Type
        [HttpGet("{languageId}")]
        public List<Genre> GetAll(int languageId)
        {
            try
            {
                return _context.Genres.Where(a => a.LanguageID == languageId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Get All Contributors Type
        [HttpGet("{id}")]
        public Genre GetDetail(Guid id)
        {
            try
            {
                var genre = _context.Genres.Where(a => a.GenreID == id).SingleOrDefault();
                return genre;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Genre genre)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");

                _context.Genres.Add(genre);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody]Genre genre)
        {
            try
            {
                if (id != genre.GenreID)
                {
                    return BadRequest();
                }

                _context.Entry(genre).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var genre = await _context.Genres.FindAsync(id);

                if (genre == null)
                { return NotFound(); }

                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}