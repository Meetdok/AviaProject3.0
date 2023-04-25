using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Database;
using WebProject.WebModels;

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplanesController : ControllerBase
    {
        private readonly user05_1Context _context;
        private int input;

        public AirplanesController(user05_1Context context)
        {
            _context = context;
        }

        // GET: api/Airplanes
        [HttpPost("ListAirplanes")]
        public async Task<ActionResult<IEnumerable<Airplane>>> GetAirplanes()
        {
          if (_context.Airplanes == null)
          {
              return NotFound();
          }
            return await _context.Airplanes.Include(s => s.Class).ToListAsync();
        }

        // GET: api/Airplanes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Airplane>> GetAirplane(int id)
        {
          if (_context.Airplanes == null)
          {
              return NotFound();
          }
            var airplane = await _context.Airplanes.FindAsync(id);

            if (airplane == null)
            {
                return NotFound();
            }

            return airplane;
        }

        // PUT: api/Airplanes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("put")]
        public async Task<IActionResult> PutAirplane([FromBody]Airplane airplane)
        {
            input = airplane.AirplanesId;
          
            var origin = _context.Airplanes.Find(input);

            _context.Entry(origin).CurrentValues.SetValues(airplane);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplaneExists(input))
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

        // POST: api/Airplanes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("save")]
        public async Task<ActionResult<Airplane>> PostAirplane(Airplane airplane)
        {
          if (_context.Airplanes == null)
          {
              return Problem("Entity set 'AviaSalesContext.Airplanes'  is null.");
          }
            _context.Airplanes.Add(airplane);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirplane", new { id = airplane.AirplanesId }, airplane);
        }

        // DELETE: api/Airplanes/5
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAirplane([FromBody] int id)
        {
            if (_context.Airplanes == null)
            {
                return NotFound();
            }
            var airplane = await _context.Airplanes.FindAsync(id);
            if (airplane == null)
            {
                return NotFound();
            }

            _context.Airplanes.Remove(airplane);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirplaneExists(int id)
        {
            return (_context.Airplanes?.Any(e => e.AirplanesId == id)).GetValueOrDefault();
        }
    }
}
