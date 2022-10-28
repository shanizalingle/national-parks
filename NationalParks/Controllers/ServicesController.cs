using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Models;


namespace NationalParks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ServicesController : ControllerBase
  {
    private readonly NationalParksContext _db;

    public ServicesController(NationalParksContext db)
    {
      _db = db;
    }

    // GET api/services/

    ///<summary>
    /// Get a specific service.
    /// </summary>
    [HttpGet]
    public async Task<List<Service>> Get()
    {
      IQueryable<Service> query = _db.Services.AsQueryable();
      return await query.ToListAsync();
    }

    // GET api/services/5
    ///<summary>
    /// Get a specific service by id.
    /// </summary>
    [HttpGet("{id}")]

    public async Task<ActionResult<Service>> GetService(int id)
    {
        var service = await _db.Services.FindAsync(id);

        if (service == null)
        {
            return NotFound();
        }

        return service;
    }

    // POST api/services

    ///<summary>
    /// Add a new service.
    /// </summary>
    /// <param name="service"></param>
    /// <returns>A newly created Service</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Services
    ///     {
    ///        "name": "ServiceName",
    ///        "type": "ServiceType",
    ///        "cost": "int",
    ///        "description": "description of place"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created service</response>
    /// <response code="400">If the service is null</response>
    [HttpPost]
    public async Task<ActionResult<Service>> Post(Service service)
    {
      _db.Services.Add(service);
      await _db.SaveChangesAsync();

      // return CreatedAtAction("Post", new { id = service.ServiceId }, service);
      return CreatedAtAction(nameof(GetService), new { id = service.ServiceId }, service);
    }

    // PUT: api/services/5
    ///<summary>
    /// Update a specific service.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Service service)
    {
      if (id != service.ServiceId)
      {
        return BadRequest();
      }

      _db.Entry(service).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ServiceExists(id))
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

    // DELETE: api/services/5

    ///<summary>
    /// Delete a specific service.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
      var service = await _db.Services.FindAsync(id);
      if (service == null)
      {
        return NotFound();
      }

      _db.Services.Remove(service);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    
    private bool ServiceExists(int id)
    {
      return _db.Services.Any(e => e.ServiceId == id);
    }
  }
}