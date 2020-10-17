using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using weatherapi3.Data;
using weatherapi3.Models;

namespace weatherapi3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ColoursController : ControllerBase
    {
        private readonly MainDbContext _context;

        public ColoursController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Colours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colour>>> GetColour()
        {
            return await _context.Colour.ToListAsync();
        }

        // GET: api/Colours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colour>> GetColour(int id)
        {
            var colour = await _context.Colour.FindAsync(id);

            if (colour == null)
            {
                return NotFound();
            }

            return colour;
        }

        // PUT: api/Colours/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColour(int id, Colour colour)
        {
            if (id != colour.Id)
            {
                return BadRequest();
            }

            _context.Entry(colour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColourExists(id))
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

        // POST: api/Colours
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Colour>> PostColour(Colour colour)
        {
            _context.Colour.Add(colour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColour", new { id = colour.Id }, colour);
        }

        // DELETE: api/Colours/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Colour>> DeleteColour(int id)
        {
            var colour = await _context.Colour.FindAsync(id);
            if (colour == null)
            {
                return NotFound();
            }

            _context.Colour.Remove(colour);
            await _context.SaveChangesAsync();

            return colour;
        }

        private bool ColourExists(int id)
        {
            return _context.Colour.Any(e => e.Id == id);
        }
    }
}
