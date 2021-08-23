using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMSAPI.Models;

namespace HRMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        private readonly HRMSDbContext _context;

        public FlatsController(HRMSDbContext context)
        {
            _context = context;
        }

        // GET: api/Flats
        [HttpGet]
        public IEnumerable<Flat> GetFlats()
        {
            return _context.Flats;
        }

        // GET: api/Flats/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlat([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flat = await _context.Flats.FindAsync(id);

            if (flat == null)
            {
                return NotFound();
            }

            return Ok(flat);
        }

        // PUT: api/Flats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlat([FromRoute] int id, [FromBody] Flat flat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flat.Id)
            {
                return BadRequest();
            }

            _context.Entry(flat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlatExists(id))
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

        // POST: api/Flats
        [HttpPost]
        public async Task<IActionResult> PostFlat([FromBody] Flat flat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Flats.Add(flat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlat", new { id = flat.Id }, flat);
        }

        // DELETE: api/Flats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlat([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flat = await _context.Flats.FindAsync(id);
            if (flat == null)
            {
                return NotFound();
            }

            _context.Flats.Remove(flat);
            await _context.SaveChangesAsync();

            return Ok(flat);
        }

        private bool FlatExists(int id)
        {
            return _context.Flats.Any(e => e.Id == id);
        }
    }
}