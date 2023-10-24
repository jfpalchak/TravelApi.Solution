using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApi.Models;

namespace TravelApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController : ControllerBase
{
  private readonly TravelApiContext _db;

  public ReviewsController(TravelApiContext db)
  {
    _db = db;
  }

  // GET: api/reviews
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Review>>> Get(string city, string country)
  {
    IQueryable<Review> query = _db.Reviews.AsQueryable();

    if (city != null)
      query = query.Where(r => r.Destination.City.Contains(city));

    if (country != null)
      query = query.Where(r => r.Destination.Country.Contains(country));

    return await query
                    .Include(review => review.Destination)
                    .ToListAsync();
  }

  // GET: api/reviews/{id}
  [HttpGet("{id}")]
  public async Task<ActionResult<Review>> GetReview(int id)
  {
    Review review = await _db.Reviews
                                    .Include(r => r.Destination)
                                    .FirstOrDefaultAsync(r => r.ReviewId == id);
    if (review == null)
      return NotFound();

    return review;
  }

  // POST: api/reviews
  [HttpPost]
  public async Task<ActionResult<Review>> Post([FromBody] Review review)
  {
    _db.Reviews.Add(review);

    // Update the reviewed Destination's Average Rating.
    Destination thisPlace = await _db.Destinations
                                            .Include(d => d.Reviews)
                                            .FirstOrDefaultAsync(d => d.DestinationId == review.DestinationId);
    thisPlace.AverageRating = thisPlace.Reviews.Select(r => r.Rating).Average();

    _db.Destinations.Update(thisPlace);
    
    await _db.SaveChangesAsync();
    return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
  }

  // PUT: api/reviews/{id}
  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, Review review)
  {
    if (id != review.ReviewId)
      return BadRequest();

    _db.Reviews.Update(review);

    try
    {
      await _db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if(!ReviewExists(id))
        return NotFound();
      else
        throw;
    }

    return NoContent();
  }

  private bool ReviewExists(int id)
  {
    return _db.Reviews.Any(r => r.ReviewId == id);
  }

  // DELETE: api/reviews/{id}
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteReview(int id)
  {
    Review review = await _db.Reviews.FindAsync(id);

    if (review == null)
      return NotFound();

    _db.Reviews.Remove(review);
    await _db.SaveChangesAsync();

    return NoContent();
  }
}