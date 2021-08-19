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
    public class FejlmeldingerController : ControllerBase
    {
        private readonly FloraTransAPIContext _context;

        public FejlmeldingerController(FloraTransAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fejlmeldinger>>> GetFejlmeldinger(int? id, bool? heltTabt)
        {

            IQueryable<Fejlmeldinger> queryable = _context.Fejlmeldinger;

            if (id != null)
            {
                queryable = queryable.Where(f => f.FID == id);                    
            }
            else
            {
                if (heltTabt != null)
                {
                    queryable = queryable.Where(f => f.HeltTabt == heltTabt);
                }
            }

            return await queryable
                .Include(b => b.Bevægelser)
                .ThenInclude(l => l.Lager)
                .Include(b => b.Bevægelser)
                .ThenInclude(k => k.Kunde)
                .ToListAsync();
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFejlmeldinger(int id, Fejlmeldinger fejlmeldinger)
        {
            if (id != fejlmeldinger.FID)
            {
                return BadRequest();
            }

            _context.Entry(fejlmeldinger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FejlmeldingerExists(id))
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
        public async Task<ActionResult<Fejlmeldinger>> PostFejlmeldinger(Fejlmeldinger fejlmeldinger)
        {
            _context.Fejlmeldinger.Add(fejlmeldinger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFejlmeldinger", new { id = fejlmeldinger.FID }, fejlmeldinger);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFejlmeldinger(int id)
        {
            var fejlmeldinger = await _context.Fejlmeldinger.FindAsync(id);
            if (fejlmeldinger == null)
            {
                return NotFound();
            }

            _context.Fejlmeldinger.Remove(fejlmeldinger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FejlmeldingerExists(int id)
        {
            return _context.Fejlmeldinger.Any(e => e.FID == id);
        }
    }
}
