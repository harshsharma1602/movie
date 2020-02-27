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
    public class ContributorTypeController : Controller
    {
        private Context _context;
        public ContributorTypeController(Context context)
        {
            _context = context;
        }

        //Get All Contributors Type
        [HttpGet("{languageId}")]
        public List<ContributorType> GetAll(int languageId)
        {
            try
            {
                var result = _context.ContributorTypes.Where(a => a.LanguageID == languageId).ToList();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Get All Contributors Type
        [HttpPost]
        public List<ContributorType> GetContributorTypesByContributorId([FromBody] List<string> contributors)
        {
            try
            {
                var result = _context.ContributorManagers.Where(a => contributors.Contains(a.ContributorID.ToString())).Select(a=>a.ContributorTypes).Distinct().ToList();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Get All Contributors Type
        [HttpGet("{id}")]
        public ContributorType GetDetail(Guid id)
        {
            try
            {
                var contributortype = _context.ContributorTypes.Where(a => a.ContributorTypeID == id).SingleOrDefault();
                return contributortype;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]ContributorType contributortype)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");

                _context.ContributorTypes.Add(contributortype);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody]ContributorType contributortype)
        {
            try
            {
                if (id != contributortype.ContributorTypeID)
                {
                    return BadRequest();
                }

                _context.Entry(contributortype).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var contributortype = await _context.ContributorTypes.FindAsync(id);

                if (contributortype == null)
                { return NotFound(); }

                _context.ContributorTypes.Remove(contributortype);
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