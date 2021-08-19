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
    public class LagerController : ControllerBase
    {
        private readonly FloraTransAPIContext _context;

        public LagerController(FloraTransAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lager>>> GetLager(int? id, bool? ledighed)
        {
            IQueryable<Lager> queryable = _context.Lager;

            if (id != null)
            {
                return await queryable.Where(l => l.LID == id).ToListAsync();
            }
            else
            {
                if (ledighed != null)
                {
                    queryable = queryable.Where(l => l.ledighed == ledighed);
                }
                return await queryable.ToListAsync();
            }                
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLager(int id, Lager lager)
        {
            if (id != lager.LID)
            {
                return BadRequest();
            }

            _context.Entry(lager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LagerExists(id))
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
        public async Task<ActionResult<Lager>> PostLager(Lager lager)
        {
            _context.Lager.Add(lager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLager", new { id = lager.LID }, lager);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLager(int id)
        {
            var lager = await _context.Lager.FindAsync(id);
            if (lager == null)
            {
                return NotFound();
            }

            _context.Lager.Remove(lager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LagerExists(int id)
        {
            return _context.Lager.Any(e => e.LID == id);
        }
    }
}
