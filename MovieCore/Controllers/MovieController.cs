using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCore.Data;
using MovieCore.Models;

namespace MovieCore.Controllers
{
    [Route("api/[Controller]/[action]")]
    public class MovieController : Controller
    {
        private Context _context;
        public MovieController(Context context)
        {
            _context = context;
        }

        //Get All Contributors Type
        [HttpGet("{languageId}")]
        public List<Movie> GetAll(int languageId)
        {
            try
            {
                var result = _context.Movies.Include("MovieContributors.Contributors.ContributorManagers.ContributorTypes").Include("MovieGenres.Genres").Include("MovieContributorTypes.ContributorTypes").Where(a => a.LanguageID == languageId).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get All Contributors Type
        [HttpGet("{id}")]
        public Movie GetDetail(Guid id)
        {
            try
            {
                var movie = _context.Movies.Where(a => a.MovieID == id).SingleOrDefault();
                var result = _context.Movies.Include("MovieContributors.Contributors").Include("MovieGenres.Genres").Include("MovieContributorTypes.ContributorTypes").FirstOrDefault(a => a.MovieID == id);
                //var movie = _context.Movies.Where(a => a.MovieID == id).SingleOrDefault();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Movie movie)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");

                _context.Movies.Add(movie);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody]Movie movie)
        {
            try
            {
                if (id != movie.MovieID)
                {
                    return BadRequest();
                }

                #region delete and add contributors
                var moviecontributors = _context.MovieContributors.Where(a => a.MovieID == movie.MovieID).ToList();
                moviecontributors.ForEach(a =>
                {
                    _context.MovieContributors.Remove(a);
                });
                movie.MovieContributors.ForEach(a =>
                {
                    _context.MovieContributors.Add(a);
                });
                #endregion


                #region delete and add contributor types
                var moviecontributortypes = _context.MovieContributorTypes.Where(a => a.MovieID == movie.MovieID).ToList();
                moviecontributortypes.ForEach(a =>
                {
                    _context.MovieContributorTypes.Remove(a);
                });
                movie.MovieContributorTypes.ForEach(a =>
                {
                    _context.MovieContributorTypes.Add(a);
                });
                #endregion

                #region delete and add genres
                var moviegenres = _context.MovieGenres.Where(a => a.MovieID == movie.MovieID).ToList();
                moviegenres.ForEach(a =>
                {
                    _context.MovieGenres.Remove(a);
                });
                movie.MovieGenres.ForEach(a =>
                {
                    _context.MovieGenres.Add(a);
                });
                #endregion

                _context.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var movie = await _context.Movies.FindAsync(id);

                if (movie == null)
                { return NotFound(); }

                _context.Movies.Remove(movie);
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