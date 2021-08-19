using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FloraTransAPI.Data;
using FloraTransAPI.Models;

namespace FloraTransAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BevægelserController : ControllerBase
    {
        private readonly FloraTransAPIContext _context;

        public BevægelserController(FloraTransAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bevægelser>>> GetBevægelser(int? id, int? kundeID)
        {
            IQueryable<Bevægelser> queryable = _context.Bevægelser;

            if (id != null)
            {
                queryable = queryable.Where(b => b.BID == id);
            }
            else
            {
                if (kundeID != null)
                {
                    queryable = queryable.Where(b => b.KundeID == kundeID);
                }
            }
            return await queryable
                .Include(k => k.Kunde)
                .Include(l => l.Lager)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Bevægelser>> PostBevægelser(Bevægelser bevægelser)
        {

            _context.Bevægelser.Add(bevægelser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBevægelser", new { id = bevægelser.BID }, bevægelser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBevægelser(int id, Bevægelser bevægelser)
        {

            if (id != bevægelser.BID)
            {
                return BadRequest();
            }

            _context.Entry(bevægelser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BevægelserExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBevægelser(int id)
        {
            var bevægelser = await _context.Bevægelser.FindAsync(id);
            if (bevægelser == null)
            {
                return NotFound();
            }

            _context.Bevægelser.Remove(bevægelser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BevægelserExists(int id)
        {
            return _context.Bevægelser.Any(e => e.BID == id);
        }
    }
}
