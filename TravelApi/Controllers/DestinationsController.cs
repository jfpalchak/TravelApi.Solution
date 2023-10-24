using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApi.Models;

namespace TravelApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DestinationsController : ControllerBase
{
  private readonly TravelApiContext _db;

  public DestinationsController(TravelApiContext db)
  {
    _db = db;
  }

  // GET: api/destinations
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Destination>>> Get(string city, string country)
  {
    IQueryable<Destination> query = _db.Destinations.AsQueryable();

    if (city != null)
      query = query.Where(d => d.City == city);

    if (country != null)
      query = query.Where(d => d.Country == country);

    return await query.ToListAsync();
  }

  // GET: api/destinations/{id}
  [HttpGet("{id}")]
  public async Task<ActionResult<Destination>> GetDestination(int id)
  {
    Destination thisPlace = await _db.Destinations.FindAsync(id);

    if (thisPlace == null)
      return NotFound();

    return thisPlace;
  }

  // [HttpGet("{id}/average")]
  // public async Task<ActionResult<Destination>> GetAverage(int id)
  // {
  //   Destination thisPlace = await _db.Destinations
  //                                           .Include(d => d.Reviews)
  //                                           .FirstOrDefaultAsync(d => d.DestinationId == id);
  //   thisPlace.AverageRating = thisPlace.Reviews.Select(r => r.Rating).Average();

  //   return thisPlace;
  // }

  // POST: api/destinations
  [HttpPost]
  public async Task<ActionResult<Destination>> Post([FromBody] Destination destination)
  {
    _db.Destinations.Add(destination);
    await _db.SaveChangesAsync();
    return CreatedAtAction(nameof(GetDestination), new { id = destination.DestinationId }, destination);
  }

  // PUT: api/destinations/{id}
  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, Destination destination)
  {
    if (id != destination.DestinationId)
      return BadRequest();

    _db.Destinations.Update(destination);

    try
    {
      await _db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!DestinationExists(id))
        return NotFound();
      else 
        throw;
    }

    return NoContent();
  }

  // Return true if destination does exist,
  // otherwise return false.
  private bool DestinationExists(int id)
  {
    return _db.Destinations.Any(d => d.DestinationId == id);
  }

  // DELETE: api/destinations/{id}
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteDestination(int id)
  {
    Destination place = await _db.Destinations.FindAsync(id);
    if (place == null)
      return NotFound();
    
    _db.Destinations.Remove(place);
    await _db.SaveChangesAsync();

    return NoContent();
  }
}