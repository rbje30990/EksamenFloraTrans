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
    public class KunderController : ControllerBase
    {
        private readonly FloraTransAPIContext _context;

        public KunderController(FloraTransAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kunder>>> GetKunder(int? id)
        {
            IQueryable<Kunder> queryable = _context.Kunder;

            if (id != null)
            {
                queryable = queryable.Where(k => k.KID == id);
            }
            return await queryable.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutKunder(int id, Kunder kunder)
        {
            if (id != kunder.KID)
            {
                return BadRequest();
            }

            _context.Entry(kunder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KunderExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Kunder>> PostKunder(Kunder kunder)
        {
            _context.Kunder.Add(kunder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKunder", new { id = kunder.KID }, kunder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKunder(int id)
        {
            var kunder = await _context.Kunder.FindAsync(id);
            if (kunder == null)
            {
                return NotFound();
            }

            _context.Kunder.Remove(kunder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KunderExists(int id)
        {
            return _context.Kunder.Any(e => e.KID == id);
        }
    }
}
