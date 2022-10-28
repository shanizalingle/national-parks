using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NationalParks.Models;


namespace NationalParks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NationalParksController : ControllerBase
    {
        private readonly NationalParksContext _db;

        public NationalParksController(NationalParksContext db)
        {
            _db = db;
        }

        // GET api/parks/
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
            query = query.Where(entry => entry.Country == state).Include(entry => entry.Services);
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
        [HttpPost]
        public async Task<ActionResult<Park>> Post(Park park)
        {
        _db.Parks.Add(park);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
        }

        // PUT: api/Parks/5
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