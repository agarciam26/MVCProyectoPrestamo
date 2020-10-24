using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProyectoPrestamo.Models.EntidadesBD;

namespace MVCProyectoPrestamo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrePrestamoesController : ControllerBase
    {
        private readonly MVCProyecto10Context _context;

        public PrePrestamoesController(MVCProyecto10Context context)
        {
            _context = context;
        }

        // GET: api/PrePrestamoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrePrestamo>>> GetPrePrestamo()
        {
            return await _context.PrePrestamo.ToListAsync();
        }

        // GET: api/PrePrestamoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrePrestamo>> GetPrePrestamo(int id)
        {
            var prePrestamo = await _context.PrePrestamo.FindAsync(id);

            if (prePrestamo == null)
            {
                return NotFound();
            }

            return prePrestamo;
        }

        // PUT: api/PrePrestamoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrePrestamo(int id, PrePrestamo prePrestamo)
        {
            if (id != prePrestamo.PrePrestamo1)
            {
                return BadRequest();
            }

            _context.Entry(prePrestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrePrestamoExists(id))
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

        // POST: api/PrePrestamoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PrePrestamo>> PostPrePrestamo(PrePrestamo prePrestamo)
        {
            _context.PrePrestamo.Add(prePrestamo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrePrestamo", new { id = prePrestamo.PrePrestamo1 }, prePrestamo);
        }

        // DELETE: api/PrePrestamoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrePrestamo>> DeletePrePrestamo(int id)
        {
            var prePrestamo = await _context.PrePrestamo.FindAsync(id);
            if (prePrestamo == null)
            {
                return NotFound();
            }

            _context.PrePrestamo.Remove(prePrestamo);
            await _context.SaveChangesAsync();

            return prePrestamo;
        }

        private bool PrePrestamoExists(int id)
        {
            return _context.PrePrestamo.Any(e => e.PrePrestamo1 == id);
        }
    }
}
