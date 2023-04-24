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
    public class AirplanesClassesController : ControllerBase
    {
        private readonly user05_1Context _context;

        public AirplanesClassesController(user05_1Context context)
        {
            _context = context;
        }

        // GET: api/AirplanesClasses
        [HttpPost("ListAirplanesClasses")]
        public async Task<ActionResult<IEnumerable<AirplanesClass>>> GetAirplanesClasses()
        {
          if (_context.AirplanesClasses == null)
          {
              return NotFound();
          }
            return await _context.AirplanesClasses.ToListAsync();

        }

        // GET: api/AirplanesClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirplanesClass>> GetAirplanesClass(int id)
        {
          if (_context.AirplanesClasses == null)
          {
              return NotFound();
          }
            var airplanesClass = await _context.AirplanesClasses.FindAsync(id);

            if (airplanesClass == null)
            {
                return NotFound();
            }

            return airplanesClass;
        }

        // PUT: api/AirplanesClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirplanesClass(int id, AirplanesClass airplanesClass)
        {
            if (id != airplanesClass.AirplaneClassId)
            {
                return BadRequest();
            }

            _context.Entry(airplanesClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplanesClassExists(id))
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

        // POST: api/AirplanesClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("save")]
        public async Task<ActionResult<AirplanesClass>> PostAirplanesClass(AirplanesClass airplanesClass)
        {
          if (_context.AirplanesClasses == null)
          {
              return Problem("Entity set 'AviaSalesContext.AirplanesClasses'  is null.");
          }
            _context.AirplanesClasses.Add(airplanesClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirplanesClass", new { id = airplanesClass.AirplaneClassId }, airplanesClass);
        }

        // DELETE: api/AirplanesClasses/5
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAirplanesClass([FromBody]int id)
        {
            if (_context.AirplanesClasses == null)
            {
                return NotFound();
            }
            var airplanesClass = await _context.AirplanesClasses.FindAsync(id);
            if (airplanesClass == null)
            {
                return NotFound();
            }

            _context.AirplanesClasses.Remove(airplanesClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirplanesClassExists(int id)
        {
            return (_context.AirplanesClasses?.Any(e => e.AirplaneClassId == id)).GetValueOrDefault();
        }
    }
}
