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
    public class ContributorController : Controller
    {
        private Context _context;
        public ContributorController(Context context)
        {
            _context = context;
        }

        //Get All Contributors Type
        [HttpGet("{languageId}")]
        public List<Contributor> GetAll(int languageId)
        {
            try
            {
                var result = _context.Contributors.Include("ContributorManagers.ContributorTypes").Where(a => a.LanguageID == languageId).ToList();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        //Get All Contributors Type
        [HttpGet("{id}")]
        public Contributor GetDetail(Guid id)
        {
            try
            {
                //var genre = _context.Contributors.Where(a => a.ContributorID == id).SingleOrDefault();
                var genre = _context.Contributors.Include("ContributorManagers.ContributorTypes").SingleOrDefault(x => x.ContributorID == id);
                return genre;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Contributor contributor)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");

                _context.Contributors.Add(contributor);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody]Contributor contributor)
        {
            try
            {
                if (id != contributor.ContributorID)
                {
                    return BadRequest();
                }

                var result = _context.ContributorManagers.Where(a => a.ContributorID == contributor.ContributorID).ToList();
                result.ForEach(a =>
                {
                    _context.ContributorManagers.Remove(a);
                });
                contributor.ContributorManagers.ForEach(a =>
                {
                    _context.ContributorManagers.Add(a);
                });
                _context.Entry(contributor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var contributor = await _context.Contributors.FindAsync(id);

                if (contributor == null)
                { return NotFound(); }

                _context.Contributors.Remove(contributor);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteContributorManager(Guid id)
        {
            try
            {
                var genre = _context.ContributorManagers.FirstOrDefault(a => a.ID == id);
                _context.ContributorManagers.Remove(genre);
                _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}