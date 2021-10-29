using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Empleados.Data;
using Empleados.Models.SubAreasViewModels;

namespace Empleados.APIs
{
    [Produces("application/json")]
    [Route("api/SubAreasapi")]
    public class SubAreasapiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubAreasapiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubAreasapi
        [HttpGet]
        public IEnumerable<SubArea> GetSubArea()
        {
            return _context.SubArea;
        }

        // GET: api/SubAreasapi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubArea([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubArea subArea = await _context.SubArea.SingleOrDefaultAsync(m => m.Id == id);

            if (subArea == null)
            {
                return NotFound();
            }

            return Ok(subArea);
        }

        // PUT: api/SubAreasapi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubArea([FromRoute] int id, [FromBody] SubArea subArea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subArea.Id)
            {
                return BadRequest();
            }

            _context.Entry(subArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubAreaExists(id))
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

        // POST: api/SubAreasapi
        [HttpPost]
        public async Task<IActionResult> PostSubArea([FromBody] SubArea subArea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SubArea.Add(subArea);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubAreaExists(subArea.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubArea", new { id = subArea.Id }, subArea);
        }

        // DELETE: api/SubAreasapi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubArea([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubArea subArea = await _context.SubArea.SingleOrDefaultAsync(m => m.Id == id);
            if (subArea == null)
            {
                return NotFound();
            }

            _context.SubArea.Remove(subArea);
            await _context.SaveChangesAsync();

            return Ok(subArea);
        }

        private bool SubAreaExists(int id)
        {
            return _context.SubArea.Any(e => e.Id == id);
        }
    }
}