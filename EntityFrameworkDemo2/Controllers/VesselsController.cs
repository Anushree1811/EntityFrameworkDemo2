using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkDemo.Db;
using EntityFrameworkDemo.Models;

namespace EntityFrameworkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesselsController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public VesselsController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/Vessels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vessel>>> GetVessels()
        {
          if (_context.Vessels == null)
          {
              return NotFound();
          }
            return await _context.Vessels.ToListAsync();
        }

        // GET: api/Vessels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vessel>> GetVessel(Guid id)
        {
          if (_context.Vessels == null)
          {
              return NotFound();
          }
            var vessel = await _context.Vessels.FindAsync(id);

            if (vessel == null)
            {
                return NotFound();
            }

            return vessel;
        }

        // PUT: api/Vessels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVessel(Guid id, Vessel vessel)
        {
            if (id != vessel.Id)
            {
                return BadRequest();
            }

            _context.Entry(vessel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VesselExists(id))
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

        // POST: api/Vessels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vessel>> PostVessel(Vessel vessel)
        {
          if (_context.Vessels == null)
          {
              return Problem("Entity set 'DemoDbContext.Vessels'  is null.");
          }
            _context.Vessels.Add(vessel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVessel", new { id = vessel.Id }, vessel);
        }

        // DELETE: api/Vessels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVessel(Guid id)
        {
            if (_context.Vessels == null)
            {
                return NotFound();
            }
            var vessel = await _context.Vessels.FindAsync(id);
            if (vessel == null)
            {
                return NotFound();
            }

            _context.Vessels.Remove(vessel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VesselExists(Guid id)
        {
            return (_context.Vessels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
