using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Models;


namespace NationalParks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParksController : ControllerBase
    {
        private readonly NationalParksContext _db;

        public ParksController(NationalParksContext db)
        {
            _db = db;
        }

        // GET api/parks/

        ///<summary>
        /// Get a specific National Park.
        /// </summary>
        [HttpGet]
        public async Task<List<Park>> Get(string name, string state, string country, int cost)
        {
        IQueryable<Park> query = _db.Parks.Include(entry => entry.Services).AsQueryable();

        if (name != null)
        {
            query = query.Where(entry => entry.Name == name).Include(entry => entry.Services);
        }

        if (state != null)
        {
            query = query.Where(entry => entry.State == state).Include(entry => entry.Services);
        }

        if (country != null)
        {
            query = query.Where(entry => entry.Country == country).Include(entry => entry.Services);
        }

        if (cost > 0)
        {
            query = query.Where(entry => entry.Cost == cost).Include(entry => entry.Services);
        }

        return await query.ToListAsync();
        }
    
        // GET api/parks/5

        ///<summary>
        /// Get a specific National Park by id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Park>>> GetPark(int id)
        {
        IQueryable<Park> park = _db.Parks.Include(entry => entry.Services).AsQueryable();
        park = park.Where(entry => entry.ParkId == id).Include(entry => entry.Services);
        if (id > _db.Parks.Count())
        {
            return NotFound();
        }
        return await park.ToListAsync();
        }

        // POST api/parks

        ///<summary>
        /// Add a new National Park.
        /// </summary>
        /// <param name="park"></param>
        /// <returns>A newly created National Park</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Parks
        ///     {
        ///        "name": "Park name",
        ///        "state": "StateName",
        ///        "country": "CountryName",
        ///        "cost": "int",
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created National Park</response>
        /// <response code="400">If the National Park is null</response>
        [HttpPost]
        public async Task<ActionResult<Park>> Post(Park park)
        {
        _db.Parks.Add(park);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
        }

        // PUT: api/Parks/5

        ///<summary>
        /// Update a specific National Park.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Park park)
        {
        if (id != park.ParkId)
        {
            return BadRequest();
        }

        _db.Entry(park).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ParkExists(id))
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

        // DELETE: api/Parks/5

        ///<summary>
        /// Delete a specific National Park.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePark(int id)
        {
        var park = await _db.Parks.FindAsync(id);
        if (park == null)
        {
            return NotFound();
        }

        _db.Parks.Remove(park);
        await _db.SaveChangesAsync();

        return NoContent();
        }
        
        private bool ParkExists(int id)
        {
        return _db.Parks.Any(e => e.ParkId == id);
        }

        
    }
}