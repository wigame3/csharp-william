using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Empleados.Data;
using Empleados.Models.AreasViewModels;

namespace Empleados.APIs
{
    [Produces("application/json")]
    [Route("api/Areasapi")]
    public class AreasapiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AreasapiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Areasapi
        [HttpGet]
        public IEnumerable<Areas> GetAreas()
        {
            return _context.Areas;
        }

        // GET: api/Areasapi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAreas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Areas areas = await _context.Areas.SingleOrDefaultAsync(m => m.Id == id);

            if (areas == null)
            {
                return NotFound();
            }

            return Ok(areas);
        }

        // PUT: api/Areasapi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreas([FromRoute] int id, [FromBody] Areas areas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != areas.Id)
            {
                return BadRequest();
            }

            _context.Entry(areas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreasExists(id))
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

        // POST: api/Areasapi
        [HttpPost]
        public async Task<IActionResult> PostAreas([FromBody] Areas areas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Areas.Add(areas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AreasExists(areas.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAreas", new { id = areas.Id }, areas);
        }

        // DELETE: api/Areasapi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAreas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Areas areas = await _context.Areas.SingleOrDefaultAsync(m => m.Id == id);
            if (areas == null)
            {
                return NotFound();
            }

            _context.Areas.Remove(areas);
            await _context.SaveChangesAsync();

            return Ok(areas);
        }

        private bool AreasExists(int id)
        {
            return _context.Areas.Any(e => e.Id == id);
        }
    }
}